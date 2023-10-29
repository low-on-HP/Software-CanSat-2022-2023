#pragma once
#ifndef __HARDWARE_H__
#define __HARDWARE_H__

#include "Common.h"
#include <Arduino.h>
#include <Adafruit_BMP3XX.h>
#include <Adafruit_BNO08x.h>
#include <Adafruit_GPS.h>
#include <EEPROM.h>
#include <Servo.h>
#include <SD.h>
#include <SPI.h>

namespace Hardware
{
  extern bool SIM_ACTIVATE;
  extern bool SIM_ENABLE;
  extern int SIM_PRESSURE;
  extern float EE_BASE_ALTITUDE;
  extern uint16_t EE_PACKET_COUNT;
  extern String EE_MISSION_TIME;
  extern int lastCheck;
  extern String lastCMD;
  
  extern Adafruit_BMP3XX bmp;
  extern Adafruit_BNO08x  bno;
  extern Adafruit_GPS GPS;
  extern Servo para_servo;
  extern Servo hs_servo;
  extern Servo mast_servo;

  extern elapsedMillis cameraHold;
  extern bool cameraRecording;
  extern bool firstCameraCall;
  
  extern bool calibrated;

  const int chipSelect = BUILTIN_SDCARD;
  static File telemetry;

  void init();

  void deploy_hs();
  void deploy_chute();
  void raise_mast();
  
  void buzzer_on();
  void buzzer_off();

  void update_camera(bool record);
  void start_recording();
  void stop_recording();
  
  void read_gps(Common::GPS_Data &data);
  void read_sensors(Common::Sensor_Data &data);
    
  void write_ground_radio(const String &data);
  bool read_ground_radio(String &data);

  static void build_packet(String& packet, const String& state, const Common::Payload_States &pay_states, const Common::GPS_Data &gps, const Common::Sensor_Data &sensors)
  {
    // <TEAM_ID>,<MISSION_TIME>,<PACKET_COUNT>,<MODE>,<STATE>,<ALTITUDE>,<HS_DEPLOYED>,<PC_DEPLOYED>,<MAST_RAISED>,<TEMPERATURE>,<VOLTAGE>,
    // <PRESSURE>,<GPS_TIME>,<GPS_ALTITUDE>,<GPS_LATITUDE>,<GPS_LONGITUDE>,<GPS_SATS>,<TILT_X>,<TILT_Y>,<CMD_ECHO>
    packet = String(Common::TEAM_ID) + ",";
    packet += String(hour()) + ":" + String(minute()) + ":" + String(second()) + ",";
    packet += String(EE_PACKET_COUNT) + ",";
    if (SIM_ACTIVATE && SIM_ENABLE)
      packet += "S,";
    else
      packet += "F,";
    packet += state + ",";          // EE_PROM States??
    packet += String(sensors.altitude) + ","; 
    packet += pay_states.HS_DEPLOYED + ",";
    packet += pay_states.PC_DEPLOYED + ",";
    packet += pay_states.MAST_RAISED + ",";
    packet += String(sensors.temperature) + ",";
    packet += String(sensors.vbat) + ",";
    packet += String(sensors.pressure) + ",";
    packet += String(gps.hours) + ":" + String(gps.minutes) + ":" + String(gps.seconds) + ",";
    packet += String(gps.altitude) + ",";  
    packet += String(gps.latitude) + ","; 
    packet += String(gps.longitude) + ","; 
    packet += String(gps.sats) + ",";
    packet += String(sensors.tilt[0]) + ",";
    packet += String(sensors.tilt[1]) + ",";    
    packet += lastCMD + "\r\n";
  }
}
#endif
