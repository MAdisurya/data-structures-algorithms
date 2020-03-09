using System;

namespace DynamicProgramming
{
    class MainClass
    {
        public static void Main()
        {
            Fibonacci fib = new Fibonacci();
            fib.Run();

            Console.WriteLine();

            MinSumPath msp = new MinSumPath();
            msp.Run();
        }
    }
}