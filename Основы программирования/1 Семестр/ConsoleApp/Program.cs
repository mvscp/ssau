using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите нужное задание:");
                Console.WriteLine("1 - 1 задание\n" + "2 - 2 задание\n" + "3 - 3 задание\n" + "4 - выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            double y;
                            Console.WriteLine("Введите значение xmin: ");
                            double xmin = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите значение xmax: ");
                            double xmax = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите шаг: ");
                            double dx = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("\tx\t\ty");
                            for (double i = xmin; i < xmax; i += dx)
                            {
                                if (i >= -7 && i <= 11)
                                {
                                    if (i <= -3)
                                    {
                                        y = 3;
                                    }
                                    else if (i <= 3)
                                    {
                                        y = 3 - Math.Sqrt(9 - Math.Pow(i, 2));
                                    }
                                    else if (i <= 6)
                                    {
                                        y = 9 - 2 * i;
                                    }
                                    else
                                    {
                                        y = i - 9;
                                    }
                                    Console.WriteLine($"{i,10:#0.00} \t {y,10:#0.00}");
                                }
                                else
                                {
                                    Console.WriteLine("{0,10:#0.00} {1}", i, "\tФункция не определена");
                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            double x, y, r = 2;
                            int n = 0;
                            while (n < 10)
                            {
                                Console.Write("Введите координату x: ");
                                x = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Введите координату y: ");
                                y = Convert.ToDouble(Console.ReadLine());
                                if (x * x + y * y <= r * r && ((x <= 0 && y <= x + 2) || (x > 0 && y >= 0)))
                                    Console.WriteLine("Вы попали в мишень! ");
                                else
                                    Console.WriteLine("Вы не попали в мишень ");
                                n++;
                            }
                        }
                        break;
                    case "3":
                        {
                            double previous, current, e, x, arctg = Math.PI / 2;
                            Console.WriteLine("Введите погрешность: ");
                            e = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите x: ");
                            x = Convert.ToDouble(Console.ReadLine());
                            int n = 0;
                            if (x > 1)
                            {
                                do
                                {
                                    previous = arctg;
                                    current = Math.Pow(-1, n + 1) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                                    arctg += current;
                                    n++;
                                } while (Math.Abs(arctg - previous) > e);
                                Console.WriteLine("Сумма членов ряда: " + arctg);
                                Console.WriteLine("Количество членов в ряду: " + n);
                            }
                            else
                                Console.WriteLine("Некорректное значение x");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}
