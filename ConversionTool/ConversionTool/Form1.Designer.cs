namespace ConversionTool
{
    partial class ConversionTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Length = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.LengthSelect2 = new System.Windows.Forms.ComboBox();
            this.LengthInputBox2 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LengthInputBox1 = new System.Windows.Forms.NumericUpDown();
            this.FileSaveButton = new System.Windows.Forms.Button();
            this.LengthCopyButton = new System.Windows.Forms.Button();
            this.LengthSelect1 = new System.Windows.Forms.ComboBox();
            this.LengthConvert = new System.Windows.Forms.Button();
            this.ConversionGroup = new System.Windows.Forms.GroupBox();
            this.LengthOutput6 = new System.Windows.Forms.TextBox();
            this.LengthOutput5 = new System.Windows.Forms.TextBox();
            this.LengthOutput4 = new System.Windows.Forms.TextBox();
            this.LengthOutput3 = new System.Windows.Forms.TextBox();
            this.LengthOutput2 = new System.Windows.Forms.TextBox();
            this.LengthOutput1 = new System.Windows.Forms.TextBox();
            this.LengthBox6 = new System.Windows.Forms.ComboBox();
            this.LengthBox5 = new System.Windows.Forms.ComboBox();
            this.LengthBox4 = new System.Windows.Forms.ComboBox();
            this.LengthBox3 = new System.Windows.Forms.ComboBox();
            this.LengthBox2 = new System.Windows.Forms.ComboBox();
            this.LengthBox1 = new System.Windows.Forms.ComboBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Length.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LengthInputBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthInputBox1)).BeginInit();
            this.ConversionGroup.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copyright (c) 2017 Kris Lai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "All Rights Reserved";
            // 
            // Length
            // 
            this.Length.BackColor = System.Drawing.Color.LightGray;
            this.Length.Controls.Add(this.label3);
            this.Length.Controls.Add(this.LengthSelect2);
            this.Length.Controls.Add(this.LengthInputBox2);
            this.Length.Controls.Add(this.textBox1);
            this.Length.Controls.Add(this.LengthInputBox1);
            this.Length.Controls.Add(this.FileSaveButton);
            this.Length.Controls.Add(this.LengthCopyButton);
            this.Length.Controls.Add(this.LengthSelect1);
            this.Length.Controls.Add(this.LengthConvert);
            this.Length.Controls.Add(this.ConversionGroup);
            this.Length.Location = new System.Drawing.Point(4, 22);
            this.Length.Name = "Length";
            this.Length.Padding = new System.Windows.Forms.Padding(3);
            this.Length.Size = new System.Drawing.Size(318, 325);
            this.Length.TabIndex = 0;
            this.Length.Text = "Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "+";
            // 
            // LengthSelect2
            // 
            this.LengthSelect2.FormattingEnabled = true;
            this.LengthSelect2.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthSelect2.Location = new System.Drawing.Point(163, 62);
            this.LengthSelect2.Name = "LengthSelect2";
            this.LengthSelect2.Size = new System.Drawing.Size(67, 21);
            this.LengthSelect2.TabIndex = 8;
            this.LengthSelect2.SelectedIndexChanged += new System.EventHandler(this.LengthSelect2_SelectedIndexChanged);
            // 
            // LengthInputBox2
            // 
            this.LengthInputBox2.DecimalPlaces = 3;
            this.LengthInputBox2.Location = new System.Drawing.Point(134, 36);
            this.LengthInputBox2.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.LengthInputBox2.Name = "LengthInputBox2";
            this.LengthInputBox2.Size = new System.Drawing.Size(96, 20);
            this.LengthInputBox2.TabIndex = 7;
            this.LengthInputBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(40, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Length Metric Conversion";
            // 
            // LengthInputBox1
            // 
            this.LengthInputBox1.DecimalPlaces = 3;
            this.LengthInputBox1.Location = new System.Drawing.Point(11, 36);
            this.LengthInputBox1.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.LengthInputBox1.Name = "LengthInputBox1";
            this.LengthInputBox1.Size = new System.Drawing.Size(96, 20);
            this.LengthInputBox1.TabIndex = 5;
            this.LengthInputBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LengthInputBox1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FileSaveButton
            // 
            this.FileSaveButton.Location = new System.Drawing.Point(163, 293);
            this.FileSaveButton.Name = "FileSaveButton";
            this.FileSaveButton.Size = new System.Drawing.Size(137, 23);
            this.FileSaveButton.TabIndex = 4;
            this.FileSaveButton.Text = "Save results to file";
            this.FileSaveButton.UseVisualStyleBackColor = true;
            this.FileSaveButton.Click += new System.EventHandler(this.FileSaveButton_Click);
            // 
            // LengthCopyButton
            // 
            this.LengthCopyButton.Location = new System.Drawing.Point(20, 293);
            this.LengthCopyButton.Name = "LengthCopyButton";
            this.LengthCopyButton.Size = new System.Drawing.Size(137, 23);
            this.LengthCopyButton.TabIndex = 3;
            this.LengthCopyButton.Text = "Copy to Clipboard";
            this.LengthCopyButton.UseVisualStyleBackColor = true;
            // 
            // LengthSelect1
            // 
            this.LengthSelect1.FormattingEnabled = true;
            this.LengthSelect1.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthSelect1.Location = new System.Drawing.Point(40, 62);
            this.LengthSelect1.Name = "LengthSelect1";
            this.LengthSelect1.Size = new System.Drawing.Size(67, 21);
            this.LengthSelect1.TabIndex = 1;
            this.LengthSelect1.SelectedIndexChanged += new System.EventHandler(this.LengthSelect1_SelectedIndexChanged);
            // 
            // LengthConvert
            // 
            this.LengthConvert.Enabled = false;
            this.LengthConvert.Location = new System.Drawing.Point(240, 49);
            this.LengthConvert.Name = "LengthConvert";
            this.LengthConvert.Size = new System.Drawing.Size(75, 23);
            this.LengthConvert.TabIndex = 1;
            this.LengthConvert.Text = "Convert";
            this.LengthConvert.UseVisualStyleBackColor = true;
            this.LengthConvert.Click += new System.EventHandler(this.LengthConvert_Click);
            // 
            // ConversionGroup
            // 
            this.ConversionGroup.Controls.Add(this.LengthOutput6);
            this.ConversionGroup.Controls.Add(this.LengthOutput5);
            this.ConversionGroup.Controls.Add(this.LengthOutput4);
            this.ConversionGroup.Controls.Add(this.LengthOutput3);
            this.ConversionGroup.Controls.Add(this.LengthOutput2);
            this.ConversionGroup.Controls.Add(this.LengthOutput1);
            this.ConversionGroup.Controls.Add(this.LengthBox6);
            this.ConversionGroup.Controls.Add(this.LengthBox5);
            this.ConversionGroup.Controls.Add(this.LengthBox4);
            this.ConversionGroup.Controls.Add(this.LengthBox3);
            this.ConversionGroup.Controls.Add(this.LengthBox2);
            this.ConversionGroup.Controls.Add(this.LengthBox1);
            this.ConversionGroup.Location = new System.Drawing.Point(5, 92);
            this.ConversionGroup.Name = "ConversionGroup";
            this.ConversionGroup.Size = new System.Drawing.Size(306, 195);
            this.ConversionGroup.TabIndex = 2;
            this.ConversionGroup.TabStop = false;
            this.ConversionGroup.Text = "Conversion";
            // 
            // LengthOutput6
            // 
            this.LengthOutput6.Enabled = false;
            this.LengthOutput6.Location = new System.Drawing.Point(6, 160);
            this.LengthOutput6.Name = "LengthOutput6";
            this.LengthOutput6.Size = new System.Drawing.Size(216, 20);
            this.LengthOutput6.TabIndex = 18;
            this.LengthOutput6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LengthOutput5
            // 
            this.LengthOutput5.Enabled = false;
            this.LengthOutput5.Location = new System.Drawing.Point(6, 134);
            this.LengthOutput5.Name = "LengthOutput5";
            this.LengthOutput5.Size = new System.Drawing.Size(216, 20);
            this.LengthOutput5.TabIndex = 17;
            this.LengthOutput5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LengthOutput4
            // 
            this.LengthOutput4.Enabled = false;
            this.LengthOutput4.Location = new System.Drawing.Point(6, 109);
            this.LengthOutput4.Name = "LengthOutput4";
            this.LengthOutput4.Size = new System.Drawing.Size(216, 20);
            this.LengthOutput4.TabIndex = 16;
            this.LengthOutput4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LengthOutput3
            // 
            this.LengthOutput3.Enabled = false;
            this.LengthOutput3.Location = new System.Drawing.Point(6, 82);
            this.LengthOutput3.Name = "LengthOutput3";
            this.LengthOutput3.Size = new System.Drawing.Size(216, 20);
            this.LengthOutput3.TabIndex = 15;
            this.LengthOutput3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LengthOutput2
            // 
            this.LengthOutput2.Enabled = false;
            this.LengthOutput2.Location = new System.Drawing.Point(6, 56);
            this.LengthOutput2.Name = "LengthOutput2";
            this.LengthOutput2.Size = new System.Drawing.Size(216, 20);
            this.LengthOutput2.TabIndex = 14;
            this.LengthOutput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LengthOutput1
            // 
            this.LengthOutput1.BackColor = System.Drawing.SystemColors.Window;
            this.LengthOutput1.Enabled = false;
            this.LengthOutput1.Location = new System.Drawing.Point(6, 30);
            this.LengthOutput1.Name = "LengthOutput1";
            this.LengthOutput1.Size = new System.Drawing.Size(216, 20);
            this.LengthOutput1.TabIndex = 13;
            this.LengthOutput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LengthBox6
            // 
            this.LengthBox6.FormattingEnabled = true;
            this.LengthBox6.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthBox6.Location = new System.Drawing.Point(233, 160);
            this.LengthBox6.Name = "LengthBox6";
            this.LengthBox6.Size = new System.Drawing.Size(67, 21);
            this.LengthBox6.TabIndex = 12;
            // 
            // LengthBox5
            // 
            this.LengthBox5.FormattingEnabled = true;
            this.LengthBox5.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthBox5.Location = new System.Drawing.Point(233, 134);
            this.LengthBox5.Name = "LengthBox5";
            this.LengthBox5.Size = new System.Drawing.Size(67, 21);
            this.LengthBox5.TabIndex = 11;
            // 
            // LengthBox4
            // 
            this.LengthBox4.FormattingEnabled = true;
            this.LengthBox4.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthBox4.Location = new System.Drawing.Point(233, 109);
            this.LengthBox4.Name = "LengthBox4";
            this.LengthBox4.Size = new System.Drawing.Size(67, 21);
            this.LengthBox4.TabIndex = 10;
            // 
            // LengthBox3
            // 
            this.LengthBox3.FormattingEnabled = true;
            this.LengthBox3.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthBox3.Location = new System.Drawing.Point(233, 82);
            this.LengthBox3.Name = "LengthBox3";
            this.LengthBox3.Size = new System.Drawing.Size(67, 21);
            this.LengthBox3.TabIndex = 6;
            // 
            // LengthBox2
            // 
            this.LengthBox2.FormattingEnabled = true;
            this.LengthBox2.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthBox2.Location = new System.Drawing.Point(233, 56);
            this.LengthBox2.Name = "LengthBox2";
            this.LengthBox2.Size = new System.Drawing.Size(67, 21);
            this.LengthBox2.TabIndex = 5;
            // 
            // LengthBox1
            // 
            this.LengthBox1.FormattingEnabled = true;
            this.LengthBox1.Items.AddRange(new object[] {
            "",
            "mm",
            "cm",
            "m",
            "km",
            "mi",
            "ft",
            "inch",
            "yd"});
            this.LengthBox1.Location = new System.Drawing.Point(233, 30);
            this.LengthBox1.Name = "LengthBox1";
            this.LengthBox1.Size = new System.Drawing.Size(67, 21);
            this.LengthBox1.TabIndex = 2;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Length);
            this.Tabs.Location = new System.Drawing.Point(3, 3);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(326, 351);
            this.Tabs.TabIndex = 0;
            // 
            // ConversionTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(332, 387);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tabs);
            this.MaximizeBox = false;
            this.Name = "ConversionTool";
            this.Text = "Conversion Tool";
            this.Load += new System.EventHandler(this.ConversionTool_Load);
            this.Length.ResumeLayout(false);
            this.Length.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LengthInputBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthInputBox1)).EndInit();
            this.ConversionGroup.ResumeLayout(false);
            this.ConversionGroup.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage Length;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox LengthSelect2;
        private System.Windows.Forms.NumericUpDown LengthInputBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown LengthInputBox1;
        private System.Windows.Forms.Button FileSaveButton;
        private System.Windows.Forms.Button LengthCopyButton;
        private System.Windows.Forms.ComboBox LengthSelect1;
        private System.Windows.Forms.Button LengthConvert;
        private System.Windows.Forms.GroupBox ConversionGroup;
        private System.Windows.Forms.TextBox LengthOutput6;
        private System.Windows.Forms.TextBox LengthOutput5;
        private System.Windows.Forms.TextBox LengthOutput4;
        private System.Windows.Forms.TextBox LengthOutput3;
        private System.Windows.Forms.TextBox LengthOutput2;
        private System.Windows.Forms.TextBox LengthOutput1;
        private System.Windows.Forms.ComboBox LengthBox6;
        private System.Windows.Forms.ComboBox LengthBox5;
        private System.Windows.Forms.ComboBox LengthBox4;
        private System.Windows.Forms.ComboBox LengthBox3;
        private System.Windows.Forms.ComboBox LengthBox2;
        private System.Windows.Forms.ComboBox LengthBox1;
        private System.Windows.Forms.TabControl Tabs;
    }
}

