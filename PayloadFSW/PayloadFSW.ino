#include "Common.h"
#include "Hardware.h"
#include "States.h"

#include <EEPROM.h>

unsigned char GROUND_WRITE_BUFFER[1024];
unsigned char GPS_READ_BUFFER[1024];

Common::Payload_States pay_states;

void setup() {
  //load recovery params
  EEPROM.get(Common::BA_ADDR, Hardware::EE_BASE_ALTITUDE);  
  EEPROM.get(Common::PC_ADDR, Hardware::EE_PACKET_COUNT); 
  EEPROM.get(Common::ST_ADDR, States::EE_STATE);   
  EEPROM.get(Common::MS_ADDR, Hardware::EE_MISSION_TIME);
  
  Serial.begin(115200);
  Hardware::init();
  GPS_SERIAL.addMemoryForRead(GPS_READ_BUFFER, 1024);
  GROUND_XBEE_SERIAL.addMemoryForWrite(GROUND_WRITE_BUFFER, 1024);
  GROUND_XBEE_SERIAL.begin(115200); //xbees must be preconfigured for this; default baud is 9600
}

void loop() {
  switch (States::EE_STATE)
  {
    case 1:
      States::Initialization(pay_states);
      break;
    case 2:
      States::Standby(pay_states);
      break;
    case 3:
      States::Deployment(pay_states);
      break;
    case 4:
      States::Landing(pay_states);
      break;
    default:
      States::Initialization(pay_states);
      break;
  }
  delay(Common::TELEMETRY_DELAY);
}
