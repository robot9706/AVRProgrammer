#include "Com.h"
#include "SPI_ISP.h"
#include "Config.h"

#include <Arduino.h>
#include "SoftwareSerial.h"

uint8_t _buffer[512];

void send_string(int len, String str)
{
	Serial.write((uint8_t)len);
	for (int x = 0;x<len;x++)
	{
		Serial.write((uint8_t)str[x]);
	}
}

void send_status(bool status)
{
	Serial.write(status ? STATUS_OK : STATUS_ERROR);
}

uint8_t readByte()
{
	while (Serial.available() < 1)
	{
		;
	}
	
	return (uint8_t)Serial.read();
}

uint16_t read16Bit()
{
	return (uint16_t)readByte() | (((uint16_t)readByte()) << 8);
	
}

uint32_t read32Bit()
{
	return (uint32_t)readByte() | (((uint32_t)readByte()) << 8) | (((uint32_t)readByte()) << 16) | (((uint32_t)readByte()) << 24);
	
}

//Module functions
void com_init()
{
	Serial.begin(SERIAL_BAUD);
	
	#ifdef WAIT_FOR_USB_SERIAL
	while (!Serial)
	{
		;
	}
	#endif
}

void com_loop()
{
	if (Serial.available()) 
	{
		uint8_t cmd = Serial.read();
		
		//Process command
		switch (cmd)
		{
			case CMD_POLL:
			{
				send_status(true);
			}
			break;
			
			case CMD_INFO:
			{
				send_status(true);
				send_string(12, F("AVR ISP v1.0"));
			}
			break;
			
			case CMD_ENTER:
			{
				send_status(true);
				Serial.write((uint8_t)isp_start());
			}
			break;
			
			case CMD_EXIT:
			{
				send_status(true);
				isp_stop();
			}
			break;
			
			case CMD_ISP_CMD:
			{
				send_status(true);
				
				uint8_t a = readByte();
				uint8_t b = readByte();
				uint8_t c = readByte();
				uint8_t d = readByte();

				uint8_t res = isp_command(a, b, c, d);
				Serial.write(res);
			}
			break;
			
			case CMD_FILL_BUFFER:
			{
				uint16_t numBytes = read16Bit();
				if (numBytes > 512)
				{
					send_status(false);
				}
				else
				{
					send_status(true); //Can accept data
					
					for (int x = 0; x < numBytes; x++)
					{
						_buffer[x] = readByte();
					}

					send_status(true); //Data accepted
				}
			}
			break;
			
			case CMD_GET_BUFFER:
			{
				send_status(true);
				
				for (int x = 0; x < 512; x++)
				{
					Serial.write((uint8_t)_buffer[x]);
				}
				
				send_status(true);
			}
			break;
			
			case CMD_BUFFER_TO_PROG:
			{
				uint16_t numInstructions = read16Bit();
				if (numInstructions > 256)
				{
					send_status(false);
				}
				else
				{
					send_status(true); //Can accept data
					
					uint32_t startOffset = read32Bit();
					uint8_t verify = readByte();
					
					bool writeOK = true;
					
					for (uint32_t offset = 0; offset < numInstructions; offset++)
					{
						uint32_t address = startOffset + offset;
						
						uint8_t low = _buffer[(offset * 2)];
						uint8_t high = _buffer[(offset * 2) + 1];
						
						if (!isp_writeInstruction(address, low, high))
						{
							writeOK = false;
							break;
						}
						
						if (verify)
						{
							while (!isp_ready())
							{
								;
							}
							
							uint16_t read = isp_readInstruction(address);
							
							
							if((uint8_t)(read & 0x00FF) != low || (uint8_t)((read & 0xFF00) >> 8) != high)
							{
								writeOK = false;
								break;
							}
						}
					}

					send_status(writeOK);
				}
			}
			break;
			
			case CMD_PROG_TO_BUFFER:
			{
				uint16_t numInstructions = read16Bit();
				if (numInstructions > 256)
				{
					send_status(false);
				}
				else
				{
					send_status(true); //Command OK
					
					uint32_t startOffset = read32Bit();
	
					for (uint32_t offset = 0; offset < numInstructions; offset++)
					{
						uint32_t address = startOffset + offset;
						
						while (!isp_ready())
						{
							;
						}

						uint16_t read = isp_readInstruction(address);
						
						_buffer[(offset * 2)] = (uint8_t)(read & 0x00FF);
						_buffer[(offset * 2) + 1] = (uint8_t)((read & 0xFF00) >> 8);
					}

					send_status(true);
				}
			}
			break;
			
			case CMD_BUFFER_TO_EEPROM:
			{
				uint16_t numBytes = read16Bit();
				if (numBytes > 512)
				{
					send_status(false);
				}
				else
				{
					send_status(true); //Can accept data
					
					uint32_t startOffset = read32Bit();
					uint8_t verify = readByte();
					
					bool writeOK = true;
					
					for (uint32_t offset = 0; offset < numBytes; offset++)
					{
						uint32_t address = startOffset + offset;
						
						uint8_t byteValue = _buffer[offset];
						
						if (!isp_writeEEPROM(address, byteValue))
						{
							writeOK = false;
							break;
						}
						
						if (verify)
						{
							while (!isp_ready())
							{
								;
							}
							
							uint8_t read = isp_readEEPROM(address);

							if (read != byteValue)
							{
								writeOK = false;
								break;
							}
						}
					}

					send_status(writeOK);
				}
			}
			break;
			
			case CMD_EEPROM_TO_BUFFER:
			{
				uint16_t numBytes = read16Bit();
				if (numBytes > 512)
				{
					send_status(false);
				}
				else
				{
					send_status(true); //Command OK
					
					uint32_t startOffset = read32Bit();
	
					for (uint32_t offset = 0; offset < numBytes; offset++)
					{
						uint32_t address = startOffset + offset;
						
						while (!isp_ready())
						{
							;
						}

						uint16_t read = isp_readEEPROM(address);
						
						_buffer[offset] = read;
					}

					send_status(true);
				}
			}
			break;
			
			default:
			{
				send_status(false);
			}
			break;
		}
		
		Serial.flush();
	}
}