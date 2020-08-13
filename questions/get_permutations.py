"""
Write a recursive function for generating all permutations of an input string. Return them as a set.

Don't worry about time or space complexity—if we wanted efficiency we'd write an iterative version.

To start, assume every character in the input string is unique.

Your function can have loops—it just needs to also be recursive.
"""
import unittest

def get_permutations(string):
    if len(string) <= 1:
        return set([string])
    chars = string[:-1]
    last_char = string[-1]
    rec_set = get_permutations(chars)
    res = set()
    for s in rec_set:
        for pos in range(len(s) + 1):
            permutation = s[:pos] + last_char + s[pos:]
            res.add(permutation)
    return res

# Tests

class Test(unittest.TestCase):

    def test_empty_string(self):
        actual = get_permutations('')
        expected = set([''])
        self.assertEqual(actual, expected)

    def test_one_character_string(self):
        actual = get_permutations('a')
        expected = set(['a'])
        self.assertEqual(actual, expected)

    def test_two_character_string(self):
        actual = get_permutations('ab')
        expected = set(['ab', 'ba'])
        self.assertEqual(actual, expected)

    def test_three_character_string(self):
        actual = get_permutations('abc')
        expected = set(['abc', 'acb', 'bac', 'bca', 'cab', 'cba'])
        self.assertEqual(actual, expected)

unittest.main(verbosity=2)