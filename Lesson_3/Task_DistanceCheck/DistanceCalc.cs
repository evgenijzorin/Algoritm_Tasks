using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; // Взаимодействие с неуправляемым кодом. Код, выполняющийся под управлением среды выполнения, называется управляемым кодом. И наоборот, код, выполняемый вне среды выполнения, называется неуправляемым кодом.


namespace Task_DistanceCheck
{
    public struct PointStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class PointClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class DistanceCalc
    {
        /// <summary>
        /// Обычное вычисление дистанции значимым типом struct оперируя,  типом данных float
        /// </summary>
        public static float PointDistanceFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Обычное вычисление дистанции, ссылочным типом class оперируя, типом данных float
        /// </summary>
        public static float PointDistanceFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Вычисление дистанции возведенной в квадрат (т.е. без вычисления кв. корня) Ссылочным типом.
        /// </summary>
        public static float PointDistanceShort(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return ((x * x) + (y * y));
        }

        /// <summary>
        /// Вычисление дистанции возведенной в квадрат (т.е. без вычисления кв. корня) Значимым типом.
        /// </summary>
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return ((x * x) + (y * y));
        }



        /// <summary>
        /// Вычисление дистанции значимым типом struct оперируя, double
        /// </summary>
        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Подсчет квадратного корня с помощью побитового сдвига
        /// </summary>
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct FloatIntUnion
        {
            [FieldOffset(0)]
            public int i;
            [FieldOffset(0)]
            public float f;
        }
        public static float fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }
    }
}
