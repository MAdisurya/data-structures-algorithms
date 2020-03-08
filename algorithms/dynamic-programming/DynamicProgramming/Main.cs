using System;

namespace DynamicProgramming
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Fibonacci fib = new Fibonacci();

            Console.WriteLine("Fibonacci Iterative: ");
            Console.WriteLine("---------------------");
            Console.WriteLine(fib.FibIterative(0));
            Console.WriteLine(fib.FibIterative(1));
            Console.WriteLine(fib.FibIterative(4));
            Console.WriteLine(fib.FibIterative(10));
            Console.WriteLine(fib.FibIterative(12));
            Console.WriteLine(fib.FibIterative(7));

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