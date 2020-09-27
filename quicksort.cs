// Похоже на сортировку методом quicksort

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Array;

namespace taskD
{
    class Program
    {
        private static int[] QuickSort(int[] arr, int start, int end, ref)
        {
            if (start < end)
            {
                int q = Partition(arr, start, end);
                arr = QuickSort(arr, start, q);
                arr = QuickSort(arr, q + 1, end);
            }
            return arr;
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int x = arr[start];
            int i = start - 1;
            int j = end + 1;
            while (true)
            {
                do
                {
                    j--;
                }
                while (arr[j] > x);
                do
                {
                    i++;
                }
                while (arr[i] < x);
                if (i < j)
                {
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
                else
                {
                    return j;
                }
            }
        }

        static void Main(string[] args)
        {
            int i, j;
            bool flag = false;
            int N = int.Parse(ReadLine());
            string[] temp;
            string[] rname = new string[N], name = new string[N];
            int[] rheight = new int[N], height = new int[N];
            int[] rweight = new int[N], weight = new int[N];
            for (i = 0; i < N; i++)
            {
                temp = ReadLine().Split(' ');
                rname[i] = temp[0] + " " + temp[1];
                rheight[i] = int.Parse(temp[2]);
                rweight[i] = int.Parse(temp[3]);
                if (rweight[i] <= 75) flag = true;
            }

            if(flag)
            {
                j = 0;
                for (i = 0; i < N; i++)
                {
                    if (rweight[i] <= 75)
                    {
                        weight[i] = rweight[i];
                        height[i] = rheight[i];
                        name[i] = rname[i];
                        j++;
                    }
                }
            }
            else
            {
                weight = rweight;
                height = rheight;
                name = rname;
            }

        }
    }
}
