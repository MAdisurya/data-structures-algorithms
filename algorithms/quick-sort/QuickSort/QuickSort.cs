using System;

public class QuickSort
{
    /// <summary>
    /// Helper method for swapping two elements in an array
    /// </summary>
    private static void Swap(ref int[] array, int left, int right)
    {
        int temp = array[left];
        array[left] = array[right];
        array[right] = temp;
    }

    /// <summary>
    /// Sorts the array by placing smaller elements on left of
    /// pivot, and larger elements on right of pivot
    /// </summary>
    /// <returns></returns>
    private static int Partition(int[] array, int low, int high)
    {
        // We set the pivot as the last element in the array
        int pivot = array[high];
        // For swapping with j
        int i = low - 1;

        // Then we loop through the entire array
        for (int j = low; j < high; j++)
        {
            // If the current element is smalller than the pivot
            if (array[j] < pivot)
            {
                // Increment i
                i++;
                // Swap array[i] and array[j] so that
                // the smaller element is on the left, and vice versa
                Swap(ref array, i, j);
            }
        }

        // Now we swap the pivot with array[i+1]
        // This is to make sure that all elements before the pivot
        // is smaller, and all elements after the pivot is larger
        Swap(ref array, i + 1, high);

        return i + 1;
    }

    /// <summary>
    /// The main recursive Quick Sort method
    /// </summary>
    private static void Sort(ref int[] array, int low, int high)
    {
        // Since it's recursive, we need a default case for
        // exiting the recursion
        // the low and high represents itemFromLeft and itemFromRight
        // from the explanation
        if (low < high)
        {
            // Find the pivot point
            int pivotLocation = Partition(array, low, high);

            // Recursively invoke Sort on the left and right side
            // of the array using the pivot as the middle point
            Sort(ref array, low, pivotLocation - 1);
            Sort(ref array, pivotLocation + 1, high);
        }
    }

    public static void Sort(ref int[] array)
    {
        if (array == null) throw new ArgumentNullException("The passed array must not be null!");

        Sort(ref array, 0, array.Length - 1);
    }

    public static void Main()
    {
        int[] testArray = { 10, 80, 30, 90, 40, 50, 70 };

        Sort(ref testArray);

        Console.WriteLine("Quick Sort");
        Console.WriteLine("-----------");
        Console.WriteLine();

        Console.WriteLine("Unsorted Array: 10, 80, 30, 90, 40, 50, 70");
        Console.WriteLine();

        Console.Write("Quick Sorted Array: ");
        foreach (int item in testArray)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();

        // Expected Output
        // ---------------
        // [10, 30, 40, 50, 70, 80, 90]
    }
}
