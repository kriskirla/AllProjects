from text_output import *
import random


def game_launcher(selection):
    """ This function is to decide which game to launch

    Args:
        selection (str) : Name of the game

    Returns:
        Nothing
    """
    if selection == "tic tac toe" or selection == '1':
        return tic_tac_toe(TIC_TAC_TOE, TIC_TAC_TOE_WIN_CONDITIONS)

    return "I don't know how to play that game yet =["


def tic_tac_toe(grid, cond):
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
    for case in cond:
        if player & case in cond:
            return 0
        elif len(moves) == 0:
            return 1

    return 2

