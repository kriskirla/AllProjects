from text_output import *
from learning import CATEGORIES
import random


def game_launcher(selection):
    """ This function is to decide which game to launch

    Args:
        selection (str) : Name of the game

    Returns:
        Message of termination corresponding to each game
    """
    selection = selection.lower()

    if selection == "tic tac toe" or selection == '1':
        return tic_tac_toe(TIC_TAC_TOE, TIC_TAC_TOE_WIN_CONDITIONS)
    if selection == "trivia" or selection == '2':
        return trivia(CATEGORIES)

    return "I don't know how to play that game yet =["


def tic_tac_toe(grid, cond):
    """ TIC TAC TOE GAME

    Args:
        grid (str): This is the string representation of Tic Tac Toe
        cond (list): This holds all of the winning conditions

    Return:
        Message of termination
    """
    moves = {'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c'}
    winner = ""
    user = set()
    chakbot = set()

    # Request player order
    player = input("Do you want to go first or second (1 or 2)\r\nUser: ")
    if not (player == '1' or player == '2'):
        return "Cheater! Game terminated."

    # Game Begins
    # If player goes first
    if player == '2':
        chakbot.add('s')
        moves.remove('s')
        grid = grid.replace('s', 'O')

    while winner == "":
        # Display Grid
        print(grid)

        # Request for next move
        valid = False
        while not valid:
            move = input("Your Move: ")

            if move in moves:
                grid = grid.replace(move, '#')
                user.add(move)
                moves.remove(move)
                valid = True
            else:
                print("Chakbot: That's not a valid move, try again!\r\n")
                print(grid)

        # Check if there's a winner
        status = tic_tac_toe_checker(user, cond, moves)
        if status == 0:
            winner = "You won!"
        elif status == 1:
            winner = "We tied =["

        # If no winner, continue
        if winner == "":
            move = random.sample(moves, 1)[0]
            grid = grid.replace(move, 'O')
            chakbot.add(move)
            moves.remove(move)

        # Check again after Chakbot moves
        status = tic_tac_toe_checker(chakbot, cond, moves)
        if status == 0:
            winner = "I won!"
        elif status == 1:
            winner = "We tied =["

    # Display winning result
    print(grid)

    return winner


def tic_tac_toe_checker(player, cond, moves):
    """ Game Status Checker

    Args:
        player (str): The current player
        cond (list): This holds all of the winning conditions
        moves (list): All available moves

    Return:
        The status of the game
    """
    for case in cond:
        if player & case in cond:
            return 0
        elif len(moves) == 0:
            return 1

    return 2


def trivia(categories):
    """ Trivia Game

    Args:
        categories (dict): All of the available categories

    Return:
        Message of termination
    """
    while True:
        # Menu
        print(TRIVIA_CATEGORIES)
        category = ""

        # Pick Category
        while True:
            selection = input("Category: ").lower()

            if selection in categories:
                category = "trivia" + selection
                break
            if selection in TRIVIA_CORRESPONDENCE.keys():
                category = TRIVIA_CORRESPONDENCE[selection]
                break

            print("Please pick one of the available categories =]\r\n")

        # Game Begins
        same = True
        while same:
            pick = random.randint(0, len(categories[category]) - 1)
            print("\r\nQuestion: " + categories[category][pick] + "?\r\n")
            print(categories["q;" + category][pick] + "\r\n")
            answer = input("Answer: ").lower()

            # Adding separator to look better
            print("-----")

            if answer == categories["r;" + category][pick].lower():
                print("Chakbot: That is correct!\r\n\r\n" + categories["t;" + category][pick])
            elif answer == TRIVIA_ANSWER[category][pick]:
                print("Chakbot: That is correct!\r\n\r\n" + categories["t;" + category][pick])
            else:
                print("Chakbot: That is incorrect!\r\nChakbot: The Answer is " + categories["r;" + category][pick] +
                      "\r\n\r\n" + categories["t;" + category][pick])

            print("-----\r\n")

            # Prompt user to play again
            terminate = str(input("Chakbot: Would you like to play again? (y/n)\r\nOption: ")).lower()

            if terminate == 'n':
                return "Thanks for playing!"
            elif terminate != 'y':
                return "I'll take that as a no =["

            confirm = input("Chakbot: Same Category?\r\nOption: ").lower()

            if confirm == 'n':
                same = False
            elif confirm != 'y':
                print("Guessing that's a no")
                same = False
