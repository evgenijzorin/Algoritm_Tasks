using System;

namespace Task_2 // НАписать функцию бинарного поиска и её проверка
{
    class Program
    {

        /// <summary>
        /// Бинарный поиск по массиву
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="searchValue">Искомое значение</param>
        /// <returns></returns>
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            // ввод стартого левого и правого индекса
            int left = 0; // O(1)
            int right = inputArray.Length - 1; // O(1)
            while (left <= right) // O(log(N))
            {
                int mid = (left + right) / 2; // средний индекс
                // в случае, если средний индекс равен искомому
                if (searchValue == inputArray[mid])
                {
                    // возврат искомого индекса
                    return mid;
                }
                // в случае, если средний индекс больше искомого
                else if (searchValue < inputArray[mid])
                {
                    // правая граница поиска получает средний индекс смещенный на единицу в лево
                    right = mid - 1;
                }
                // в случае, если средний индекс меньше искомого
                else if (searchValue > inputArray[mid])
                {
                    // левая граница поиска получает средний индекс смещенный на единицу в право
                    left = mid + 1;
                }
            } // end while
            return -1; // в случае, если искомое не найдено
        }

        /// <summary>
        /// Проверка бинарного поиска
        /// </summary>
        /// <param name="array">массив для поиска значения</param>
        /// <param name="searchValue"> искомое значение </param>
        public static void ChekingBinarySearch (int[] array, int searchValue)
        {
            Array.Sort(array); // Отсортировать массив
            Console.WriteLine("Визуализация списка: " +
                String.Join(' ', array)// Сепара́тор - Сцепляет элементы указанного массива или элементы коллекции, помещая между ними заданный разделитель.
                );
            int result = BinarySearch(array, searchValue);
            Console.Write("результаты поиска: ");
            if (result > -1)
                Console.WriteLine($"искомый номер {result}");
            else
                Console.WriteLine($"искомый номер не найден");
            // Проверка поиска:
            Console.Write("Проверка поиска: ");
            int chekResult = -1;
            int n = 0;
            foreach (var item in array)
            {                
                if (item == searchValue)
                {                    
                    chekResult = n;
                }
                n++;
            }
            if (chekResult == -1 && result == -1)
            {
                Console.WriteLine($"Проверка прошла успешно, искомого элемента нет в списке");
            }
            else if (chekResult == result)
            {
                Console.WriteLine($"Проверка прошла успешно, результат бинарного поиска {result} равен результату проверки {chekResult}");
            }
            else
            {
                Console.WriteLine($"Проверка прошла с ошибкой. Результат бинарного поиска = {result}, должен быть {chekResult}.");
            }
        }

        static void Main(string[] args)
        {
            // бинарный поиск // дихотомический поиск // поиск метода половинного деления
            int[] array = new int[] { 1, 2, 3, 34, -8, 4, -1, 5, 6, 3, 19, 20 };
            ChekingBinarySearch(array, 345);
            Console.WriteLine("Асимпатическая сложность функции бинарного поиска log(N)");
        }
    }
}
