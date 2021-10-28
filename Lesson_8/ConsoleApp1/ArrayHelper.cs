using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckedSort
{
    class ArrayHelper
    {
        /// <summary>
        /// Визуализация массива
        /// </summary>
        /// <param name="sortedArray"></param>
        internal void Visual(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        
        /// <summary>
        /// Визуализация списка
        /// </summary>
        /// <param name="sortedArray"></param>
        internal void Visual(List<int> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        /// <summary>
        /// Блочная сортировака BucketSort
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<int> BucketSort(params int[] x)
        {
            // Итоговый список для отсортированных элементов
            List<int> sortedArray = new List<int>();
            // число блоков
            int numOfBuckets = 10;
            // Создание блоков
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Перебор переданного массива для добавления чисел в соответствующий блок            
            for (int i = 0; i < x.Length; i++)
            {
                int iBucket  
                    = (x[i] / numOfBuckets);// номер блока в который помещается элемент.
                // значение обрезается для int и тем самым значение соответсвует диапазону блока.
                buckets[iBucket].Add(x[i]);
            }

            // сортировка и соединение списка в единый
            for (int i = 0; i < numOfBuckets; i++)
            {
                // Сортировка вставкой
                List<int> temp = InsertionSort(buckets[i]);
                sortedArray.AddRange(temp); // Соединение списков
            }
            return sortedArray;
        }



        /// <summary>
        /// Сортировка вставкой
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<int> InsertionSort(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                //2. Сохранить текущее значение в переменную
                int currentValue = input[i];
                // сдвиг указателя
                int pointer = i - 1;

                //3. 
                while (pointer >= 0) // пока указатель в доп. знач.
                {
                    // Если текущее значение меньше чем значение на указателе (указатель левее)
                    if (currentValue < input[pointer])
                    {                         
                        input[pointer + 1] = input[pointer];
                        input[pointer] = currentValue;
                    }
                    else break;
                }
            }
            return input;
        }



    }
}
