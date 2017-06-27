using System;
using System.ComponentModel;

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
            this.components = new System.ComponentModel.Container();
            this.OutputChat = new System.Windows.Forms.RichTextBox();
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RCShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayTime = new System.Windows.Forms.ToolStripMenuItem();
            this.Calculator = new System.Windows.Forms.ToolStripMenuItem();
            this.UnitConverter = new System.Windows.Forms.ToolStripMenuItem();
            this.TeachChakbot = new System.Windows.Forms.ToolStripMenuItem();
            this.Encrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.Decrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.TranslateMorse = new System.Windows.Forms.ToolStripMenuItem();
            this.InputChat = new System.Windows.Forms.RichTextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TypingDisplay = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.BarHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.BarClear = new System.Windows.Forms.ToolStripMenuItem();
            this.BarCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.BarConv = new System.Windows.Forms.ToolStripMenuItem();
            this.BarTeach = new System.Windows.Forms.ToolStripMenuItem();
            this.BarEn = new System.Windows.Forms.ToolStripMenuItem();
            this.BarDe = new System.Windows.Forms.ToolStripMenuItem();
            this.BarMorse = new System.Windows.Forms.ToolStripMenuItem();
            this.BarDisplayTime = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputChat
            // 
            this.OutputChat.BackColor = System.Drawing.Color.Black;
            this.OutputChat.ContextMenuStrip = this.RightClick;
            this.OutputChat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OutputChat.ForeColor = System.Drawing.Color.White;
            this.OutputChat.Location = new System.Drawing.Point(4, 24);
            this.OutputChat.Name = "OutputChat";
            this.OutputChat.ReadOnly = true;
            this.OutputChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.OutputChat.Size = new System.Drawing.Size(337, 431);
            this.OutputChat.TabIndex = 0;
            this.OutputChat.Text = "";
            this.OutputChat.TextChanged += new System.EventHandler(this.OutputChat_TextChanged);
            // 
            // RightClick
            // 
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCShortcuts});
            this.RightClick.Name = "RightClick";
            this.RightClick.Size = new System.Drawing.Size(125, 26);
            // 
            // RCShortcuts
            // 
            this.RCShortcuts.BackColor = System.Drawing.Color.LightCyan;
            this.RCShortcuts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenu,
            this.ClearScreen,
            this.DisplayTime,
            this.Calculator,
            this.UnitConverter,
            this.TeachChakbot,
            this.Encrypt,
            this.Decrypt,
            this.TranslateMorse});
            this.RCShortcuts.Name = "RCShortcuts";
            this.RCShortcuts.Size = new System.Drawing.Size(124, 22);
            this.RCShortcuts.Text = "Shortcuts";
            // 
            // HelpMenu
            // 
            this.HelpMenu.BackColor = System.Drawing.Color.LightCyan;
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(189, 22);
            this.HelpMenu.Text = "Help Menu";
            this.HelpMenu.Click += new System.EventHandler(this.HelpMenu_Click);
            // 
            // ClearScreen
            // 
            this.ClearScreen.BackColor = System.Drawing.Color.LightCyan;
            this.ClearScreen.Name = "ClearScreen";
            this.ClearScreen.Size = new System.Drawing.Size(189, 22);
            this.ClearScreen.Text = "Clear Screen";
            this.ClearScreen.Click += new System.EventHandler(this.ClearScreen_Click);
            // 
            // DisplayTime
            // 
            this.DisplayTime.BackColor = System.Drawing.Color.LightCyan;
            this.DisplayTime.Name = "DisplayTime";
            this.DisplayTime.Size = new System.Drawing.Size(189, 22);
            this.DisplayTime.Text = "Display Time";
            this.DisplayTime.Click += new System.EventHandler(this.DisplayTime_Click);
            // 
            // Calculator
            // 
            this.Calculator.BackColor = System.Drawing.Color.LightCyan;
            this.Calculator.Name = "Calculator";
            this.Calculator.Size = new System.Drawing.Size(189, 22);
            this.Calculator.Text = "Calculator";
            this.Calculator.Click += new System.EventHandler(this.Calculator_Click);
            // 
            // UnitConverter
            // 
            this.UnitConverter.BackColor = System.Drawing.Color.LightCyan;
            this.UnitConverter.Name = "UnitConverter";
            this.UnitConverter.Size = new System.Drawing.Size(189, 22);
            this.UnitConverter.Text = "Unit Converter";
            this.UnitConverter.Click += new System.EventHandler(this.UnitConverter_Click);
            // 
            // TeachChakbot
            // 
            this.TeachChakbot.BackColor = System.Drawing.Color.LightCyan;
            this.TeachChakbot.Name = "TeachChakbot";
            this.TeachChakbot.Size = new System.Drawing.Size(189, 22);
            this.TeachChakbot.Text = "Teach Chakbot";
            this.TeachChakbot.Click += new System.EventHandler(this.TeachChakbot_Click);
            // 
            // Encrypt
            // 
            this.Encrypt.BackColor = System.Drawing.Color.LightCyan;
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(189, 22);
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.BackColor = System.Drawing.Color.LightCyan;
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(189, 22);
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // TranslateMorse
            // 
            this.TranslateMorse.BackColor = System.Drawing.Color.LightCyan;
            this.TranslateMorse.Name = "TranslateMorse";
            this.TranslateMorse.Size = new System.Drawing.Size(189, 22);
            this.TranslateMorse.Text = "Translate Morse Code";
            this.TranslateMorse.Click += new System.EventHandler(this.TranslateMorse_Click);
            // 
            // InputChat
            // 
            this.InputChat.BackColor = System.Drawing.Color.Black;
            this.InputChat.ContextMenuStrip = this.RightClick;
            this.InputChat.EnableAutoDragDrop = true;
            this.InputChat.ForeColor = System.Drawing.Color.White;
            this.InputChat.Location = new System.Drawing.Point(4, 459);
            this.InputChat.Name = "InputChat";
            this.InputChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.InputChat.Size = new System.Drawing.Size(337, 61);
            this.InputChat.TabIndex = 1;
            this.InputChat.Text = "";
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.SlateGray;
            this.Enter.ForeColor = System.Drawing.Color.White;
            this.Enter.Location = new System.Drawing.Point(278, 524);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(63, 23);
            this.Enter.TabIndex = 2;
            this.Enter.Text = "Send";
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "All Rights Reserved";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 523);
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
            this.TypingDisplay.Location = new System.Drawing.Point(7, 439);
            this.TypingDisplay.Name = "TypingDisplay";
            this.TypingDisplay.Size = new System.Drawing.Size(316, 13);
            this.TypingDisplay.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.SlateGray;
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(171, 524);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save Message";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.SlateGray;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShortcuts});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(345, 24);
            this.Menu.TabIndex = 11;
            this.Menu.Text = "menuStrip1";
            // 
            // MenuShortcuts
            // 
            this.MenuShortcuts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarHelp,
            this.BarClear,
            this.BarCalc,
            this.BarConv,
            this.BarTeach,
            this.BarEn,
            this.BarDe,
            this.BarMorse,
            this.BarDisplayTime});
            this.MenuShortcuts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuShortcuts.ForeColor = System.Drawing.Color.LightCyan;
            this.MenuShortcuts.Name = "MenuShortcuts";
            this.MenuShortcuts.Size = new System.Drawing.Size(73, 20);
            this.MenuShortcuts.Text = "Shortcuts";
            // 
            // BarHelp
            // 
            this.BarHelp.BackColor = System.Drawing.Color.LightCyan;
            this.BarHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarHelp.Name = "BarHelp";
            this.BarHelp.Size = new System.Drawing.Size(189, 22);
            this.BarHelp.Text = "Help Menu";
            this.BarHelp.Click += new System.EventHandler(this.BarHelp_Click);
            // 
            // BarClear
            // 
            this.BarClear.BackColor = System.Drawing.Color.LightCyan;
            this.BarClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarClear.Name = "BarClear";
            this.BarClear.Size = new System.Drawing.Size(189, 22);
            this.BarClear.Text = "Clear Screen";
            this.BarClear.Click += new System.EventHandler(this.BarClear_Click);
            // 
            // BarCalc
            // 
            this.BarCalc.BackColor = System.Drawing.Color.LightCyan;
            this.BarCalc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarCalc.Name = "BarCalc";
            this.BarCalc.Size = new System.Drawing.Size(189, 22);
            this.BarCalc.Text = "Calculator";
            this.BarCalc.Click += new System.EventHandler(this.BarCalc_Click);
            // 
            // BarConv
            // 
            this.BarConv.BackColor = System.Drawing.Color.LightCyan;
            this.BarConv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarConv.Name = "BarConv";
            this.BarConv.Size = new System.Drawing.Size(189, 22);
            this.BarConv.Text = "Unit Converter";
            this.BarConv.Click += new System.EventHandler(this.BarConv_Click);
            // 
            // BarTeach
            // 
            this.BarTeach.BackColor = System.Drawing.Color.LightCyan;
            this.BarTeach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarTeach.Name = "BarTeach";
            this.BarTeach.Size = new System.Drawing.Size(189, 22);
            this.BarTeach.Text = "Teach Chakbot";
            this.BarTeach.Click += new System.EventHandler(this.BarTeach_Click);
            // 
            // BarEn
            // 
            this.BarEn.BackColor = System.Drawing.Color.LightCyan;
            this.BarEn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarEn.Name = "BarEn";
            this.BarEn.Size = new System.Drawing.Size(189, 22);
            this.BarEn.Text = "Encrypt";
            this.BarEn.Click += new System.EventHandler(this.BarEn_Click);
            // 
            // BarDe
            // 
            this.BarDe.BackColor = System.Drawing.Color.LightCyan;
            this.BarDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarDe.Name = "BarDe";
            this.BarDe.Size = new System.Drawing.Size(189, 22);
            this.BarDe.Text = "Decrypt";
            this.BarDe.Click += new System.EventHandler(this.BarDe_Click);
            // 
            // BarMorse
            // 
            this.BarMorse.BackColor = System.Drawing.Color.LightCyan;
            this.BarMorse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarMorse.Name = "BarMorse";
            this.BarMorse.Size = new System.Drawing.Size(189, 22);
            this.BarMorse.Text = "Translate Morse Code";
            this.BarMorse.Click += new System.EventHandler(this.BarMorse_Click);
            // 
            // BarDisplayTime
            // 
            this.BarDisplayTime.BackColor = System.Drawing.Color.LightCyan;
            this.BarDisplayTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarDisplayTime.Name = "BarDisplayTime";
            this.BarDisplayTime.Size = new System.Drawing.Size(189, 22);
            this.BarDisplayTime.Text = "Display Time";
            this.BarDisplayTime.Click += new System.EventHandler(this.BarDisplayTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(345, 553);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.Menu);
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
            this.Text = "ChakBot - AI Friend";
            this.RightClick.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.ToolStripMenuItem RCShortcuts;
        private System.Windows.Forms.ToolStripMenuItem UnitConverter;
        private System.Windows.Forms.ToolStripMenuItem Calculator;
        private System.Windows.Forms.ToolStripMenuItem TeachChakbot;
        private System.Windows.Forms.ToolStripMenuItem Encrypt;
        private System.Windows.Forms.ToolStripMenuItem Decrypt;
        private System.Windows.Forms.ToolStripMenuItem TranslateMorse;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem ClearScreen;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuShortcuts;
        private System.Windows.Forms.ToolStripMenuItem BarHelp;
        private System.Windows.Forms.ToolStripMenuItem BarClear;
        private System.Windows.Forms.ToolStripMenuItem BarCalc;
        private System.Windows.Forms.ToolStripMenuItem BarConv;
        private System.Windows.Forms.ToolStripMenuItem BarTeach;
        private System.Windows.Forms.ToolStripMenuItem BarEn;
        private System.Windows.Forms.ToolStripMenuItem BarDe;
        private System.Windows.Forms.ToolStripMenuItem BarMorse;
        private System.Windows.Forms.ToolStripMenuItem DisplayTime;
        private System.Windows.Forms.ToolStripMenuItem BarDisplayTime;
    }
}

