#include <Adafruit_GPS.h>
#include <Wire.h>

// Connect to the GPS on the hardware port
#define GPS_SERIAL Serial7
Adafruit_GPS GPS1(&GPS_SERIAL);

struct GPS_Data
{
  uint8_t hours;
  uint8_t minutes;
  uint8_t seconds;
  uint16_t milliseconds;
  float latitude;
  float longitude;
  float altitude;
  byte sats;
}; 

void read_gps(GPS_Data &data) {
  while (!GPS1.newNMEAreceived())
  {
    GPS1.read();
  }
        
  data.hours = GPS1.hour;
  data.minutes = GPS1.minute;
  data.seconds = GPS1.seconds;
  data.milliseconds = GPS1.milliseconds;
  data.latitude = GPS1.latitude;
  data.longitude = GPS1.longitude;
  data.altitude = GPS1.altitude;
  data.sats = (byte)(unsigned int)GPS1.satellites;  // We do this double conversion to avoid signing issues
}

void setup()
{
  Serial.begin(115200);
  Serial.println("Adafruit GPS Testing");
  GPS1.begin(9600);                   // 9600 is the default baud rate
  GPS1.sendCommand("$PMTK251,38400*27");
  delay(800);
  GPS1.sendCommand(PMTK_SET_NMEA_OUTPUT_RMCGGA);
}

void loop() // run over and over again
{
  GPS_Data stuff;
  read_gps(stuff);
  Serial.println("Hours: " + stuff.hours);
  Serial.println();
  delay(10000);
}
