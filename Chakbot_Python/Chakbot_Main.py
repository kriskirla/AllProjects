import random
import os
import re
import sys
import datetime

# Declare Global Variables
PATH = os.getcwd() + "/brain.txt"


def main():
    categories = read_brain(PATH)
    chakbot_conversation(categories)


def read_brain(path):
    """
    This function is used to read the brain.txt file so Chakbot knows how to respond

    Args:
        path (str): The path to the brain.txt file

    Returns:
        (dict of str:list): All Categories read from brain
    """
    categories = {}

    # Check if brain exist, if not then create it
    try:
        # Read file to list by lines
        with open(path) as f:
            lines = f.read().splitlines()

        # Get information for each line
        for i in lines:
            category = i[:i.index('=')]
            content = i[i.index('=') + 1:].split(';')
            categories[category] = content
    except FileNotFoundError:
        open(path, 'w')

    return categories


def chakbot_conversation(categories):
    """
    This will execute commands or reply base on user input

    Args:
        categories (dict of str: list): All categories

    Returns:
        Nothing
    """
    help_menu = str("ChakBot: " +
                    "List of functions\r\n" +
                    "====================================================\r\n" +
                    "//date\t| Display the current time\r\n" +
                    "//exit\t| Terminate Chakbot\r\n" +
                    "teach=\t| Teach chakbot (root>message>corres>message)\r\n" +
                    "e=\t\t| Encrypt the message inserted after =\r\n" +
                    "d;c=\t| Decrypt with the code c\r\n" +
                    "mc=\t\t| Encrypt/decrypt message into morse code\r\n" +
                    "cal=\t| Calculate\r\n" +
                    "con=\t| Convert units (#unit to unit)\r\n" +
                    "====================================================\r\n")

    commands = {"//help": "print(help_menu)",
                "//date": "print('Chakbot: ' + datetime.datetime.now())",
                "teach": "print('Chakbot: ' + teach(user_input[user_input.index('=') + 1:]))",
                "cal": "print('Chakbot: ' + calculate(user_input[user_input.index('=') + 1:]))",
                "con": "print('Chakbot: ' + convert(user_input[user_input.index('=') + 1:]))",
                "e": "print('Chakbot: ' + encrypt(user_input[user_input.index('=') + 1:]))",
                "d;c": "print('Chakbot: ' + decrypt(user_input[user_input.index(';') + 1:user_input.index('=')], " +
                       "user_input[user_input.index('=') + 1:]))",
                "mc": "print('Chakbot: ' + morse(user_input[user_input.index('=') + 1:]))"}

    print("====================================================\r\n" +
          "Chakbot: (v ^  O ^ )> Hello! My name is Chakbot!\r\n" +
          "Type //help if you need help.\r\n" +
          "====================================================\r\n")

    # User Input Analyzer
    while True:
        # Get user input
        user_input = input("User: ")

        if user_input == "//exit":
            # Always check if user wants to terminate
            sys.exit()
        elif user_input in commands.keys():
            # Check if user commands
            exec(commands[user_input])
        elif '=' in user_input and user_input[0:2] == "d;":
            # Since decrypt has its own format
            exec(commands["d;c"])
        elif '=' in user_input and user_input[:user_input.index('=')] in commands:
            # Check if user wants Chakbot Functionality
            exec(commands[user_input[:user_input.index('=')]])
        else:
            # Get reply from brain
            print("Chakbot: " + get_message(categories, user_input))


def get_message(categories, user_input):
    """ This function will get messages as Chakbot's response

    Args:
        categories (dict of str:list): All categories
        user_input (str): User's input

    Returns:
        str: the selected message
    """
    try:
        # Remove all non-ascii from user_input
        regex = re.compile('[^a-zA-Z ]')
        user_input = regex.sub('', user_input).lower()

        # Loop through all categories
        for i in categories.keys():
            # Check if category is question or response. ; is questions
            if (';' in i) and (user_input in categories[i]):
                question = i[:i.index(';')]
                response = i[i.index(';') + 1:]

                # If question = response, then it must be a greeting
                if question == response:
                    pick = random.choice(categories[i])
                    return pick
                else:
                    pick = random.choice(categories[response])
                    return pick

        # If it's not learned, make a random guess
        # Pick random response category, then select any element
        if (len(categories) > 0):
            pick_categ, item = random.choice(list(categories.items()))
            while ';' in pick_categ:
                pick_categ, item = random.choice(list(categories.items()))
            return random.choice(item)

        return "I don't know how to answer that, please teach me =]"
    except:
        return "Something went wrong, please trace the steps you performed and report to developer."


def teach(user_input):
    return 'works' + user_input


def calculate(user_input):
    """ This function is to calculate user inputted formula

    Args:
        user_input (str): Formula user inputted

    Returns:
        str: The result after evaluation
    """
    try:
        return eval(user_input.replace('^', "**"))
    except:
        return 'Please check your syntax'


