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

GAMES_MENU = str("Chakbot: Sure, here are the games\r\n" +
                 "1. Tic Tac Toe\r\n" +
                 "2. Trivia\r\n"
)

INTRO = str("====================================================\r\n" +
            "Hello! My name is Chakbot! <(^ O ^ v) \r\n" +
            "Type 'help' if you want to see the help menu.\r\n" +
            "====================================================\r\n")

METRICS = {
    'Length': {
        'mm': 1000000,
        'cm': 100000,
        'm': 1000,
        'km': 1,
        'mi': 0.62137, 'mile': 0.62137, 'miles': 0.62137,
        'ft': 3280.84, 'feet': 3280.84,
        'in': 39370.1, 'inch': 39370.1,
        'yd': 1093.61, 'yard': 1093.61,
    },
    'Digital': {
        'b': 8,
        'B': 1000000,
        'KB': 1000,
        'MB': 1,
        'GB': 0.001,
        'TB': 0.000001,
        'PB': 0.000000001
    },
    'Mass': {
        'lb': 0.00220462,
        'oz': 0.035274,
        'mg': 1000,
        'g': 1,
        'kg': 0.001
    },
    "Volume": {
        'tsp': 202.884,
        'tbsp': 62.628,
        'c': 4.16667,
        'ml': 1000,
        'l': 1,
        'pt': 2.11338,
        'gal': 0.264172
    }
}

TIC_TAC_TOE = str("\r\n q | w | e \r\n" +
                  "-----------\r\n" +
                  " a | s | d \r\n" +
                  "-----------\r\n" +
                  " z | x | c \r\n")

TIC_TAC_TOE_WIN_CONDITIONS = [
    # Columns
    {'q', 'a', 'z'}, {'w', 's', 'x'}, {'e', 'd', 'c'},
    # Rows
    {'q', 'w', 'e'}, {'a', 's', 'd'}, {'z', 'x', 'c'},
    # Diagonals
    {'q', 's', 'c'}, {'z', 's', 'e'}
]

TRIVIA_CATEGORIES = str(
    "Chakbot: Sure! Which category do you like?\r\n" +
    "1. Geography\r\n" +
    "2. Science\r\n" +
    "3. History\r\n" +
    "4. Art\r\n" +
    "5. Music\r\n" +
    "6. Cultural\r\n" +
    "7. Technology\r\n" +
    "8. Religion\r\n"
)

TRIVIA_CORRESPONDENCE = {
    '1': "trivia_geography",
    '2': "trivia_science",
    '3': "trivia_history",
    '4': "trivia_art",
    '5': "trivia_music",
    '6': "trivia_culture",
    '7': "trivia_technology",
    '8': "trivia_religion"
}

TRIVIA_ANSWER = {
    "trivia_geography": ['1', '2', '2', '4', '4', '4', '1', '1'],
    "trivia_science": ['3', '2', '2', '3', '1', '1', '3', '3'],
    "trivia_history": ['3', '4', '2', '2', '4', '3', '2', '1'],
    "trivia_art": ['4', '2', '3', '2', '2'],
    "trivia_music": ['2', '2', '4', '2', '3', '4', '3', '3', '3'],
    "trivia_culture": ['3', '4', '4', '2', '1', '2'],
    "trivia_technology": ['4', '4', '2', '2', '3', '2', '3', '2', '4', '4', '4'],
    "trivia_religion": ['2', '1', '3', '2', '1']
}
