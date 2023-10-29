#include <Adafruit_BMP3XX.h>
#include <bmp3.h>
#include <bmp3_defs.h>

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include "Adafruit_BMP3XX.h"

Adafruit_BMP3XX bmp;

void setup() {
  // this for the serial monitor
  Serial.begin(115200);
  Serial.println("Starting...");

  if (!bmp.begin_I2C(0x77)) { // &Wire2
    Serial.println("Failed to find the BMP388");
  } else {
    Serial.println("Found the BMP388");
  }

  // Set up oversampling and filter initialization
  bmp.setTemperatureOversampling(BMP3_OVERSAMPLING_8X);
  bmp.setPressureOversampling(BMP3_OVERSAMPLING_4X);
  bmp.setIIRFilterCoeff(BMP3_IIR_FILTER_COEFF_3);
  bmp.setOutputDataRate(BMP3_ODR_50_HZ);
}

void loop() {
  // put your main code here, to run repeatedly:

  bmp.performReading();
  String telemetry = "Altitude: " + String(bmp.readAltitude(1013.25)) + "\n";
  telemetry += "Temperature: " + String(bmp.temperature) + "\n";

  Serial.println(telemetry);

  delay(1000);
}
