using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson_4
{
    class Program
    {
        public static bool SerchValueArray<T>(T value, T[] array)
        {
            foreach (T val in array)
            {
                if (val.Equals(value)) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            // Новый секундомер
            Stopwatch sw = new Stopwatch();
            // искомая строка
            string serchedLine = "73032c86-049f-43c7-82cf-3f0b5946c67c";

            // генерация 1000_000 строк в массив в hashSet                       
            string[] LineArray = new string[1000_000];
            // добавить строки в массив
            sw.Start();
            for (int i = 0; i < 1000_000; i++)
            {
                string Line = Guid.NewGuid().ToString();
                // Искуственно добавляем в массив искомое значение
                if (i == 500_000)
                    LineArray[i] = "73032c86-049f-43c7-82cf-3f0b5946c67c";
                else
                    LineArray[i] = Line;
            }
            // Проверка наличия строки в массиве
            bool serchedRezult = SerchValueArray(serchedLine, LineArray);

            sw.Stop();
            Console.WriteLine($"при заполнении массива 1000_000 стороками и поиске в нем значения {serchedLine}, затрачено {sw.ElapsedMilliseconds} милисекунд. Результат поиска:{serchedRezult}");

            sw.Reset();  // сбросс таймера

            // добавить строки в хэшьсет            
            sw.Start();
            var hashSet = new HashSet<string>();
            for (int i = 0; i < 1000_000; i++)
            {
                string Line = Guid.NewGuid().ToString();
                // Искуственно добавляем в массив искомое значение
                if (i == 500_000)
                    hashSet.Add("73032c86-049f-43c7-82cf-3f0b5946c67c");
                else
                    hashSet.Add(Line);
            }
            // Проверка наличия строки в хешьсете
            bool serchedRezult1 = hashSet.Contains(serchedLine);
            sw.Stop();
            Console.WriteLine($"при заполнении хешсета 1000_000 стороками и поиска в нем {serchedLine}, затрачено {sw.ElapsedMilliseconds} милисекунд. Результат поиска:{serchedRezult1}");
            // Результаты выполнения
            //     при заполнении массива 1000_000 стороками и поиске в нем значения "73032c86 - 049f - 43c7 - 82cf - 3f0b5946c67c", затрачено 422 милисекунд.Результат поиска:True
            //при заполнении хешсета 1000_000 стороками и поиска в нем "73032c86 - 049f - 43c7 - 82cf - 3f0b5946c67c", затрачено 640 милисекунд.Результат поиска:True
        }
    }
}
