using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 5. Классы");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            while (true)
            {
                Console.WriteLine("Выберите нужное задание:");
                Console.WriteLine("1 - Действия над дробями\n" + "2 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Console.Write("Введите числитель первой дроби: ");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите знаменатель первой дроби: ");
                            int d1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите числитель второй дроби: ");
                            int n2 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите знаменатель второй дроби: ");
                            int d2 = Convert.ToInt32(Console.ReadLine());
                            Fraction f1 = new Fraction(n1, d1);
                            Fraction f2 = new Fraction(n2, d2);
                            Console.WriteLine("Выберите действие над дробями:");
                            Console.WriteLine("0 - Выход\n" + "1 - Сложение\n" + "2 - Вычитание\n" + "3 - Умножение\n" + "4 - Деление");
                            string menu1 = Convert.ToString(Console.ReadLine());
                            switch (menu1)
                            {
                                case "0":
                                    return;
                                case "1":
                                    {
                                        Console.WriteLine("Статический метод:");
                                        SFraction.Write(SFraction.Sum(f1, f2));
                                        Console.WriteLine("Операция:");
                                        SFraction.Write(f1 + f2);
                                        Console.WriteLine("Обычный метод:");
                                        SFraction.Write(f1.Sum(f2));
                                    }
                                    break;
                                case "2":
                                    {
                                        Console.WriteLine("Статический метод:");
                                        SFraction.Write(SFraction.Subtraction(f1, f2));
                                        Console.WriteLine("Операция:");
                                        SFraction.Write(f1 - f2);
                                        Console.WriteLine("Обычный метод:");
                                        SFraction.Write(f1.Subtraction(f2));
                                    }
                                    break;
                                case "3":
                                    { 
                                        Console.WriteLine("Статический метод:");
                                        SFraction.Write(SFraction.Multiplication(f1, f2));
                                        Console.WriteLine("Операция:");
                                        SFraction.Write(f1 * f2);
                                        Console.WriteLine("Обычный метод:");
                                        SFraction.Write(f1.Multiplication(f2));
                                    }
                                    break;
                                case "4":
                                    {
                                        Console.WriteLine("Статический метод:");
                                        SFraction.Write(SFraction.Division(f1, f2));
                                        Console.WriteLine("Операция:");
                                        SFraction.Write(f1 / f2);
                                        Console.WriteLine("Обычный метод:");
                                        SFraction.Write(f1.Division(f2));  
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение");
                                    break;
                            }
                        }
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}