using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 3. Матрицы");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            while (true)
            {
                Console.WriteLine("Выберите нужное задание:");
                Console.WriteLine("1 - Обработка матриц\n" + "2 - Перевод из двоичной с/c в десятичную\n" + "3 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Console.Write("Введите размер матрицы: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            int[,] mas = new int[n, n];
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < n; j++)
                                {
                                    Console.Write("Введите элемент {0}:{1}: ", i+1, j+1);
                                    int value = Convert.ToInt32(Console.ReadLine());
                                    mas[i, j] = value;
                                }
                            }
                            Console.WriteLine("Выберите операцию:");
                            Console.WriteLine("1 - Сложение\n" + "2 - Вычитание\n" + 
                                "3 - Умножение на число\n" + "4 - Умножение матриц\n" + 
                                "5 - Сравнение матриц\n" + "6 - Транспонирование");
                            string operation = Console.ReadLine();
                            switch(operation)
                            {
                                case "1":
                                    {
                                        int[,] mas1 = new int[n, n];
                                        Console.WriteLine("Создание второй матрицы:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write("Введите элемент {0}:{1}: ", i+1, j+1);
                                                int value = Convert.ToInt32(Console.ReadLine());
                                                mas1[i, j] = value;
                                                mas[i, j] += mas1[i, j];
                                            }
                                        }
                                        Console.WriteLine("Сумма матриц равна:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write("{0} \t", mas[i, j]);
                                            }
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                                case "2":
                                    {
                                        int[,] mas1 = new int[n, n];
                                        Console.WriteLine("Создание второй матрицы:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write("Введите элемент {0}:{1}: ", i + 1, j + 1);
                                                int value = Convert.ToInt32(Console.ReadLine());
                                                mas1[i, j] = value;
                                                mas[i, j] -= mas1[i, j];
                                            }
                                        }
                                        Console.WriteLine("Разность матриц равна:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write("{0} \t", mas[i, j]);
                                            }
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                                case "3":
                                    {
                                        Console.Write("Введите число, на которое нужно умножить: ");
                                        int num = Convert.ToInt32(Console.ReadLine());
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                mas[i, j] *= num;
                                                Console.Write("{0} \t", mas[i, j]);
                                            }
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                                case "4":
                                    {
                                        Console.Write("Введите размер матрицы: ");
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        if (m != n)
                                        {
                                            Console.WriteLine("Умножение невозможно");
                                            break;
                                        }
                                        int[,] mas1 = new int[n, n];
                                        Console.WriteLine("Создание второй матрицы:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write("Введите элемент {0}:{1}: ", i + 1, j + 1);
                                                int value = Convert.ToInt32(Console.ReadLine());
                                                mas1[i, j] = value;
                                            }
                                        }
                                        int[,] mas2 = new int[n, n];
                                        Console.WriteLine("Произведение матриц равно:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                for (int k = 0; k < n; k++)
                                                {
                                                    mas2[i, j] += mas[i, k] * mas1[k, j];
                                                }
                                                Console.Write("{0} \t", mas2[i, j]);
                                            }
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                                case "5":
                                    {
                                        Console.Write("Введите размер матрицы: ");
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        if (m != n)
                                        {
                                            Console.WriteLine("Сравнение невозможно");
                                            break;
                                        }
                                        int[,] mas1 = new int[n, n];
                                        int c = 0;
                                        Console.WriteLine("Создание второй матрицы:");
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write("Введите элемент {0}:{1}: ", i + 1, j + 1);
                                                int value = Convert.ToInt32(Console.ReadLine());
                                                mas1[i, j] = value;
                                                if (mas1[i, j] != mas[i, j])
                                                    c += 1;
                                            }
                                        }
                                        if (c == 0)
                                            Console.WriteLine("Матрицы равны");
                                        else
                                            Console.WriteLine("Матрицы не равны");
                                    }
                                    break;
                                case "6":
                                    {
                                        Console.WriteLine("Транспонированная матрица:");
                                        int[,] mas1 = new int[n, n];
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                mas1[i, j] = mas[j, i];
                                                Console.Write("{0} \t", mas1[i, j]);
                                            }
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Введите число в десятичной системе счисления: ");
                            int decimalNum = Int32.Parse(Console.ReadLine());
                            int divide = 0;
                            string binaryNum = "";
                            Console.WriteLine("Десятичное число: {0}", decimalNum);
                            while (decimalNum > 0)
                            {
                                divide = decimalNum % 2;
                                decimalNum /= 2;
                                binaryNum = divide.ToString() + binaryNum;
                            }
                            Console.WriteLine("Двоичное число: {0}", binaryNum);
                            Char[] triad = binaryNum.ToCharArray();
                            int c = 0;
                            while (triad.Length < 9)
                            {
                                Array.Resize(ref triad, triad.Length + 1);
                                triad[triad.Length - 1] = '0';
                                c++;
                            }
                            for (int n = 0; n < c; n++)
                            {
                                char last = triad[triad.Length - 1];
                                for (int i = triad.Length - 1; i > 0; i--)
                                {
                                    triad[i] = triad[i-1];
                                }
                                triad[0] = last;
                            }
                            for (int i = 0; i < 3; i++)
                            {
                                char k = triad[i];
                                triad[i] = triad[i + 6];
                                triad[i + 6] = k;
                            }
                            string res = new string(triad);
                            Console.WriteLine("После смены триад местами: {0}", res);
                            decimalNum = 0;
                            for (int j = 0; j < res.Length; j++)
                            {
                                if (res[res.Length - 1 - j] == '0') continue;
                                decimalNum += (int)Math.Pow(2, j);
                            }
                            Console.WriteLine("Десятичное число: {0}", decimalNum);
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}