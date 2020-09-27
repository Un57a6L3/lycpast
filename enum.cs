// практика с перечислениями (enum)

using System;
using static System.Console;
namespace Fon52
{
    class MatrixWeather
    {
        enum Month
        {
            Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        }
        static int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int month;
        int day;
        int[,] t;
        public MatrixWeather()
        {
            Random rnd = new Random();
            month = rnd.Next(1, 13);
            day = rnd.Next(1, days[month - 1] + 1);
            t = Temp(month, day);
        }
        public MatrixWeather(int month, int day)
        {
            this.month = month;
            this.day = day;
            t = Temp(month, day);
        }
        private int[,] Temp(int m, int d)
        {
            int[,] temp;
            Random rnd = new Random();
            if (m == 2 && d == 1) temp = new int[4, 7];
            else temp = new int[5, 7];
            for (int i = 0; i < temp.GetLength(0); i++)
                for (int j = 0; j < temp.GetLength(1); j++)
                    temp[i, j] = rnd.Next(-10, 11);
            return temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
