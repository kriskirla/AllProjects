import re
from text_output import METRICS


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

    try:
        # Parse string
        user_input = user_input.replace(" ", "")
        m = re.search("[a-zA-Z]", user_input)
        unit_number = float(user_input[:m.start()])
        unit_1 = user_input[m.start():user_input.index('to')]
        unit_2 = user_input[user_input.index('to') + 2:]

        # Find out the metric category
        for i in METRICS.keys():
            if unit_1 in METRICS[i].keys() and unit_2 in METRICS[i].keys():
                return str(round(unit_number * (METRICS[i][unit_2] / METRICS[i][unit_1]), 3)) + \
                       unit_2 + " [" + i + " Conversion]"

        return "Please make sure the two units are convertible."
    except:
        return "Please check your syntax and make sure the unit is correct."
