# AVRProgrammer
A tool able to program AVR (tested with ATmega328 / ATtiny84 - 44) microcontrollers using an Ardunio/Genuino as a programmer.

# Description
AVRProgrammer is an easy to use GUI tool which can use any Arduino/Genuino board to program AVR MCUs.

Features:

1) Change fuses

2) Erase the chip

3) Read/Write the program memory

4) Read/Write the EEPROM

# Wiring
You only need to connect the SPI pins of you programmer Arduino and the target MCU, as well as connect the reset line (MCU) to Digital Pin 10. No other components required.

Note: No crystal needed for factory new chips (they are fused for their internal 8MHz/1MHz oscillators).
![Alt text](/Misc/Breadboard.png?raw=true "Wiring")

(A pull-up resistor on the reset pin is highly suggested.)

# GUI usage
![Alt text](/Misc/Screenshot.png?raw=true "Wiring")

1) First of all upload the sketch to an Arduino from the "Misc/ArduinoMicro_AVRProgrammer" folder (you migh need to edit the "Config.h" to make it work on your Arduino).

2) Start the GUI tool.

3) Select the COM port of the Ardunio device and connect to it.

4) Using the "Processor" tab put the target MCU into ISP mode and verify the signature.

5) Change the fuses to your needs, use the "Help" button to open an online helper tool (not supported for all CPUs).

6) Modify the program memory / EEPROM (make sure memory sizes are correctly set when dumping the data).

# Projects
ATmegaProgrammer - GUI version: Easy to use.

CMDATmega328Programmer - Test version.
Using this project is not advised, it's only a test project. Can only fuse chips to Ardunio Nano fuses (16MHz external clock).

ArdunioISP modified sketch included.

# License
Use it, modify it, but don't sell it, also give credit.
