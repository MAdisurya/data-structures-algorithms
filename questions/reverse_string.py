"""
Write a function that takes a list of characters and reverses the letters in place.

Why a list of characters instead of a string?

The goal of this question is to practice manipulating strings in place. 
Since we're modifying the input, we need a mutable type like a list, instead of Python 3.6's immutable strings.
"""

import unittest

def reverse(list_of_chars):
    # Reverse the input list of chars in place
    # Because python strings are immutable
    if len(list_of_chars) < 2:
        return
    left, right = 0, len(list_of_chars) - 1
    while left < right:
        list_of_chars[left], list_of_chars[right] = list_of_chars[right], list_of_chars[left]
        left += 1
        right -= 1

# Tests

class Test(unittest.TestCase):

    def test_empty_string(self):
        list_of_chars = []
        reverse(list_of_chars)
        expected = []
        self.assertEqual(list_of_chars, expected)

    def test_single_character_string(self):
        list_of_chars = ['A']
        reverse(list_of_chars)
        expected = ['A']
        self.assertEqual(list_of_chars, expected)

    def test_longer_string(self):
        list_of_chars = ['A', 'B', 'C', 'D', 'E']
        reverse(list_of_chars)
        expected = ['E', 'D', 'C', 'B', 'A']
        self.assertEqual(list_of_chars, expected)

unittest.main(verbosity=2)