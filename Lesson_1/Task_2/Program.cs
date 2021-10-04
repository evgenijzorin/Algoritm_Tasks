using System;

namespace Task_2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    { 
                        int y = 0; // O(1)
                        if (j != 0) { y = k / j; }  // O(1)
                        sum += inputArray[i] // O(1)
                            + i // O(1)
                            + k // O(1)
                            + j // O(1)
                            + y; // O(1)
                        // Асимптотическая сложность Функции StrangeSum = О(7N * N * N)
                        // Сокращаем постоянные множители = О(N^3) 
                    }
                }
            }
            return sum;
        }                
        static void Main(string[] args)
        {
            Console.WriteLine("Асимптотическая сложность Функции StrangeSum = О(N^3)");
        }
    }
}
