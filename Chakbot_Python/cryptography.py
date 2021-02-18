import random


def encrypt(message):
    alpha_u = "LBWFPXGDIAKJMVOEQSZURNCHYT"
    alpha_l = "zvgfwdhoijclknmperytsxbqau"
    numbers = "5973164802"
    symbols = "!>{$%'(*&)-_=+#}?/<];:~`,.@^[|\" "
    code = ""
    res = ""

    try:
        # Encrypt, then shift each character by random
        for i in message:
            pick = random.randint(0, 9)
            code = str(pick) + code

            if i in alpha_u or i in alpha_l:
                if i.isupper():
                    res += alpha_u[(alpha_u.index(i) + pick) % 26]
                else:
                    res += alpha_l[(alpha_l.index(i) + pick) % 26]
            elif i in numbers:
                res += numbers[(numbers.index(i) + pick) % 10]
            elif i in symbols:
                res += symbols[(symbols.index(i) + pick) % 32]
            else:
                res += i
                code = "0" + code[1:]

        return res + " [" + code + ']'

    except Exception:
        return "Encrpytion Error"


def decrypt(message, key):
    alpha_u = "LBWFPXGDIAKJMVOEQSZURNCHYT"
    alpha_l = "zvgfwdhoijclknmperytsxbqau"
    numbers = "5973164802"
    symbols = "!>{$%'(*&)-_=+#}?/<];:~`,.@^[|\" "
    dcode = key
    res = ""

    try:
        for i in range(0, len(message)):
            if message[i] in alpha_u or message[i] in alpha_l:
                if message[i].isupper():
                    # The code is actually read backwards for security
                    res += alpha_u[alpha_u.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
                else:
                    res += alpha_l[alpha_l.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
            elif message[i] in numbers:
                res += numbers[numbers.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
            elif message[i] in symbols:
                res += symbols[symbols.index(message[i]) - int(dcode[len(dcode) - 1 - i])]
            else:
                res += message[i]

        return res
    except:
        return "Decryption Error"


def morse(user_input):
    morse_table = {
        'a': ".-", 'b': "-...", 'c': "-.-.", 'd': "-..", 'e': ".", 'f': "..-.", 'g': "--.", 'h': "....", 'i': "..",
        'j': ".---", 'k': "-.-", 'l': ".-..", 'm': "--", 'n': "-.", 'o': "---", 'p': ".--.", 'q': "--.-", 'r': ".-.",
        's': "...", 't': "-", 'u': "..-", 'v': "...-", 'w': ".--", 'x': "-..-", 'y': "-.--", 'z': "--..",
        '1': ".----", '2': "..---", '3': "...--", '4': "....-", '5': ".....",
        '6': "-....", '7': "--...", '8': "---..", '9': "----.", '0': "-----"
    }
    res = ""
    message = user_input.lower().split(" ")

    try:
        for i in range(0, len(message)):
            # Check if morse code
            if message[i] in morse_table.values():
                res += next(key for key, value in morse_table.items() if value == message[i])
            elif message[i] == "":
                res += " "
            else:
                for j in message[i]:
                    if j in morse_table.keys():
                        res += morse_table[j] + " "
                    else:
                        res += j + " "
                # End of word
                res += " "

        return res.rstrip()
    except Exception:
        print("Morse Code Error")
