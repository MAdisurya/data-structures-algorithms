using System;

class Sort<T> where T : IComparable
{
    /// <summary>
    /// Handles splitting of the array. This method will be called recursively.
    /// </summary>
    public T[] MergeSort(T[] _array)
    {
        // Handle case where array only consists of one or less elements
        // Since this method is called recursively, we need a base case for
        // exiting the recursion to avoid Overflow
        if (_array.Length <= 1)
        {
            return _array;
        }

        // Find the middle index for the array
        int mid = (_array.Length) / 2;
        // Divide the array so we have a left and right array
        T[] left = new T[mid];
        T[] right = new T[_array.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            left[i] = _array[i];
        }
        for (int i = 0; i < (_array.Length - mid); i++)
        {
            right[i] = _array[mid + i];
        }

        // Return the result of Merge and call MergeSort recursively,
        // to divide the array until each subarray has 0-1 elements
        return Merge(MergeSort(left), MergeSort(right));
    }

    /// <summary>
    /// Merges two subarrays (left, right).
    /// </summary>
    public T[] Merge(T[] _left, T[] _right)
    {
        // The results array where we will store the merged array
        T[] resultsArray = new T[_left.Length + _right.Length];
        // Need two separate pointers for left and right subarrays
        // for when we start traversing and comparing the two subarrays
        int leftIndex = 0;
        int rightIndex = 0;
        // Also need a pointer for the resultsArray
        int resultsIndex = 0;

        // Loop through the subarrays
        while (leftIndex < _left.Length && rightIndex < _right.Length)
        {
            // Compare the elements inside of the subarrays
            // If left < right, then we store the left element in the resultsArray
            // if left >= right, then we store the right element in the resultsArray
            // Also need to make sure that we increment all the pointers
            if (_left[leftIndex].CompareTo(_right[rightIndex]) < 0)
            {
                resultsArray[resultsIndex] = _left[leftIndex];
                leftIndex++;
            }
            else
            {
                resultsArray[resultsIndex] = _right[rightIndex];
                rightIndex++;
            }

            resultsIndex++;
        }

        // Loop through both left and right subarrays
        // and copy any left over elements into resultsArray
        // Make sure to update our pointers as well
        while (leftIndex < _left.Length)
        {
            resultsArray[resultsIndex] = _left[leftIndex];
            leftIndex++;
            resultsIndex++;
        }

        while (rightIndex < _right.Length)
        {
            resultsArray[resultsIndex] = _right[rightIndex];
            rightIndex++;
            resultsIndex++;
        }

        return resultsArray;
    }
}

class MainClass
{
    private static void printArray(int[] _array)
    {
        foreach (int item in _array)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Sort<int> sort = new Sort<int>();
        int[] testArray = { 12, 11, 13, 5, 6, 7 };
        int[] testArray2 = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine("Test array 1:");
        printArray(testArray);
        Console.WriteLine("Merge Sort: Test array 1");
        printArray(sort.MergeSort(testArray));

        Console.WriteLine();

        Console.WriteLine("Test array 2:");
        printArray(testArray2);
        Console.WriteLine("Merge Sort: Test array 2");
        printArray(sort.MergeSort(testArray2));

        // Expected Output
        // ---------------
        // Test array 1:
        // [12, 11, 13, 5, 6, 7]
        // Merge sort - Test array 1:
        // [5, 6, 7, 11, 12, 13]
        //
        // Test array 2:
        // [38, 27, 43, 3, 9, 82, 10]
        // Merge sort - Test array 2:
        // [3, 9, 10, 27, 38, 43, 82]
    }
}
