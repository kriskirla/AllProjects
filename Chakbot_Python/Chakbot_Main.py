from random import randint
import os

# Declare Global Variables
PATH = os.getcwd() + "/brain.txt"
COMMANDS = ["//help", "//clear", "//time", "teach=", "cal=", "convert=", "e;n=", "d;n=", "mc="]
CATEGORIES = {}
Metrics = {
    "Length": {
        "mm": 1000000,
        "cm": 100000,
        "m": 1000,
        "km": 1,
        "mi": 0.62137,
        "ft": 3280.84,
        "in": 39370.1,
        "yd": 1093.61
    },
    "Digital": {
        "b": 8,
        "B": 1,
        "KB": 1024,
        "MB": 1048576,
        "GB": 1073741824.0005517,
        "TB": 1099511627775.9133,
        "PB": 1125899906842782.8
    }
}


def main():
    read_brain(PATH)
    chakbot_conversaion()

def read_brain(path):
    # Check if brain exist, if not then create it
    try:
        # Read file to list by lines
        with open(path) as f:
            lines = f.read().splitlines()

        # Get information for each line
        for i in lines:
            category = i[:i.index('=')]
            content = i[i.index('=') + 1:].split(';')
            CATEGORIES[category] = content
    except FileNotFoundError:
        open(path, 'w')


def chakbot_conversaion():
    # Declare Chat
    userInput = ""

    print("====================================================\r\n" +
          "Chakbot: (v ^  O ^ )> Hello! My name is Chakbot!\r\n" +
          "====================================================\r\n")

    # Get user input
    userInput = input()
    


# Runs the code at launch
main()

