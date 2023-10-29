namespace CanSat_GSW
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.serialPortPanel = new System.Windows.Forms.Panel();
            this.simpButton = new System.Windows.Forms.Button();
            this.setTimeDropdown = new System.Windows.Forms.ComboBox();
            this.setTimeButton = new System.Windows.Forms.Button();
            this.calButton = new System.Windows.Forms.Button();
            this.simButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.serialPorts = new System.Windows.Forms.ComboBox();
            this.serialConnect = new System.Windows.Forms.Button();
            this.startTelemetry = new System.Windows.Forms.Button();
            this.csvPanel = new System.Windows.Forms.Panel();
            this.loadButton = new System.Windows.Forms.Button();
            this.csvLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.outputName = new System.Windows.Forms.TextBox();
            this.radioChecker = new System.Windows.Forms.Timer(this.components);
            this.statusBox = new System.Windows.Forms.TextBox();
            this.telemetryBox = new System.Windows.Forms.TextBox();
            this.graphPanel = new System.Windows.Forms.TableLayoutPanel();
            this.telemetryPanel = new System.Windows.Forms.Panel();
            this.telemetryLabel = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.altGraph = new CanSat_GSW.RealTimeChart();
            this.vbatGraph = new CanSat_GSW.RealTimeChart();
            this.posGraph = new CanSat_GSW.RealTimeChart();
            this.tempGraph = new CanSat_GSW.RealTimeChart();
            this.presGraph = new CanSat_GSW.RealTimeChart();
            this.satsGraph = new CanSat_GSW.RealTimeChart();
            this.tiltGraph = new CanSat_GSW.RealTimeChart();
            this.topBarPanel.SuspendLayout();
            this.serialPortPanel.SuspendLayout();
            this.csvPanel.SuspendLayout();
            this.graphPanel.SuspendLayout();
            this.telemetryPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBarPanel.BackColor = System.Drawing.SystemColors.InfoText;
            this.topBarPanel.Controls.Add(this.serialPortPanel);
            this.topBarPanel.Controls.Add(this.csvPanel);
            this.topBarPanel.Location = new System.Drawing.Point(0, -4);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1524, 52);
            this.topBarPanel.TabIndex = 0;
            // 
            // serialPortPanel
            // 
            this.serialPortPanel.Controls.Add(this.simpButton);
            this.serialPortPanel.Controls.Add(this.setTimeDropdown);
            this.serialPortPanel.Controls.Add(this.setTimeButton);
            this.serialPortPanel.Controls.Add(this.calButton);
            this.serialPortPanel.Controls.Add(this.simButton);
            this.serialPortPanel.Controls.Add(this.portLabel);
            this.serialPortPanel.Controls.Add(this.serialPorts);
            this.serialPortPanel.Controls.Add(this.serialConnect);
            this.serialPortPanel.Controls.Add(this.startTelemetry);
            this.serialPortPanel.Location = new System.Drawing.Point(12, 12);
            this.serialPortPanel.Name = "serialPortPanel";
            this.serialPortPanel.Size = new System.Drawing.Size(1051, 36);
            this.serialPortPanel.TabIndex = 5;
            // 
            // simpButton
            // 
            this.simpButton.Location = new System.Drawing.Point(693, 0);
            this.simpButton.Name = "simpButton";
            this.simpButton.Size = new System.Drawing.Size(100, 35);
            this.simpButton.TabIndex = 11;
            this.simpButton.Text = "SIMP";
            this.simpButton.UseVisualStyleBackColor = true;
            // 
            // setTimeDropdown
            // 
            this.setTimeDropdown.FormattingEnabled = true;
            this.setTimeDropdown.Items.AddRange(new object[] {
            "UTC",
            "GPS"});
            this.setTimeDropdown.Location = new System.Drawing.Point(904, 1);
            this.setTimeDropdown.Name = "setTimeDropdown";
            this.setTimeDropdown.Size = new System.Drawing.Size(90, 33);
            this.setTimeDropdown.TabIndex = 10;
            // 
            // setTimeButton
            // 
            this.setTimeButton.Location = new System.Drawing.Point(1000, 1);
            this.setTimeButton.Name = "setTimeButton";
            this.setTimeButton.Size = new System.Drawing.Size(58, 35);
            this.setTimeButton.TabIndex = 6;
            this.setTimeButton.Text = "ST";
            this.setTimeButton.UseVisualStyleBackColor = true;
            this.setTimeButton.Click += new System.EventHandler(this.setTimeButton_Click);
            // 
            // calButton
            // 
            this.calButton.Location = new System.Drawing.Point(797, 0);
            this.calButton.Name = "calButton";
            this.calButton.Size = new System.Drawing.Size(101, 35);
            this.calButton.TabIndex = 9;
            this.calButton.Text = "CAL";
            this.calButton.UseVisualStyleBackColor = true;
            this.calButton.Click += new System.EventHandler(this.calibration_Click);
            // 
            // simButton
            // 
            this.simButton.Location = new System.Drawing.Point(493, 0);
            this.simButton.Name = "simButton";
            this.simButton.Size = new System.Drawing.Size(197, 35);
            this.simButton.TabIndex = 7;
            this.simButton.Text = "SIM ENABLE";
            this.simButton.UseVisualStyleBackColor = true;
            this.simButton.Click += new System.EventHandler(this.simButton_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.portLabel.Location = new System.Drawing.Point(0, 4);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(112, 25);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Serial Port";
            // 
            // serialPorts
            // 
            this.serialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(121, 1);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(110, 33);
            this.serialPorts.TabIndex = 8;
            // 
            // serialConnect
            // 
            this.serialConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serialConnect.Location = new System.Drawing.Point(239, 0);
            this.serialConnect.Name = "serialConnect";
            this.serialConnect.Size = new System.Drawing.Size(127, 35);
            this.serialConnect.TabIndex = 1;
            this.serialConnect.Text = "Connect";
            this.serialConnect.UseVisualStyleBackColor = true;
            this.serialConnect.Click += new System.EventHandler(this.serialConnect_Click);
            // 
            // startTelemetry
            // 
            this.startTelemetry.Location = new System.Drawing.Point(372, 0);
            this.startTelemetry.Name = "startTelemetry";
            this.startTelemetry.Size = new System.Drawing.Size(115, 35);
            this.startTelemetry.TabIndex = 1;
            this.startTelemetry.Text = "CX ON";
            this.startTelemetry.UseVisualStyleBackColor = true;
            this.startTelemetry.Click += new System.EventHandler(this.startTelemetry_Click);
            // 
            // csvPanel
            // 
            this.csvPanel.Controls.Add(this.loadButton);
            this.csvPanel.Controls.Add(this.csvLabel);
            this.csvPanel.Controls.Add(this.saveButton);
            this.csvPanel.Controls.Add(this.outputName);
            this.csvPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.csvPanel.Location = new System.Drawing.Point(1069, 0);
            this.csvPanel.Name = "csvPanel";
            this.csvPanel.Padding = new System.Windows.Forms.Padding(0, 15, 10, 0);
            this.csvPanel.Size = new System.Drawing.Size(455, 52);
            this.csvPanel.TabIndex = 5;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(359, 14);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 32);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load Data";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadData);
            // 
            // csvLabel
            // 
            this.csvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.csvLabel.AutoSize = true;
            this.csvLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.csvLabel.Location = new System.Drawing.Point(7, 18);
            this.csvLabel.Name = "csvLabel";
            this.csvLabel.Size = new System.Drawing.Size(158, 25);
            this.csvLabel.TabIndex = 1;
            this.csvLabel.Text = "CSV File Name";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(278, 14);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 32);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Data";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // outputName
            // 
            this.outputName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputName.Location = new System.Drawing.Point(171, 15);
            this.outputName.Name = "outputName";
            this.outputName.Size = new System.Drawing.Size(100, 31);
            this.outputName.TabIndex = 2;
            // 
            // radioChecker
            // 
            this.radioChecker.Enabled = true;
            this.radioChecker.Interval = 500;
            this.radioChecker.Tick += new System.EventHandler(this.checkRadio);
            // 
            // statusBox
            // 
            this.statusBox.AcceptsReturn = true;
            this.statusBox.AcceptsTab = true;
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.statusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.statusBox.Location = new System.Drawing.Point(0, 32);
            this.statusBox.Margin = new System.Windows.Forms.Padding(0);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(762, 246);
            this.statusBox.TabIndex = 14;
            // 
            // telemetryBox
            // 
            this.telemetryBox.AcceptsReturn = true;
            this.telemetryBox.AcceptsTab = true;
            this.telemetryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.telemetryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.telemetryBox.ForeColor = System.Drawing.SystemColors.Window;
            this.telemetryBox.Location = new System.Drawing.Point(0, 32);
            this.telemetryBox.Margin = new System.Windows.Forms.Padding(0);
            this.telemetryBox.Multiline = true;
            this.telemetryBox.Name = "telemetryBox";
            this.telemetryBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.telemetryBox.Size = new System.Drawing.Size(762, 246);
            this.telemetryBox.TabIndex = 15;
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BackColor = System.Drawing.Color.Magenta;
            this.graphPanel.ColumnCount = 4;
            this.graphPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.graphPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.graphPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.graphPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.graphPanel.Controls.Add(this.altGraph, 0, 0);
            this.graphPanel.Controls.Add(this.vbatGraph, 0, 1);
            this.graphPanel.Controls.Add(this.posGraph, 1, 0);
            this.graphPanel.Controls.Add(this.telemetryPanel, 2, 2);
            this.graphPanel.Controls.Add(this.tempGraph, 2, 0);
            this.graphPanel.Controls.Add(this.presGraph, 3, 0);
            this.graphPanel.Controls.Add(this.satsGraph, 1, 1);
            this.graphPanel.Controls.Add(this.tiltGraph, 2, 1);
            this.graphPanel.Controls.Add(this.statusPanel, 0, 2);
            this.graphPanel.Location = new System.Drawing.Point(0, 48);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.RowCount = 3;
            this.graphPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.graphPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.graphPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.graphPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.graphPanel.Size = new System.Drawing.Size(1524, 832);
            this.graphPanel.TabIndex = 4;
            // 
            // telemetryPanel
            // 
            this.telemetryPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.graphPanel.SetColumnSpan(this.telemetryPanel, 2);
            this.telemetryPanel.Controls.Add(this.telemetryLabel);
            this.telemetryPanel.Controls.Add(this.telemetryBox);
            this.telemetryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telemetryPanel.Location = new System.Drawing.Point(762, 554);
            this.telemetryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.telemetryPanel.Name = "telemetryPanel";
            this.telemetryPanel.Size = new System.Drawing.Size(762, 278);
            this.telemetryPanel.TabIndex = 9;
            // 
            // telemetryLabel
            // 
            this.telemetryLabel.BackColor = System.Drawing.Color.Black;
            this.telemetryLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.telemetryLabel.ForeColor = System.Drawing.Color.White;
            this.telemetryLabel.Location = new System.Drawing.Point(0, 0);
            this.telemetryLabel.Name = "telemetryLabel";
            this.telemetryLabel.Size = new System.Drawing.Size(762, 32);
            this.telemetryLabel.TabIndex = 16;
            this.telemetryLabel.Text = "Telemetry Feed";
            this.telemetryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.Black;
            this.graphPanel.SetColumnSpan(this.statusPanel, 2);
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Controls.Add(this.statusBox);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(0, 554);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(762, 278);
            this.statusPanel.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Black;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(762, 32);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.Text = "CanSat Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.DiscardNull = true;
            this.serialPort.ReadTimeout = 150;
            // 
            // altGraph
            // 
            this.altGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.altGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.altGraph.Location = new System.Drawing.Point(0, 0);
            this.altGraph.Margin = new System.Windows.Forms.Padding(0);
            this.altGraph.Name = "altGraph";
            this.altGraph.Size = new System.Drawing.Size(381, 277);
            this.altGraph.TabIndex = 10;
            // 
            // vbatGraph
            // 
            this.vbatGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.vbatGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vbatGraph.Location = new System.Drawing.Point(0, 277);
            this.vbatGraph.Margin = new System.Windows.Forms.Padding(0);
            this.vbatGraph.Name = "vbatGraph";
            this.vbatGraph.Size = new System.Drawing.Size(381, 277);
            this.vbatGraph.TabIndex = 14;
            // 
            // posGraph
            // 
            this.posGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.posGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.posGraph.Location = new System.Drawing.Point(381, 0);
            this.posGraph.Margin = new System.Windows.Forms.Padding(0);
            this.posGraph.Name = "posGraph";
            this.posGraph.Size = new System.Drawing.Size(381, 277);
            this.posGraph.TabIndex = 11;
            // 
            // tempGraph
            // 
            this.tempGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.tempGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tempGraph.Location = new System.Drawing.Point(762, 0);
            this.tempGraph.Margin = new System.Windows.Forms.Padding(0);
            this.tempGraph.Name = "tempGraph";
            this.tempGraph.Size = new System.Drawing.Size(381, 277);
            this.tempGraph.TabIndex = 13;
            // 
            // presGraph
            // 
            this.presGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.presGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.presGraph.Location = new System.Drawing.Point(1143, 0);
            this.presGraph.Margin = new System.Windows.Forms.Padding(0);
            this.presGraph.Name = "presGraph";
            this.presGraph.Size = new System.Drawing.Size(381, 277);
            this.presGraph.TabIndex = 15;
            // 
            // satsGraph
            // 
            this.satsGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.satsGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satsGraph.Location = new System.Drawing.Point(381, 277);
            this.satsGraph.Margin = new System.Windows.Forms.Padding(0);
            this.satsGraph.Name = "satsGraph";
            this.satsGraph.Size = new System.Drawing.Size(381, 277);
            this.satsGraph.TabIndex = 12;
            // 
            // tiltGraph
            // 
            this.tiltGraph.BackColor = System.Drawing.Color.Gainsboro;
            this.graphPanel.SetColumnSpan(this.tiltGraph, 2);
            this.tiltGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tiltGraph.Location = new System.Drawing.Point(762, 277);
            this.tiltGraph.Margin = new System.Windows.Forms.Padding(0);
            this.tiltGraph.Name = "tiltGraph";
            this.tiltGraph.Size = new System.Drawing.Size(762, 277);
            this.tiltGraph.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1522, 879);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.topBarPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1500, 950);
            this.Name = "MainWindow";
            this.Text = "CanSat Ground Station";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Leave += new System.EventHandler(this.MainWindow_Leave);
            this.topBarPanel.ResumeLayout(false);
            this.serialPortPanel.ResumeLayout(false);
            this.serialPortPanel.PerformLayout();
            this.csvPanel.ResumeLayout(false);
            this.csvPanel.PerformLayout();
            this.graphPanel.ResumeLayout(false);
            this.telemetryPanel.ResumeLayout(false);
            this.telemetryPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button serialConnect;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label csvLabel;
        private System.Windows.Forms.TextBox outputName;
        private System.Windows.Forms.Button startTelemetry;
        private System.Windows.Forms.Timer radioChecker;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button simButton;
        private System.Windows.Forms.Button setTimeButton;
        private System.Windows.Forms.ComboBox serialPorts;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox telemetryBox;
        private System.Windows.Forms.TableLayoutPanel graphPanel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel telemetryPanel;
        private System.Windows.Forms.Label telemetryLabel;
        private RealTimeChart posGraph;
        private RealTimeChart altGraph;
        private RealTimeChart vbatGraph;
        private RealTimeChart tempGraph;
        private RealTimeChart satsGraph;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel serialPortPanel;
        private System.Windows.Forms.Panel csvPanel;
        private RealTimeChart presGraph;
        private RealTimeChart tiltGraph;
        private System.Windows.Forms.Button calButton;
        private System.Windows.Forms.ComboBox setTimeDropdown;
        private System.Windows.Forms.Button simpButton;
    }
}

