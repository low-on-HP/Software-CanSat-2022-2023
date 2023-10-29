#include "Common.h"
#include "Hardware.h"
#include "States.h"

namespace States
{  
  uint16_t EE_STATE = 0;
  
  void Initialization(Common::Payload_States &pay_states)
  { 
    Common::GPS_Data gps_data;
    Common::Sensor_Data sensor_data;
    
    Hardware::read_gps(gps_data);
    Hardware::read_sensors(sensor_data);
    pay_states.HS_DEPLOYED = 'N';
    pay_states.PC_DEPLOYED = 'N';
    pay_states.MAST_RAISED = 'N';
    EE_STATE = 0;
    
    String received;
    if (Hardware::read_ground_radio(received)) 
    {
      if (received.startsWith("CMD," + String(Common::TEAM_ID) + ",")) 
      {
        String cmd = received.substring(9,received.length());
        if (cmd.startsWith("CX")) {
          Hardware::lastCMD = "CX";
          if (cmd.endsWith("ON")) {
            Hardware::CX = true;
            EE_STATE = 2; // standby mode
            EEPROM.put(Common::ST_ADDR, EE_STATE);
          }
          else {
            Hardware::CX = false;
          }
        }
        else if (cmd.startsWith("ST")) {
          Hardware::lastCMD = "ST"; 
          if (cmd.endsWith("GPS")) {
            // set to GPS time
          }
          else {
            String utc = cmd.substring(2,cmd.length());
            // set to utc time
          }
        }
        else if (cmd.startsWith("SIM")) {
          Hardware::lastCMD = "SIM";
          if (cmd.endsWith("ENABLE")) {
            Hardware::SIM_ENABLE = true;
          }
          else if (cmd.endsWith("ACTIVATE")) {
            if (Hardware::SIM_ENABLE) {
              Hardware::SIM_ACTIVATE = true;
            }
          }
          else if (cmd.endsWith("DISABLE")) {
            Hardware::SIM_ENABLE = false;
            Hardware::SIM_ACTIVATE = false;
          }
        }
        else if (cmd.endsWith("CAL")) {
          Hardware::lastCMD = "CAL";
          Hardware::calibrated = true;
        }
      }
    }
    if (Hardware::EE_PACKET_COUNT == 0) {
      String packet;
      Hardware::build_packet(packet, "Initialization", pay_states, gps_data, sensor_data); // build new packet
      Hardware::write_ground_radio(packet);
    }
  }
}
