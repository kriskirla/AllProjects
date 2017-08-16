import re
import random
import os

# This global variable is used to refresh every time new content is learned
CATEGORIES = {}
PATH = os.getcwd() + "/brain.txt"


def read_brain():
    """
    This function is used to read the brain.txt file so Chakbot knows how to respond

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


def get_message(user_input):
    """ This function will get messages as Chakbot's response

    Args:
        user_input (str): User's input

    Returns:
        str: the selected message
    """
    try:
        # Remove all non-ascii from user_input
        regex = re.compile('[^a-zA-Z ]')
        user_input = regex.sub('', user_input).lower()

        # Loop through all categories
        for i in CATEGORIES.keys():
            # Loop through all requests to see if it exists
            if user_input in CATEGORIES[i] and ';' not in i:
                # Special Interactions
                if i == "salute":
                    return 0
                elif i == "askingdate":
                    return 1
                elif i[:6] == "trivia":
                    print("Chakbot: " + CATEGORIES["r;" + i][CATEGORIES[i].index(user_input)])
                    return 2

                # For the rest of the messages
                return random.choice(CATEGORIES["r;" + i])

        # If it's not learned, ask to teach
        response = input("Chakbot: I did not learn how to respond to this. How should I respond? (or cancel)\r\nInput: ")

        # Make sure chakbot responses. Program can handle empty response, but I don't want that.
        while response == "":
            return "Cancelled"

        if response.lower() == "cancel":
            return "Cancelled Successfully"
        else:
            return teach("taught" + user_input.replace(' ', ''), user_input, response)
            
        # This is for random picks
        # if len(CATEGORIES) > 0:
        #    pick_categ, item = random.choice(list(CATEGORIES.items()))
        #    while ';' in pick_categ:
        #        pick_categ, item = random.choice(list(CATEGORIES.items()))
        #    return random.choice(item)
    except Exception:
        return "Something went wrong, please trace the steps you performed and report to developer."


def teach(categ, request, response):
    """ This function is to input information to brain.txt

    Args:
        categ (str) : Current category to teach
        request(str) : When the trigger the response
        response (str) : The response for the request

    Returns:
        str: The result of success of fail.
    """
    try:
        # Check to make sure no field is empty
        if request == "" or response == "":
            return "Please enter the correctly for each field."

        # Remove all non-ascii from user_input
        regex = re.compile('[^a-zA-Z0-9 ]')
        request = regex.sub('', request).lower()

        # If categ already exist
        if categ in CATEGORIES.keys():
            # Replace the original with original + new
            with open(PATH, 'r+') as f:
                # Locate line and replace
                lines = f.readlines()
                for i, line in enumerate(lines):
                    # This actually means no response wanted, just adding requests
                    if request != "":
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
    except Exception:
        return "Please make sure your format is correct. Check help for more details."
