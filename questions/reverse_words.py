"""
Your team is scrambling to decipher a recent message, worried it's a plot to break into a major European National Cake Vault.
The message has been mostly deciphered, but all the words are backward! Your colleagues have handed off the last step to you.

Write a function reverse_words() that takes a message as a list of characters and reverses the order of the words in place.

Why a list of characters instead of a string?

The goal of this question is to practice manipulating strings in place.
Since we're modifying the message, we need a mutable type like a list, instead of Python 3.6's immutable strings.

For example:

    message = [ 'c', 'a', 'k', 'e', ' ',
                'p', 'o', 'u', 'n', 'd', ' ',
                's', 't', 'e', 'a', 'l' ]

    reverse_words(message)

    # Prints: 'steal pound cake'
    print(''.join(message))

When writing your function, assume the message contains only letters and spaces, and all words are separated by one space.
"""

import unittest

def reverse_words(message):
    left, right = 0, 0
    reverse_chars(message, 0, len(message) - 1)
    while right < len(message):
        if message[right] == ' ':
            reverse_chars(message, left, right-1)
            right += 1
            left = right
        if right == len(message) - 1:
            reverse_chars(message, left, right)
        right += 1
    

def reverse_chars(message, left, right):
    while left < right:
        message[left], message[right] = message[right], message[left]
        left += 1
        right -= 1

# Tests

class Test(unittest.TestCase):

    def test_one_word(self):
        message = list('vault')
        reverse_words(message)
        expected = list('vault')
        self.assertEqual(message, expected)

    def test_two_words(self):
        message = list('thief cake')
        reverse_words(message)
        expected = list('cake thief')
        self.assertEqual(message, expected)

    def test_three_words(self):
        message = list('one another get')
        reverse_words(message)
        expected = list('get another one')
        self.assertEqual(message, expected)

    def test_multiple_words_same_length(self):
        message = list('rat the ate cat the')
        reverse_words(message)
        expected = list('the cat ate the rat')
        self.assertEqual(message, expected)

    def test_multiple_words_different_lengths(self):
        message = list('yummy is cake bundt chocolate')
        reverse_words(message)
        expected = list('chocolate bundt cake is yummy')
        self.assertEqual(message, expected)

    def test_empty_string(self):
        message = list('')
        reverse_words(message)
        expected = list('')
        self.assertEqual(message, expected)

unittest.main(verbosity=2)