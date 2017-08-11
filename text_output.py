HELP_MENU = str("ChakBot: " +
                "List of functions\r\n" +
                "===========================================================\r\n" +
                "To see more details, type help <category>.\r\ni.e. help teach\r\n" +
                "---\r\n" +
                "//date\t| Display the current time\r\n" +
                "//exit\t| Terminate Chakbot\r\n" +
                "teach\t| Teach chakbot. Optional teach <category> \"<request>\" \"<response>\"\r\n" +
                "encrypt\t| Encrypt a message. Optional: encrypt <message>\r\n" +
                "decrypt\t| Decrypt a message with the key. Optional: decrypt <message> <key>\r\n" +
                "morse\t| Encrypt/decrypt message into morse code. Optional: morse <message>\r\n" +
                "calculate\t| Calculator. Optional: calculate <formula>\r\n" +
                "convert\t| Convert units. Optional: convert <number> <metric> to <metric>\r\n" +
                "game\t| Play built-in games. Optional: gmae <name of game>\r\n"
                "===========================================================\r\n")

HELP_EX = {
    "//date": "Format yyyy-mm-dd hr:min:sec.mili-sec",
    "//exit": "This will close the program.",
    "teach": "Usage 1: teach\r\nThis will guide the user step by step.\r\n\r\n" +
             "Usage 2: teach <category> \"<request>\" \"<response>\"\r\nThis is a faster shortcut.\r\n" +
             "Example: teach greeting \"Hello\" \"Hey Human!\"",
    "encrypt": "Usage 1: encrypt\r\nThis will guide the user step by step.\r\n\r\n" +
               "Usage 2: encrypt <message>\r\nThis is a faster shortcut.\r\n" +
               "Example: encrypt this message should be hidden!",
    "decrypt": "Usage 1: decrypt\r\nThis will guide the user step by step.\r\n\r\n" +
               "Usage 2: decrypt <message> <key>\r\nThis is a faster shortcut.\r\n" +
               "Example: decrypt blah blah blah blah 0123456789",
    "morse": "Usage 1: morse\r\nThis will guide the user step by step.\r\n\r\n" +
             "Usage 2: morse <message>\r\nThis is a faster shortcut.\r\n" +
             "Example: morse translate this to morse code",
    "calculate": "Usage 1: calculate\r\nThis will guide the user step by step.\r\n\r\n" +
                 "Usage 2: calculate <formula>\r\nThis is a faster shortcut.\r\n" +
                 "Example: calculate 1+1^3",
    "convert": "Usage 1: convert\r\nThis will guide the user step by step.\r\n\r\n" +
               "Usage 2: convert <conversion>\r\nThis is a faster shortcut.\r\n" +
               "Example: convert 3 cm to mm",
    "game": "Usage 1: game\r\nThis will guide the user step by step.\r\n\r\n" +
            "Usage 2: game <name of the game>\r\nThis is a faster shortcut.\r\n" +
            "Example: game tictactoe",
}

INTRO = str("====================================================\r\n" +
            "Hello! My name is Chakbot! <(^ O ^ v) \r\n" +
            "Type 'help' if you want to see the help menu.\r\n" +
            "====================================================\r\n")
