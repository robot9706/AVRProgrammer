# ATmegaProgrammer
A tool used to program ATmega (ATmega328P) microcontrollers using a Genuino 101 as an USB to SPI interface.

# Description
These tools are made to program ATmega328 (might work with others too) microcontrollers with a GUI interface. The wiring is very simple, one 10k resistor and few wires are required to wire up everything (the GUI has a graphical guide to wiring). The Genuino 101 is used as a USB to SPI interface and also it handles the proper reseting of the MCU too. Other Ardunio boards might also work. 

A non-paged method is used to write the program flash which makes it slow and it also depends on the MCU osc freq.

Changes to the ArdunioISP sketch: I had to lower the SPI clock to program the MCU reliably also hardcoded the old wiring style (pins 10-13). Also I scrapped the STK500 command set and only the "universal" command is used to communicate with the MCU chip.

# Why?
The original ArduinoToBreadboard method didn't work (because of the Genuino 101 I think), the Ardunio IDE (with it's avrdude) didn't see the MCU so I came up with this project.

# Projects
ATmegaProgrammer - GUI version: Easy to use.

CMDATmega328Programmer - Test version.

ArdunioISP modified sketch included.

# License
Use it, modify it, but obviously don't sell it, also give credit.
