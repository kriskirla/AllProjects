import random

def NumberHunter():
    ''' () -> None
    Runs the game of Number Hunter
    '''
    print("===== Welcome to Number Hunter! =====")
    status = 1
    mode = intro()
    while (status):
        if (mode == '0'):
            answer = difficulty()
            game(answer)
            mode = end_game()
        elif (mode == '1'):
            rules()
            mode = intro()
        elif (mode == '2'):
            status = 0
        else:
            print("Invalid Input.")
            mode = intro()


def intro():
    mode = input("Please choose the following (Enter number):\n(0) Start Game\n(1) Rules\n(2) Quit\n>> ")
    return mode


def rules():
    print("===== Rules =====\n" +
        "Objective:\n  Given a 3 digit number, you have 5 chances to guess it correctly.\n" + 
        "Example:\n  If the answer is 045\n  " + 
        "For each guesses you submit, the following hint will be displayed:\n  " + 
        "1) If a digit is guessed correctly and it is in the correct position, it's a Hit!\n    " +
        ">> 067, 1 Hit (Because 0 is correct and in the correct position)\n    " +
        ">> 047, 2 Hit (Because both 0 and 4 is correct and in the correct position)\n  " +
        "2) If a digit is guessed correctly but it is not in the correct position, it's a Blow!\n    " +
        ">> 437, 1 Blow (Because 4 is correct but is not in the correct position)\n    " +
        ">> 457, 2 Blow (Because both 4 and 5 is correct but not in the correct position)\n    " +
        ">> 450, 3 Blow (Because all are correct but none are in the correct position)\n  " +
        "3) If none of the three digits are correct, then it will display None.\n  " +
        "4) If you guessed the correct number, then it will display Correct.\n" + 
        "Note:\n  All digits are distinct, so each digits will not be the same number.\n==================")


def difficulty():
    level = 3
    while (level not in ['0', '1', '2']):
        level = input("Choose the difficulty (Enter number):\n" +
            "(0) Easy (Digits will be between 0-7)\n" +
            "(1) Normal (Digits will be between 0-8)\n" +
            "(2) Hard (Digits will be between 0-9)\n>> ")
    
    limit = 1
    if (level == '0'):
        limit += 7
    elif (level == '1'):
        limit += 8
    else:
        limit += 9

    x = random.randint(0,limit - 1)
    y = random.choice([i for i in range(0,limit) if i not in [x]])
    z = random.choice([i for i in range(0,limit) if i not in [x,y]])

    return str(x) + str(y) + str(z)


def game(answer):
    print("Please enter your initial guess (i.e 012):")
    count = 0
    guess = ""
    while (guess != answer and count < 5):
        guess = input(">> ")
        if (input_check(guess)):
            hit = 0
            blow = 0
            for i in range(0,3):
                if (guess[i] == answer[i]):
                    hit += 1
                elif (guess[i] in answer):
                    blow += 1
            if (hit == 3):
                print("==================\n" +
                    "Correct [Guess " + str(count + 1) + "]\n"+
                    "------------------")
            elif (hit == 0 and blow == 0):
                print("None [Guess #" + str(count + 1) + "]")
            else:
                print(str(hit) + " Hit  " + str(blow) + " Blow" + " [Guess " + str(count + 1) + "]")
        else:
            print("Invalid input, please try again!")
            count -= 1
        count += 1
    print("[Answer] " + answer + "\n==================")


def end_game():
    mode = input("What would you like to do?\n(0) Replay\n(1) Read Rules Again!\n(2) Quit\n>> ")
    return mode

def input_check(guess):
    if (len(guess) != 3):
        return 0

    try:
        int(guess)
    except:
        return 0

    return 1

# Start Game
if __name__ == "__main__":
    NumberHunter()