using NationalInstruments.DAQmx;
using NationalInstruments.Examples.ContAcqThermocoupleSamples_IntClk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAQmxProj
{

    internal class DAQmxChannel 
    {
        private string[] _channels;
        private NewChannelForm NewChannelForm;
        private string PhysicalChannel;
        private string channelName;
        private string CJCChannel;
        private int CJCSource;
        private double MaximumTemp;
        private double MinimumTemp;
        private AIThermocoupleType thermocoupleType;
        private AIAutoZeroMode autoZeroMode;

        private double Rate;
        private double CJCValue;
        private string ThermocoupleType;

        public AIChannel aIChannel;


        public GroupBox channelGroupBox;

        public int getCJCSource()
        {
            return CJCSource;
        }

        public string getChannelName()
        {
            return channelName;
        }

        public string getPhysicalChannel()
        {
            return PhysicalChannel;
        }
        public NewChannelForm getNewChannelForm()
        {
                if(NewChannelForm != null)
                return NewChannelForm;
            return null;
        }

        public double getMinTemperature()
        {
            return MinimumTemp;
        }

        public double getMaxTemperature()
        {
            return MaximumTemp;
        }

        public AIThermocoupleType getAIThermocoupleType()
        {
            return thermocoupleType;
        }

        public string getCJCChannel()
        {
            return CJCChannel;
        }

        public double getTemperatureConstant()
        {
            return CJCValue;
        }

        public double getRate()
        {
            return Rate;
        }

        public DAQmxChannel() {
            channelGroupBox = new GroupBox();
            initializeComponents();       
             NewChannelForm = new NewChannelForm();
             NewChannelForm.addChannelButton.Click += AddChannelButton_Click;
             NewChannelForm.Show();
             NewChannelForm.physicalChannelComboBox.SelectedIndex = 0;
            _channels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External);
        }

        public void show()
        {
           channelGroupBox.Show();
        }

        private void AddChannelButton_Click(object sender, EventArgs e)
        {
            if (NewChannelForm != null)
            {
                PhysicalChannel = NewChannelForm.physicalChannelComboBox.Text;
                MinimumTemp = (double)NewChannelForm.minimumValueNumeric.Value;
                MaximumTemp = (double)NewChannelForm.maximumValueNumeric.Value;


                if(channelName == null)
                    channelName = "AI" + NewChannelForm.physicalChannelComboBox.SelectedIndex.ToString();

                PhysicalChannelValueLabel.Text = channelName;
                channelGroupBox.Text = PhysicalChannel;
                ThermocoupleTypeValueLabel.Text = ThermocoupleType;
                TemperatureValueLabel.Text = CJCValue.ToString();
                minValueLabel.Text = MinimumTemp.ToString();
                maxValueLabel.Text = MaximumTemp.ToString();

                autoZeroMode = AIAutoZeroMode.None;

                NewChannelForm.Close();
            }       
        }
        private void initializeComponents()
        {
            this.channelGroupBox = new System.Windows.Forms.GroupBox();
            this.ThermocoupleTypeLabel = new System.Windows.Forms.Label();
            this.PhysicalChannelValueLabel = new System.Windows.Forms.Label();
            this.channelNameLabel = new System.Windows.Forms.Label();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.TemperatureValueLabel = new System.Windows.Forms.Label();
            this.TemperatureValueLabel = new System.Windows.Forms.Label();
            this.ThermocoupleTypeValueLabel = new System.Windows.Forms.Label();

            this.CJCSourceLabel = new System.Windows.Forms.Label();
            this.CJCSourceValueLabel = new System.Windows.Forms.Label();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.maximumValueLabel = new System.Windows.Forms.Label();
            this.minValueLabel = new System.Windows.Forms.Label();
            this.minimumLabel = new System.Windows.Forms.Label();

            // 
            // channelGroupBox
            // 
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;
            this.channelGroupBox.BackColor = System.Drawing.Color.Bisque;


            this.channelGroupBox.Controls.Add(this.ThermocoupleTypeValueLabel);
            this.channelGroupBox.Controls.Add(this.ThermocoupleTypeLabel);
            this.channelGroupBox.Controls.Add(this.PhysicalChannelValueLabel);
            this.channelGroupBox.Controls.Add(this.channelNameLabel);
            this.channelGroupBox.Controls.Add(this.TemperatureLabel);
            this.channelGroupBox.Controls.Add(this.TemperatureValueLabel);

            this.channelGroupBox.Controls.Add(this.CJCSourceValueLabel);
            this.channelGroupBox.Controls.Add(this.CJCSourceLabel);
            this.channelGroupBox.Controls.Add(this.maxValueLabel);
            this.channelGroupBox.Controls.Add(this.maximumValueLabel);
            this.channelGroupBox.Controls.Add(this.minValueLabel);
            this.channelGroupBox.Controls.Add(this.minimumLabel);

            this.channelGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.channelGroupBox.Location = new System.Drawing.Point(3, 3);
            this.channelGroupBox.Name = "channelGroupBox";
            this.channelGroupBox.Size = new System.Drawing.Size(156, 159);
            this.channelGroupBox.TabIndex = 0;
            this.channelGroupBox.TabStop = false;
            this.channelGroupBox.Text = "Physical channel";

            // 
            // maxValueLabel
            // 
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.maxValueLabel.ForeColor = System.Drawing.Color.Black;
            this.maxValueLabel.Location = new System.Drawing.Point(88, 106);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(28, 15);
            this.maxValueLabel.TabIndex = 9;
            this.maxValueLabel.Text = "000";
            // 
            // maximumValueLabel
            // 
            this.maximumValueLabel.AutoSize = true;
            this.maximumValueLabel.ForeColor = System.Drawing.Color.Black;
            this.maximumValueLabel.Location = new System.Drawing.Point(9, 106);
            this.maximumValueLabel.Margin = new System.Windows.Forms.Padding(3);
            this.maximumValueLabel.Name = "maximumValueLabel";
            this.maximumValueLabel.Size = new System.Drawing.Size(33, 15);
            this.maximumValueLabel.TabIndex = 8;
            this.maximumValueLabel.Text = "Max:";
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minValueLabel.ForeColor = System.Drawing.Color.Black;
            this.minValueLabel.Location = new System.Drawing.Point(88, 85);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(28, 15);
            this.minValueLabel.TabIndex = 7;
            this.minValueLabel.Text = "000";
            // 
            // minimumLabel
            // 
            this.minimumLabel.AutoSize = true;
            this.minimumLabel.ForeColor = System.Drawing.Color.Black;
            this.minimumLabel.Location = new System.Drawing.Point(9, 85);
            this.minimumLabel.Margin = new System.Windows.Forms.Padding(3);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(31, 15);
            this.minimumLabel.TabIndex = 6;
            this.minimumLabel.Text = "Min:";
            // 
            // ThermocoupleTypeValue
            // 
            this.ThermocoupleTypeValueLabel.AutoSize = true;
            this.ThermocoupleTypeValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ThermocoupleTypeValueLabel.ForeColor = System.Drawing.Color.Black;
            this.ThermocoupleTypeValueLabel.Location = new System.Drawing.Point(88, 64);
            this.ThermocoupleTypeValueLabel.Name = "ThermocoupleTypeValue";
            this.ThermocoupleTypeValueLabel.Size = new System.Drawing.Size(33, 15);
            this.ThermocoupleTypeValueLabel.TabIndex = 5;
            this.ThermocoupleTypeValueLabel.Text = "Type";
            // 
            // ThermocoupleTypeLabel
            // 
            this.ThermocoupleTypeLabel.AutoSize = true;
            this.ThermocoupleTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.ThermocoupleTypeLabel.Location = new System.Drawing.Point(6, 64);
            this.ThermocoupleTypeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ThermocoupleTypeLabel.Name = "ThermocoupleTypeLabel";
            this.ThermocoupleTypeLabel.Size = new System.Drawing.Size(34, 15);
            this.ThermocoupleTypeLabel.TabIndex = 4;
            this.ThermocoupleTypeLabel.Text = "Type:";
            // 
            // PhysicalChannelValueLabel
            // 
            this.PhysicalChannelValueLabel.AutoSize = true;
            this.PhysicalChannelValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PhysicalChannelValueLabel.ForeColor = System.Drawing.Color.Black;
            this.PhysicalChannelValueLabel.Location = new System.Drawing.Point(88, 43);
            this.PhysicalChannelValueLabel.Name = "PhysicalChannelValueLabel";
            this.PhysicalChannelValueLabel.Size = new System.Drawing.Size(51, 15);
            this.PhysicalChannelValueLabel.TabIndex = 3;
            this.PhysicalChannelValueLabel.Text = "Channel";
            // 
            // channelNameLabel
            // 
            this.channelNameLabel.AutoSize = true;
            this.channelNameLabel.ForeColor = System.Drawing.Color.Black;
            this.channelNameLabel.Location = new System.Drawing.Point(6, 43);
            this.channelNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.channelNameLabel.Name = "channelNameLabel";
            this.channelNameLabel.Size = new System.Drawing.Size(54, 15);
            this.channelNameLabel.TabIndex = 2;
            this.channelNameLabel.Text = "Channel:";
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.ForeColor = System.Drawing.Color.Black;
            this.TemperatureLabel.Location = new System.Drawing.Point(6, 22);
            this.TemperatureLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(76, 15);
            this.TemperatureLabel.TabIndex = 1;
            this.TemperatureLabel.Text = "Temperature:";
            // 
            // TemperatureValueLabel
            // 
            this.TemperatureValueLabel.AutoSize = true;
            this.TemperatureValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TemperatureValueLabel.ForeColor = System.Drawing.Color.Black;
            this.TemperatureValueLabel.Location = new System.Drawing.Point(88, 22);
            this.TemperatureValueLabel.Name = "TemperatureValueLabel";
            this.TemperatureValueLabel.Size = new System.Drawing.Size(45, 15);
            this.TemperatureValueLabel.TabIndex = 0;
            this.TemperatureValueLabel.Text = "0.0000";
            // 
            // CJCSourceLabel
            // 
            this.CJCSourceLabel.AutoSize = true;
            this.CJCSourceLabel.ForeColor = System.Drawing.Color.Black;
            this.CJCSourceLabel.Location = new System.Drawing.Point(9, 127);
            this.CJCSourceLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CJCSourceLabel.Name = "CJCSourceLabel";
            this.CJCSourceLabel.Size = new System.Drawing.Size(68, 15);
            this.CJCSourceLabel.TabIndex = 10;
            this.CJCSourceLabel.Text = "CJC source:";
            // 
            // CJCSourceValue
            // 
            this.CJCSourceValueLabel.AutoSize = true;
            this.CJCSourceValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CJCSourceValueLabel.ForeColor = System.Drawing.Color.Black;
            this.CJCSourceValueLabel.Location = new System.Drawing.Point(88, 127);
            this.CJCSourceValueLabel.Name = "CJCSourceValue";
            this.CJCSourceValueLabel.Size = new System.Drawing.Size(16, 15);
            this.CJCSourceValueLabel.TabIndex = 11;
            this.CJCSourceValueLabel.Text = "Q";
        }



        public Label TemperatureValueLabel;
        public Label ThermocoupleTypeValueLabel;
        private Label ThermocoupleTypeLabel;
        public Label PhysicalChannelValueLabel;
        private Label TemperatureLabel;
        private Label channelNameLabel;

        public Label maxValueLabel;
        public Label maximumValueLabel;
        public Label minValueLabel;
        private Label minimumLabel;
        public Label CJCSourceValueLabel;
        private Label CJCSourceLabel;
    }
}
