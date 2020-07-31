"""
Given a list of integers, find the highest product you can get from three of the integers.

The input list_of_ints will always have at least three integers.
"""
import unittest

def highest_product_of_3(list_of_ints):
    if len(list_of_ints) < 3:
        raise Exception()
    high = max(list_of_ints[0], list_of_ints[1])
    low = min(list_of_ints[0], list_of_ints[1])
    hp_2, lp_2, hp_3 = high * low, high * low, -float("inf")
    for i in range(2, len(list_of_ints)):
        hp_3 = max(hp_3, hp_2 * list_of_ints[i], lp_2 * list_of_ints[i])
        hp_2 = max(hp_2, high * list_of_ints[i], low * list_of_ints[i])
        lp_2 = min(lp_2, low * list_of_ints[i], high * list_of_ints[i])
        high = max(high, list_of_ints[i])
        low = min(low, list_of_ints[i])
    return hp_3

# Tests

class Test(unittest.TestCase):

    def test_short_list(self):
        actual = highest_product_of_3([1, 2, 3, 4])
        expected = 24
        self.assertEqual(actual, expected)

    def test_longer_list(self):
        actual = highest_product_of_3([6, 1, 3, 5, 7, 8, 2])
        expected = 336
        self.assertEqual(actual, expected)

    def test_list_has_one_negative(self):
        actual = highest_product_of_3([-5, 4, 8, 2, 3])
        expected = 96
        self.assertEqual(actual, expected)

    def test_list_has_two_negatives(self):
        actual = highest_product_of_3([-10, 1, 3, 2, -10])
        expected = 300
        self.assertEqual(actual, expected)

    def test_list_is_all_negatives(self):
        actual = highest_product_of_3([-5, -1, -3, -2])
        expected = -6
        self.assertEqual(actual, expected)

    def test_error_with_empty_list(self):
        with self.assertRaises(Exception):
            highest_product_of_3([])

    def test_error_with_one_number(self):
        with self.assertRaises(Exception):
            highest_product_of_3([1])

    def test_error_with_two_numbers(self):
        with self.assertRaises(Exception):
            highest_product_of_3([1, 1])

unittest.main(verbosity=2)