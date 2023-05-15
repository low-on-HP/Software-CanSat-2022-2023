#pragma once
#ifndef __COMMON_H__
#define __COMMON_H__

#include <Arduino.h>

namespace Common {
  const unsigned long TELEMETRY_DELAY = 1000; //1hz
  
  const byte PAYLOAD_SERVO_PIN = 29;
  const byte CAMERA_PIN = 25;
  const float SEA_LEVEL = 1014.6f; //update this before launch
  
  struct Sensor_Data
  {
    float altitude;
  };
}
#endif
