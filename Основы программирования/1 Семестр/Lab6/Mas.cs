using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Mas
    {
        public int[][] x;
        public Mas()
        { }
        public Mas(int m)
        {
            x = new int[m][];
        }
        public void Input()
        {
            Console.WriteLine("Ступенчатый массив:");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write("Введите длину {0} ступени: ", i+1);
                int l = Convert.ToInt32(Console.ReadLine());
                x[i] = new int[l];
                Console.WriteLine("Заполнение ступени:");
                for (int j = 0; j < l; j++)
                {
                    Console.Write("Введите {0} элемент ступени: ", j+1);
                    x[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void Output()
        {
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x[i].Length; j++)
                {
                    Console.Write(x[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void SortMax()
        {
            int sum = 0;
            int count = -1;
            for (int i = 0; i < x.Length; i++)
            { sum += x[i].Length; }
            int[] y = new int[sum];
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x[i].Length; j++)
                {
                    count++;
                    y[count] = x[i][j];
                }
            }
            Sort.BubbleSort(y);
            for (int i = x.Length - 1; i >= 0; i--)
            {
                for (int j = x[i].Length - 1; j >= 0; j--)
                {
                    x[i][j] = y[count];
                    count--;
                }
            }
        }
        public void SortMin()
        {
            int sum = 0;
            int count = -1;
            for (int i = 0; i < x.Length; i++)
            { sum += x[i].Length; }
            int[] y = new int[sum];
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x[i].Length; j++)
                {
                    count++;
                    y[count] = x[i][j];
                }
            }
            Sort.BubbleSort(y);
            Array.Reverse(y);
            for (int i = x.Length - 1; i >= 0; i--)
            {
                for (int j = x[i].Length - 1; j >= 0; j--)
                {
                    x[i][j] = y[count];
                    count--;
                }
            }
        }
    }
}
