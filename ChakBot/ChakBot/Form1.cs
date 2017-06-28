using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ChakBot
{
    public partial class Form1 : Form
    {
        // ============================ Initilization ================================

        List<string> tempText = new List<string>() { };
        int historyIndex = 0;
        int prevIndex = 0;
        Random rnd = new Random();
        string PATH = System.IO.Directory.GetCurrentDirectory() + "/brain.txt";

        // Variables to store responses
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();

        // All commands
        List<string> commands = new List<string> { "//help", "//clear", "//time", "teach=", "cal=", "convert=", "e;n=", "d;n=", "mc=" };

        // All Metric units
        Dictionary<string, Dictionary<string, double>> Metrics = new Dictionary<string, Dictionary<string, double>> ()
        {
            { "Length",
                new Dictionary<string, double>
                {
                    { "mm", 1000000 },
                    { "cm", 100000 },
                    { "m", 1000 },
                    { "km", 1 },
                    { "mi", 0.62137 },
                    { "ft", 3280.84 },
                    { "in", 39370.1 },
                    { "yd", 1093.61 }
                }
            },
            { "Digital",
                new Dictionary<string, double>
                {
                    { "b", 8 },
                    { "B", 1 },
                    { "KB", 1024 },
                    { "MB", 1048576 },
                    { "GB", 1073741824.0005517 },
                    { "TB", 1099511627775.9133 },
                    { "PB", 1125899906842782.8 }
                }
            },
            { "Mass",
                new Dictionary<string, double>
                {
                    { "lb", 0.00220462 },
                    { "oz", 0.035274 },
                    { "mg", 1000 },
                    { "g", 1 },
                    { "kg", 0.001 }
                }
            },
            { "Volume",
                new Dictionary<string, double>
                {
                    { "tsp", 202.884 },
                    { "tbsp", 62.628 },
                    { "c", 4.16667 },
                    { "ml", 1000 },
                    { "l", 1 },
                    { "pt", 2.11338 },
                    { "gal", 0.264172 }
                }
            }
        };


        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = Enter;
            this.ActiveControl = InputChat;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            // Read Text file to get responses
            // If brain.txt DNE, then create a blank new one
            if (!System.IO.File.Exists(PATH))
            {
                using (System.IO.File.Create(PATH)) { }
            }

            System.IO.StreamReader file = new System.IO.StreamReader(PATH);

            // Read line and put into list
            string line;
            int counter = 0;
            string categ;
            List<string> content;
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");

            while ((line = file.ReadLine()) != null)
            {
                categ = line.Substring(0, line.IndexOf("="));
                content = line.ToLower().Substring(line.IndexOf("=") + 1, line.Length - line.IndexOf("=") - 1).Split(';').ToList();
                categories[categ] = content;
                counter++;
            }

            file.Close();
        }

        // ============================ End Initialization ================================

        // ============================ UI Features ================================
        private void HelpMenu_Click(object sender, EventArgs e)
        {
            InputChat.Text = "//help";
            SendKeys.Send("{ENTER}");
        }

        private void ClearScreen_Click(object sender, EventArgs e)
        {
            InputChat.Text = "//clear";
            SendKeys.Send("{ENTER}");
        }

        private void DisplayTime_Click(object sender, EventArgs e)
        {
            InputChat.Text = "//time";
            SendKeys.Send("{ENTER}");
        }

        private void Calculator_Click(object sender, EventArgs e)
        {
            if (InputChat.Text == "")
            {
                InputChat.Text = "cal=";
                InputChat.SelectionStart = InputChat.Text.Length;
            }
            else
            {
                InputChat.Text = "cal=" + InputChat.Text;
                SendKeys.Send("{ENTER}");
            }
        }

        private void UnitConverter_Click(object sender, EventArgs e)
        {
            if (InputChat.Text == "")
            {
                InputChat.Text = "convert=";
                InputChat.SelectionStart = InputChat.Text.Length;
            }
            else
            {
                InputChat.Text = "convert=" + InputChat.Text;
                SendKeys.Send("{ENTER}");
            }
        }

        private void TeachChakbot_Click(object sender, EventArgs e)
        {
            if (InputChat.Text == "")
            {
                InputChat.Text = "teach=";
                InputChat.SelectionStart = InputChat.Text.Length;
            }
            else
            {
                InputChat.Text = "teach=" + InputChat.Text;
                SendKeys.Send("{ENTER}");
            }
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            if (InputChat.Text == "")
            {
                InputChat.Text = "e;" + rnd.Next(1, 25) + "=";
                InputChat.SelectionStart = InputChat.Text.Length;
            }
            else
            {
                InputChat.Text = "e;" + rnd.Next(1, 25) + "=" + InputChat.Text;
                SendKeys.Send("{ENTER}");
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (InputChat.Text == "")
            {
                InputChat.Text = "d;=";
                InputChat.SelectionStart = InputChat.Text.Length;
            }
            else
            {
                InputChat.Text = "d;=" + InputChat.Text;
            }
        }

        private void TranslateMorse_Click(object sender, EventArgs e)
        {
            if (InputChat.Text == "")
            {
                InputChat.Text = "mc=";
                InputChat.SelectionStart = InputChat.Text.Length;
            }
            else
            {
                InputChat.Text = "mc=" + InputChat.Text;
                SendKeys.Send("{ENTER}");
            }
        }

        private void BarHelp_Click(object sender, EventArgs e)
        {
            HelpMenu_Click(sender, e);
        }

        private void BarClear_Click(object sender, EventArgs e)
        {
            ClearScreen_Click(sender, e);
        }

        private void BarCalc_Click(object sender, EventArgs e)
        {
            Calculator_Click(sender, e);
        }

        private void BarConv_Click(object sender, EventArgs e)
        {
            UnitConverter_Click(sender, e);
        }

        private void BarTeach_Click(object sender, EventArgs e)
        {
            TeachChakbot_Click(sender, e);
        }

        private void BarEn_Click(object sender, EventArgs e)
        {
            Encrypt_Click(sender, e);
        }

        private void BarDe_Click(object sender, EventArgs e)
        {
            Decrypt_Click(sender, e);
        }

        private void BarMorse_Click(object sender, EventArgs e)
        {
            TranslateMorse_Click(sender, e);
        }

        private void BarDisplayTime_Click(object sender, EventArgs e)
        {
            DisplayTime_Click(sender, e);
        }

        private void OutputChat_TextChanged(object sender, EventArgs e)
        {
            OutputChat.SelectionStart = OutputChat.Text.Length;
            OutputChat.ScrollToCaret();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() +
                "/ChakBot Conversaion History.txt");
            file.WriteLine(OutputChat.Text.Replace("\\r\\n", System.Environment.NewLine));
            file.Close();
            MessageBox.Show("File has been saved to current directory.");
        }

        /// <summary>
        /// When Enter is clicked, many operations happen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter_Click(object sender, EventArgs e)
        {
            // Output user message
            OutputChat.AppendText("User:\r\n >>> " + InputChat.Text + "\r\n");

            // Add convo to history
            tempText.Add(InputChat.Text);
            historyIndex++;

            // Refresh Chatbox
            InputChat.Text = "";
            prevIndex = historyIndex;
            OutputChat.Refresh();
            InputChat.Refresh();

            // Call Chakbot to respond
            ChakBot_Convo();
        }

        // ============================ END UI Features ================================


        // ============================ Chakbot Settings ================================
        /// <summary>
        /// Robot Response
        /// </summary>
        private async void ChakBot_Convo()
        {
            // Delay for aesthetics
            for (int i = 0; i < rnd.Next(1, 2); i++)
            {
                TypingDisplay.Text = "ChakBot is typing.";
                await Task.Delay(400);
                TypingDisplay.Text = "ChakBot is typing..";
                await Task.Delay(400);
                TypingDisplay.Text = "ChakBot is typing...";
                await Task.Delay(400);
            }

            if (tempText[historyIndex - 1] == "//help")
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                    "List of functions\r\n" +
                    "====================================================\r\n" +
                    "//clear\t| Clear the messages on screen\r\n" +
                    "//time\t| Display the current time\r\n" +
                    "teach=\t| Teach chakbot (root>message>corres>message)\r\n" +
                    "e;n=\t| Encrypt by shifting n times\r\n" +
                    "d;n=\t| Decrypt by shifting n times\r\n" +
                    "morse=\t| Encrypr/decrypt message into morse code\r\n" + 
                    "cal=\t| Calculate\r\n" + 
                    "convert=\t| Convert units (#unit>unit)\r\n" +
                    "====================================================\r\n");
                TypingDisplay.Text = "";
            }
            else if (tempText[historyIndex - 1] == "//clear")
            {
                OutputChat.Clear();
                TypingDisplay.Text = "";
            }
            else if (tempText[historyIndex - 1] == "//time")
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                DateTime.Now.ToString() + " EST\r\n");
                TypingDisplay.Text = "";
            }
            else if (tempText[historyIndex - 1] == "//brain")
            {
                System.IO.StreamReader read = new System.IO.StreamReader(PATH);

                // Read line and put into list
                string line;
                string message = "";

                while ((line = read.ReadLine()) != null)
                {
                    message += line + "\r\n";
                    message += "---\r\n";
                }

                read.Close();
                OutputChat.AppendText(message + "\r\n");
                TypingDisplay.Text = "";
            }
            else if (tempText[historyIndex - 1].Contains("="))
            {
                if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf('=') + 1).ToLower() == "teach=")
                {
                    teach_chakbot(tempText[historyIndex - 1].Substring(6,
                        tempText[historyIndex - 1].Length - 6));
                }
                else if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf(';') + 1).ToLower() == "e;" ||
                    tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf(';') + 1).ToLower() == "d;")
                {
                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                        chakbot_en_de(tempText[historyIndex - 1]) + "\r\n");
                    TypingDisplay.Text = "";
                }
                else if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf('=') + 1).ToLower() == "mc=")
                {
                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                    MorseCode(tempText[historyIndex - 1].Substring(3, tempText[historyIndex - 1].Length - 3)) + "\r\n");
                    TypingDisplay.Text = "";
                }
                else if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf('=') + 1).ToLower() == "cal=")
                {
                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                    Calculate(tempText[historyIndex - 1].Substring(4, tempText[historyIndex - 1].Length - 4)) + "\r\n");
                    TypingDisplay.Text = "";
                }
                else if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf('=') + 1).ToLower() == "convert=")
                {
                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                    Convert(tempText[historyIndex - 1].Substring(8, tempText[historyIndex - 1].Length - 8)) + "\r\n");
                    TypingDisplay.Text = "";
                }
                else
                {
                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                    "Please check your syntax." + "\r\n");
                    TypingDisplay.Text = "";
                }
            }
            else
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                    getMessage(tempText[historyIndex - 1]) + "\r\n");
                TypingDisplay.Text = "";
            }
        }

        /// <summary>
        /// Key detection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (prevIndex > 0)
                {
                    InputChat.Text = tempText[prevIndex - 1];
                    if (prevIndex != 0) { prevIndex--; }
                    InputChat.SelectionStart = InputChat.Text.Length;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (prevIndex < historyIndex - 1)
                {
                    InputChat.Text = tempText[prevIndex + 1];
                    if (prevIndex != historyIndex - 1) { prevIndex++; }
                    InputChat.SelectionStart = InputChat.Text.Length;
                }
            }
        }

        /// <summary>
        /// Brain of Robot
        /// </summary>
        /// <param name="feed"></param>
        /// <returns></returns>
        private string getMessage(string feed)
        {
            // Analyze by word
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            string sentence = rgx.Replace(feed, "").ToLower();
            string root;
            string cor;

            // === Response Decider ===
            // First see if sentence exist, if not then decide by word
            foreach (string categ in categories.Keys)
            {
                // Find the corresponding answer (only applies to requests)
                if (categ.Contains(';'))
                {
                    root = categ.Substring(0, categ.IndexOf(';'));
                    cor = categ.Substring(categ.IndexOf(';') + 1, categ.Length - categ.IndexOf(';') - 1);

                    // If the root and cor is the same, then remain same
                    if (root == cor)
                    {
                        cor = categ;
                    }

                    if (categories[categ].Contains(sentence))
                    {
                        return categories[cor][rnd.Next(0, categories[cor].Count())];
                    }
                }
            }

            return "Sorry, I did not learn how to answer that =[\r\n >>> Please type //help or right click to show help in shortcut menu.\r\n";
        }
        // ============================ End Chakbot Settings ================================


        // ============================ Chakbot Features ================================
        /// <summary>
        /// Adding info to ckabot's brain
        /// </summary>
        private void teach_chakbot(string learn)
        {
            // Format of teaching
            // categ>question>response
            List<string> disect = learn.Split('>').ToList();

            try
            {
                // Check format
                if (disect[0] == "" || disect[1] == "" || disect[2] == "" || disect[3] == "")
                {
                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                        "Please enter the correct format: teach=categ;corres>question>Rcateg>reponse" + "\r\n");
                    TypingDisplay.Text = "";
                }
                else
                {
                    // If category exist
                    if (categories.Keys.Contains(disect[0] + ";" + disect[2]))
                    {
                        var text = new StringBuilder();

                        foreach (string s in System.IO.File.ReadAllLines(PATH))
                        {
                            // Check if category is request
                            if (s.Substring(0, s.IndexOf("=")) == disect[0] + ";" + disect[2])
                            {
                                if (disect[0] == disect[2])
                                {
                                    text.AppendLine(s.Replace(s, s + ";" + disect[1] + ";" + disect[3]));
                                }
                                else
                                {
                                    text.AppendLine(s.Replace(s, s + ";" + disect[1]));
                                }
                            }
                            // If not request, then must be response. Leave as it is
                            else
                            {
                                text.AppendLine(s);
                            }
                        }

                        using (var file = new System.IO.StreamWriter(PATH))
                        {
                            file.Write(text.ToString());
                            file.Close();
                        }
                    }
                    // Otherwise
                    else
                    {
                        if (disect[0] != disect[2])
                        {
                            System.IO.File.AppendAllText(PATH,
                                disect[0] + ";" + disect[2] + "=" + disect[1] + Environment.NewLine);
                        }
                        else
                        {
                            System.IO.File.AppendAllText(PATH,
                                disect[0] + ";" + disect[2] + "=" + disect[1] + disect[3] + Environment.NewLine);
                        }
                    }

                    if (disect[0] != disect[2])
                    {
                        // If category exist
                        if (categories.Keys.Contains(disect[2]))
                        {
                            var text = new StringBuilder();

                            foreach (string s in System.IO.File.ReadAllLines(PATH))
                            {
                                if (s.Substring(0, s.IndexOf("=")) == disect[2])
                                {
                                    text.AppendLine(s.Replace(s, s + ";" + disect[3]));
                                }
                                else
                                {
                                    text.AppendLine(s);
                                }
                            }

                            using (var file = new System.IO.StreamWriter(PATH))
                            {
                                file.Write(text.ToString());
                                file.Close();
                            }
                        }
                        // Otherwise
                        else
                        {
                            System.IO.File.AppendAllText(PATH,
                                    disect[2] + "=" + disect[3] + Environment.NewLine);
                        }
                    }

                    OutputChat.AppendText("ChakBot:\r\n >>> " +
                            "Thanks! I learned it! =D" + "\r\n");
                    TypingDisplay.Text = "";
                }
            }
            catch
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                            "Please check that you included all information." + "\r\n");
                TypingDisplay.Text = "";
            }

            // Reread content
            categories.Clear();

            System.IO.StreamReader read = new System.IO.StreamReader(PATH);

            // Read line and put into list
            string line;
            int counter = 0;
            string categ;
            List<string> content;

            while ((line = read.ReadLine()) != null)
            {
                categ = line.Substring(0, line.IndexOf("="));
                content = line.ToLower().Substring(line.IndexOf("=") + 1, line.Length - line.IndexOf("=") - 1).Split(';').ToList();
                categories[categ] = content;
                counter++;
            }

            read.Close();
        }

        /// <summary>
        /// Encrypt/Decrypt main program
        /// </summary>
        /// <param name="action"></param>
        /// <param name="shiftNumber"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private string chakbot_en_de(string message)
        {
            // Initializing variables
            string[] AlphabetsU = new[] { "L", "B", "W", "F", "P", "X", "G", "D", "I", "A", "K", "J", "M", "V", "O", "E", "Q", "S", "Z", "U", "R", "N", "C", "H", "Y", "T" };
            string[] AlphabetsL = new[] { "z", "v", "g", "f", "w", "d", "h", "o", "i", "j", "c", "l", "k", "n", "m", "p", "e", "r", "y", "t", "s", "x", "b", "q", "a", "u" };
            string[] Numbers = new[] { "5", "9", "7", "3", "1", "6", "4", "8", "0", "2" };
            string[] Signs = new[] { "!", ">", "{", "$", "%", "'", "(", "*", "&", ")", "-", "_", "=", "+", "#", "}", "?", "/", ">", "]", ";", ":", "~", "`", ",", ".", "<", "@", "^" };
            string action = message.Substring(0, 1);
            int shiftNumber = Int32.Parse(message.Substring(2, message.IndexOf('=') - 2));
            string sentence = message.Substring(message.IndexOf("=") + 1, message.Length - message.IndexOf("=") - 1);
            string newText = "";

            // First encrytion/decrytion
            foreach (char letter in sentence)
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
                    newText += Shift(letter, shiftNumber % 10, action, Numbers);
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
        private string Shift(char letter, int shiftNumber, string action, string[] letterCase)
        {
            int index = Array.IndexOf(letterCase, letter.ToString());
            int newIndex = index + shiftNumber;

            if (action.Equals("e"))
            {
                if (newIndex > letterCase.Count() - 1)
                {
                    newIndex = (index + shiftNumber) % letterCase.Count();
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
                    newIndex = letterCase.Count() + ((index - shiftNumber) % letterCase.Count());
                }
                else
                {
                    newIndex = index - shiftNumber;
                }
            }

            return letterCase[newIndex];
        }

        /// <summary>
        /// Morse Code Algo
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string MorseCode(string message)
        {
            string converted_Message = "";
            List<string> morse_Letters = new List<string>()
                { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            List<string> morse_Codes = new List<string>()
                { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..",
            ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };

            List<string> splitedList = message.Split(' ').ToList();

            foreach (string element in splitedList)
            {
                // Morse Code
                if (morse_Codes.Contains(element.ToString().ToLower()))
                {
                    converted_Message += morse_Letters[morse_Codes.IndexOf(element.ToString().ToLower())];
                }
                // Letters
                else
                {
                    foreach (char character in element)
                    {
                        if (morse_Letters.Contains(character.ToString().ToLower()))
                        {
                            converted_Message += morse_Codes[morse_Letters.IndexOf(character.ToString().ToLower())] + " ";
                        }
                    }
                    converted_Message += " ";
                }
            }

            return converted_Message;
        }

        /// <summary>
        /// Calculator Brain
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string Calculate(string message)
        {
            try
            {
                if (message.Any(x => char.IsLetter(x)))
                {
                    return "Please check your syntax";
                }
                else
                {
                    return new DataTable().Compute(message, null).ToString();
                }
            }
            catch
            {
                return "This is currently not supported.";
            }
        }

        private string Convert(string message)
        {
            try
            {
                message = message.Replace(" ", "");
                int separator = message.IndexOfAny("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMOPQRSTUVWXYZ".ToCharArray());
                double number = Double.Parse(message.Substring(0, separator));
                string unit1 = message.Substring(separator, message.IndexOf(">") - separator);
                string unit2 = message.Substring(message.IndexOf(">") + 1, message.Length - message.IndexOf(">") - 1);

                foreach (string categ in Metrics.Keys)
                {
                    if (Metrics[categ].Keys.Contains(unit1) && Metrics[categ].Keys.Contains(unit2))
                    {
                        return (number * (Metrics[categ][unit2] / Metrics[categ][unit1])) + " <" + categ + " Conversion>";
                    }
                }

                return "Please make sure the unit or the conversion is valid.";
            }
            catch
            {
                return "Please make sure you input the format correctly";
            }
        }

        // ============================ End Chakbot Features ================================

        // ============================ Additional Features ================================
        private void ThemeDark_Click(object sender, EventArgs e)
        {
            // Frame
            this.BackColor = Color.SlateGray;
            CopyRight1.BackColor = Color.SlateGray;
            CopyRight1.ForeColor = Color.White;
            CopyRight2.BackColor = Color.SlateGray;
            CopyRight2.ForeColor = Color.White;

            // Text
            OutputChat.BackColor = Color.Black;
            OutputChat.ForeColor = Color.White;
            InputChat.BackColor = Color.Black;
            InputChat.ForeColor = Color.White;
            TypingDisplay.BackColor = Color.Black;
            TypingDisplay.ForeColor = Color.White;

            // Buttons
            Menu.BackColor = Color.SlateGray;
            MenuShortcuts.BackColor = Color.SlateGray;
            MenuShortcuts.ForeColor = Color.LightCyan;
            MenuSettings.BackColor = Color.SlateGray;
            MenuSettings.ForeColor = Color.LightCyan;
            SaveButton.BackColor = Color.SlateGray;
            SaveButton.ForeColor = Color.White;
            Enter.BackColor = Color.SlateGray;
            Enter.ForeColor = Color.White;

            // Right click
            RCShortcuts.BackColor = Color.LightCyan;
            RCShortcuts.ForeColor = Color.Black;
            HelpMenu.BackColor = Color.LightCyan;
            HelpMenu.ForeColor = Color.Black;
            ClearScreen.BackColor = Color.LightCyan;
            ClearScreen.ForeColor = Color.Black;
            DisplayTime.BackColor = Color.LightCyan;
            DisplayTime.ForeColor = Color.Black;
            Calculator.BackColor = Color.LightCyan;
            Calculator.ForeColor = Color.Black;
            UnitConverter.BackColor = Color.LightCyan;
            UnitConverter.ForeColor = Color.Black;
            TeachChakbot.BackColor = Color.LightCyan;
            TeachChakbot.ForeColor = Color.Black;
            Encrypt.BackColor = Color.LightCyan;
            Encrypt.ForeColor = Color.Black;
            Decrypt.BackColor = Color.LightCyan;
            Decrypt.ForeColor = Color.Black;
            TranslateMorse.BackColor = Color.LightCyan;
            TranslateMorse.ForeColor = Color.Black;
        }

        private void ThemeLight_Click(object sender, EventArgs e)
        {
            // Frame
            this.BackColor = Color.SlateGray;
            CopyRight1.BackColor = Color.SlateGray;
            CopyRight1.ForeColor = Color.White;
            CopyRight2.BackColor = Color.SlateGray;
            CopyRight2.ForeColor = Color.White;

            // Text
            OutputChat.BackColor = Color.Black;
            OutputChat.ForeColor = Color.White;
            InputChat.BackColor = Color.Black;
            InputChat.ForeColor = Color.White;
            TypingDisplay.BackColor = Color.Black;
            TypingDisplay.ForeColor = Color.White;

            // Buttons
            Menu.BackColor = Color.SlateGray;
            MenuShortcuts.BackColor = Color.SlateGray;
            MenuShortcuts.ForeColor = Color.LightCyan;
            MenuSettings.BackColor = Color.SlateGray;
            MenuSettings.ForeColor = Color.LightCyan;
            SaveButton.BackColor = Color.SlateGray;
            SaveButton.ForeColor = Color.White;
            Enter.BackColor = Color.SlateGray;
            Enter.ForeColor = Color.White;

            // Right click
            RCShortcuts.BackColor = Color.LightCyan;
            RCShortcuts.ForeColor = Color.Black;
            HelpMenu.BackColor = Color.LightCyan;
            HelpMenu.ForeColor = Color.Black;
            ClearScreen.BackColor = Color.LightCyan;
            ClearScreen.ForeColor = Color.Black;
            DisplayTime.BackColor = Color.LightCyan;
            DisplayTime.ForeColor = Color.Black;
            Calculator.BackColor = Color.LightCyan;
            Calculator.ForeColor = Color.Black;
            UnitConverter.BackColor = Color.LightCyan;
            UnitConverter.ForeColor = Color.Black;
            TeachChakbot.BackColor = Color.LightCyan;
            TeachChakbot.ForeColor = Color.Black;
            Encrypt.BackColor = Color.LightCyan;
            Encrypt.ForeColor = Color.Black;
            Decrypt.BackColor = Color.LightCyan;
            Decrypt.ForeColor = Color.Black;
            TranslateMorse.BackColor = Color.LightCyan;
            TranslateMorse.ForeColor = Color.Black;
        }

        // ============================ End Additional Features ================================
    }
}
