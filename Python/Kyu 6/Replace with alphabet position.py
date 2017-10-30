import string

def _character_index(character):
    try:
        return string.ascii_letters.index(character)+1
    except ValueError:
        return None

def _append(positions, character):
    position = _character_index(character)
    if position:
        positions.append(str(position))

def alphabet_position(text):

    positions = []
    for c in text.lower():
        _append(positions, c)

    return " ".join(positions)


#-------------------------------------------------------------------------------

import test

from random import randint
test.assert_equals(alphabet_position("The sunset sets at twelve o' clock."), "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11")
test.assert_equals(alphabet_position("The narwhal bacons at midnight."), "20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20")

number_test = ""
for item in range(10):
    number_test += str(randint(1, 9))
test.assert_equals(alphabet_position(number_test), "")