using NationalInstruments.DAQmx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NationalInstruments.Examples.ContAcqThermocoupleSamples_IntClk
{
    public partial class NewChannelForm : Form
    {
        private Button button1;
        string[] AIchannels;
        public NewChannelForm( )
        {
            InitializeComponent();

            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External));
            if (physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 0;
            else
            {
                MessageBox.Show("physical Channels found\n");
            }

        }
        private void InitializeComponent()
        {
            this.channelPrarametersGroupBox = new System.Windows.Forms.GroupBox();
            this.channelNameTextBox = new System.Windows.Forms.TextBox();
            this.channelNameLabel = new System.Windows.Forms.Label();
            this.minimumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.maximumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.addChannelButton = new System.Windows.Forms.Button();
            this.channelPrarametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // channelPrarametersGroupBox
            // 
            this.channelPrarametersGroupBox.Controls.Add(this.channelNameTextBox);
            this.channelPrarametersGroupBox.Controls.Add(this.channelNameLabel);
            this.channelPrarametersGroupBox.Controls.Add(this.minimumValueNumeric);
            this.channelPrarametersGroupBox.Controls.Add(this.minimumLabel);
            this.channelPrarametersGroupBox.Controls.Add(this.maximumValueNumeric);
            this.channelPrarametersGroupBox.Controls.Add(this.maximumLabel);
            this.channelPrarametersGroupBox.Controls.Add(this.physicalChannelComboBox);
            this.channelPrarametersGroupBox.Controls.Add(this.physicalChannelLabel);
            this.channelPrarametersGroupBox.Location = new System.Drawing.Point(10, 10);
            this.channelPrarametersGroupBox.Name = "channelPrarametersGroupBox";
            this.channelPrarametersGroupBox.Size = new System.Drawing.Size(250, 160);
            this.channelPrarametersGroupBox.TabIndex = 0;
            this.channelPrarametersGroupBox.TabStop = false;
            this.channelPrarametersGroupBox.Text = "Channel Parameters";
            // 
            // channelNameTextBox
            // 
            this.channelNameTextBox.Location = new System.Drawing.Point(119, 104);
            this.channelNameTextBox.Name = "channelNameTextBox";
            this.channelNameTextBox.Size = new System.Drawing.Size(126, 20);
            this.channelNameTextBox.TabIndex = 7;
            // 
            // channelNameLabel
            // 
            this.channelNameLabel.AutoSize = true;
            this.channelNameLabel.Location = new System.Drawing.Point(15, 107);
            this.channelNameLabel.Name = "channelNameLabel";
            this.channelNameLabel.Size = new System.Drawing.Size(80, 13);
            this.channelNameLabel.TabIndex = 6;
            this.channelNameLabel.Text = "Channel Name:";
            // 
            // minimumValueNumeric
            // 
            this.minimumValueNumeric.Location = new System.Drawing.Point(120, 74);
            this.minimumValueNumeric.Name = "minimumValueNumeric";
            this.minimumValueNumeric.Size = new System.Drawing.Size(125, 20);
            this.minimumValueNumeric.TabIndex = 5;
            // 
            // minimumLabel
            // 
            this.minimumLabel.AutoSize = true;
            this.minimumLabel.Location = new System.Drawing.Point(15, 75);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(88, 13);
            this.minimumLabel.TabIndex = 4;
            this.minimumLabel.Text = "Minimum (deg C):";
            // 
            // maximumValueNumeric
            // 
            this.maximumValueNumeric.Location = new System.Drawing.Point(120, 44);
            this.maximumValueNumeric.Name = "maximumValueNumeric";
            this.maximumValueNumeric.Size = new System.Drawing.Size(125, 20);
            this.maximumValueNumeric.TabIndex = 3;
            this.maximumValueNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // maximumLabel
            // 
            this.maximumLabel.AutoSize = true;
            this.maximumLabel.Location = new System.Drawing.Point(15, 47);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(91, 13);
            this.maximumLabel.TabIndex = 2;
            this.maximumLabel.Text = "Maximum (deg C):";
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.FormattingEnabled = true;
            this.physicalChannelComboBox.Location = new System.Drawing.Point(119, 19);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(127, 21);
            this.physicalChannelComboBox.TabIndex = 1;
            this.physicalChannelComboBox.Text = "Select channel";
            // 
            // physicalChannelLabel
            // 
            this.physicalChannelLabel.AutoSize = true;
            this.physicalChannelLabel.Location = new System.Drawing.Point(15, 22);
            this.physicalChannelLabel.Name = "physicalChannelLabel";
            this.physicalChannelLabel.Size = new System.Drawing.Size(91, 13);
            this.physicalChannelLabel.TabIndex = 0;
            this.physicalChannelLabel.Text = "Physical Channel:";
            // 
            // addChannelButton
            // 
            this.addChannelButton.Location = new System.Drawing.Point(89, 176);
            this.addChannelButton.Name = "addChannelButton";
            this.addChannelButton.Size = new System.Drawing.Size(84, 20);
            this.addChannelButton.TabIndex = 4;
            this.addChannelButton.Text = "Add Channel";
            this.addChannelButton.UseVisualStyleBackColor = true;
            // 
            // NewChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 206);
            this.Controls.Add(this.addChannelButton);
            this.Controls.Add(this.channelPrarametersGroupBox);
            this.Name = "NewChannelForm";
            this.Text = "New Channel";
            this.channelPrarametersGroupBox.ResumeLayout(false);
            this.channelPrarametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        private GroupBox channelPrarametersGroupBox;
        public NumericUpDown minimumValueNumeric;
        private Label minimumLabel;
        public NumericUpDown maximumValueNumeric;
        private Label maximumLabel;
        public ComboBox physicalChannelComboBox;
        private Label physicalChannelLabel;
        public Button addChannelButton;
        public TextBox channelNameTextBox;
        private Label channelNameLabel;

    }
}
