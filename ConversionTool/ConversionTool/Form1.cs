using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using System.Diagnostics;

namespace ConversionTool
{
    public partial class ConversionTool : Form
    {
        public ConversionTool()
        {
            InitializeComponent();
        }

        private void ConversionTool_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// TAB1: This is solely for convert lengths
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LengthConvert_Click(object sender, EventArgs e)
        {
            // When clicked, use the selected item as default ratio
            StaticVariables metric = new StaticVariables();
            double input1 = (double)LengthInputBox1.Value;
            double input2 = (double)LengthInputBox2.Value;

            LengthOutput1.Text = metric.getValue(input1, input2,
                LengthSelect1.Text, LengthSelect2.Text, LengthBox1.Text);

            LengthOutput2.Text = metric.getValue(input1, input2,
                LengthSelect1.Text, LengthSelect2.Text, LengthBox2.Text);

            LengthOutput3.Text = metric.getValue(input1, input2,
                LengthSelect1.Text, LengthSelect2.Text, LengthBox3.Text);

            LengthOutput4.Text = metric.getValue(input1, input2,
                LengthSelect1.Text, LengthSelect2.Text, LengthBox4.Text);

            LengthOutput5.Text = metric.getValue(input1, input2,
                LengthSelect1.Text, LengthSelect2.Text, LengthBox5.Text);

            LengthOutput6.Text = metric.getValue(input1, input2,
                LengthSelect1.Text, LengthSelect2.Text, LengthBox6.Text);
            
        }

        private void LengthSelect1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LengthSelect1.Text != "" || LengthSelect2.Text != "")
            {
                LengthConvert.Enabled = true;
            }
            else
            {
                LengthConvert.Enabled = false;
            }
        }

        private void LengthSelect2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LengthSelect2.Text != "" || LengthSelect1.Text != "")
            {
                LengthConvert.Enabled = true;
            }
            else
            {
                LengthConvert.Enabled = false;
            }
        }

        private void LengthCopyButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(readHelper());
            MessageBox.Show("Successfully copied to clipboard.");
        }

        private void FileSaveButton_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + 
                "/Length Metric Conversion.txt");
            file.WriteLine(readHelper());
            file.Close();
            MessageBox.Show("File has been saved to current directory.");
        }

        private string readHelper()
        {
            string result = "";

            for (int i = 1; i < 3; i++)
            {
                string unit = ((ComboBox)this.GetType().GetField("LengthSelect" + i,
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this)).Text;
                string input = ((NumericUpDown)this.GetType().GetField("LengthInputBox" + i,
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this)).Text;

                if (unit != "")
                {
                    result += input + " " + unit + "\r\n";
                }
            }

            result += "=\r\n";

            for (int i = 1; i < 7; i++)
            {
                string unit = ((ComboBox)this.GetType().GetField("LengthBox" + i,
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this)).Text;
                string output = ((TextBox)this.GetType().GetField("LengthOutput" + i,
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this)).Text;

                if (unit != "")
                {
                    result += output + " " + unit + "\r\n";
                }
            }

            return result;
        }
    }

    public class StaticVariables
    {
        // Length Variables
        double mm = 1000000, cm = 100000, m = 1000, km = 1, 
            mi = 0.62137, ft = 3280.84, inch = 39370.1, yd = 1093.61;

        // Digital Size Variables
        double b = 8, B = 1, KB = 1024, MB = 1048576, GB = 1073741824.0005517,
            TB = 1099511627775.9133, PB = 1125899906842782.8;

        public string getValue(double i1, double i2, string m1, string m2, string m3)
        {
            if (m1 != "" && m2 != "" && m3 != "")
            {
                return (i1 * getRatio(m1, m3) + i2 * getRatio(m2, m3)).ToString();
            }
            else if (m1 != "" && m2 == "" && m3 != "")
            {
                return (i1 * getRatio(m1, m3)).ToString();
            }
            else if (m1 == "" && m2 != "" && m3 != "")
            {
                return (i2 * getRatio(m2, m3)).ToString();
            }
            else
            {
                return "";
            }
            
        }

        public double getRatio(string m1, string m2)
        {
            double v1 = (double) this.GetType().GetField(m1,
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            double v2 = (double) this.GetType().GetField(m2,
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            return v2 / v1;
        }
    }
}