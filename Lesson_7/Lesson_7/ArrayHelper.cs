using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    class ArrayHelper
    {
        internal void Visual(int[,] arrayOfPath)
        {
            for (int i = 0; i < arrayOfPath.GetLength(0); i++)
            {
                if (i != 0) Console.WriteLine();
                for (int j = 0; j < arrayOfPath.GetLength(1); j++)
                {
                    Console.Write(arrayOfPath[i, j] + "\t");
                }
            }
            Console.WriteLine();
        }

        internal int[,] GetNumberOfPath(int[,] _arrayOfPath)
        {
            int[,] arrayOfPath = new int[_arrayOfPath.GetLength(0), _arrayOfPath.GetLength(1)];
            // Заполнение ячейки 0,0 как извесной
            arrayOfPath[0, 0] = 1;
            // Заполнение горизонтальной и вертикальной строки как производных от ячейки 0,0
            for (int i = 0; i < arrayOfPath.GetLength(0); i++)
            {
                for (int j = 0; j < arrayOfPath.GetLength(1); j++)
                {
                    // Заполнение строки
                    if ((i == 0) && (j != 0)) arrayOfPath[i, j] = arrayOfPath[i, j - 1];
                    // Заполнение столбца
                    if ((j == 0) && (i != 0)) arrayOfPath[i, j] = arrayOfPath[i - 1, j];
                }
            }
            // Визуализация массива
            // this.Visual(arrayOfPath); Console.WriteLine();

            // Заполнение последующих ячеек как сумма верхней и левой ячейки
            for (int i = 1; i < arrayOfPath.GetLength(0); i++)
            {
                for (int j = 1; j < arrayOfPath.GetLength(1); j++)
                {
                    // Заполнение построчно:
                    arrayOfPath[i, j] = arrayOfPath[i, j - 1] + arrayOfPath[i - 1, j];
                }
            }
            return arrayOfPath;
        }

    }
}
