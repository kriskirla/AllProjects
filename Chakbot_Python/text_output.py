HELP_MENU = str("ChakBot: " +
                "List of functions\r\n" +
                "===========================================================\r\n" +
                "To see usage and details, type help <category>\r\n" +
                "i.e. help teach\r\n" +
                "-----------------------------------------------------------\r\n" +
                "//exit\t\t| Terminate Chakbot\r\n" +
                "teach\t\t| Teach chakbot how to respond\r\n"
                "encrypt\t\t| Encrypt a message\r\n" +
                "decrypt\t\t| Decrypt a message with the key\r\n" +
                "morse\t\t| Translate message into morse code\r\n" +
                "calculate\t| Built-in Calculator\r\n" +
                "convert\t\t| Convert units\r\n" +
                "game\t\t| Play built-in games\r\n"
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
            "Usage 2: game <name/id of the game>\r\nThis is a faster shortcut.\r\n" +
            "Example: game tictactoe\r\n" +
            "Example: game 1"
}

INTRO = str("====================================================\r\n" +
            "Hello! My name is Chakbot! <(^ O ^ v) \r\n" +
            "Type 'help' if you want to see the help menu.\r\n" +
            "====================================================\r\n")

TIC_TAC_TOE = str("\r\n q | w | e \r\n" +
                  "-----------\r\n" +
                  " a | s | d \r\n" +
                  "-----------\r\n" +
                  " z | x | c \r\n")

TIC_TAC_TOE_WIN_CONDITIONS = [
    # Columns
    {'q', 'a', 's'}, {'w', 's', 'x'}, {'e', 'd', 'c'},
    # Rows
    {'q', 'w', 'e'}, {'a', 's', 'd'}, {'z', 'x', 'c'},
    # Diagonals
    {'q', 's', 'c'}, {'z', 's', 'e'}
]



