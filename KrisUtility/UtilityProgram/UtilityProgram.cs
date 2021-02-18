using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UtilityProgram
{
    public partial class UtilityProgram : Form
    {
        //==================================================================== START OF CIPER =======================================================================
        string message = "";
        int shiftNumber = 0;
        bool popup = true;

        /// <summary>
        /// Ceasar Ciper
        /// </summary>
        /// <param name="message">The inputted message to be processed</param>
        /// <param name="action">Encrypt or Decrypt</param>
        /// <returns>The new message</returns>
        private string Code(string message, string action)
        {
            // Initializing variables
            string[] AlphabetsU = new[] { "L", "B", "W", "F", "P", "X", "G", "D", "I", "A", "K", "J", "M", "V", "O", "E", "Q", "S", "Z", "U", "R", "N", "C", "H", "Y", "T" };
            string[] AlphabetsL = new[] { "z", "v", "g", "f", "w", "d", "h", "o", "i", "j", "c", "l", "k", "n", "m", "p", "e", "r", "y", "t", "s", "x", "b", "q", "a", "u" };
            string[] Numbers = new[] { "5", "9", "7", "3", "1", "6", "4", "8", "0", "2" };
            string[] Signs = new[] { "!", ">", "{", "$", "%", "'", "(", "*", "&", ")", "-", "_", "=", "+", "#", "}", "?", "/", ">", "]", ";", ":", "~", "`" , ",", ".", "<", "@", "^" };

            string newText = "";

            // First encrytion/decrytion
            foreach (char letter in message)
            {
                if (AlphabetsU.Contains(letter.ToString()) || AlphabetsL.Contains(letter.ToString()))
                {
                    if (AlphabetsU.Contains(letter.ToString()))
                    {
                        newText += Shift(letter, shiftNumber, action, AlphabetsU);
                    }
                    else
                    {
                        newText += Shift(letter, shiftNumber, action, AlphabetsL);
                    }
                }
                else if (Numbers.Contains(letter.ToString()))
                {
                    newText += Shift(letter, shiftNumber%10, action, Numbers);
                }
                else if (Signs.Contains(letter.ToString()))
                {
                    newText += Shift(letter, shiftNumber, action, Signs);
                }
                else
                {
                    newText += letter;
                }
            }

            return newText;
        }

        /// <summary>
        /// Helps perform the ceasar shift
        /// </summary>
        /// <param name="letter">The current letter</param>
        /// <param name="shiftNumber">Shift number</param>
        /// <param name="shiftType">Encrypt or decrypt</param>
        /// <param name="letterCase">Keeps the original casing</param>
        /// <returns>The new letter</returns>
        private static string Shift(char letter, int shiftNumber, string shiftType, string[] letterCase)
        {
            int index = Array.IndexOf(letterCase, letter.ToString());
            int newIndex;

            if (shiftType.Equals("RS"))
            {
                if ((index + shiftNumber) > letterCase.Count() - 1)
                {
                    newIndex = (index + shiftNumber) - (letterCase.Count());
                }
                else
                {
                    newIndex = index + shiftNumber;
                }
            }
            else
            {
                if ((index - shiftNumber) < 0)
                {
                    newIndex = (letterCase.Count()) + (index - shiftNumber);
                }
                else
                {
                    newIndex = index - shiftNumber;
                }
            }

            return letterCase[newIndex];
        }

        public UtilityProgram()
        {
            InitializeComponent();
            for (int i = 1; i < 26; i++)
            {
                ShiftNumberBox.Items.Add(i);
            }
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            message = InputBox.Text;
        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
            OutputBox.Text = message;
        }

        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            InputBox_TextChanged(sender, e);
            message = Code(message, "LS");
            OutputBox_TextChanged(sender, e);
            if (popup)
            {
                MessageBox.Show("Encryption Completed");
            }
        }

        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            InputBox_TextChanged(sender, e);
            message = Code(message, "RS");
            OutputBox_TextChanged(sender, e);
            if (popup)
            {
                MessageBox.Show("Decryption Completed");
            }
        }

        private void ShiftNumberBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiftNumber = ShiftNumberBox.SelectedIndex + 1;
        }

        private void PopupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (PopupCheckbox.Checked)
            {
                popup = false;
            }
            else
            {
                popup = true;
            }
        }

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("=========== Instructions ===========\n 1) Input Message under 'Input Box'\n 2) Pick a Channel\n 3) Choose to Encrypt or Decrypt\n"
                + "To Save content, Navigate to 'File Manager' -> 'Save Content'");
        }

        //==================================================================== END OF CIPER =======================================================================

        //==================================================================== START OF DIGITAL =======================================================================
        string currentNumber = "";
        string displayNumber = "";
        string previousSign = "";
        long finalNumber = 0;

        List<string> Signs = new List<string> { "+", "-", "/", "*" };

        private void Sign_Buttons(string sign, object sender, EventArgs e)
        {
            // Check if it is the first number
            if (previousSign.Equals("") || (previousSign.Equals("-") && finalNumber == 0))
            {
                finalNumber = Int64.Parse(currentNumber);
            }
            else
            {
                Calculations(previousSign, sender, e);
            }

            // Check enter if duplicated operators
            if (Signs.Any(s => displayNumber.Contains(s)))
            {
                if (finalNumber.ToString().Contains("-"))
                {
                    displayNumber = " (" + finalNumber.ToString() + ") " + sign;
                }
                else
                {
                    displayNumber = finalNumber.ToString() + " " + sign;
                }
            }
            else
            {
                if (currentNumber.Contains("-"))
                {
                    displayNumber = " (" + currentNumber + ") " + sign;
                }
                else
                {
                    displayNumber = currentNumber + " " + sign;
                }
            }
            currentNumber = "";
            previousSign = sign;
            textBox1_TextChanged(sender, e);
            richTextBox1_TextChanged(sender, e);
        }

        private void Calculations(string sign, object sender, EventArgs e)
        {
            if (sign.Equals("+"))
            {
                finalNumber += Int64.Parse(currentNumber);
            }
            else if (sign.Equals("-"))
            {
                finalNumber -= Int64.Parse(currentNumber);
            }
            else if (sign.Equals("*"))
            {
                finalNumber *= Int64.Parse(currentNumber);
            }
            else if (sign.Equals("/"))
            {
                if (!currentNumber.Equals("0"))
                {
                    finalNumber /= Int64.Parse(currentNumber);
                }
                else
                {
                    MessageBox.Show("Cannot divide a number by 0.");
                }
            }
            else
            {
                finalNumber = Int64.Parse(currentNumber);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = displayNumber;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.Text = currentNumber;
        }

        private void Number_Button(string number, object sender, EventArgs e)
        {
            if (currentNumber.Count() < 17)
            {
                currentNumber += number;
                richTextBox1_TextChanged(sender, e);
            }
        }

        private void Zero_Button_Click(object sender, EventArgs e)
        {
            Number_Button("0", sender, e);
        }

        private void One_Button_Click(object sender, EventArgs e)
        {
            Number_Button("1", sender, e);
        }

        private void Two_Button_Click(object sender, EventArgs e)
        {
            Number_Button("2", sender, e);
        }

        private void Three_Button_Click(object sender, EventArgs e)
        {
            Number_Button("3", sender, e);
        }

        private void Four_Button_Click(object sender, EventArgs e)
        {
            Number_Button("4", sender, e);
        }

        private void Five_Button_Click(object sender, EventArgs e)
        {
            Number_Button("5", sender, e);
        }

        private void Six_Button_Click(object sender, EventArgs e)
        {
            Number_Button("6", sender, e);
        }

        private void Seven_Button_Click(object sender, EventArgs e)
        {
            Number_Button("7", sender, e);
        }

        private void Eight_Button_Click(object sender, EventArgs e)
        {
            Number_Button("8", sender, e);
        }

        private void Nine_Button_Click(object sender, EventArgs e)
        {
            Number_Button("9", sender, e);
        }

        private long DigitalRoot(long number)
        {
            if (number == 0)
            {
                return 0;
            }

            return DigitalRoot(number / 10) + number % 10;
        }

        private void Root_Button_Click(object sender, EventArgs e)
        {
            if (!(currentNumber.Contains("-") && currentNumber.Count() == 1) && !currentNumber.Equals(""))
            {
                displayNumber = currentNumber;
                while (Int64.Parse(currentNumber) > 9 || Int64.Parse(currentNumber) < -10)
                {
                    currentNumber = DigitalRoot(Int64.Parse(currentNumber)).ToString();
                }
                textBox1_TextChanged(sender, e);
                richTextBox1_TextChanged(sender, e);
            }
            else
            {
                Clear_Button_Click(sender, e);
            }
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            currentNumber = "";
            displayNumber = "";
            previousSign = "";
            finalNumber = 0;
            richTextBox1_TextChanged(sender, e);
            textBox1_TextChanged(sender, e);
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (!currentNumber.Equals("") && !currentNumber.Equals("-"))
            {
                Sign_Buttons("+", sender, e);
            }
        }

        private void Subtract_Button_Click(object sender, EventArgs e)
        {
            if (currentNumber.Equals(""))
            {
                currentNumber += "-";
                richTextBox1_TextChanged(sender, e);
            }
            else if (!currentNumber.Equals("") && !currentNumber.Equals("-"))
            {
                Sign_Buttons("-", sender, e);
            }
        }

        private void Times_Button_Click(object sender, EventArgs e)
        {
            if (!currentNumber.Equals("") && !currentNumber.Equals("-"))
            {
                Sign_Buttons("*", sender, e);
            }
        }

        private void Divide_Button_Click(object sender, EventArgs e)
        {
            if (!currentNumber.Equals("") && !currentNumber.Equals("-"))
            {
                Sign_Buttons("/", sender, e);
            }
        }

        private void Enter_Button_Click(object sender, EventArgs e)
        {
            if (!currentNumber.Equals("") && !currentNumber.Equals("-"))
            {
                Calculations(previousSign, sender, e);

                if (currentNumber.Contains("-"))
                {
                    displayNumber += " (" + currentNumber + ")";
                }
                else
                {
                    displayNumber += " " + currentNumber;
                }
                currentNumber = finalNumber.ToString();

                textBox1_TextChanged(sender, e);
                richTextBox1_TextChanged(sender, e);

                displayNumber = "";
                finalNumber = 0;
            }
        }

        private void RNG_Button_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            currentNumber = rnd.Next(999999999).ToString();
            richTextBox1_TextChanged(sender, e);
        }

        private void Chennel_Link_Click(object sender, EventArgs e)
        {
            if (!currentNumber.Equals("") && Int32.Parse(currentNumber) >= 0 && Int32.Parse(currentNumber) < 26)
            {
                KrisUtilityProgram.SelectedIndex = 0;
                shiftNumber = Int32.Parse(currentNumber);
                ShiftNumberBox.Text = currentNumber;
            }
            else
            {
                MessageBox.Show("That number is not within the range of channels!");
            }
        }

        //==================================================================== END OF DIGITAL =======================================================================
        
        //==================================================================== START OF FILE MANAGER ================================================================

        string folderPath = "";
        string logText = "";
        string completeness = "0%";

        private void WriteToFile(string log, string output, bool append, object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Refresh();
            completeness = "0%";
            DisplayPercent_Click(sender, e);

            if (folderPath.Contains(".txt"))
            {
                DisplayMessage(log + "...", sender, e);

                if (!append)
                {
                    // Checks if file exists
                    if (File.Exists(folderPath))
                    {
                        File.Delete(folderPath);
                    }

                    FileStream save = new FileStream(folderPath, FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(save);
                    writer.WriteLine(shiftNumber);
                    writer.WriteLine("========================================================================");
                    writer.WriteLine(Code(DateTime.Now.ToString(), "LS"));
                    writer.WriteLine(Code("Message: ", "LS") + output);
                    writer.Flush(); writer.Close(); save.Close();
                }
                else
                {
                    FileStream save = new FileStream(folderPath, FileMode.Append);
                    StreamWriter writer = new StreamWriter(save);
                    writer.WriteLine("========================================================================");
                    writer.WriteLine(Code(DateTime.Now.ToString(), "LS"));
                    writer.WriteLine(Code("Message: ", "LS") + output);
                    writer.Flush(); writer.Close(); save.Close();
                }

                DisplayMessage(log + " Completed!", sender, e);
                progressBar1.Increment(1);
                progressBar1.Refresh();
                completeness = "100%";
                DisplayPercent_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please select a file to save to!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This event handler was created by the browse button.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // The user selected a text file and pressed the OK button.
                folderPath = openFileDialog1.FileName;
            }

            FilePath_TextChanged(sender, e);
        }

        private void DisplayMessage(string message, object sender, EventArgs e)
        {
            logText += message + "\n";
            Output_Log_TextChanged(sender, e);
        }

        private void FilePath_TextChanged(object sender, EventArgs e)
        {
            FilePath.Text = folderPath;
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 1;
            Form1_Load(sender, e);
        }

        private void Output_Log_TextChanged(object sender, EventArgs e)
        {
            Output_Log.Text = logText;
            Output_Log.ScrollToCaret();
        }

        private void DisplayPercent_Click(object sender, EventArgs e)
        {
            DisplayPercent.Text = completeness;
        }

        private void SaveContent_Button_Click(object sender, EventArgs e)
        {
            WriteToFile("Saving Content", message, false, sender, e);
        }

        private void AppendContent_Button_Click(object sender, EventArgs e)
        {
            WriteToFile("Appending Content", message, true, sender, e);
        }

        private void EncryptSave_Button_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Refresh();
            completeness = "0%";
            DisplayPercent_Click(sender, e);
            DisplayMessage("Encrypting File...", sender, e);
            try
            {
                using (StreamReader reader = new StreamReader(folderPath))
                {
                    string line = reader.ReadToEnd();
                    message = line;
                    reader.Close();
                    FileStream save = new FileStream(folderPath, FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(save);
                    Random rng = new Random();
                    shiftNumber = rng.Next(25);
                    writer.WriteLine(shiftNumber);
                    writer.WriteLine(Code(message, "LS"));
                    writer.Flush(); writer.Close(); save.Close();
                    DisplayMessage("Encryption Completed!", sender, e);
                    progressBar1.Increment(1);
                    progressBar1.Refresh();
                    completeness = "100%";
                    DisplayPercent_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("The file could not be read.");
            }
        }

        private void DecryptSave_Button_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Refresh();
            completeness = "0%";
            DisplayPercent_Click(sender, e);
            DisplayMessage("Decrypting File...", sender, e);
            try
            {
                using (StreamReader reader = new StreamReader(folderPath))
                {
                    string line = reader.ReadToEnd();
                    int number;
                    if (int.TryParse(line[1].ToString(), out number))
                    {
                        shiftNumber = Int32.Parse(line[0].ToString() + line[1].ToString());
                        message = line.Remove(0, 4);
                    }
                    else
                    {
                        shiftNumber = Int32.Parse(line[0].ToString());
                        message = line.Remove(0, 3);
                    }
                    reader.Close();
                    FileStream save = new FileStream(folderPath, FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(save);
                    writer.WriteLine(Code(message, "RS"));
                    writer.Flush(); writer.Close(); save.Close();
                    DisplayMessage("Decryption Completed!", sender, e);
                    progressBar1.Increment(1);
                    progressBar1.Refresh();
                    completeness = "100%";
                    DisplayPercent_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("The file could not be read.");
            }
        }

        private void DisplayContent_Button_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(folderPath))
                {
                    string line = reader.ReadToEnd();
                    message = line;
                    reader.Close();
                    OutputBox_TextChanged(sender, e);
                    KrisUtilityProgram.SelectedIndex = 0;
                }
            }
            catch
            {
                MessageBox.Show("The file could not be read.");
            }
        }

        //==================================================================== END OF FILE MANAGER =======================================================================

        //==================================================================== START OF MORSE CODE ================================================================

        string morse_Message = "";
        string converted_Message = "";
        List<string> morse_Letters = new List<string>() 
        { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        List<string> morse_Codes = new List<string>() 
        { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", 
            ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };
        
        private void Morse_Input_TextChanged(object sender, EventArgs e)
        {
            morse_Message = Morse_Input.Text;
        }

        private void Morse_Output_TextChanged(object sender, EventArgs e)
        {
            Morse_Output.Text = converted_Message;
        }

        private void Morse_Convert_Click(object sender, EventArgs e)
        {
            Morse_Input_TextChanged(sender, e);
            List<string> splitedList = morse_Message.Split(' ').ToList();

            foreach (string element in splitedList)
            {
                // Morse Code
                if (morse_Codes.Contains(element.ToString().ToUpper()))
                {
                    converted_Message += morse_Letters[morse_Codes.IndexOf(element.ToString().ToUpper())];
                }
                // Letters
                else 
                {
                    foreach (char character in element)
                    {
                        if (morse_Letters.Contains(character.ToString().ToUpper()))
                        {
                            converted_Message += morse_Codes[morse_Letters.IndexOf(character.ToString().ToUpper())] + " ";
                        }
                    }
                    converted_Message += " ";
                }
            }

            Morse_Output_TextChanged(sender, e);
            morse_Message = "";
            converted_Message = "";
            if (popup)
            {
                MessageBox.Show("Conversion Completed");
            }
        }
    }
}