def convert(user_input):
    """ This function will take user input and convert units

    Args:
        user_input (str): User input with conversion format

    Returns:
        str: The result after the conversion
    """
    Metrics = {
        'Length': {
            'mm': 1000000,
            'cm': 100000,
            'm': 1000,
            'km': 1,
            'mi': 0.62137,
            'ft': 3280.84,
            'in': 39370.1,
            'yd': 1093.61
        },
        'Digital': {
            'b': 8,
            'B': 1,
            'KB': 1024,
            'MB': 1048576,
            'GB': 1073741824.0005517,
            'TB': 1099511627775.9133,
            'PB': 1125899906842782.8
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

    try:
        # Parse string
        user_input = user_input.replace(" ", "")
        m = re.search("[a-z]", user_input)
        unit_number = float(user_input[:m.start()])
        unit_1 = user_input[m.start():user_input.index('to')]
        unit_2 = user_input[user_input.index('to') + 2:]

        # Find out the metric category
        for i in Metrics.keys():
            if unit_1 in Metrics[i].keys() and unit_2 in Metrics[i].keys():
                return str(unit_number * (Metrics[i][unit_2] / Metrics[i][unit_1])) + unit_2 + " [" + i + " Conversion]"

        return "Please make sure the two units are convertible."
    except:
        return "Please check your syntax and make sure the unit is correct."


def encrypt(user_input):
    alpha_u = "LBWFPXGDIAKJMVOEQSZURNCHYT"
    alpha_l = "zvgfwdhoijclknmperytsxbqau"
    numbers = "5973164802"
    symbols = "!>{$%'(*&)-_=+#}?/<];:~`,.@^[|\" "
    code = ""
    res = ""

    try:
        # Encrypt, then shift each character by random
        for i in user_input:
            pick = random.randint(0, 9)
            code = str(pick) + code

            if i in alpha_u or i in alpha_l:
                if i.isupper():
                    res += alpha_u[(alpha_u.index(i) + pick) % 26]
                else:
                    res += alpha_l[(alpha_l.index(i) + pick) % 26]
            elif i in numbers:
                res += numbers[(numbers.index(i) + pick) % 10]
            elif i in symbols:
                res += symbols[(symbols.index(i) + pick) % 32]
            else:
                res += i
                code = "0" + code[1:]

        return res + " [" + morse(code) + ']'

    except:
        return "Encrpytion Error"


def decrypt(code, user_input):
    alpha_u = "LBWFPXGDIAKJMVOEQSZURNCHYT"
    alpha_l = "zvgfwdhoijclknmperytsxbqau"
    numbers = "5973164802"
    symbols = "!>{$%'(*&)-_=+#}?/<];:~`,.@^[|\" "
    dcode = morse(code)
    res = ""

    try:
        for i in range(0, len(user_input)):
            if user_input[i] in alpha_u or user_input[i] in alpha_l:
                if user_input[i].isupper():
                    # The code is actually read backwards for security
                    res += alpha_u[alpha_u.index(user_input[i]) - int(dcode[len(dcode) - 1 - i])]
                else:
                    res += alpha_l[alpha_l.index(user_input[i]) - int(dcode[len(dcode) - 1 - i])]
            elif user_input[i] in numbers:
                res += numbers[numbers.index(user_input[i]) - int(dcode[len(dcode) - 1 - i])]
            elif user_input[i] in symbols:
                res += symbols[symbols.index(user_input[i]) - int(dcode[len(dcode) - 1 - i])]
            else:
                res += user_input[i]

        return res
    except:
        return "Decryption Error"


def morse(user_input):
    morse_table = {
        'a': ".-", 'b': "-...", 'c': "-.-.", 'd': "-..", 'e': ".", 'f': "..-.", 'g': "--.", 'h': "....", 'i': "..",
        'j': ".---", 'k': "-.-", 'l': ".-..", 'm': "--", 'n': "-.", 'o': "---", 'p': ".--.", 'q': "--.-", 'r': ".-.",
        's': "...", 't': "-", 'u': "..-", 'v': "...-", 'w': ".--", 'x': "-..-", 'y': "-.--", 'z': "--..",
        '1': ".----", '2': "..---", '3': "...--", '4': "....-", '5': ".....",
        '6': "-....", '7': "--...", '8': "---..", '9': "----.", '0': "-----"
    }
    res = ""
    message = user_input.lower().split(" ")

    try:
        for i in range(0, len(message)):
            # Check if morse code
            if message[i] in morse_table.values():
                res += next(key for key, value in morse_table.items() if value == message[i])
            elif message[i] == "":
                res += " "
            else:
                for j in message[i]:
                    if j in morse_table.keys():
                        res += morse_table[j] + " "
                    else:
                        res += j + " "
                # End of word
                res += " "

        return res.rstrip()
    except:
        print("Morse Code Error")


# Runs the code at launch
main()
