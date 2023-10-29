#include <SD.h>

const byte CAMERA_PIN = 35;
elapsedMillis cameraHold = 0;
bool cameraRecording = false;
bool firstCameraCall = true;

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
    pinMode(CAMERA_PIN, OUTPUT);
    digitalWrite(CAMERA_PIN, LOW);
  } else
  {
    pinMode(CAMERA_PIN, OUTPUT);
    digitalWrite(CAMERA_PIN, HIGH);
    cameraRecording = true;
    firstCameraCall = true;
  }
}

void stop_recording()
{
  if (cameraHold < 550)
  {
    pinMode(CAMERA_PIN, OUTPUT);  
    digitalWrite(CAMERA_PIN, LOW);
  } else
  {
    pinMode(CAMERA_PIN, OUTPUT);
    digitalWrite(CAMERA_PIN, HIGH);
    cameraRecording = false;
    firstCameraCall = true;
  }
}

void setup() {
  // put your setup code here, to run once:
  pinMode(CAMERA_PIN, OUTPUT);
  digitalWrite(CAMERA_PIN, HIGH);
  cameraHold = 0;
  cameraRecording = false;
  firstCameraCall = true;
}

void loop() {
  // put your main code here, to run repeatedly:
  // update camera
  if (millis() < 5000)
  {
      update_camera(true);
  } else if (millis() > 10000)
  {
      update_camera(false);
  }
  delay(3000);
}
