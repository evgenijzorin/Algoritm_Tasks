using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число, которое необходимо преобразовать в число Фибоначчи");
            int num = Convert.ToInt32(Console.ReadLine());
            int numFibonachi = GetNumberOfFibonachi(num);
            Console.WriteLine($"Число Фибоначчи от {num} = {numFibonachi}");
        }
        static int GetNumberOfFibonachi(int num)
        {
            int numFibonachi;
            if (num >= 0)
            {

                switch (num)
                {
                    case 1:
                        numFibonachi = 1;
                        break;
                    case 0:
                        numFibonachi = 0;
                        break;
                    default:
                        numFibonachi = GetNumberOfFibonachi(num - 1) + GetNumberOfFibonachi(num - 2);
                        break;
                }
            }
            else
            {
                switch (num)
                {
                    case -1:
                        numFibonachi = 1;
                        break;
                    case 0:
                        numFibonachi = 0;
                        break;
                    default:
                        numFibonachi = GetNumberOfFibonachi(num + 2) - GetNumberOfFibonachi(num + 1);
                        break;
                }

            }
            return numFibonachi;
        } // end of GetNumberOfFibonachi
    }
}
