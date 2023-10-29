#include <Wire.h>
#include <Adafruit_Sensor.h>
#include "Adafruit_BMP3XX.h"
#include <TimeLib.h>

#define TEAM_ID 1043
#define XBEE_SERIAL Serial2
//#define GPS_SERIAL Serial2

Adafruit_BMP3XX bmp;
//Adafruit_GPS GPS1(&GPS_SERIAL);

int packet_count = 0;
double groundPressure = 1013.25;
String received = "";

//struct GPS_Data
//{
//  uint8_t hours;
//  uint8_t minutes;
//  uint8_t seconds;
////  uint16_t milliseconds;
//  float latitude;
//  float longitude;
//  float altitude;
//  byte sats;
//}; 

//void read_gps(GPS_Data &data) {
//  while (!GPS1.newNMEAreceived())
//  {
//    GPS1.read();
//  }
//        
//  data.hours = GPS1.hour;
//  data.minutes = GPS1.minute;
//  data.seconds = GPS1.seconds;
////  data.milliseconds = GPS1.milliseconds;
//  data.latitude = GPS1.latitude;
//  data.longitude = GPS1.longitude;
//  data.altitude = GPS1.altitude;
//  data.sats = (byte)(unsigned int)GPS1.satellites;  // We do this double conversion to avoid signing issues
//}

void setup() {
  // random numbers for testing
  randomSeed(analogRead(A1));
  
  // this for the serial monitor
  Serial.begin(115200);
  Serial.println("Starting...");

  // this for the xbee
  XBEE_SERIAL.begin(115200);
  XBEE_SERIAL.println("Connecting to the XBee!");

  if (!bmp.begin_I2C(0x77, &Wire2))
  {
    XBEE_SERIAL.println("Failed to find the BMP388");
  } else
  {
    XBEE_SERIAL.println("Found the BMP388");
  }

//  if (!GPS1.begin(9600))
//  {
//    XBEE_SERIAL.println("Failed to find the GPS");
//  } else
//  {
//    XBEE_SERIAL.println("Found the GPS");
//  }

  // Set up oversampling and filter initialization
  bmp.setTemperatureOversampling(BMP3_OVERSAMPLING_8X);
  bmp.setPressureOversampling(BMP3_OVERSAMPLING_4X);
  bmp.setIIRFilterCoeff(BMP3_IIR_FILTER_COEFF_3);
  bmp.setOutputDataRate(BMP3_ODR_50_HZ);
}

void loop() {
  // put your main code here, to run repeatedly:
  bmp.performReading();

  if (XBEE_SERIAL.available())
  {
    String msg = XBEE_SERIAL.readStringUntil("\r\n");
    received = msg;

    if (msg.indexOf("CAL") != -1)
    {
      groundPressure = bmp.pressure / 100.0;
    }
  }

  String packet = String(TEAM_ID) + ",";
  packet += getTime() + ",";
  packet += String(packet_count++) + ",";
  packet += "S,";
  packet += "Test,";
  packet += String(bmp.readAltitude(groundPressure)) + ",";
  packet += "N,N,N,";
  packet += String(bmp.temperature) + ",";
  packet += String(random(300,400) / 100.00) + ","; // voltage
  packet += String(bmp.pressure) + ",";
  packet += getTime() + ","; // gps time
  packet += String(bmp.readAltitude(groundPressure)) + ","; // gps altitude
  packet += String(random(-10,10) / 100.00) + ","; // gps latitude
  packet += String(random(-10,10) / 100.00) + ","; // gps longitude
  packet += String(random(5, 15)) + ","; // gps sats
  packet += String(random(-9000,9000) / 100.00) + ",";
  packet += String(random(-9000,9000) / 100.00) + ",";
  packet += received + "\r\n";
  
  XBEE_SERIAL.println(packet);
  Serial.println(packet);
  
  delay(1000);
}

String getTime()
{
  int h = hour();
  int m = minute();
  int s = second();

  String hh = ((h <= 9) ? "0" : "") + String(h);
  String mm = ((m <= 9) ? "0" : "") + String(m);
  String ss = ((s <= 9) ? "0" : "") + String(s);
  
  return hh + ":" + mm + ":" + ss;
}
