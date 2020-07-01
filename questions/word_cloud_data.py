"""
You want to build a word cloud, an infographic where the size of a word corresponds to how often it appears in the body of text.

To do this, you'll need data. Write code that takes a long string and builds its word cloud data in a dictionary, where the keys are words and the values are the number of times the words occurred.

Think about capitalized words. For example, look at these sentences:

    'After beating the eggs, Dana read the next step:'
    'Add milk and eggs, then add flour and sugar.'

What do we want to do with "After", "Dana", and "add"? In this example, your final dictionary should include one "Add" or "add" with a value of 22.
Make reasonable (not necessarily perfect) decisions about cases like "After" and "Dana".

Assume the input will only contain words and standard punctuation.

You could make a reasonable argument to use regex in your solution.
We won't, mainly because performance is difficult to measure and can get pretty bad.
"""
import unittest

class WordCloudData(object):

    def __init__(self, input_string):
        # Count the frequency of each word
        self.words_to_counts = {}
        for w in self.split_word(input_string):
            if len(w) == 0:
                continue
            w = w.lower()
            if w in self.words_to_counts:
                self.words_to_counts[w] += 1
            else:
                self.words_to_counts[w] = 1
        
    def split_word(self, word: str) -> list:
        res = []
        start = 0
        for i in range(len(word)):
            if i > 0 and not word[i-1].isalpha() and word[i] == "-" and \
                not word[i+1].isalpha():
                    start = i + 1
                    continue
            if not word[i].isalpha() and word[i] != "'" and word[i] != "-":
                res.append(word[start:i])
                start = i + 1
            elif i == len(word) - 1:
                res.append(word[start:i+1])
        return res

# Tests

# There are lots of valid solutions for this one. You
# might have to edit some of these tests if you made
# different design decisions in your solution.

class Test(unittest.TestCase):

    def test_simple_sentence(self):
        input = 'I like cake'

        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts

        expected = {'i': 1, 'like': 1, 'cake': 1}
        self.assertEqual(actual, expected)

    def test_longer_sentence(self):
        input = 'Chocolate cake for dinner and pound cake for dessert'

        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts

        expected = {
            'and': 1,
            'pound': 1,
            'for': 2,
            'dessert': 1,
            'chocolate': 1,
            'dinner': 1,
            'cake': 2,
        }
        self.assertEqual(actual, expected)

    def test_punctuation(self):
        input = 'Strawberry short cake? Yum!'

        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts

        expected = {'cake': 1, 'strawberry': 1, 'short': 1, 'yum': 1}
        self.assertEqual(actual, expected)

    def test_hyphenated_words(self):
        input = 'Dessert - mille-feuille cake'

        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts

        expected = {'cake': 1, 'dessert': 1, 'mille-feuille': 1}
        self.assertEqual(actual, expected)

    def test_ellipses_between_words(self):
        input = 'Mmm...mmm...decisions...decisions'

        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts

        expected = {'mmm': 2, 'decisions': 2}
        self.assertEqual(actual, expected)

    def test_apostrophes(self):
        input = "Allie's Bakery: Sasha's Cakes"

        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts

        expected = {"allie's": 1, "bakery": 1, "sasha's": 1, "cakes": 1}
        self.assertEqual(actual, expected)
        
    def test_complex_sentence(self):
        input = "We came, we saw, we conquered...then we ate Bill's (Mille-Feuille) cake."
        
        word_cloud = WordCloudData(input)
        actual = word_cloud.words_to_counts
        
        expected = {
            "we": 4,
            "came": 1,
            "saw": 1,
            "conquered": 1,
            "then": 1,
            "ate": 1,
            "bill's": 1,
            "mille-feuille": 1,
            "cake": 1
        }
        self.assertEqual(actual, expected)

unittest.main(verbosity=2)