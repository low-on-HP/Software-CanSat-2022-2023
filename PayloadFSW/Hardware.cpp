#include "Common.h"
#include "Hardware.h"
#include "States.h"

#include <Wire.h>
#include <Adafruit_BMP3XX.h>
#include <Adafruit_BNO08x.h>
#include <Adafruit_GPS.h>
#include <EEPROM.h>
#include <TimeLib.h>
#include <Servo.h>
#include <SD.h>
#include <SPI.h>

namespace Hardware
{
bool SIM_ACTIVATE = false;
bool SIM_ENABLE = false;
int SIM_PRESSURE = 0;
float EE_BASE_ALTITUDE = 0;
uint16_t EE_PACKET_COUNT = 0;
String EE_MISSION_TIME = "00:00:00.00";
int lastCheck = 4;
String lastCMD = "None";
elapsedMillis cameraHold = 0;
bool cameraRecording = false;
bool firstCameraCall = true;
bool calibrated = false;
bool CX = false; // CX on = true ; CX off = false

Adafruit_BMP3XX bmp;
Adafruit_BNO08x  bno(-1);
Adafruit_GPS GPS(&GPS_SERIAL);
Servo para_servo;
Servo hs_servo;
Servo mast_servo;

void init()
{
  pinMode(Common::CAMERA_PIN, OUTPUT);
  digitalWrite(Common::CAMERA_PIN, HIGH);
  cameraHold = 0;
  cameraRecording = false;
  firstCameraCall = true;

  para_servo.attach(Common::PARA_SERVO_PIN);
  hs_servo.attach(Common::HS_SERVO_PIN);
  mast_servo.attach(Common::MAST_SERVO_PIN);

  para_servo.write(0);
  hs_servo.write(0);
  mast_servo.write(0);
  
  Wire.begin();
  bmp.begin_I2C(0x77);
  bno.begin_I2C(0x4A,&Wire2);
=
  if (States::EE_STATE <= 1) {
      EE_BASE_ALTITUDE = bmp.readAltitude(Common::SEA_LEVEL);
  }

  buzzer_on();

  if (SD.begin(chipSelect))
  {
    //setup GPS
    GPS.begin(9600);                   // 9600 is the default baud rate
    GPS.sendCommand("$PMTK251,38400*27");
    GPS_SERIAL.end();
    delay(200);
    buzzer_off();
    delay(800);
    GPS.begin(38400);
    GPS.sendCommand(PMTK_SET_NMEA_OUTPUT_RMCGGA);
  }

//  buzzer_off();
}

void buzzer_on()
{
  analogWriteFrequency(Common::AUDIO_BEACON_PIN, 4000);
  analogWrite(Common::AUDIO_BEACON_PIN, 128);
}

void buzzer_off()
{
  analogWriteFrequency(Common::AUDIO_BEACON_PIN, 0);
  analogWrite(Common::AUDIO_BEACON_PIN, 0);
}

void deploy_hs(Common::Payload_States &state)
{
  hs_servo.write(120);
  state.HS_DEPLOYED = 'P';
}

void deploy_chute(Common::Payload_States &state)
{
  para_servo.write(100);
  state.PC_DEPLOYED = 'C';
}

void raise_mast(Common::Payload_States &state)
{
  mast_servo.write(720); 
  state.MAST_RAISED = 'M';
}

void update_camera(bool record)
{
  if (record && !cameraRecording)
  {
    if (firstCameraCall)
    {
      cameraHold = 0;
      firstCameraCall = false;
    }

    start_recording();
  } else if (!record && cameraRecording)
  {
    if (firstCameraCall)
    {
      cameraHold = 0;
      firstCameraCall = false;
    }

    stop_recording();
  }
}

void start_recording()
{
  if (cameraHold < 150)
  {
    digitalWrite(Common::CAMERA_PIN, LOW);
  } else
  {
    digitalWrite(Common::CAMERA_PIN, HIGH);
    cameraRecording = true;
    firstCameraCall = true;
  }
}

void stop_recording()
{
  if (cameraHold < 550)
  {
    digitalWrite(Common::CAMERA_PIN, LOW);
  } else
  {
    digitalWrite(Common::CAMERA_PIN, HIGH);
    cameraRecording = false;
    firstCameraCall = true;
  }
}

void read_gps(Common::GPS_Data &data)
{
  bool newData = false;

  while (!GPS.newNMEAreceived())
  {
    char c = GPS.read();
  }
  newData = GPS.parse(GPS.lastNMEA());

  if (newData)
  {
    //Serial.println(String(GPS.hour) + ":" + String(GPS.minute) + ":" + String(GPS.seconds) + "." + String(GPS.milliseconds));
    setTime(GPS.hour, GPS.minute, GPS.seconds, GPS.day, GPS.month, GPS.year);
    lastCheck = GPS.milliseconds + millis();
  }

  data.hours = GPS.hour;
  data.minutes = GPS.minute;
  data.seconds = GPS.seconds;
  data.milliseconds = GPS.milliseconds;
  data.latitude = GPS.latitude;
  data.longitude = GPS.longitude;
  data.altitude = GPS.altitude;
  data.sats = (byte)(unsigned int)GPS.satellites;  // We do this double conversion to avoid signing issues
}

void read_sensors(Common::Sensor_Data &data)
{
  data.vbat = ((analogRead(Common::VOLTAGE_PIN) / 1023.0) * 4.2) + 0.35;
  bmp.performReading();
  if (calibrated) {
      data.altitude = bmp.readAltitude(Common::SEA_LEVEL) - EE_BASE_ALTITUDE;
  }
  else {
    data.altitude = bmp.readAltitude(Common::SEA_LEVEL);
  }
  data.temperature = bmp.temperature;
  data.pressure = bmp.pressure;

  // tilt data
  
}

bool read_ground_radio(String &data)
{
  if (GROUND_XBEE_SERIAL.available())
  {
    data = GROUND_XBEE_SERIAL.readStringUntil("\r\n");
    return true;
  } else {
    return false;
  }
}

void write_ground_radio(const String &data) 
{
  GROUND_XBEE_SERIAL.println(data);
  telemetry = SD.open("Flight_1043.csv", FILE_WRITE);
  telemetry.print(data);
  telemetry.close();
}
}
