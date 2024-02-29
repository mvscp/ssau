using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class MyMas
    {
        public int[,] x;
        public MyMas()
        { }
        public MyMas(int m, int n)
        {
            x = new int[m, n];
        }
        public void Fill()
        {
            Random rnd = new Random();
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    x[i, j] = rnd.Next(-100, 100);
                    Console.Write(x[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void Output()
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.Write(x[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void SortUp(int[,] Array)
        {
            for (int n = 0; n < Array.GetLength(1); n++)
            {
                for (int col = 1; col < Array.GetLength(1); col++)
                {
                    int PrevCol = 0;
                    for (int m = 0; m < Array.GetLength(0); m++)
                    {
                        PrevCol += Array[m, col - 1];
                    }
                    int CurrCol = 0;
                    for (int m = 0; m < Array.GetLength(0); m++)
                    {
                        CurrCol += Array[m, col];
                    }
                    if (PrevCol > CurrCol)
                    {
                        for (int k = 0; k < Array.GetLength(0); k++)
                        {
                            int temp = Array[k, col];
                            Array[k, col] = Array[k, col - 1];
                            Array[k, col - 1] = temp;
                        }
                    }
                }
            }
        }
        public void SortDown(int[,] Array)
        {
            for (int n = 0; n < Array.GetLength(1); n++)
            {
                for (int col = 1; col < Array.GetLength(1); col++)
                {
                    int PrevCol = 0;
                    for (int m = 0; m < Array.GetLength(0); m++)
                    {
                        PrevCol += Array[m, col - 1];
                    }
                    int CurrCol = 0;
                    for (int m = 0; m < Array.GetLength(0); m++)
                    {
                        CurrCol += Array[m, col];
                    }
                    if (PrevCol < CurrCol)
                    {
                        for (int k = 0; k < Array.GetLength(0); k++)
                        {
                            int temp = Array[k, col];
                            Array[k, col] = Array[k, col - 1];
                            Array[k, col - 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
