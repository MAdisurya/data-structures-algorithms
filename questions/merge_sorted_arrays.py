"""
In order to win the prize for most cookies sold, my friend Alice and I are going to merge our Girl Scout Cookies orders and enter as one unit.

Each order is represented by an "order id" (an integer).

We have our lists of orders sorted numerically already, in lists. Write a function to merge our lists of orders into one sorted list.

For example:

    my_list     = [3, 4, 6, 10, 11, 15]
    alices_list = [1, 5, 8, 12, 14, 19]

    # Prints [1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19]
    print(merge_lists(my_list, alices_list))
"""

import unittest

def merge_lists(my_list, alices_list) -> list:
    if len(my_list) == 0 and len(alices_list) == 0:
        return []
    if len(my_list) > 0 and len(alices_list) == 0:
        return my_list
    if len(alices_list) > 0 and len(my_list) == 0:
        return alices_list
    p1, p2 = 0, 0
    res = []
    while p1 < len(my_list) and p2 < len(alices_list):
        if my_list[p1] < alices_list[p2]:
            res.append(my_list[p1])
            p1 += 1
        else:
            res.append(alices_list[p2])
            p2 += 1
    while p1 < len(my_list):
        res.append(my_list[p1])
        p1 += 1
    while p2 < len(alices_list):
        res.append(alices_list[p2])
        p2 += 1
    return res

# Tests

class Test(unittest.TestCase):

    def test_both_lists_are_empty(self):
        actual = merge_lists([], [])
        expected = []
        self.assertEqual(actual, expected)

    def test_first_list_is_empty(self):
        actual = merge_lists([], [1, 2, 3])
        expected = [1, 2, 3]
        self.assertEqual(actual, expected)

    def test_second_list_is_empty(self):
        actual = merge_lists([5, 6, 7], [])
        expected = [5, 6, 7]
        self.assertEqual(actual, expected)

    def test_both_lists_have_some_numbers(self):
        actual = merge_lists([2, 4, 6], [1, 3, 7])
        expected = [1, 2, 3, 4, 6, 7]
        self.assertEqual(actual, expected)

    def test_lists_are_different_lengths(self):
        actual = merge_lists([2, 4, 6, 8], [1, 7])
        expected = [1, 2, 4, 6, 7, 8]
        self.assertEqual(actual, expected)

unittest.main(verbosity=2)