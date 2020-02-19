using System;

class BinarySearch
{
    /// <summary>
    /// Performs a binary search on the given array of integers
    /// and returns the index position of the searched number.
    /// If the number is not found, will return -1
    /// </summary>
    /// <param name="arr">the array of integers to search through</param>
    /// <param name="num">the desired number to find in the array</param>
    /// <returns></returns>
    public int IntSearch(int[] arr, int num)
    {
        // Initialize 3 variables: low, high, mid
        // These will be pointers to determine which section of the array
        // we are currently in
        // Low: index reference for the left edge of the array
        int low = 0;
        // High: index reference for the right edge of the array
        int high = arr.Length - 1;
        // Mid: index reference for the middle of the array
        int mid;

        // We want to continue iterating until we've checked the whole array
        // In this case, we will know if the left edge and right edge swap places
        while (low <= high)
        {
            // Find the middle index
            mid = (low + high) / 2;

            // Handle the case if the middle index value is equal to num
            if (arr[mid] == num)
            {
                return mid;
            }

            if (arr[mid] > num)
            {
                // If the value of the middle index is greater than num
                // We set high (right edge of array) to the index before mid
                // As we want to check the left side of the array
                high = mid - 1;
            }
            else if (arr[mid] < num)
            {
                // If the value of the middle index is less than num
                // We set the low (left edge of the array) to the index after mid
                // As we want to check the right side of the array
                low = mid + 1;
            }
        }

        return -1;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        BinarySearch search = new BinarySearch();
        int[] array = { 2, 3, 4, 10, 12, 16, 30, 40 };

        Console.WriteLine("Binary search using array: [2, 3, 4, 10, 12, 16, 30, 40]");
        Console.WriteLine("4 is present at index: " + search.IntSearch(array, 4).ToString());
        Console.WriteLine("16 is present at index: " + search.IntSearch(array, 16).ToString());
        Console.WriteLine("2 is present at index: " + search.IntSearch(array, 2).ToString());
        Console.WriteLine("40 is present at index: " + search.IntSearch(array, 40).ToString());
        Console.WriteLine("26 is present at index: " + search.IntSearch(array, 26).ToString());

        // Expected Output

        // 2
        // 5
        // 0
        // 40
        // -1
    }
}
