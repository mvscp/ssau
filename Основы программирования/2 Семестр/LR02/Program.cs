using System;

namespace LR02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №2. Выполнил Лукашевич Роман");
            bool key = true;
            while (key)
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1 - Операции над массивом");
                Console.WriteLine("2 - Операции над векторами");
                Console.WriteLine("3 - Список");
                Console.WriteLine("0 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Write("Введите количество элементов массива: ");
                        int n = Int32.Parse(Console.ReadLine());
                        if (n <= 0)
                        {
                            Console.WriteLine("Недопустимое значение");
                            break;
                        }
                        ArrayVector a = new ArrayVector(n);
                        Console.WriteLine("Введите значения элементов массива:");
                        for (int i = 0; i < n; i++)
                        {
                            int x = Int32.Parse(Console.ReadLine());
                            a[i] = x;
                        }
                        Console.Write("Ваш массив: ");
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write(a[i] + " ");
                        }
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
                            string po = Console.ReadLine();
                            switch (po)
                            {
                                case "1":
                                    Console.WriteLine("Ввод 1 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int j = Int32.Parse(Console.ReadLine());
                                    ArrayVector g = new ArrayVector(j);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < g.Length; i++)
                                    {
                                        g[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.Write("1 вектор: ");
                                    for (int i = 0; i < g.Length; i++)
                                    {
                                        Console.Write(g[i] + " ");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Ввод 2 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int p = Int32.Parse(Console.ReadLine());
                                    ArrayVector c = new ArrayVector(p);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < c.Length; i++)
                                    {
                                        c[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.Write("2 вектор: ");
                                    for (int i = 0; i < c.Length; i++)
                                    {
                                        Console.Write(c[i] + " ");
                                    }
                                    Console.WriteLine();
                                    ArrayVector res = Vectors.Sum(g, c);
                                    Console.Write("Полученный вектор: ");
                                    for (int i = 0; i < res.Length; i++)
                                    {
                                        Console.Write(res[i] + " ");
                                    }
                                    Console.WriteLine();
                                    break;
                                case "2":
                                    Console.WriteLine("Ввод 1 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int r = Int32.Parse(Console.ReadLine());
                                    ArrayVector z = new ArrayVector(r);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < z.Length; i++)
                                    {
                                        z[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.Write("1 вектор: ");
                                    for (int i = 0; i < z.Length; i++)
                                    {
                                        Console.Write(z[i] + " ");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Ввод 2 вектора");
                                    Console.Write("Введите количество координат вектора: ");
                                    int y = Int32.Parse(Console.ReadLine());
                                    ArrayVector m = new ArrayVector(y);
                                    Console.WriteLine("Введите значения координат вектора:");
                                    for (int i = 0; i < m.Length; i++)
                                    {
                                        m[i] = Int32.Parse(Console.ReadLine());
                                    }
                                    Console.Write("2 вектор: ");
                                    for (int i = 0; i < m.Length; i++)
                                    {
                                        Console.Write(m[i] + " ");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Полученный результат: " + Vectors.Scalar(z,m));
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
                                    Console.Write("Введенный вектор: ");
                                    for (int i = 0; i < t.Length; i++)
                                    {
                                        Console.Write(t[i] + " ");
                                    }
                                    Console.WriteLine();
                                    Console.Write("Полученный результат: ");
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
                    case "3":
                        Console.Write("Введите длину списка: ");
                        int len = Int32.Parse(Console.ReadLine());
                        LinkedListVector link = new LinkedListVector(len);
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("1 - Установить значение по индексу");
                            Console.WriteLine("2 - Удалить значение по индексу");
                            Console.WriteLine("3 - Прочитать значение по индексу");
                            Console.WriteLine("4 - Модуль вектора");
                            Console.WriteLine("5 - Число координат вектора");
                            Console.WriteLine("6 - Добавить в начало");
                            Console.WriteLine("7 - Удалить из начала");
                            Console.WriteLine("8 - Добавить в конец");
                            Console.WriteLine("9 - Удалить из конца");
                            Console.WriteLine("10 - Вывести список");
                            Console.WriteLine("0 - Выход");
                            string menu1 = Console.ReadLine();
                            switch (menu1)
                            {
                                case "1":
                                    Console.Write("Введите индекс: ");
                                    int ind = Int32.Parse(Console.ReadLine());
                                    Console.Write("Введите значение: ");
                                    int val = Int32.Parse(Console.ReadLine());
                                    link.AddIndex(ind, val);
                                    break;
                                case "2":
                                    Console.Write("Введите индекс: ");
                                    int ind1 = Int32.Parse(Console.ReadLine());
                                    link.PopIndex(ind1);
                                    break;
                                case "3":
                                    Console.Write("Введите индекс: ");
                                    ind = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Значение по этому индексу: " + link[ind]);
                                    break;
                                case "4":
                                    Console.WriteLine("Модуль вектора = " + "{0,4:0.00}", link.GetNorm());
                                    break;
                                case "5":
                                    Console.WriteLine("Число координат вектора: " + link.Length);
                                    break;
                                case "6":
                                    Console.Write("Введите значение: ");
                                    int val1 = Int32.Parse(Console.ReadLine());
                                    link.AddStart(val1);
                                    break;
                                case "7":
                                    link.PopStart();
                                    break;
                                case "8":
                                    Console.Write("Введите значение: ");
                                    int val2 = Int32.Parse(Console.ReadLine());
                                    link.AddEnd(val2);
                                    break;
                                case "9":
                                    link.PopEnd();
                                    break;
                                case "10":
                                    for (int i = 0; i < link.Length; i++)
                                        Console.Write(link[i] + " ");
                                    Console.WriteLine();
                                    break;
                                case "0":
                                    flag2 = false;
                                    break;
                                default:
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
