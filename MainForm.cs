/******************************************************************************
*
* Example program:
*   ContAcqThermocoupleSamples_IntClk
*
* Category:
*   AI
*
* Description:
*   This example demonstrates how to continuously acquire temperature readings
*   from one or more thermocouples.
*
* Instructions for running:
*   1.  Specify the physical channel where you have connected the thermocouple.
*   2.  Enter the minimum and maximum temperature values in degrees C that you
*       expect to measure. A smaller range will allow a more accurate
*       measurement.
*   3.  Enter the scan rate at which you want to run the acquisition.
*   4.  Specify the type of thermocouple you are using.
*   5.  Thermocouple measurements require cold-junction compensation (CJC) to
*       correctly scale them. Specify the source of your cold-junction
*       compensation.
*   6.  If your CJC source is "Internal", skip the rest of the steps.
*   7.  If your CJC source is "Constant Value", specify the value (usually room
*       temperature) in degrees C.
*   8.  If your CJC source is "Channel", specify the CJC Channel name.
*   9.  Specify the appropriate Auto Zero Mode. See your SCXI device's hardware
*       manual to find out if your device supports this attribute. E-Series
*       devices do not support this attribute.
*
* Steps:
*   1.  Create a new Task.  Create a AIChannel object by using the
*       CreateThermocoupleChannel method.
*   2.  Set the AutoZero mode.  This attribute is set to compensate for input
*       offset errors and may not be supported by all devices.
*   3.  Configure the timing parameters by using the Timing.ConfigureSampleClock
*       method.  Use the device's internal clock, continuous mode acquisition,
*       and the sample rate specified by the user.
*   4.  Call AnalogMultiChannelReader.BeginReadWaveform to install a callback
*       and begin the asynchronous read operation.
*   5.  Inside the callback, call AnalogMultiChannelReader.EndReadWaveform to
*       retrieve the data from the read operation.  
*   6.  Call AnalogMultiChannelReader.BeginMemoryOptimizedReadWaveform
*   7.  Dispose the Task object to clean-up any resources associated with the
*       task.
*   8.  Handle any DaqExceptions, if they occur.
*
*   Note: This example sets SynchronizeCallback to true. If SynchronizeCallback
*   is set to false, then you must give special consideration to safely dispose
*   the task and to update the UI from the callback. If SynchronizeCallback is
*   set to false, the callback executes on the worker thread and not on the main
*   UI thread. You can only update a UI component on the thread on which it was
*   created. Refer to the How to: Safely Dispose Task When Using Asynchronous
*   Callbacks topic in the NI-DAQmx .NET help for more information.
*
* I/O Connections Overview:
*   Connect your thermocouple to the terminals corresponding to the physical
*   channel value. For more information on the input and output terminals for
*   your device, open the NI-DAQmx Help, and refer to the NI-DAQmx Device
*   Terminals and Device Considerations books in the table of contents.
*
* Microsoft Windows Vista User Account Control
*   Running certain applications on Microsoft Windows Vista requires
*   administrator privileges, 
*   because the application name contains keywords such as setup, update, or
*   install. To avoid this problem, 
*   you must add an additional manifest to the application that specifies the
*   privileges required to run 
*   the application. Some Measurement Studio NI-DAQmx examples for Visual Studio
*   include these keywords. 
*   Therefore, all examples for Visual Studio are shipped with an additional
*   manifest file that you must 
*   embed in the example executable. The manifest file is named
*   [ExampleName].exe.manifest, where [ExampleName] 
*   is the NI-provided example name. For information on how to embed the manifest
*   file, refer to http://msdn2.microsoft.com/en-us/library/bb756929.aspx.Note: 
*   The manifest file is not provided with examples for Visual Studio .NET 2003.
*
******************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using NationalInstruments.DAQmx;
using NationalInstruments.Restricted;
using System.Runtime.Remoting.Channels;
using DAQmxProj;
using System.Collections.Generic;
using System.Linq;

namespace NationalInstruments.Examples.ContAcqThermocoupleSamples_IntClk
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {

        private AnalogMultiChannelReader analogInReader;
        private AsyncCallback myAsyncCallback;
        private Task myTask;
        private Task runningTask;
        private AnalogWaveform<double>[] data;
        private DataColumn[] dataColumn = null;
        private DataTable dataTable = null;
        private int NumberOfChannels = 0;
        private string[] _channels;
        internal System.Windows.Forms.GroupBox acquisitionResultsGroupBox;
        internal System.Windows.Forms.GroupBox channelParametersGroupBox;
        internal System.Windows.Forms.Label maximumLabel;
        internal System.Windows.Forms.Label minimumLabel;
        internal System.Windows.Forms.Label physicalChannelLabel;
        internal System.Windows.Forms.Button startButton;
        internal System.Windows.Forms.Button stopButton;
        internal System.Windows.Forms.NumericUpDown minimumValueNumeric;
        internal System.Windows.Forms.NumericUpDown maximumValueNumeric;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private FlowLayoutPanel channelsflowLayoutPanel;

        DAQmxChannel channel;
        List <DAQmxChannel> daqmxChannels;
        private MenuStrip DAQmenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem channelToolStripMenuItem;
        public GlobalVariablesParam GlobalParam;
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            daqmxChannels = new List<DAQmxChannel>();
            GlobalParam = new GlobalVariablesParam();
            GlobalParam.SubmitButton.Click += SubmitButton_Click;

            GlobalParam.cjcSourceComboBox.SelectedIndex = 1;
            GlobalParam.autoZeroModeComboBox.SelectedIndex = 0;
            GlobalParam.thermocoupleTypeComboBox.SelectedIndex = 2;
            myAsyncCallback = new AsyncCallback(AnalogInCallback);
            dataTable = new DataTable();

            

            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External));
            _channels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External);


            NumberOfChannels = physicalChannelComboBox.Items.Count;

            if (physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 0;
        }



        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
                if (myTask != null)
                {
                    runningTask = null;
                    myTask.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.acquisitionResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.channelsflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.channelParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.minimumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.DAQmenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquisitionResultsGroupBox.SuspendLayout();
            this.channelsflowLayoutPanel.SuspendLayout();
            this.channelParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).BeginInit();
            this.DAQmenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // acquisitionResultsGroupBox
            // 
            this.acquisitionResultsGroupBox.Controls.Add(this.channelsflowLayoutPanel);
            this.acquisitionResultsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.acquisitionResultsGroupBox.Location = new System.Drawing.Point(40, 53);
            this.acquisitionResultsGroupBox.Name = "acquisitionResultsGroupBox";
            this.acquisitionResultsGroupBox.Size = new System.Drawing.Size(686, 375);
            this.acquisitionResultsGroupBox.TabIndex = 7;
            this.acquisitionResultsGroupBox.TabStop = false;
            this.acquisitionResultsGroupBox.Text = "Acquisition Results";
            // 
            // channelsflowLayoutPanel
            // 
            this.channelsflowLayoutPanel.Controls.Add(this.channelParametersGroupBox);
            this.channelsflowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.channelsflowLayoutPanel.Name = "channelsflowLayoutPanel";
            this.channelsflowLayoutPanel.Size = new System.Drawing.Size(662, 350);
            this.channelsflowLayoutPanel.TabIndex = 8;
            // 
            // channelParametersGroupBox
            // 
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelComboBox);
            this.channelParametersGroupBox.Controls.Add(this.minimumValueNumeric);
            this.channelParametersGroupBox.Controls.Add(this.maximumValueNumeric);
            this.channelParametersGroupBox.Controls.Add(this.maximumLabel);
            this.channelParametersGroupBox.Controls.Add(this.minimumLabel);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelLabel);
            this.channelParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.channelParametersGroupBox.Location = new System.Drawing.Point(3, 3);
            this.channelParametersGroupBox.Name = "channelParametersGroupBox";
            this.channelParametersGroupBox.Size = new System.Drawing.Size(232, 122);
            this.channelParametersGroupBox.TabIndex = 2;
            this.channelParametersGroupBox.TabStop = false;
            this.channelParametersGroupBox.Text = "Channel Parameters";
            this.channelParametersGroupBox.Visible = false;
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.Location = new System.Drawing.Point(120, 24);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(104, 21);
            this.physicalChannelComboBox.TabIndex = 1;
            this.physicalChannelComboBox.Text = "SC1Mod1/ai0";
            // 
            // minimumValueNumeric
            // 
            this.minimumValueNumeric.DecimalPlaces = 2;
            this.minimumValueNumeric.Location = new System.Drawing.Point(120, 88);
            this.minimumValueNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.minimumValueNumeric.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.minimumValueNumeric.Name = "minimumValueNumeric";
            this.minimumValueNumeric.Size = new System.Drawing.Size(104, 20);
            this.minimumValueNumeric.TabIndex = 5;
            // 
            // maximumValueNumeric
            // 
            this.maximumValueNumeric.DecimalPlaces = 2;
            this.maximumValueNumeric.Location = new System.Drawing.Point(120, 56);
            this.maximumValueNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.maximumValueNumeric.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.maximumValueNumeric.Name = "maximumValueNumeric";
            this.maximumValueNumeric.Size = new System.Drawing.Size(104, 20);
            this.maximumValueNumeric.TabIndex = 3;
            this.maximumValueNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // maximumLabel
            // 
            this.maximumLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maximumLabel.Location = new System.Drawing.Point(16, 58);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(104, 16);
            this.maximumLabel.TabIndex = 2;
            this.maximumLabel.Text = "Maximum (deg C):";
            // 
            // minimumLabel
            // 
            this.minimumLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minimumLabel.Location = new System.Drawing.Point(16, 90);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(96, 16);
            this.minimumLabel.TabIndex = 4;
            this.minimumLabel.Text = "Minimum (deg C):";
            // 
            // physicalChannelLabel
            // 
            this.physicalChannelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.physicalChannelLabel.Location = new System.Drawing.Point(16, 26);
            this.physicalChannelLabel.Name = "physicalChannelLabel";
            this.physicalChannelLabel.Size = new System.Drawing.Size(96, 16);
            this.physicalChannelLabel.TabIndex = 0;
            this.physicalChannelLabel.Text = "Physical Channel:";
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(263, 428);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 24);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(372, 428);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 24);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // DAQmenuStrip
            // 
            this.DAQmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.DAQmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.DAQmenuStrip.Name = "DAQmenuStrip";
            this.DAQmenuStrip.Size = new System.Drawing.Size(790, 24);
            this.DAQmenuStrip.TabIndex = 9;
            this.DAQmenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // channelToolStripMenuItem
            // 
            this.channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            this.channelToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.channelToolStripMenuItem.Text = "Channel";
            this.channelToolStripMenuItem.Click += new System.EventHandler(this.channelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(790, 504);
            this.Controls.Add(this.acquisitionResultsGroupBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.DAQmenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DAQmenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continuous Acquisition of Thermocouple Samples - Internal Clock";
            this.acquisitionResultsGroupBox.ResumeLayout(false);
            this.channelsflowLayoutPanel.ResumeLayout(false);
            this.channelParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).EndInit();
            this.DAQmenuStrip.ResumeLayout(false);
            this.DAQmenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(new MainForm());
        }

        private void startButton_Click(object sender, System.EventArgs e)
        {
            if(daqmxChannels.Count == 0)
            {
                MessageBox.Show("No channels added");
            }else
            {
                startButton.Enabled = false;
                stopButton.Enabled = true;
                analogInReader.BeginReadWaveform(1, myAsyncCallback, myTask);
            }

        }

        private void stopButton_Click(object sender, System.EventArgs e)
        {
            runningTask = null;
            myTask.Dispose();
            stopButton.Enabled = false;
            startButton.Enabled = true;
        }

        private void AnalogInCallback(IAsyncResult ar)
        {
            double dt;
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    data = analogInReader.EndReadWaveform(ar);
                  
                    dataToDataTable(data, ref dataTable);

                    foreach(DAQmxChannel dAQmx in daqmxChannels)
                    {
                        dt = dataToValue(data, dAQmx.getPhysicalChannel());
                        dAQmx.TemperatureValueLabel.Text =Math.Round(dt,4).ToString();
                    }

                    analogInReader.BeginMemoryOptimizedReadWaveform(1, myAsyncCallback, myTask, data);
                }
            }
            catch (DaqException exception)
            {
                MessageBox.Show(exception.Message);
                myTask.Dispose();
                startButton.Enabled = true;
                stopButton.Enabled = false;
                runningTask = null;
            }
            
        }

        private void cjcSourceComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (GlobalParam.cjcSourceComboBox.SelectedIndex)
            {
                case 0: // Channel
                    GlobalParam.cjcChannelTextBox.Enabled = true;
                    GlobalParam.cjcValueNumeric.Enabled = false;
                    break;
                case 1: // Constant 
                    GlobalParam.cjcChannelTextBox.Enabled = false;
                    GlobalParam.cjcValueNumeric.Enabled = true;
                    break;
                case 2: // Internal
                    GlobalParam.cjcChannelTextBox.Enabled = false;
                    GlobalParam.cjcValueNumeric.Enabled = false;
                    break;
            }
        }

        private void InitializeDataTable(AIChannelCollection channelCollection,ref DataTable data)
        {
            if (channelCollection == null)
                return;

            int numOfChannels = channelCollection.Count;
            data.Rows.Clear();
            data.Columns.Clear();
            dataColumn = new DataColumn[numOfChannels];
            int numOfRows = 10;

            for (int currentChannelIndex = 0; currentChannelIndex < numOfChannels; currentChannelIndex++)
            {   
                dataColumn[currentChannelIndex] = new DataColumn();
                dataColumn[currentChannelIndex].DataType = typeof(double);
                dataColumn[currentChannelIndex].ColumnName = channelCollection[currentChannelIndex].PhysicalName;
            }

            data.Columns.AddRange(dataColumn); 

            for(int currentDataIndex = 0; currentDataIndex < numOfRows; currentDataIndex++)             
            {
                object[] rowArr = new object[numOfChannels];
                data.Rows.Add(rowArr);              
            }
        }

        private double dataToValue(AnalogWaveform<double>[] sourceArray, string physicalChannel)
        {

            foreach (AnalogWaveform<double> waveform in sourceArray)
            {
                if(waveform.ChannelName == physicalChannel)
                {
                    return waveform.Samples[0].Value; ;
                } 
            }
            return 0;
        }
        private void dataToDataTable(AnalogWaveform<double>[] sourceArray, ref DataTable dataTable)
        {
            // Iterate over channels
            int currentLineIndex = 0;
            foreach (AnalogWaveform<double> waveform in sourceArray)
            {
                for (int sample = 0; sample < waveform.Samples.Count; ++sample)
                {
                    if (sample == 10)
                        break;

                    dataTable.Rows[sample][currentLineIndex] = waveform.Samples[sample].Value;
                }
                currentLineIndex++;
            }
        }

        private void channelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(daqmxChannels.Count == 0)
            {
                GlobalParam.Show();
            }
            else
            {
                daqmxChannels.Add(new DAQmxChannel());
                daqmxChannels.Last().getNewChannelForm().addChannelButton.Click += AddChannelButton_Click;
            }
            
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            GlobalParam.Hide();
            daqmxChannels.Add(new DAQmxChannel());
            daqmxChannels.Last().getNewChannelForm().addChannelButton.Click += AddChannelButton_Click;
        }

        private void AddChannelButton_Click(object sender, EventArgs e)
        {
            try
            {
                myTask = new Task();

                DAQmxChannel dAQmx = daqmxChannels.Last();
                AIChannel[] AIChannels;

                AIChannels = new AIChannel[NumberOfChannels];
                AIThermocoupleType thermocoupleType;
                AIAutoZeroMode autoZeroMode;

                switch (GlobalParam.thermocoupleTypeComboBox.SelectedIndex)
                {
                    case 0:
                        thermocoupleType = AIThermocoupleType.B;
                        break;
                    case 1:
                        thermocoupleType = AIThermocoupleType.E;
                        break;
                    case 2:
                        thermocoupleType = AIThermocoupleType.J;
                        break;
                    case 3:
                        thermocoupleType = AIThermocoupleType.K;
                        break;
                    case 4:
                        thermocoupleType = AIThermocoupleType.N;
                        break;
                    case 5:
                        thermocoupleType = AIThermocoupleType.R;
                        break;
                    case 6:
                        thermocoupleType = AIThermocoupleType.S;
                        break;
                    case 7:
                    default:
                        thermocoupleType = AIThermocoupleType.T;
                        break;
                }

                switch (GlobalParam.cjcSourceComboBox.SelectedIndex)
                {
                    case 0: // Channel
                        for (int i = 0; i < NumberOfChannels; i++)
                        {
                            AIChannels[i] = myTask.AIChannels.CreateThermocoupleChannel(_channels[i],
                                "", Convert.ToDouble(minimumValueNumeric.Value), Convert.ToDouble(maximumValueNumeric.Value),
                             thermocoupleType, AITemperatureUnits.DegreesC, GlobalParam.cjcChannelTextBox.Text);
                        }
                        break;
                    case 1: // Constant

                        for (int i = 0; i < NumberOfChannels; i++)
                        {
                            AIChannels[i] = myTask.AIChannels.CreateThermocoupleChannel(_channels[i],
                            "", Convert.ToDouble(minimumValueNumeric.Value), Convert.ToDouble(maximumValueNumeric.Value),
                            thermocoupleType, AITemperatureUnits.DegreesC, Convert.ToDouble(GlobalParam.cjcValueNumeric.Value));
                        }

                        break;
                    case 2: // Internal
                        dAQmx.aIChannel = myTask.AIChannels.CreateThermocoupleChannel(dAQmx.getPhysicalChannel(),
                             "", Convert.ToDouble(minimumValueNumeric.Value), Convert.ToDouble(maximumValueNumeric.Value),
                            thermocoupleType, AITemperatureUnits.DegreesC);
                        break;
                }

                if (GlobalParam.scxiModuleCheckBox.Checked)
                {
                    switch (GlobalParam.autoZeroModeComboBox.SelectedIndex)
                    {
                        case 0:
                            autoZeroMode = AIAutoZeroMode.None;
                            break;
                        case 1:
                        default:
                            autoZeroMode = AIAutoZeroMode.Once;
                            break;
                    }
                    dAQmx.aIChannel.AutoZeroMode = autoZeroMode;
                }

                myTask.Timing.ConfigureSampleClock("", Convert.ToDouble(GlobalParam.rateNumeric.Value),
                    SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 1);

                myTask.Control(TaskAction.Verify);

                analogInReader = new AnalogMultiChannelReader(myTask.Stream);

                runningTask = myTask;

                InitializeDataTable(myTask.AIChannels, ref dataTable);


                // Use SynchronizeCallbacks to specify that the object 
                // marshals callbacks across threads appropriately.
                analogInReader.SynchronizeCallbacks = true;
            //    analogInReader.BeginReadWaveform(1, myAsyncCallback, myTask);
                this.channelsflowLayoutPanel.Controls.Add(dAQmx.channelGroupBox);

            }
            catch (DaqException exception)
            {
                MessageBox.Show(exception.Message);
                myTask.Dispose();
                startButton.Enabled = true;
                stopButton.Enabled = false;
                runningTask = null;
            }
        }
    }
}
