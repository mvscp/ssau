using System;

namespace LR04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №4. Выполнил Лукашевич Роман");
            bool key = true;
            while (key)
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1 - Операции над массивом");
                Console.WriteLine("2 - Операции над векторами");
                Console.WriteLine("0 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Write("Введите количество элементов массива: ");
                        ArrayVector a;
                        int n = Int32.Parse(Console.ReadLine());
                        if (n <= 0)
                        {
                            Console.WriteLine("Недопустимое значение");
                            break;
                        }
                        a = new ArrayVector(n);
                        Console.WriteLine("Введите значения элементов массива:");
                        for (int i = 0; i < n; i++)
                        {
                            int x = Int32.Parse(Console.ReadLine());
                            a[i] = x;
                        }
                        Console.Write(a.ToString());
                        Console.WriteLine();
                        bool flag = true;
                        while (flag)
                        {
                            Console.WriteLine("Выберите операцию над массивом:");
                            Console.WriteLine("1 - Модуль");
                            Console.WriteLine("0 - Выход");
                            string op = Console.ReadLine();
                            switch (op)
                            {
                                case "1":
                                    Console.WriteLine("Модуль равен {0,4:0.00}", a.GetNorm());
                                    break;
                                case "0":
                                    flag = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "2":
                        bool flag1 = true;
                        while (flag1)
                        {
                            Console.WriteLine("Выберите операцию над векторами:");
                            Console.WriteLine("1 - Сложение двух векторов");
                            Console.WriteLine("2 - Скалярное произведение двух векторов");
                            Console.WriteLine("3 - Получение модуля (длины) вектора");
                            Console.WriteLine("0 - Выход");
                            string m1 = Console.ReadLine();
                            switch (m1)
                            {
                                case "1":
                                    Console.WriteLine("Ввод 1 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int j = Int32.Parse(Console.ReadLine());
                                    LinkedListVector g = new LinkedListVector(j);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < g.Length; i++)
                                    {
                                        g[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine("1 вектор: " + g.ToString());
                                    Console.WriteLine("Ввод 2 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int p = Int32.Parse(Console.ReadLine());
                                    ArrayVector c = new ArrayVector(p);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < c.Length; i++)
                                    {
                                        c[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine("2 вектор: " + c.ToString());
                                    Console.WriteLine("Полученный вектор: " + Vectors.Sum(g, c).ToString());
                                    break;
                                case "2":
                                    Console.WriteLine("Ввод 1 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int r = Int32.Parse(Console.ReadLine());
                                    LinkedListVector z = new LinkedListVector(r);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < z.Length; i++)
                                    {
                                        z[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine("1 вектор: " + z.ToString());
                                    Console.WriteLine("Ввод 2 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int y = Int32.Parse(Console.ReadLine());
                                    LinkedListVector m = new LinkedListVector(y);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < m.Length; i++)
                                    {
                                        m[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine("2 вектор: " + m.ToString());
                                    Console.WriteLine("Полученный результат: " + Vectors.Scalar(z, m));
                                    break;
                                case "3":
                                    Console.Write("Введите количество координат вектора: ");
                                    int l = Int32.Parse(Console.ReadLine());
                                    ArrayVector t = new ArrayVector(l);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < t.Length; i++)
                                    {
                                        t[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine("Введенный вектор: " + t.ToString());
                                    Console.WriteLine("Полученный результат: ");
                                    Console.WriteLine("{0,4:0.00}", Vectors.GetNorm2(t));
                                    break;
                                case "0":
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение.");
                                    break;
                            }
                        }
                        break;
                    case "0":
                        key = false;
                        break;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}
