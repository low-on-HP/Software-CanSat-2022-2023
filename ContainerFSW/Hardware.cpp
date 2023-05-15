#include "Common.h"
#include "Hardware.h"

#include <Wire.h>
#include <Adafruit_BMP3XX.h>
#include <TimeLib.h>
#include <Servo.h>
#include <SD.h>
#include <SPI.h>

namespace Hardware
{
elapsedMillis cameraHold = 0;
bool cameraRecording = false;
bool firstCameraCall = true;

Adafruit_BMP3XX bmp;
Servo payload_servo; // deploys payload from container

void init()
{
  pinMode(Common::CAMERA_PIN, OUTPUT);
  digitalWrite(Common::CAMERA_PIN, HIGH);
  cameraHold = 0;
  cameraRecording = false;
  firstCameraCall = true;

  payload_servo.attach(Common::PAYLOAD_SERVO_PIN);
  payload_servo.write(15);
  Wire.begin();
  bmp.begin_I2C(0x77);

  bmp.setTemperatureOversampling(BMP3_OVERSAMPLING_8X);
  bmp.setPressureOversampling(BMP3_OVERSAMPLING_4X);
  bmp.setIIRFilterCoeff(BMP3_IIR_FILTER_COEFF_3);
  bmp.setOutputDataRate(BMP3_ODR_50_HZ);
}

void deploy_payload()
{
  payload_servo.write(30);
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

void read_sensors(Common::Sensor_Data &data)
{
  bmp.performReading();
  data.altitude = bmp.readAltitude(Common::SEA_LEVEL);
}
}
