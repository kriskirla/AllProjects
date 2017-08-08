import random
import os
import re
import sys
import datetime

# Declare Global Variables
PATH = os.getcwd() + "/brain.txt"
CATEGORIES = {}

def main():
    read_brain()
    response_decider()


def read_brain():
    """
    This function is used to read the brain.txt file so Chakbot knows how to respond

    Args:
        path (str): The path to the brain.txt file

    Returns:
        (dict of str:list): All Categories read from brain
    """

    # Check if brain exist, if not then create it
    try:
        # Read file to list by lines
        with open(PATH) as f:
            lines = f.read().splitlines()

        # Get information for each line
        for i in lines:
            if i != "":
                category = i[:i.index('=')]
                content = i[i.index('=') + 1:].split(';')
                CATEGORIES[category] = content
    except FileNotFoundError:
        open(PATH, 'w')


def response_decider():
    """
    This will execute commands or reply base on user input

    Returns:
        Nothing
    """
    help_menu = str("ChakBot: " +
                    "List of functions\r\n" +
                    "====================================================\r\n" +
                    "//date\t| Display the current time\r\n" +
                    "//exit\t| Terminate Chakbot\r\n" +
                    "teach\t| Teach chakbot. Optional teach <category> \"<request>\" \"<response>\"\r\n" +
                    "encrypt\t| Encrypt a message. Optional: encrypt <message>\r\n" +
                    "decrypt\t| Decrypt a message with the key. Optional: decrypt <message> <key>\r\n" +
                    "morse\t| Encrypt/decrypt message into morse code. Optional: morse <message>\r\n" +
                    "calculate\t| Calculator. Optional: calculate <formula>\r\n" +
                    "convert\t| Convert units (#unit to unit). Optional: convert <number> <metric> to <metric>\r\n" +
                    "====================================================\r\n")

    print("====================================================\r\n" +
          "Chakbot: Hello! My name is Chakbot! <(^ O ^ v) \r\n" +
          "Type 'help' if you want to see the help menu.\r\n" +
          "====================================================\r\n")

    # User Input Analyzer
    while True:
        # Get user input
        user_input = input("User: ")

        if user_input.lower() == "help":
            print(help_menu)
        elif user_input == "//date":
            # Display date and time
            print('Chakbot: ' + str(datetime.datetime.now()))
        elif user_input == "//exit":
            # Always check if user wants to terminate
            sys.exit()
        elif user_input[0:9].lower() == "calculate":
            # Determine if formula follows after calculate, if not then prompt
            if len(user_input) <= 9:
                # Chakbot will request formula
                print('Chakbot: ' + str(calculate(input("Chakbot: Sure, what is your formula?\r\nUser: "))))
            else:
                # Formula following calculate
                print('Chakbot: ' + str(calculate(user_input[9:])))
        elif user_input[0:7].lower() == "convert":
            if len(user_input) <= 7:
                # Chakbot will request conversion
                print('Chakbot: ' + str(convert(input("Chakbot: Sure, what do you want to convert?\r\nUser: "))))
            else:
                # Conversion following convert
                print('Chakbot: ' + str(convert(user_input[7:])))
        elif user_input[0:7].lower() == "encrypt":
            if len(user_input) <= 7:
                # Chakbot will request message to encrypt
                print('Chakbot: ' + str(encrypt(input("Chakbot: Sure, what's the message?\r\nUser: "))))
            else:
                # Conversion following encrypt
                print('Chakbot: ' + str(encrypt(user_input[8:])))
        elif user_input[0:7].lower() == "decrypt":
            if len(user_input) <= 7:
                # Chakbot will request message and key to decrypt
                message = input("Chakbot: Sure, what's the message?\r\nUser: ")
                print('Chakbot: ' + str(decrypt(message, input("Chakbot: What's the key?\r\nUser: "))))
            else:
                # Conversion following decrypt
                print('Chakbot: ' + str(decrypt(user_input[8:user_input.rfind(' ')],
                                                user_input[user_input.rfind(' ') + 1:])))
        elif user_input[0:5].lower() == "morse":
            if len(user_input) <= 5:
                # Chakbot will request message to translate to morse
                print('Chakbot: ' + str(morse(input("Chakbot: Sure, what's the message?\r\nUser: "))))
            else:
                # Conversion following decrypt
                print('Chakbot: ' + str(morse(user_input[6:])))
        elif user_input[0:5].lower() == "teach":
            if len(user_input) <= 5:
                # Chakbot will request message to translate to morse
                categ = input("Chakbot: Sure, what's the category?\r\nUser: ")
                request = input("Chakbot: Okay, what's the request?\r\nUser: ")
                response = input("Chakbot: How should I response to it?\r\nUser: ")
                print('Chakbot: ' + str(teach(CATEGORIES, categ, request, response)))
            else:
                # Conversion following decrypt
                categ = user_input[6:][:user_input[6:].find(' ')]
                sec_1 = 6 + len(categ) + 2
                request = user_input[sec_1: sec_1 + user_input[sec_1:].find("\"")]
                sec_2 = sec_1 + len(request) + 2
                response = user_input[sec_2:len(user_input) - 1]

                print('Chakbot: ' + str(teach(CATEGORIES, categ, request, response)))
        else:
            # Get reply from brain
            print("Chakbot: " + get_message(CATEGORIES, user_input))


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
            # Loop through all requests to see if it exists
            if user_input in categories[i] and ';' not in i:
                return random.choice(categories["r;" + i])

        # If it's not learned, make a random guess
        # Pick random response category, then select any element
        if len(categories) > 0:
            pick_categ, item = random.choice(list(categories.items()))
            while ';' in pick_categ:
                pick_categ, item = random.choice(list(categories.items()))
            return random.choice(item)

        return "I don't know how to answer that, please teach me =]"
    except:
        return "Something went wrong, please trace the steps you performed and report to developer."


