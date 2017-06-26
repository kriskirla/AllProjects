using System;

namespace ChakBot
{
    partial class Form1
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
            this.OutputChat = new System.Windows.Forms.RichTextBox();
            this.InputChat = new System.Windows.Forms.RichTextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TypingDisplay = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutputChat
            // 
            this.OutputChat.BackColor = System.Drawing.Color.Black;
            this.OutputChat.ForeColor = System.Drawing.Color.White;
            this.OutputChat.Location = new System.Drawing.Point(12, 12);
            this.OutputChat.Name = "OutputChat";
            this.OutputChat.ReadOnly = true;
            this.OutputChat.Size = new System.Drawing.Size(329, 439);
            this.OutputChat.TabIndex = 0;
            this.OutputChat.Text = "";
            this.OutputChat.TextChanged += new System.EventHandler(this.OutputChat_TextChanged);
            // 
            // InputChat
            // 
            this.InputChat.BackColor = System.Drawing.Color.Black;
            this.InputChat.EnableAutoDragDrop = true;
            this.InputChat.ForeColor = System.Drawing.Color.White;
            this.InputChat.Location = new System.Drawing.Point(12, 457);
            this.InputChat.Name = "InputChat";
            this.InputChat.Size = new System.Drawing.Size(329, 61);
            this.InputChat.TabIndex = 1;
            this.InputChat.Text = "";
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.SlateGray;
            this.Enter.ForeColor = System.Drawing.Color.White;
            this.Enter.Location = new System.Drawing.Point(266, 524);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 23);
            this.Enter.TabIndex = 2;
            this.Enter.Text = "Send";
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "All Rights Reserved";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Copyright (c) 2017 Kris Lai";
            // 
            // TypingDisplay
            // 
            this.TypingDisplay.BackColor = System.Drawing.Color.Black;
            this.TypingDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypingDisplay.ForeColor = System.Drawing.Color.White;
            this.TypingDisplay.Location = new System.Drawing.Point(15, 436);
            this.TypingDisplay.Name = "TypingDisplay";
            this.TypingDisplay.Size = new System.Drawing.Size(300, 13);
            this.TypingDisplay.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.SlateGray;
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(145, 524);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(115, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save Message";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(353, 553);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TypingDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.InputChat);
            this.Controls.Add(this.OutputChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ChakBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputChat;
        private System.Windows.Forms.RichTextBox InputChat;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TypingDisplay;
        private System.Windows.Forms.Button SaveButton;
    }
}

