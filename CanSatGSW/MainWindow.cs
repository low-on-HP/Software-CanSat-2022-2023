using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;

namespace CanSat_GSW
{
    public partial class MainWindow : Form
    {
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        List<string> allPackets;
        Random r;
        int time = 0;

        string MISSION_TIME = "00:00:00.00";
        int PACKET_COUNT = 0;
        string MODE = "F";
        string STATE = "INITIALZATION";
        string HS_DEPLOYED = "N";
        string PC_DEPLOYED = "N";
        string MAST_RAISED = "N";
        string GPS_TIME = "00:00:00";
        string CMD_ECHO = "None";

        public MainWindow()
        {
            InitializeComponent();

            r = new Random();
            altGraph.setTitle("Altitude");
            posGraph.setTitle("GPS Position");
            satsGraph.setTitle("GPS Satellites");
            tempGraph.setTitle("Temperature");
            presGraph.setTitle("Pressure");
            vbatGraph.setTitle("Battery Voltage");
            tiltGraph.setTitle("Tilt");

            altGraph.AddChart("UTC Time", "Height", "GPS", SeriesChartType.FastLine);
            altGraph.AddLineToChart("chart0", "Payload", SeriesChartType.FastLine);

            posGraph.AddChart("Degrees", "Degrees", "GPS Position", SeriesChartType.FastLine);

            tempGraph.AddChart("UTC Time", "Celsuis", "Payload", SeriesChartType.FastLine);

            presGraph.AddChart("UTC Time", "kPa", "Payload", SeriesChartType.FastLine);

            vbatGraph.AddChart("UTC Time", "Voltage", "Payload", SeriesChartType.FastLine);

            satsGraph.AddChart("UTC Time", "Number of Satellites", "GPS Sats", SeriesChartType.FastLine);

            tiltGraph.AddChart("UTC Time", "Degrees", "X", SeriesChartType.FastLine);
            tiltGraph.AddLineToChart("chart0", "Y", SeriesChartType.FastLine);

            allPackets = new List<string>();
        }

        private bool updatePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
            {
                if (!serialPorts.Items.Contains(ports[i]))
                    return true;
            }
            return false;
        }

        private void checkRadio(object sender, EventArgs e)
        {
            // grey out connect/disconnect buttom
            if (serialPorts.SelectedItem == null)
            {
                serialConnect.Enabled = false;
                serialConnect.BackColor = Color.FromArgb(100, Color.Black);
            }
            else
            {
                serialConnect.Enabled = true;
                serialConnect.BackColor = SystemColors.ButtonFace;
            }

            // grey out other buttoms if no serial port is connected
            if (serialConnect.Text == "Connect")
            {
                startTelemetry.Enabled = false;
                startTelemetry.BackColor = Color.FromArgb(100, Color.Black);
                simButton.Enabled = false;
                simButton.BackColor = Color.FromArgb(100, Color.Black);
                simpButton.Enabled = false;
                simpButton.BackColor = Color.FromArgb(100, Color.Black);
                calButton.Enabled = false;
                calButton.BackColor = Color.FromArgb(100, Color.Black);
                setTimeDropdown.Enabled = false;
                setTimeButton.Enabled = false;
                setTimeButton.BackColor = Color.FromArgb(100, Color.Black);
            }
            // enable buttons if serial port is active and states allow it
            if (serialConnect.Text == "Disconnect")
            {
                // CX
                startTelemetry.Enabled = true;
                startTelemetry.BackColor = SystemColors.ButtonFace;
                // SIM and SIMP
                if (STATE != "INITIALIZATION")
                {
                    simButton.Enabled = true;
                    simButton.BackColor = SystemColors.ButtonFace;
                    simpButton.Enabled = true;
                    simpButton.BackColor = SystemColors.ButtonFace;
                }
                // CAL
                if (STATE == "INITIALIZATION")
                {
                    calButton.Enabled = true;
                    calButton.BackColor = SystemColors.ButtonFace;
                }
                // ST
                setTimeDropdown.Enabled = true;
                if (setTimeDropdown.SelectedItem != null)
                {
                    setTimeButton.Enabled = true;
                    setTimeButton.BackColor = SystemColors.ButtonFace;
                }
            }

            if (!serialPort.IsOpen)
            {
                if (updatePorts())
                {
                    serialPorts.Items.Clear();

                    foreach (string p in SerialPort.GetPortNames())
                    {
                        serialPorts.Items.Add(p);
                    }
                }
                return;
            }

            try
            {
                //serialPort.BytesToRead > 0
                //time % 500 == 0
                while (serialPort.BytesToRead > 0)
                {
                    string packet = serialPort.ReadLine();

                    Console.WriteLine(packet);

                    allPackets.Add(packet);

                    string[] items = packet.Split(',');

                    AddNewData(packet, items);
                    //AddRandomData();
                }
            }
            catch (Exception) { }
        }

        private void serialConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = serialPorts.SelectedItem.ToString();
                serialPort.Open();
                serialConnect.Text = "Disconnect";

