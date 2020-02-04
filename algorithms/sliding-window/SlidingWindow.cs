/**
 * Sliding Window C# implementation written by Mario Adisurya
 * Feel free to fork it from my GitHub - https://github.com/MAdisurya/data-structures-algorithms
 */

using System;
using System.Collections.Generic;

class SlidingWindow
{
    /// <summary>
    /// Given a string, returns the longest substring length that
    /// has no repeating characters
    /// </summary>
    /// <param name="_S"></param>
    /// <returns></returns>
    public int LongestSubstring(string _S)
    {
        // Initialize the variables
        // longest variable for storing the longest substring length
        int longest = 0;
        // left index to represent the left bounds of the window
        int left = 0;
        // right index to represent the right bounds of the window
        int right = 0;
        // the Hash Map to store duplicate Characters
        Dictionary<char, uint> duplicateMap = new Dictionary<char, uint>();

        // We loop through the string
        // Keep looping until the right bound >= the length of the String
        // That's when we know we've checked the entire String
        while (right < _S.Length)
        {
            // First we check if we found any duplicates from the right index
            if (duplicateMap.ContainsKey(_S[right]) && duplicateMap[_S[right]] > 0)
            {
                // If we found a duplicate, then decrement the Character
                // in the left index from the Hash Map
                duplicateMap[_S[left]] -= 1;
                // Then we increment the left index to contract the window
                left += 1;

                // We continue to the next iteration
                // To make sure we don't increment the right index
                continue;
            }

            // Otherwise if no duplicate found, then
            // We add/increment the Character from the right index
            // into the Hash Map
            if (duplicateMap.ContainsKey(_S[right]))
            {
                // If key already exists, we increment
                duplicateMap[_S[right]] += 1;
            }
            else
            {
                // Otherwise, we add it into the Hash Map
                duplicateMap.Add(_S[right], 1);
            }

            // If the sum of right - left (the length of current window/substring)
            // is greater than longest, then update longest.
            // We also need to +1 here to get correct length
            // E.g. right = 4, left = 2, _S = "pwwkew"
            // So the current longest substring = "wke"
            // 4 - 2 = 2, when it should be 3, so we +1
            if ((right - left) + 1 > longest)
            {
                longest = right - left + 1;
            }

            // Increment right index to expand the window
            right += 1;
        }

        return longest;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        SlidingWindow slidingWindowExample = new SlidingWindow();

        Console.WriteLine(slidingWindowExample.LongestSubstring("pwwkew"));
        Console.WriteLine(slidingWindowExample.LongestSubstring("abcabcbb"));
        Console.WriteLine(slidingWindowExample.LongestSubstring("bbbbb"));

        // Output

        // 3
        // 3
        // 1
    }
}
