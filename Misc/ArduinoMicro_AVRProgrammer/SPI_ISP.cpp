#include "SPI_ISP.h"
#include "Config.h"

#include <Arduino.h>
#include <SPI.h>

#define SPI_CLOCK (1000000/4)
#define SPI_MODE0 0x00

//Helper functions
static bool rst_active_high;
void reset_target(bool reset) {
  digitalWrite(PIN_RESET, ((reset && rst_active_high) || (!reset && !rst_active_high)) ? HIGH : LOW);
}

uint8_t spi_transaction(uint8_t a, uint8_t b, uint8_t c, uint8_t d) 
{
  SPI.transfer(a);
  SPI.transfer(b);
  SPI.transfer(c);
  
  return SPI.transfer(d);
}

//Module functions
void isp_init()
{
	pinMode(PIN_RESET, OUTPUT);
	digitalWrite(PIN_RESET, HIGH);
	
	pinMode(PIN_SCK, OUTPUT);
	pinMode(PIN_MOSI, OUTPUT);
	pinMode(PIN_MISO, INPUT);
}

uint8_t isp_start()
{
	reset_target(true);
	
	SPI.begin();
	SPI.beginTransaction(SPISettings(SPI_CLOCK, MSBFIRST, SPI_MODE0));
	
	digitalWrite(PIN_SCK, LOW);
	delay(20); // discharge PIN_SCK, value arbitrally chosen
	reset_target(false);

	delayMicroseconds(100);
	reset_target(true);

	delay(50); // datasheet: must be > 20 msec
	return spi_transaction(0xAC, 0x53, 0x00, 0x00);
}

void isp_stop()
{
	SPI.end();

	pinMode(PIN_MOSI, INPUT);
	pinMode(PIN_SCK, INPUT);
	reset_target(false);
	pinMode(PIN_RESET, OUTPUT);
	digitalWrite(PIN_RESET, true);
}

uint8_t isp_command(uint8_t a, uint8_t b, uint8_t c, uint8_t d)
{
	return spi_transaction(a, b, c, d);
}

bool isp_ready()
{
	return (spi_transaction(0xF0, 0x00, 0x00, 0x00) == 0xFE);	
}

bool isp_writeInstruction(uint32_t address, uint8_t lowByte, uint8_t highByte)
{
	uint8_t high = (uint8_t)((address & 0xFF00) >> 8);
	uint8_t low = (address & 0xFF);
	
	while (!isp_ready())
	{
		;
	}
	
	if (spi_transaction(0x40, high, low, lowByte) != low) //Load the low byte
		return false;
	
	while (!isp_ready())
	{
		;
	}
	
	if (spi_transaction(0x48, high, low, highByte) != low) //Load the high byte
		return false;
	
	while (!isp_ready())
	{
		;
	}
	
	return (spi_transaction(0x4C, high, low, 0x00) == low); //Write program memory address
}

uint16_t isp_readInstruction(uint32_t address)
{
	uint8_t high = (uint8_t)((address & 0xFF00) >> 8);
	uint8_t low = (address & 0xFF);
	
	return (uint16_t)spi_transaction(0x20, high, low, 0x00) | ((uint16_t)spi_transaction(0x28, high, low, 0x00) << 8);
}

bool isp_writeEEPROM(uint32_t address, uint8_t value)
{
	uint8_t high = (uint8_t)((address & 0xFF00) >> 8);
	uint8_t low = (address & 0xFF);
	
	while (!isp_ready())
	{
		;
	}
	
	if (spi_transaction(0xC0, high, low, value) != low)
		return false;
	
	while (!isp_ready())
	{
		;
	}
	
	return (spi_transaction(0xC2, high, low, 0x00) == low); //Write EEPROM memory address
}

uint8_t isp_readEEPROM(uint32_t address)
{
	uint8_t high = (uint8_t)((address & 0xFF00) >> 8);
	uint8_t low = (address & 0xFF);
	
	return spi_transaction(0xA0, high, low, 0xFF);
}
