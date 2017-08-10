import os
import sys
import datetime
from Chakbot_Python.cryptography import *
from Chakbot_Python.extra_tools import *
from Chakbot_Python.learning import *


def main():
    path = os.getcwd() + "/brain.txt"
    response_decider(path)


def response_decider(path):
    """
    This will execute commands or reply base on user input

    Args:
        categories (dict) : All the content in brain.txt

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

    # First Initialization
    read_brain(path)

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
                print('Chakbot: ' + str(teach(path, categ, request, response)))
            else:
                # Conversion following decrypt
                categ = user_input[6:][:user_input[6:].find(' ')]
                sec_1 = 6 + len(categ) + 2
                request = user_input[sec_1: sec_1 + user_input[sec_1:].find("\"")]
                sec_2 = sec_1 + len(request) + 3
                response = user_input[sec_2:len(user_input) - 1]

                print('Chakbot: ' + str(teach(path, categ, request, response)))
        else:
            # Get reply from brain
            print("Chakbot: " + get_message(user_input))


# Runs the code at launch
main()
