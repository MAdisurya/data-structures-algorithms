using System;

namespace DynamicProgramming
{
    class Fibonacci
    {
        /// <summary>
        /// Fibonacci sequence method that uses iterative approach.
        /// Unlike the recursive approach, this stores the computed values
        /// into an array so that the same computation isn't repeated.
        /// Takes an input (n), and returns the value in the fibonacci
        /// sequence associated with n.
        /// Use unsigned int to make sure it's a positive integer.
        /// Also takes up less memory.
        /// </summary>
        public uint FibIterative(uint n)
        {
            // Handle edge cases where n is either 0 or 1
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Define the array to store the fibonacci values
            uint[] array = new uint[n + 1];

            // Need to predefine the first two items in the array
            // for computing
            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                // array[i] is the sum of the previous
                // two items in the array
                array[i] = array[i - 1] + array[i - 2];
            }

            return array[n];
        }

        public void Run()
        {
            Console.WriteLine("Fibonacci Iterative: ");
            Console.WriteLine("---------------------");
            Console.WriteLine(FibIterative(0));
            Console.WriteLine(FibIterative(1));
            Console.WriteLine(FibIterative(4));
            Console.WriteLine(FibIterative(10));
            Console.WriteLine(FibIterative(12));
            Console.WriteLine(FibIterative(7));

            // Expected Output
            // -----------------
            // 0
            // 1
            // 3
            // 55
            // 144
            // 13
        }
    }
}
