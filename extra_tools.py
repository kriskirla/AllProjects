import re


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
    metrics = {
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
        for i in metrics.keys():
            if unit_1 in metrics[i].keys() and unit_2 in metrics[i].keys():
                return str(round(unit_number * (metrics[i][unit_2] / metrics[i][unit_1]), 3)) + \
                       unit_2 + " [" + i + " Conversion]"

        return "Please make sure the two units are convertible."
    except:
        return "Please check your syntax and make sure the unit is correct."
