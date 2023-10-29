#pragma once
#ifndef __COMMON_H__
#define __COMMON_H__

#include <Arduino.h>
#include <TimeLib.h>

#define GPS_SERIAL Serial7
#define GROUND_XBEE_SERIAL Serial8

namespace Common {
  const unsigned long TELEMETRY_DELAY = 1000; //1hz
  const byte VOLTAGE_PIN = 38;
  const byte PARA_SERVO_PIN = 22;
  const byte HS_SERVO_PIN = 23;
  const byte MAST_SERVO_PIN = 2;
  const byte CAMERA_PIN = 3;
  const byte AUDIO_BEACON_PIN = 6;
  const float SEA_LEVEL = 1014.6f; //update this before launch
  const uint16_t TEAM_ID = 1043;
  const uint16_t BA_ADDR = 0; // base altitude
  const uint16_t PC_ADDR = 4; // packet count 
  const uint16_t ST_ADDR = 6; // states
  const String MS_ADDR = 17; // mission time

  struct Payload_States
  {
    char HS_DEPLOYED; // heat shield
    char PC_DEPLOYED; // parachute 
    char MAST_RAISED; // flag mast
  };
  
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
  
  struct Sensor_Data
  {
    float vbat; // Teensy voltage sensor
    float altitude; // BMP388 pressure-calculated
    float temperature; // BMP388
    float pressure; // BMP388
    float tilt[2]; // BNO085 (0: x-tilt, 1: y-tilt)
  };
}
#endif
