#ifndef __SPI_ISP__
#define __SPI_ISP__

#include <Arduino.h>

void isp_init();

uint8_t isp_start();
void isp_stop();

uint8_t isp_command(uint8_t a, uint8_t b, uint8_t c, uint8_t d);

bool isp_ready();

bool isp_writeInstruction(uint32_t address, uint8_t low, uint8_t high);
uint16_t isp_readInstruction(uint32_t address);

bool isp_writeEEPROM(uint32_t address, uint8_t value);
uint8_t isp_readEEPROM(uint32_t address);

#endif