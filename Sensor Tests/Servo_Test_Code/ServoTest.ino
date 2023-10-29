#include <Servo.h>

Servo motor;
bool hi = true;

void setup() {
  motor.attach(29);
  motor.write(0);
}

void loop() {
  if (hi) {
      motor.write(15);
      hi = false;
  }
  else {
      motor.write(165);
      hi = true;
  }
//  hi = 
  delay(3000);
}
