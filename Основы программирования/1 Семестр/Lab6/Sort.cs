using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Sort
    {
        public int[] x;
        public Sort()
        { }
        public Sort(int n)
        {
            x = new int[n];
        }
        public void Input()
        {
            for (int j = 0; j < x.Length; j++)
            {
                Console.Write("Введите элемент {0}: ", j + 1);
                x[j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Output()
        {
            for (int j = 0; j < x.Length; j++)
            {
                Console.Write(x[j] + " ");
            }
            Console.WriteLine();
        }
        public static void BubbleSort(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int swap = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = swap;
                    }
                }
            }
        }
        public static void ShellSort(int[] Array)
        {
            int step = Array.Length / 2;
            while (step > 0)
            {
                int distance;
                for (int i = step; i < Array.Length; i++)
                {
                    distance = i - step;
                    while ((distance >= 0) && (Array[distance] > Array[i]))
                    {
                        int swap = Array[i];
                        Array[i] = Array[distance];
                        Array[distance] = swap;
                        i = distance;
                        distance = i - step;
                    }
                }
                step /= 2;
            }
        }
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
        }
    }
}
