# CanSat Container Flight Software
This is the flight software code used to operate the 2022-2023 CanSat Container. 

# Key Features
* Autonomous mission phases
* Ported to Arduino IDE
* Designed for Teensy microcontrollers such as Teensy 3.6, 4.1.
* Uses Adafruit BMP388 as Pressure/Temperature Sensor and Altimeter

# Getting Started
1. Download and install the Arduino IDE.
2. Dowload and install Teensyduino. <br>
   1. Go to File > Preferences, and add the Teensy board manager link under the "Additonal Boards Manager URLs" (https://www.pjrc.com/teensy/package_teensy_index.json).
   2. Go to Tools > Board > Board Manager.
   3. Search for "Teensy" and install.
3. Download Adafruit BMP388 Library.
   1. Go to Sketch > Include Library > Manage Libraries.
   2. Search for "Adafruit BMP3XX" and install.
4. Set up container hardware.
   1. Plug Teensy microcontroller to computer using USB to MicroUSB cable. <br>
   Within Arduino IDE: 
   2. Go to Tools > Board > Teensyduino > Teensy 3.6.
   3. Go to Tools > Port, and choose the Serial COM port that corresponds to the cable that is plugged in.
5. Verify and upload Github code.
   1. Download and open the code within this folder on the Arduino IDE.
   2. Verify the Teensy Board is set to Teesny 3.6 and the Port is set to the proper COM port.
   3. Click the Upload buttom.
