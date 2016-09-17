# ATmegaProgrammer
A tool used to program ATmega (ATmega328P) microcontrollers using a Genuino 101 as an USB to SPI interface.

# Description
NOTE: Everything had been tested using a Genuino 101 and ATmega328P-PUs, but might work with other boards and CPUs too.

These tools are made to program ATmega328 (might work with others too) microcontrollers with a GUI interface. The wiring is very simple, one 10k resistor and few wires are required to wire up everything (the GUI has a graphical guide to help wiring, but this image is also shown below). The Ardunio (I used a Genuino 101) is used as a USB to SPI interface and also it handles the proper reseting of the MCU too. I'm not sure which Ardunio boards work, only tested with the Genuino 101.

Changes to the ArdunioISP sketch: I had to lower the SPI clock to program the MCU reliably also hardcoded the old wiring style (pins 10-13). I also scrapped the STK500 command set and only the "universal" command is used to communicate with the MCU chip.

# Wiring
Note: No crystal needed for factory new chips (they are fused for their internal 8MHz/1MHz oscillators).
![Alt text](/Misc/Breadboard.png?raw=true "Wiring")

# GUI usage
![Alt text](/Misc/Screenshot.png?raw=true "Wiring")

1) First of all upload the ArdunioISP from the "Misc/ArdunioISP_modified" folder.

2) Start the GUI tool.

3) Select the COM port of the Ardunio device (the baud rate is set correctly).

4) Using the "Programmer - Info" tab verify that it works (you should see "AVR ISP").

5) Enter the programming mode.

6) Verify the CPU signature you get. For example the ATmega328 CPU signature is 0x1E950F.

7) (Optional) Change fuse values and write them.

8) Load the Intel Hex into the buffer using the "Load" button.

9) Press "Write program memory" and wait until the task is finished.


Note: If you are not sure if the hex you want to use is correct or not, use the "Check Intel hex compatibility". This option will check if the hex file has special records, if they do they might not work on ATmega328 CPUs (For example 32bit hexs have these records).

# Rescuing badly fused chips
If you have problems with the oscillator fuse you might be able to fix it using 2 options in the GUI tool.

First try to see if the "Very low SPI clock" helps you. This option is desinged for those CPUs which have the low internal clock freq enabled.

If you fused a low external clock use the "PWM on pin 9" to create ~400Hz on pin 9. Connect that pin to OSC1 on the ATmega328, also try messing with the "Very low SPI clock" and you might be able to write some fuses.

# Why?
The original ArduinoToBreadboard method didn't work (because of the Genuino 101 I think), the Ardunio IDE (with it's avrdude) didn't see the MCU so I came up with this project.

# Projects
ATmegaProgrammer - GUI version: Easy to use.

CMDATmega328Programmer - Test version.
Using this project is not advised, it's only a test project. Can only fuse chips to Ardunio Nano fuses (16MHz external clock).

ArdunioISP modified sketch included.

# License
Use it, modify it, but obviously don't sell it, also give credit.
