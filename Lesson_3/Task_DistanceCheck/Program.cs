using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Runtime.InteropServices; // Взаимодействие с неуправляемым кодом. Код, выполняющийся под управлением среды выполнения, называется управляемым кодом. И наоборот, код, выполняемый вне среды выполнения, называется неуправляемым кодом.


namespace Task_DistanceCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }              

    }

    [MemoryDiagnoser] // Атрибут метода. указывающий, что нужно просчитать использование памяти
    [RankColumn] // Атрибут указывает на то что нужно для каждого метода поставить оценку
    public class BechmarkClass
    {
        // Создаем точки для проверки
        PointStruct pointOneStruct = new PointStruct(){ X = 12, Y=33 };
        PointStruct pointTwoStruct = new PointStruct() { X = 1, Y = 3 };                
        PointClass pointOneClass = new PointClass() { X = 12, Y = 33 };
        PointClass pointTwoClass = new PointClass() { X = 1, Y = 3 };

        // Создаем экземпляр класса distanceCalc
        //DistanceCalc distanceCalc = new DistanceCalc();
        // Проверяемые методы:

        // 1. Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа
        // float).
        [Benchmark]
        public void CheckPointDistanceFloat_Class ()
        {
            DistanceCalc.PointDistanceFloat(pointOneClass, pointTwoClass);
        }
        // 2. Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа
        // float).
        [Benchmark]
        public void CheckPointDistanceFloat_Struct()
        {
            DistanceCalc.PointDistanceFloat(pointOneStruct, pointTwoStruct);
        }
        // 3. Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа
        // double).
        [Benchmark]
        public void CheckPointDistanceDouble_Struct()
        {
            DistanceCalc.PointDistanceDouble(pointOneStruct, pointTwoStruct);
        }
        // 4. Метод расчёта дистанции возведенной в квадрат (т.е. без вычисления кв. корня) со значимым типом (PointStruct —
        // координаты типа float).
        [Benchmark]
        public void CheckPointDistanceShort()
        {
            DistanceCalc.PointDistanceShort(pointOneStruct, pointTwoStruct);
        }

        //        Результаты проверки:
        //|                          Method |     Mean |     Error |    StdDev | Rank | Gen 0 | Gen 1 | Gen 2 | Allocated |
        //|-------------------------------- |---------:|----------:|----------:|-----:|------:|------:|------:|----------:|
        //|   CheckPointDistanceFloat_Class | 2.505 ns | 0.0177 ns | 0.0165 ns |    2 |     - |     - |     - |         - |
        //|   CheckPointDistanceFloat_Class | 2.505 ns | 0.0177 ns | 0.0165 ns |    2 |     - |     - |     - |         - |
        //|  CheckPointDistanceFloat_Struct | 2.471 ns | 0.0132 ns | 0.0123 ns |    2 |     - |     - |     - |         - |
        //| CheckPointDistanceDouble_Struct | 2.849 ns | 0.0192 ns | 0.0180 ns |    3 |     - |     - |     - |         - |
        //|         CheckPointDistanceShort | 2.116 ns | 0.0159 ns | 0.0149 ns |    1 |     - |     - |     - |         - |

        // Проверка показала что быстрее всего работает функция без вычисления корня квадратного. Кроме того я задал атрибут проверки RankColumn, в результате работы которого Benchmark посчитал функцию PointDistanceShort самой быстрой. 

    }
}
