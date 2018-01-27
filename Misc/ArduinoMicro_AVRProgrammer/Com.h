#ifndef __COM__
#define __COM__

//Status
#define STATUS_OK (uint8_t)0xFF
#define STATUS_ERROR (uint8_t)0x00

//Commands
#define CMD_POLL 1
#define CMD_INFO 2
#define CMD_ENTER 3
#define CMD_EXIT 4
#define CMD_ISP_CMD 5
#define CMD_FILL_BUFFER 6
#define CMD_BUFFER_TO_PROG 7
#define CMD_PROG_TO_BUFFER 8
#define CMD_GET_BUFFER 9
#define CMD_BUFFER_TO_EEPROM 10
#define CMD_EEPROM_TO_BUFFER 11

//Functions
void com_init();
void com_loop();

#endif