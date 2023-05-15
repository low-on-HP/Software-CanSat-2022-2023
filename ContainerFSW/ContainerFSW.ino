#include "Common.h"
#include "Hardware.h"

// checks before payload deployment
bool check1 = false;
bool check2 = false;
bool check3 = false;  
bool payload_deployed = false;
bool reached_apogee = false;
float lastAlt = 0.0;
bool cameraCall = false;

int alt = 5;
int it = 25;

void setup() {
  Serial.begin(115200);
  Hardware::init();
}

void loop() {
  // read altitude from bmp388
  Common::Sensor_Data sensor_data;
  Hardware::read_sensors(sensor_data);

  sensor_data.altitude += alt;
  alt += it;

  if (sensor_data.altitude < 130 && reached_apogee) {
    alt = 0;
    it = 0;
  }
  
  Serial.println("Altitude: " + String(sensor_data.altitude));

  // reaches apogee if altitude surpasses 600 m 
  if (!reached_apogee) {
    if (sensor_data.altitude > 600) {
      if (!check1) {
        check1 = true;
      }
      else if (!check2) {
        check2 = true;
      }
      else if (!check3) {
        check3 = true;
      }
    }
    if (check1 && check2 && check3) {
      check1 = false;
      check2 = false;
      check3 = false;
      reached_apogee = true;
      it = -10;
    }
  }

  // deploy payload if reached apogee and altitude drops to 500 m  
  if (reached_apogee && !payload_deployed) {
    if (sensor_data.altitude < 502) {
      if (!check1) {
        check1 = true;
      }
      else if (!check2) {
        check2 = true;
      }
      else if (!check3) {
        check3 = true;
      }
    }
    if (check1 && check2 && check3) {
      Hardware::deploy_payload();
      payload_deployed = true;
      cameraCall = true;
      check1 = false;
      check2 = false;
      check3 = false;
    }
  }

  // static altitude to end recording
  if (reached_apogee && payload_deployed) {
    if (abs(sensor_data.altitude - lastAlt) < 1) {
      if (!check1) {
        check1 = true;
      }
      else if (!check2) {
        check2 = true;
      }
      else if (!check3) {
        check3 = true;
      }
    }
    if (check1 && check2 && check3) {
      cameraCall = false;
    }
  }

  // turn on/off camera
  if (cameraCall) {
    Hardware::update_camera(true);
  }
  else {
    Hardware::update_camera(false);
  }

  lastAlt = sensor_data.altitude;
  
  delay(Common::TELEMETRY_DELAY);
}
