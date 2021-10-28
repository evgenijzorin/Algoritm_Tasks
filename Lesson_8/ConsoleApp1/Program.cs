using System;
using System.Collections.Generic;

namespace BuckedSort
{
    class BucketSort
    {

        static void Main(string[] args)
        {
            int[] array = new int[] { 43, 17, 87, 92, 31, 6, 96, 13, 66, 62, 4 };
                              
            Console.WriteLine("Исходный массив:");
            ArrayHelper arrayHelper = new ArrayHelper(); // класс для визуализации

            arrayHelper.Visual(array);

            List<int> sortedArray = arrayHelper.BucketSort(array);
            Console.WriteLine();

            Console.WriteLine("Блочная сортировка:");
            arrayHelper.Visual(sortedArray);

            Console.ReadLine();

        }
    }
}
