//Robot9706 @ 2016
//-Lowered SPI clock
//-Reenabled old style wiring
//Scrapped non used commands
//Cleaned the code (no led indicators, removed unused functions...)

//Original license:
// ArduinoISP version 04m3
// Copyright (c) 2008-2011 Randall Bohn
// If you require a license, see 
//     http://www.opensource.org/licenses/bsd-license.php

#include "Arduino.h"
#include "SPI.h"

int SPI_CLOCK = (1000000/32);

#define RESET     10
#define PIN_MOSI	11
#define PIN_MISO	12
#define PIN_SCK		13

#define BAUDRATE	19200

// STK Definitions
#define STK_OK      0x10
#define STK_FAILED  0x11
#define STK_UNKNOWN 0x12
#define STK_INSYNC  0x14
#define STK_NOSYNC  0x15
#define CRC_EOP     0x20

#define SPI_MODE0 0x00

void setup() {
  Serial.begin(BAUDRATE);
  pinMode(9, OUTPUT);
}

int error = 0;
int pmode = 0;

static bool rst_active_high;

void reset_target(bool reset) {
  digitalWrite(RESET, ((reset && rst_active_high) || (!reset && !rst_active_high)) ? HIGH : LOW);
}

void loop(void) {
  if (Serial.available()) {
    avrisp();
  }
}

uint8_t getch() {
  while (!Serial.available());
    return Serial.read();
}

uint8_t buff[256];
void fill(int n) {
  for (int x = 0; x < n; x++) {
    buff[x] = getch();
  }
}

uint8_t spi_transaction(uint8_t a, uint8_t b, uint8_t c, uint8_t d) {
  SPI.transfer(a);
  SPI.transfer(b);
  SPI.transfer(c);
  return SPI.transfer(d);
}

void empty_reply() {
  if (CRC_EOP == getch()) {
    Serial.print((char)STK_INSYNC);
    Serial.print((char)STK_OK);
  } else {
    error++;
    Serial.print((char)STK_NOSYNC);
  }
}

void breply(uint8_t b) {
  if (CRC_EOP == getch()) {
    Serial.print((char)STK_INSYNC);
    Serial.print((char)b);
    Serial.print((char)STK_OK);
  } else {
    error++;
    Serial.print((char)STK_NOSYNC);
  }
}

void get_version(uint8_t c) {
  switch (c) {
    case 0x80:
      breply(1);
      break;
    case 0x81:
      breply(0);
      break;
    case 0x82:
      breply(0);
      break;
    case 0x93:
      breply('S');
      break;
    default:
      breply(0);
  }
}

void start_pmode() {
  reset_target(true);
  pinMode(RESET, OUTPUT);
  SPI.begin();
  SPI.beginTransaction(SPISettings(SPI_CLOCK, MSBFIRST, SPI_MODE0));

  digitalWrite(PIN_SCK, LOW);
  delay(20); // discharge PIN_SCK, value arbitrally chosen
  reset_target(false);

  delayMicroseconds(100);
  reset_target(true);

  delay(50); // datasheet: must be > 20 msec
  spi_transaction(0xAC, 0x53, 0x00, 0x00);
  pmode = 1;
}

void end_pmode() {
  SPI.end();

  pinMode(PIN_MOSI, INPUT);
  pinMode(PIN_SCK, INPUT);
  reset_target(false);
  pinMode(RESET, INPUT);
  pmode = 0;
}

void universal() {
  uint8_t ch;

  fill(4);
  ch = spi_transaction(buff[0], buff[1], buff[2], buff[3]);
  breply(ch);
}

void avrisp() {
  uint8_t ch = getch();
  switch (ch) {
    case '0': //Poll programmer
      error = 0;
      empty_reply();
      break;
    case '1': //Get programmer name
      if (getch() == CRC_EOP) {
        Serial.print((char) STK_INSYNC);
        Serial.print("AVR ISP");
        Serial.print((char) STK_OK);
      }
      else {
        error++;
        Serial.print((char) STK_NOSYNC);
      }
      break;
    case 'A': //Get programmer version
      get_version(getch());
      break;
    case 'P': //Start programming mode
      if (!pmode)
        start_pmode();
      empty_reply();
      break;
    case 'V': //Universal command
      universal();
      break;
    case 'Q': //End programming mode
      error = 0;
      end_pmode();
      empty_reply();
      break;

   case 'q': //Enable ~400Hz PWM on pin 9
      analogWrite(9, 128);
      break;
   case 'w': //Disable PWM on pin 9
      analogWrite(9, 0);
      break;

   case 'r': //Very slow SPI clock to rescue chips
      SPI_CLOCK = 16;
      break;
   case 't': //Revert SPI clock
      SPI_CLOCK = (1000000/32);
      break;
      
    default:
      error++;
      if (CRC_EOP == getch())
        Serial.print((char)STK_UNKNOWN);
      else
        Serial.print((char)STK_NOSYNC);
  }
}

