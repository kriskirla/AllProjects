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

    try:
        if selection == "tic tac toe" or selection == '1':
            return tic_tac_toe(TIC_TAC_TOE, TIC_TAC_TOE_WIN_CONDITIONS)
        if selection == "trivia" or selection == '2':
            return trivia(CATEGORIES)

        return "I don't know how to play that game yet =["
    except:
        return "Something went wrong, please report to developer."


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

    # Difficulty
    difficulty = input("1) Jokes\r\n2) Impossible\r\nDifficulty: ")
    if not (difficulty == '1' or difficulty == '2' or
            difficulty.lower() == "jokes" or difficulty.lower() == "impossible"):
        return "That's not a valid option. Game Terminated."

    # Request player order
    player = input("Do you want to go first or second (1 or 2)\r\nUser: ")
    if not (player == '1' or player == '2' or player.lower() == "first" or player.lower() == "second"):
        return "Cheater! Game terminated."

    # Game Begins
    # If player goes first
    if player == '2' or player.lower() == "second":
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
                grid = grid.replace(move, 'X')
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
            if difficulty == '1' or difficulty.lower() == "easy":
                # Easy
                move = random.sample(moves, 1)[0]
            else:
                # Hard
                move = ttt_optimize(chakbot, user, cond, moves)

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
        # Player wins
        if player & case in cond:
            return 0
        # Tie
        elif len(moves) == 0:
            return 1
    # Neither
    return 2


def ttt_optimize(chakbot, user, cond, moves):
    # First check if Chakbot can win
    for i in moves:
        if tic_tac_toe_checker(chakbot | {i}, cond, moves - {i}) == 0:
            return i

    # If not, then check if player can win
    for i in moves:
        if tic_tac_toe_checker(user | {i}, cond, moves - {i}) == 0:
            return i

    # If not, place the next most probable winning move (Diagonal first then horizontal
    # Middle is most probable
    if 's' in moves:
            return 's'

    # Block 2-ways
    if {'q', 'c'} | user == user or {'z', 'e'} | user == user:
        if 'w' in moves: return 'w'
        elif 'a' in moves: return 'a'
        elif 'x' in moves: return 'x'
        elif 'd' in moves: return 'd'

    # Diagonal next to user then v/h
    # Have to do both ways since set has no order
    if 'q' in moves and 'c' in moves:
        if 'w' in user or 'a' in user:
            return 'q'
        else:
            return 'c'
    elif 'e' in moves and 'z' in moves:
        if 'w' in user or 'd' in user:
            return 'e'
        else:
            return 'z'
    elif 'w' in moves and 'x' in moves:
        return 'w' or 'x'
    elif 'a' in moves and 'd' in moves:
        return 'a' or 'd'

    # This will always end in tie
    return random.sample(moves, 1)[0]


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

            confirm = input("Chakbot: Same Category? (y/n)\r\nOption: ").lower()

            if confirm == 'n':
                same = False
            elif confirm != 'y':
                print("Guessing that's a no")
                same = False