def teach(categories, categ, request, response):
    """ This function is to input information to brain.txt

    Args:
        categories (dict): Formula user inputted
        categ (str) : Current category to teach
        request(str) : When the trigger the response
        response (str) : The response for the request

    Returns:
        str: The result of success of fail.
    """
    try:
        # Remove all non-ascii from user_input
        regex = re.compile('[^a-zA-Z0-9 ]')
        request = regex.sub('', request).lower()
        response = regex.sub('', response).lower()

        # If categ already exist
        if categ in categories.keys():
            # Replace the original with original + new
            with open(PATH, 'r+') as f:
                # Locate line and replace
                lines = f.readlines()
                for i, line in enumerate(lines):
                    if request != "": # This actually means no response wanted, just adding requests
                        if line.startswith(categ):
                            lines[i] = line.replace('\n', '') + ';' + request + '\n'
                        if line.startswith("r;" + categ):
                            lines[i] = line.replace('\n', '') + ';' + response + '\n'
                    else:
                        # Only want more request
                        if line.startswith(categ):
                            lines[i] = line.replace('\n', '') + ';' + response + '\n'
                # Write result to file
                f.seek(0)
                for line in lines:
                    f.write(line)
        else:
            # If not, then add a new category
            with open(PATH, "a") as file:
                file.write(categ + "=" + request + "\n" + "r;" + categ + "=" + response + '\n')

        # Update CATEGORIES
        read_brain()

        return "Thank you, I've learned it!"
    except:
        return "Please make sure your format is correct. Check help for more details."


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
            'mi': 0.62137, 'mile': 0.62137, 'miles': 0.62137,
            'ft': 3280.84, 'feet': 3280.84,
            'in': 39370.1, 'inch': 39370.1,
            'yd': 1093.61, 'yard': 1093.61,
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
        m = re.search("[a-zA-Z]", user_input)
        unit_number = float(user_input[:m.start()])
        unit_1 = user_input[m.start():user_input.index('to')]
        unit_2 = user_input[user_input.index('to') + 2:]

        # Find out the metric category
        for i in Metrics.keys():
            if unit_1 in Metrics[i].keys() and unit_2 in Metrics[i].keys():
                return str(round(unit_number * (Metrics[i][unit_2] / Metrics[i][unit_1]), 3)) + \
                       unit_2 + " [" + i + " Conversion]"

        return "Please make sure the two units are convertible."
    except:
        return "Please check your syntax and make sure the unit is correct."


def encrypt(message):
    alpha_u = "LBWFPXGDIAKJMVOEQSZURNCHYT"
    alpha_l = "zvgfwdhoijclknmperytsxbqau"
    numbers = "5973164802"
    symbols = "!>{$%'(*&)-_=+#}?/<];:~`,.@^[|\" "
    code = ""
    res = ""

    try:
        # Encrypt, then shift each character by random
        for i in message:
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

        return res + " [" + code + ']'

    except:
        return "Encrpytion Error"


def decrypt(message, key):
    alpha_u = "LBWFPXGDIAKJMVOEQSZURNCHYT"
    alpha_l = "zvgfwdhoijclknmperytsxbqau"
    numbers = "5973164802"
    symbols = "!>{$%'(*&)-_=+#}?/<];:~`,.@^[|\" "
    dcode = key
    res = ""

    try:
        for i in range(0, len(message)):
            if message[i] in alpha_u or message[i] in alpha_l:
                if message[i].isupper():
                    # The code is actually read backwards for security
                    res += alpha_u[alpha_u.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
                else:
                    res += alpha_l[alpha_l.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
            elif message[i] in numbers:
                res += numbers[numbers.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
            elif message[i] in symbols:
                res += symbols[symbols.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
            else:
                res += message[i]

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
    message = user_input.split(" ")

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
