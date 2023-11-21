using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NationalInstruments.Examples.ContAcqThermocoupleSamples_IntClk
{
    public partial class GlobalVariablesParam : Form
    {
        public System.Windows.Forms.ComboBox getAutoZeroModeComboBox() { return autoZeroModeComboBox; }
        public System.Windows.Forms.CheckBox getscxiModuleCheckBox() { return scxiModuleCheckBox; }
        public System.Windows.Forms.NumericUpDown getcjcValueNumeric() { return cjcValueNumeric; }
        public System.Windows.Forms.Label getcjcValueLabel() { return cjcValueLabel; }
        public System.Windows.Forms.ComboBox getcjcSourceComboBox(){ return cjcSourceComboBox;}
        public System.Windows.Forms.TextBox getcjcChannelTextBox() { return cjcChannelTextBox; }
        public System.Windows.Forms.ComboBox getthermocoupleTypeComboBox() { return thermocoupleTypeComboBox; }
        public System.Windows.Forms.NumericUpDown getrateNumeric() { return rateNumeric; }

        public GlobalVariablesParam()
        {
            InitializeComponent();
        }
    }
}
