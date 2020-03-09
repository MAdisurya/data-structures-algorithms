using System;

namespace DynamicProgramming
{
    // Refer to this: https://algorithms.tutorialhorizon.com/dynamic-programming-minimum-cost-path-problem/
    // Question and solution I will base my solution off can be found here.
    // However, I will try and explain it in more detail.
    // Also has good explanation on why DP is used instead of recursive solution.
    // (Basically, recursive approach repeats many of the computations unnecessarily).

    class MinSumPath
    {
        /// <summary>
        /// Finds the value of the min sum path from top-left
        /// to the bottom-right of the matrix.
        /// Time Complexity: O(col*row) = O(mn)
        /// Visual explanation of the algorithm:
        /// https://raw.githubusercontent.com/MAdisurya/data-structures-algorithms/master/algorithms/dynamic-programming/DynamicProgramming/minsumpath-visual.jpg
        /// </summary>
        private int Find(int[,] matrix, int col, int row)
        {
            // Initialize a new matrix for storing the computed total cost for each square.
            int[,] tcMatrix = new int[col, row];

            // We assign the first value (0,0) of tcMatrix to
            // the first value (0,0) of the matrix.
            tcMatrix[0, 0] = matrix[0, 0];

            // Fill the first row of the tcMatrix
            // Since we're filling the first row, it means that we can only move right
            // from the first square to get to each square in the first row
            // The idea then is to iterate and add the value of (i-1) to the value of (i)
            // so we can total cost for each path traversal
            for (int i = 1; i < row; i++)
            {
                tcMatrix[0, i] = matrix[0, i] + tcMatrix[0, i - 1];
            }

            // Fill the first column of the tcMatrix
            // The same concept applies with filling up the first row
            for (int i = 1; i < col; i++)
            {
                tcMatrix[i, 0] = matrix[i, 0] + tcMatrix[i - 1, 0];
            }

            // Fill in the rest of the tcMatrix
            // We apply the same concept as before, but this time we have 2 options to add from
            // We can either pick from the left square or the top square
            // So we pick the one results in the smallest/minimum value for the current square
            for (int i = 1; i < col; i++)
            {
                for (int j = 1; j < row; j++)
                {
                    tcMatrix[i, j] = matrix[i, j] + Math.Min(tcMatrix[i - 1, j], tcMatrix[i, j - 1]);
                }
            }

            return tcMatrix[col - 1, row - 1];
        }

        public void Run()
        {
            int[,] mat = {
                { 1, 7, 9, 2 },
                { 8, 6, 3, 2 },
                { 1, 6, 7, 8},
                { 2, 9, 8, 2},
            };

            Console.WriteLine("MinSumPath Iterative:");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("[1, 7, 9, 2]");
            Console.WriteLine("[8, 6, 3, 2]");
            Console.WriteLine("[1, 6, 7, 8]");
            Console.WriteLine("[2, 9, 8, 2]");
            Console.WriteLine();
            Console.WriteLine($"Minimum Sum Path = {Find(mat, 4, 4)}");

            // Expected Output
            // ----------------
            // 29
        }
    }
}
