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

namespace ChakBot
{
    public partial class Form1 : Form
    {
        List<string> tempText = new List<string>() {};
        int historyIndex = 0;
        int prevIndex = 0;
        Random rnd = new Random();
        string PATH = System.IO.Directory.GetCurrentDirectory() + "/brain.txt";

        // Variables to store responses
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();

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

            while ((line = file.ReadLine())!= null)
            {
                categ = line.Substring(0, line.IndexOf("="));
                content = line.ToLower().Substring(line.IndexOf("=") + 1, line.Length - line.IndexOf("=") - 1).Split(';').ToList();
                categories[categ] = content;
                counter++;
            }

            file.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            file.WriteLine(OutputChat.Text.Replace(System.Environment.NewLine, "\\r\\n"));
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

        /// <summary>
        /// Robot Response
        /// </summary>
        private async void ChakBot_Convo()
        {
            // Delay for aesthetics
            for (int i = 0; i < rnd.Next(1, 3); i++)
            {
                TypingDisplay.Text = "ChakBot is typing.";
                await Task.Delay(500);
                TypingDisplay.Text = "ChakBot is typing..";
                await Task.Delay(500);
                TypingDisplay.Text = "ChakBot is typing...";
                await Task.Delay(500);
            }

            if (tempText[historyIndex - 1] == "//help")
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                    "List of functions\r\n" +
                    "//clear >> clear the messages on screen\r\n" +
                    "teach >> teach chakbot (root;corres>message>corres>message)\r\n" + 
                    "e;n >> encrypt by shifting n times\r\n" +
                    "d;n >> decrypt by shifting n times\r\n"+ "\r\n");
                TypingDisplay.Text = "";
            }
            else if (tempText[historyIndex - 1] == "//clear")
            {
                OutputChat.Clear();
                TypingDisplay.Text = "";
            }
            else if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf('=') + 1).ToLower() == "teach=")
            {
                teach_chakbot(tempText[historyIndex - 1].Substring(6,
                    tempText[historyIndex - 1].Length - 6));
            }
            else if (tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf(';') + 1).ToLower() == "e;" ||
                tempText[historyIndex - 1].Substring(0, tempText[historyIndex - 1].IndexOf(';') + 1).ToLower() == "d;")
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                chakbot_en_de(tempText[historyIndex - 1].Substring(0, 1),
                               Int32.Parse(tempText[historyIndex - 1].Substring(2, tempText[historyIndex - 1].IndexOf('=') - 2)), 
                               tempText[historyIndex - 1].Substring(tempText[historyIndex - 1].IndexOf('=') + 1, 
                                                                        tempText[historyIndex - 1].Length - tempText[historyIndex - 1].IndexOf('=') - 1)) + "\r\n");
                TypingDisplay.Text = "";
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
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (prevIndex < historyIndex - 1)
                {
                    InputChat.Text = tempText[prevIndex + 1];
                    if (prevIndex != historyIndex - 1) { prevIndex++; }
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

            return "Sorry, I did not learn how to answer that =[. Please type //Help";
        }

        /// <summary>
        /// Adding info to ckabot's brain
        /// </summary>
        private void teach_chakbot(string learn)
        {
            // Format of teaching
            // categ>question>response
            List<string> disect = learn.Split('>').ToList();

            // Check format
            if (disect[0] == "" || disect[1] == "" || disect[2] == "" || disect[3] == "")
            {
                OutputChat.AppendText("ChakBot:\r\n >>> " +
                    "Please enter the correct format: teach=categ;corres>question>Rcateg>reponse" + "\r\n");
            }
            else
            {
                // If category exist
                if (categories.Keys.Contains(disect[0] + ";" + disect[2]))
                {
                    var text = new StringBuilder();

                    foreach (string s in System.IO.File.ReadAllLines(PATH))
                    {
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
                            disect[0] + ";" + disect[2] + "=" + disect[1] + Environment.NewLine);
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
                //categories.Add(categ, content);
                counter++;
            }

            read.Close();
        }

        private string chakbot_en_de(string action, int shiftNumber, string message)
        {
            // Initializing variables
            string[] AlphabetsU = new[] { "L", "B", "W", "F", "P", "X", "G", "D", "I", "A", "K", "J", "M", "V", "O", "E", "Q", "S", "Z", "U", "R", "N", "C", "H", "Y", "T" };
            string[] AlphabetsL = new[] { "z", "v", "g", "f", "w", "d", "h", "o", "i", "j", "c", "l", "k", "n", "m", "p", "e", "r", "y", "t", "s", "x", "b", "q", "a", "u" };
            string[] Numbers = new[] { "5", "9", "7", "3", "1", "6", "4", "8", "0", "2" };
            string[] Signs = new[] { "!", ">", "{", "$", "%", "'", "(", "*", "&", ")", "-", "_", "=", "+", "#", "}", "?", "/", ">", "]", ";", ":", "~", "`", ",", ".", "<", "@", "^" };

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
        private static string Shift(char letter, int shiftNumber, string action, string[] letterCase)
        {
            int index = Array.IndexOf(letterCase, letter.ToString());
            int newIndex = index + shiftNumber;

            if (action.Equals("e"))
            {
                if (newIndex > letterCase.Count() - 1)
                {
                    while (newIndex > letterCase.Count() - 1)
                    {
                        newIndex = newIndex - (letterCase.Count());
                    }
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
                    while (newIndex < 0)
                    {
                        newIndex = (letterCase.Count()) + newIndex;
                    }
                }
                else
                {
                    newIndex = index - shiftNumber;
                }
            }

            return letterCase[newIndex];
        }
    }
}
