def response_decider():
    """
    This will execute commands or reply base on user input

    Returns:
        Nothing
    """
    # Begin Application
    print(INTRO)

    # User Input Analyzer
    while True:
        # Get user input
        user_input = input("User: ")

        if user_input.lower() == "help":
            print(HELP_MENU)
        elif user_input[:4].lower() == "help" and user_input[5:] in HELP_EX.keys():
            print("{\r\n" + HELP_EX[user_input[5:]] + "\r\n}\r\n")
        elif user_input == "//exit":
            # Always check if user wants to terminate
            sys.exit()
        elif user_input[:9].lower() == "calculate":
            # Determine if formula follows after calculate, if not then prompt
            if len(user_input) <= 9:
                # Chakbot will request formula
                print('Chakbot: ' + str(calculate(input("Chakbot: Sure, what is your formula?\r\nFormula: "))))
            else:
                # Formula following calculate
                print('Chakbot: ' + str(calculate(user_input[9:])))
        elif user_input[:7].lower() == "convert":
            if len(user_input) <= 7:
                # Chakbot will request conversion
                print('Chakbot: ' + str(convert(input("Chakbot: Sure, what do you want to convert?\r\nConversion: "))))
            else:
                # Conversion following convert
                print('Chakbot: ' + str(convert(user_input[7:])))
        elif user_input[:7].lower() == "encrypt":
            if len(user_input) <= 7:
                # Chakbot will request message to encrypt
                print('Chakbot: ' + str(encrypt(input("Chakbot: Sure, what's the message?\r\nMessage: "))))
            else:
                # Conversion following encrypt
                print('Chakbot: ' + str(encrypt(user_input[8:])))
        elif user_input[:7].lower() == "decrypt":
            if len(user_input) <= 7:
                # Chakbot will request message and key to decrypt
                message = input("Chakbot: Sure, what's the message?\r\nMessage: ")
                print('Chakbot: ' + str(decrypt(message, input("Chakbot: What's the key?\r\nKey: "))))
            else:
                # Conversion following decrypt
                print('Chakbot: ' + str(decrypt(user_input[8:user_input.rfind(' ')],
                                                user_input[user_input.rfind(' ') + 1:])))
        elif user_input[:5].lower() == "morse":
            if len(user_input) <= 5:
                # Chakbot will request message to translate to morse
                print('Chakbot: ' + str(morse(input("Chakbot: Sure, what's the message?\r\nMessage: "))))
            else:
                # Conversion following decrypt
                print('Chakbot: ' + str(morse(user_input[6:])))
        elif user_input[:5].lower() == "teach":
            if len(user_input) <= 5:
                # Chakbot will request message to translate to morse
                categ = input("Chakbot: Sure, what's the category?\r\nCategory: ")
                request = input("Chakbot: Okay, what's the request?\r\nMessage: ")
                response = input("Chakbot: How should I response to it?\r\nMessage: ")
                print('Chakbot: ' + str(teach(categ, request, response)))
            else:
                # Conversion following decrypt
                categ = user_input[6:][:user_input[6:].find(' ')]
                sec_1 = 6 + len(categ) + 2
                request = user_input[sec_1: sec_1 + user_input[sec_1:].find("\"")]
                sec_2 = sec_1 + len(request) + 3
                response = user_input[sec_2:len(user_input) - 1]
                print('Chakbot: ' + str(teach(categ, request, response)))
        elif user_input[:4].lower() == "game":
            if len(user_input) <= 4:
                # Chakbot will request message to translate to morse
                print(GAMES_MENU)
                print(str(game_launcher(input("Chakbot: Which game would you like to play?\r\nInput: "))))
            else:
                # Conversion following decrypt
                print('Chakbot: ' + str(game_launcher(user_input[5:])))
        else:
            # Get reply from brain
            reply = get_message(user_input)

            # For if user wants to stop talking
            if reply == 0:
                option = input("Chakbot: Do you want to leave me? (y/n) <(T ^ T v)\r\nOption: ")
                if option == 'y':
                    print(str("Chakbot: " + random.choice(CATEGORIES["r;salute"])))
                    sys.exit()
                elif option == 'n':
                    print("Chakbot: Yay! We can continue talking ^( ^ o ^ )>")
                else:
                    print("Chakbot: That's not a valid option, so you are staying with me.")
            elif reply == 1:
                # For asking dates
                print("Chakbot: " + random.choice(CATEGORIES["r;askingdate"]) + " " + str(datetime.datetime.now()))
            elif reply == 2:
                # Placeholder for corresponding trivia
                pass
            else:
                # For all responses
                print("Chakbot: " + reply)


if __name__ == "__main__":
    import sys
    import datetime
    from text_output import *
    from learning import *
    from cryptography import *
    from extra_tools import *
    from games import *

    # First Initialization
    read_brain()
    response_decider()
