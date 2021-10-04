using System;

namespace Task_1
{
    class Program
    {
        static string chekingNumber_SimpleComplex(int number)
        {
            int d = 0; // числовой индикатор, соответствующий количеству чисел на которые можно разделить число без остатка
            int i = 2; // первое присвоение значения делителю. 
            while(i < number)
            {
                if(number % i == 0)
                {
                    d++;
                }
                i++; // инкремент делителя
            }
            string ansver;
            if (d == 0)
            {
                ansver = $"Число {number} - простое.";                
            }
            else
            {
                ansver =$"Число {number} - составное.";
            }


            return ansver;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(chekingNumber_SimpleComplex(1223));
            Console.WriteLine(chekingNumber_SimpleComplex(123));
            Console.WriteLine(chekingNumber_SimpleComplex(12));
            Console.WriteLine(chekingNumber_SimpleComplex(13));
            Console.WriteLine(chekingNumber_SimpleComplex(43));
            Console.WriteLine(chekingNumber_SimpleComplex(2));
        }
    }
}
