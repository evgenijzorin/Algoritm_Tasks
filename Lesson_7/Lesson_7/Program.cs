using System;

namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача: Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой клетки в правую нижнюю.Известно что ходить можно только на одну клетку вправо или вниз.
            // Объект который будет визуализировать массив, и расчитывать колличество путей
            ArrayHelper arrayHelper = new ArrayHelper();
            // построение матрицы 
            int m = 10;
            int n = 10;
            int[,] arrayOfPath = new int[m, n];
            Console.WriteLine("Визуализация исходного массива");
            arrayHelper.Visual(arrayOfPath);
            // Создание массива - матрицы, описывающей количество вариантов путей:
            int[,] arrayNumberOfPath = arrayHelper.GetNumberOfPath(arrayOfPath);
            Console.WriteLine();

            Console.WriteLine("Визуализация массива - матрицы, описывающей количество вариантов путей:");
            arrayHelper.Visual(arrayNumberOfPath);

            Console.WriteLine(); Console.ReadKey();
        }
    }
}
