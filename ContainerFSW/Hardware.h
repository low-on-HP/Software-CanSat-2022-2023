#pragma once
#ifndef __HARDWARE_H__
#define __HARDWARE_H__

#include "Common.h"
#include <Adafruit_BMP3XX.h>
#include <Servo.h>
#include <SD.h>
#include <SPI.h>

namespace Hardware
{  
  extern Adafruit_BMP3XX bmp;
  extern Servo payload_servo;

  extern elapsedMillis cameraHold;
  extern bool cameraRecording;
  extern bool firstCameraCall;

  void init();

  void deploy_payload();

  void update_camera(bool record);
  void start_recording();
  void stop_recording();

  void read_sensors(Common::Sensor_Data &data);
}
#endif
