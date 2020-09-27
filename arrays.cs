// работа с двумерными массивами

using System;
namespace std
{
    class Program
    {
        static int[,] ArrInit()
        {
            Console.Write("Введите количество строк массива: ");
            int M = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов массива: ");
            int N = int.Parse(Console.ReadLine());
            int[,] arr = new int[M, N];
            string[] strval;
            for (int i = 0; i < M; i++)
            {
                Console.Write("Введите {0}-ую строку массива: ", i + 1);
                strval = Console.ReadLine().Split(new char[] { ' ' });
                for (int j = 0; j < N; j++)
                    arr[i, j] = int.Parse(strval[j]);
            }
            return arr;
        }
        static void ArrPrint (int[] arr)
        {
            foreach (int x in arr)
                Console.Write("{0} ", x);
        }

        static void SqArrPrint(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write("{0} ", arr[i, j]);
                Console.Write("\n");
            }
        }
        static void MinusMin(int[,] arr)
        {
            int min = arr[0, 0];
            foreach (int i in arr)
            {
                if (min > i)
                    min = i;
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < (i * arr.GetLength(1) + (j + 1)))
                        arr[i, j] -= min;
                }
            }
        }
        static int[] PositiveN(int[,] arr)
        {
            int[] posn = new int[arr.GetLength(0)];
            int n;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                n = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] >= 0) n++;
                }
                posn[i] = n;
            }
            return posn;
        }
        static int MaxAmongMin(int[,] arr)
        {
            int max, min, r = 0;
            int[] arr2 = new int[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                max = arr[i, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (max < arr[i, j]) max = arr[i, j];
                }
                arr2[i] = max;
            }
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                min = arr2[0];
                r = 1;
                if (min > arr2[i])
                {
                    min = arr2[i];
                    r += i;
                }
            }
            return r;
        }
        static int MinAmongMax(int[,] arr)
        {
            int max, min, r = 0;
            int[] arr2 = new int[arr.GetLength(1)];
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                min = arr[0, j];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (min > arr[i, j]) min = arr[i, j];
                }
                arr2[j] = min;
            }
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                max = arr2[0];
                r = 1;
                if (max < arr2[i])
                {
                    max = arr2[i];
                    r = i;
                }
            }
            return r;
        }
        static void Main()
        {
            int[,] arr = ArrInit();
            MinusMin(arr);
            SqArrPrint(arr);
            int[] n = PositiveN(arr); ArrPrint(n);
            MaxAmongMin(arr); SqArrPrint(arr);
            MinAmongMax(arr); SqArrPrint(arr);
            Console.ReadKey();
        }
    }
}