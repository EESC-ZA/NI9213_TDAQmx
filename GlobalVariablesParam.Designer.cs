namespace NationalInstruments.Examples.ContAcqThermocoupleSamples_IntClk
{
    partial class GlobalVariablesParam
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
            this.globalVariablesGroupBox = new System.Windows.Forms.GroupBox();
            this.highAccuracySettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.autoZeroModeComboBox = new System.Windows.Forms.ComboBox();
            this.scxiModuleLabel = new System.Windows.Forms.Label();
            this.scxiModuleCheckBox = new System.Windows.Forms.CheckBox();
            this.autoZeroModeLabel = new System.Windows.Forms.Label();
            this.coldJunctionParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.cjcValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.cjcValueLabel = new System.Windows.Forms.Label();
            this.cjcChannelLabel = new System.Windows.Forms.Label();
            this.cjcSourceLabel = new System.Windows.Forms.Label();
            this.cjcSourceComboBox = new System.Windows.Forms.ComboBox();
            this.cjcChannelTextBox = new System.Windows.Forms.TextBox();
            this.thermocoupleParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.thermocoupleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.thermocoupleTypeLabel = new System.Windows.Forms.Label();
            this.timingParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.rateNumeric = new System.Windows.Forms.NumericUpDown();
            this.rateLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.globalVariablesGroupBox.SuspendLayout();
            this.highAccuracySettingsGroupBox.SuspendLayout();
            this.coldJunctionParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cjcValueNumeric)).BeginInit();
            this.thermocoupleParametersGroupBox.SuspendLayout();
            this.timingParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // globalVariablesGroupBox
            // 
            this.globalVariablesGroupBox.Controls.Add(this.SubmitButton);
            this.globalVariablesGroupBox.Controls.Add(this.highAccuracySettingsGroupBox);
            this.globalVariablesGroupBox.Controls.Add(this.coldJunctionParametersGroupBox);
            this.globalVariablesGroupBox.Controls.Add(this.thermocoupleParametersGroupBox);
            this.globalVariablesGroupBox.Controls.Add(this.timingParametersGroupBox);
            this.globalVariablesGroupBox.Location = new System.Drawing.Point(12, 9);
            this.globalVariablesGroupBox.Name = "globalVariablesGroupBox";
            this.globalVariablesGroupBox.Size = new System.Drawing.Size(244, 397);
            this.globalVariablesGroupBox.TabIndex = 11;
            this.globalVariablesGroupBox.TabStop = false;
            this.globalVariablesGroupBox.Text = "Global Parameters";
            // 
            // highAccuracySettingsGroupBox
            // 
            this.highAccuracySettingsGroupBox.Controls.Add(this.autoZeroModeComboBox);
            this.highAccuracySettingsGroupBox.Controls.Add(this.scxiModuleLabel);
            this.highAccuracySettingsGroupBox.Controls.Add(this.scxiModuleCheckBox);
            this.highAccuracySettingsGroupBox.Controls.Add(this.autoZeroModeLabel);
            this.highAccuracySettingsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.highAccuracySettingsGroupBox.Location = new System.Drawing.Point(6, 269);
            this.highAccuracySettingsGroupBox.Name = "highAccuracySettingsGroupBox";
            this.highAccuracySettingsGroupBox.Size = new System.Drawing.Size(232, 90);
            this.highAccuracySettingsGroupBox.TabIndex = 6;
            this.highAccuracySettingsGroupBox.TabStop = false;
            this.highAccuracySettingsGroupBox.Text = "High Accuracy Settings";
            // 
            // autoZeroModeComboBox
            // 
            this.autoZeroModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoZeroModeComboBox.Items.AddRange(new object[] {
            "None",
            "Once"});
            this.autoZeroModeComboBox.Location = new System.Drawing.Point(120, 56);
            this.autoZeroModeComboBox.Name = "autoZeroModeComboBox";
            this.autoZeroModeComboBox.Size = new System.Drawing.Size(104, 21);
            this.autoZeroModeComboBox.TabIndex = 3;
            // 
            // scxiModuleLabel
            // 
            this.scxiModuleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.scxiModuleLabel.Location = new System.Drawing.Point(16, 28);
            this.scxiModuleLabel.Name = "scxiModuleLabel";
            this.scxiModuleLabel.Size = new System.Drawing.Size(100, 16);
            this.scxiModuleLabel.TabIndex = 0;
            this.scxiModuleLabel.Text = "SCXI Module?:";
            // 
            // scxiModuleCheckBox
            // 
            this.scxiModuleCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.scxiModuleCheckBox.Location = new System.Drawing.Point(120, 24);
            this.scxiModuleCheckBox.Name = "scxiModuleCheckBox";
            this.scxiModuleCheckBox.Size = new System.Drawing.Size(16, 24);
            this.scxiModuleCheckBox.TabIndex = 1;
            this.scxiModuleCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // autoZeroModeLabel
            // 
            this.autoZeroModeLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.autoZeroModeLabel.Location = new System.Drawing.Point(16, 58);
            this.autoZeroModeLabel.Name = "autoZeroModeLabel";
            this.autoZeroModeLabel.Size = new System.Drawing.Size(88, 16);
            this.autoZeroModeLabel.TabIndex = 2;
            this.autoZeroModeLabel.Text = "Auto Zero Mode:";
            // 
            // coldJunctionParametersGroupBox
            // 
            this.coldJunctionParametersGroupBox.Controls.Add(this.cjcValueNumeric);
            this.coldJunctionParametersGroupBox.Controls.Add(this.cjcValueLabel);
            this.coldJunctionParametersGroupBox.Controls.Add(this.cjcChannelLabel);
            this.coldJunctionParametersGroupBox.Controls.Add(this.cjcSourceLabel);
            this.coldJunctionParametersGroupBox.Controls.Add(this.cjcSourceComboBox);
            this.coldJunctionParametersGroupBox.Controls.Add(this.cjcChannelTextBox);
            this.coldJunctionParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coldJunctionParametersGroupBox.Location = new System.Drawing.Point(6, 143);
            this.coldJunctionParametersGroupBox.Name = "coldJunctionParametersGroupBox";
            this.coldJunctionParametersGroupBox.Size = new System.Drawing.Size(232, 120);
            this.coldJunctionParametersGroupBox.TabIndex = 5;
            this.coldJunctionParametersGroupBox.TabStop = false;
            this.coldJunctionParametersGroupBox.Text = "Cold Junction Parameters";
            // 
            // cjcValueNumeric
            // 
            this.cjcValueNumeric.DecimalPlaces = 2;
            this.cjcValueNumeric.Location = new System.Drawing.Point(120, 88);
            this.cjcValueNumeric.Name = "cjcValueNumeric";
            this.cjcValueNumeric.Size = new System.Drawing.Size(104, 20);
            this.cjcValueNumeric.TabIndex = 5;
            this.cjcValueNumeric.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // cjcValueLabel
            // 
            this.cjcValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cjcValueLabel.Location = new System.Drawing.Point(16, 90);
            this.cjcValueLabel.Name = "cjcValueLabel";
            this.cjcValueLabel.Size = new System.Drawing.Size(104, 16);
            this.cjcValueLabel.TabIndex = 4;
            this.cjcValueLabel.Text = "CJC Value (deg C):";
            // 
            // cjcChannelLabel
            // 
            this.cjcChannelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cjcChannelLabel.Location = new System.Drawing.Point(16, 58);
            this.cjcChannelLabel.Name = "cjcChannelLabel";
            this.cjcChannelLabel.Size = new System.Drawing.Size(80, 16);
            this.cjcChannelLabel.TabIndex = 2;
            this.cjcChannelLabel.Text = "CJC Channel:";
            // 
            // cjcSourceLabel
            // 
            this.cjcSourceLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cjcSourceLabel.Location = new System.Drawing.Point(16, 26);
            this.cjcSourceLabel.Name = "cjcSourceLabel";
            this.cjcSourceLabel.Size = new System.Drawing.Size(88, 16);
            this.cjcSourceLabel.TabIndex = 0;
            this.cjcSourceLabel.Text = "CJC Source:";
            // 
            // cjcSourceComboBox
            // 
            this.cjcSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cjcSourceComboBox.Items.AddRange(new object[] {
            "Channel",
            "Constant Value",
            "Internal"});
            this.cjcSourceComboBox.Location = new System.Drawing.Point(120, 24);
            this.cjcSourceComboBox.Name = "cjcSourceComboBox";
            this.cjcSourceComboBox.Size = new System.Drawing.Size(104, 21);
            this.cjcSourceComboBox.TabIndex = 1;
            // 
            // cjcChannelTextBox
            // 
            this.cjcChannelTextBox.Location = new System.Drawing.Point(120, 56);
            this.cjcChannelTextBox.Name = "cjcChannelTextBox";
            this.cjcChannelTextBox.Size = new System.Drawing.Size(104, 20);
            this.cjcChannelTextBox.TabIndex = 3;
            // 
            // thermocoupleParametersGroupBox
            // 
            this.thermocoupleParametersGroupBox.Controls.Add(this.thermocoupleTypeComboBox);
            this.thermocoupleParametersGroupBox.Controls.Add(this.thermocoupleTypeLabel);
            this.thermocoupleParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.thermocoupleParametersGroupBox.Location = new System.Drawing.Point(6, 81);
            this.thermocoupleParametersGroupBox.Name = "thermocoupleParametersGroupBox";
            this.thermocoupleParametersGroupBox.Size = new System.Drawing.Size(232, 56);
            this.thermocoupleParametersGroupBox.TabIndex = 4;
            this.thermocoupleParametersGroupBox.TabStop = false;
            this.thermocoupleParametersGroupBox.Text = "Thermocouple Parameters";
            // 
            // thermocoupleTypeComboBox
            // 
            this.thermocoupleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thermocoupleTypeComboBox.Items.AddRange(new object[] {
            "B",
            "E",
            "J",
            "K",
            "N",
            "R",
            "S",
            "T"});
            this.thermocoupleTypeComboBox.Location = new System.Drawing.Point(120, 24);
            this.thermocoupleTypeComboBox.Name = "thermocoupleTypeComboBox";
            this.thermocoupleTypeComboBox.Size = new System.Drawing.Size(104, 21);
            this.thermocoupleTypeComboBox.TabIndex = 1;
            // 
            // thermocoupleTypeLabel
            // 
            this.thermocoupleTypeLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.thermocoupleTypeLabel.Location = new System.Drawing.Point(16, 26);
            this.thermocoupleTypeLabel.Name = "thermocoupleTypeLabel";
            this.thermocoupleTypeLabel.Size = new System.Drawing.Size(112, 16);
            this.thermocoupleTypeLabel.TabIndex = 0;
            this.thermocoupleTypeLabel.Text = "Thermocouple Type:";
            // 
            // timingParametersGroupBox
            // 
            this.timingParametersGroupBox.Controls.Add(this.rateNumeric);
            this.timingParametersGroupBox.Controls.Add(this.rateLabel);
            this.timingParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingParametersGroupBox.Location = new System.Drawing.Point(6, 19);
            this.timingParametersGroupBox.Name = "timingParametersGroupBox";
            this.timingParametersGroupBox.Size = new System.Drawing.Size(232, 56);
            this.timingParametersGroupBox.TabIndex = 3;
            this.timingParametersGroupBox.TabStop = false;
            this.timingParametersGroupBox.Text = "Timing Parameters";
            // 
            // rateNumeric
            // 
            this.rateNumeric.DecimalPlaces = 2;
            this.rateNumeric.Location = new System.Drawing.Point(120, 24);
            this.rateNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.rateNumeric.Name = "rateNumeric";
            this.rateNumeric.Size = new System.Drawing.Size(104, 20);
            this.rateNumeric.TabIndex = 1;
            this.rateNumeric.Value = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            // 
            // rateLabel
            // 
            this.rateLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rateLabel.Location = new System.Drawing.Point(16, 26);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(56, 16);
            this.rateLabel.TabIndex = 0;
            this.rateLabel.Text = "Rate (Hz):";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(84, 365);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 7;
            this.SubmitButton.Text = "Done";
            this.SubmitButton.UseVisualStyleBackColor = true;
            // 
            // GlobalVariablesParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 418);
            this.Controls.Add(this.globalVariablesGroupBox);
            this.Name = "GlobalVariablesParam";
            this.Text = "GlobalVariablesParam";
            this.globalVariablesGroupBox.ResumeLayout(false);
            this.highAccuracySettingsGroupBox.ResumeLayout(false);
            this.coldJunctionParametersGroupBox.ResumeLayout(false);
            this.coldJunctionParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cjcValueNumeric)).EndInit();
            this.thermocoupleParametersGroupBox.ResumeLayout(false);
            this.timingParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox globalVariablesGroupBox;
        public System.Windows.Forms.Button SubmitButton;
        internal System.Windows.Forms.GroupBox highAccuracySettingsGroupBox;
        public System.Windows.Forms.ComboBox autoZeroModeComboBox;
        internal System.Windows.Forms.Label scxiModuleLabel;
        public System.Windows.Forms.CheckBox scxiModuleCheckBox;
        internal System.Windows.Forms.Label autoZeroModeLabel;
        internal System.Windows.Forms.GroupBox coldJunctionParametersGroupBox;
        public System.Windows.Forms.NumericUpDown cjcValueNumeric;
        internal System.Windows.Forms.Label cjcValueLabel;
        internal System.Windows.Forms.Label cjcChannelLabel;
        internal System.Windows.Forms.Label cjcSourceLabel;
        public System.Windows.Forms.ComboBox cjcSourceComboBox;
        public System.Windows.Forms.TextBox cjcChannelTextBox;
        internal System.Windows.Forms.GroupBox thermocoupleParametersGroupBox;
        public System.Windows.Forms.ComboBox thermocoupleTypeComboBox;
        internal System.Windows.Forms.Label thermocoupleTypeLabel;
        internal System.Windows.Forms.GroupBox timingParametersGroupBox;
        public System.Windows.Forms.NumericUpDown rateNumeric;
        internal System.Windows.Forms.Label rateLabel;
    }
}