                allPackets.Clear();
                altGraph.Clear();
                posGraph.Clear();
                tempGraph.Clear();
                presGraph.Clear();
                satsGraph.Clear();
                vbatGraph.Clear();
                tiltGraph.Clear();
                statusBox.Clear();
                telemetryBox.Clear();
            }
            else
            {
                serialPort.Close();
                serialConnect.Text = "Connect";
            }
        }

        private void AddNewData(string packet, string[] data)
        {
            try
            {
                int TEAM_ID = Convert.ToInt32(data[0]);

                if (TEAM_ID != 1043) return;

                MISSION_TIME = data[1];
                PACKET_COUNT = Convert.ToInt32(data[2]);


                telemetryBox.AppendText(packet + "\r\n");

                {
                    MODE = data[3];
                    STATE = data[4];
                    altGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[5]), "Payload");
                    HS_DEPLOYED = data[6];
                    PC_DEPLOYED = data[7];
                    MAST_RAISED = data[8];
                    tempGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[9]), "Payload");
                    vbatGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[10]), "Payload");
                    presGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[11]), "Payload");
                    GPS_TIME = data[12];
                    altGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[13]), "GPS");
                    Console.WriteLine(Convert.ToDouble(data[14]));
                    Console.WriteLine(Convert.ToDouble(data[15]));
                    posGraph.AddPoint(Convert.ToDouble(data[14]), Convert.ToDouble(data[15]), "GPS Position");
                    satsGraph.AddPoint(MISSION_TIME, Convert.ToInt32(data[16]), "GPS Sats");
                    tiltGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[17]), "X");
                    tiltGraph.AddPoint(MISSION_TIME, Convert.ToDouble(data[18]), "Y");
                    CMD_ECHO = data[19];
                }

                statusBox.Clear();
                statusBox.AppendText("MISSION_TIME: " + MISSION_TIME + "\r\n");
                statusBox.AppendText("PACKET_COUNT: " + Convert.ToInt32(PACKET_COUNT) + "\r\n");
                statusBox.AppendText("MODE: " + MODE + "\r\n");
                statusBox.AppendText("STATE: " + STATE + "\r\n");
                statusBox.AppendText("HS_DEPLOYED: " + HS_DEPLOYED + "\r\n");
                statusBox.AppendText("PC_DEPLOYED: " + PC_DEPLOYED + "\r\n");
                statusBox.AppendText("MAST_RAISED: " + MAST_RAISED+ "\r\n");
                statusBox.AppendText("GPS_TIME: " + GPS_TIME + "\r\n");
                statusBox.AppendText("CMD_ECHO: " + CMD_ECHO + "\r\n");
            }
            catch { }
        }

        private void AddRandomData()
        {
            try
            {
                altGraph.AddPoint(time, Convert.ToDouble(r.NextDouble()), "GPS");
                altGraph.AddPoint(time, Convert.ToDouble(r.NextDouble()), "Press");

                posGraph.AddPoint(time, Convert.ToDouble(r.NextDouble()), "Lat");
                posGraph.AddPoint(time, Convert.ToDouble(r.NextDouble()), "Long");

                tempGraph.AddPoint(time, Convert.ToDouble(r.NextDouble()), "Temp");

                vbatGraph.AddPoint(time, Convert.ToDouble(r.NextDouble()), "Vbat");
            }
            catch { }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(outputName.Text + ".csv", allPackets);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
        }

        private void MainWindow_Leave(object sender, EventArgs e)
        {
            serialPort.Close(); 
        }
        
        private void loadData(object sender, EventArgs e)
        {
            allPackets.Clear();
            altGraph.Clear();
            posGraph.Clear();
            tempGraph.Clear();
            presGraph.Clear();
            satsGraph.Clear();
            vbatGraph.Clear();
            tiltGraph.Clear();
            statusBox.Clear();
            telemetryBox.Clear();

            string[] data = File.ReadAllLines(outputName.Text + ".csv");

            foreach (string line in data)
            {
                AddNewData(line, line.Split(','));
            }
        }

        private void startTelemetry_Click(object sender, EventArgs e)
        {
            if (startTelemetry.Text == "CX ON")
            {
                serialPort.WriteLine("CMD,1043,CX,ON\r\n");
                startTelemetry.Text = "CX OFF";
            }
            else if (startTelemetry.Text == "CX OFF")
            {
                serialPort.WriteLine("CMD,1043,CX,OFF\r\n");
                startTelemetry.Text = "CX ON";
            }
            else { }
        }
        private void setTimeButton_Click(object sender, EventArgs e)
        {
            if (setTimeDropdown.Text == "UTC")
            {
                DateTime saveUtcNow = DateTime.UtcNow;
                String utc = saveUtcNow.ToString().Split(' ')[1];
                String[] parts = utc.Split(':');
                int h = Convert.ToInt16(parts[0]);
                int m = Convert.ToInt16(parts[1]);
                int s = Convert.ToInt16(parts[2]);
                String hh = ((h <= 9) ? "0" : "") + h.ToString();
                String mm = ((m <= 9) ? "0" : "") + m.ToString();
                String ss = ((s <= 9) ? "0" : "") + s.ToString();
                utc = hh + ":" + mm + ":" + ss;

                serialPort.WriteLine("CMD,1043,ST," + (utc) + "\r\n");
            }
            else if (setTimeDropdown.Text == "GPS")
            {
                serialPort.WriteLine("CMD,1043,ST,GPS\r\n");
            }
            else { }
        }

        private void simButton_Click(object sender, EventArgs e)
        {
            if (simButton.Text == "SIM ENABLE")
            {
                serialPort.WriteLine("CMD,1043,SIM,ENABLE\r\n");
                simButton.Text = "SIM ACTIVATE";
            }
            else if (simButton.Text == "SIM ACTIVATE")
            {
                serialPort.WriteLine("CMD,1043,SIM,ACTIVATE\r\n");
                simButton.Text = "SIM DISABLE";
            }
            else if (simButton.Text == "SIM DISABLE")
            {
                serialPort.WriteLine("CMD,1043,SIM,DISABLE\r\n");
                simButton.Text = "SIM ENABLE";
            }
            else { }
        }

        private void calibration_Click(object sender, EventArgs e)
        {
            serialPort.WriteLine("CAL\r\n");
        }
    }
}
