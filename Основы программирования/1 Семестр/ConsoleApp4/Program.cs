using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 4. Простейшие классы");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            while (true)
            {
                Console.WriteLine("Выберите нужное задание:");
                Console.WriteLine("1 - Счетчик\n" + "2 - Квадратное уравнение\n" + "3 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Console.Write("Введите левую границу диапазона: ");
                            int minV = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите правую границу диапазона: ");
                            int maxV = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите текущее значение: ");
                            int curV = Convert.ToInt32(Console.ReadLine());
                            Counter c = new Counter(minV, maxV, curV);
                            bool n = true;
                            while(n == true)
                            {
                                Console.WriteLine("Выберите действие:");
                                Console.WriteLine("1 - Увеличение значения на 1\n" + "2 - Уменьшение значения на 1\n" + "3 - Получение текущего значения\n" + "4 - Выход");
                                string menu1 = Console.ReadLine();
                                switch (menu1)
                                {
                                    case "1":
                                        c.Inc();
                                        Console.WriteLine("Увеличение на единицу: " + c.GetV());
                                        break;
                                    case "2":
                                        c.Dec();
                                        Console.WriteLine("Уменьшение на единицу: " + c.GetV());
                                        break;
                                    case "3":
                                        Console.WriteLine("Текущее значение: " + c.GetV());
                                        break;
                                    case "4":
                                        n = false;
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                            }
                        }
                        break;
                    case "2":
                        {  
                            Console.Write("Введите a: ");
                            int a = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите b: ");
                            int b = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите c: ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            Polynominal x = new Polynominal(a, b, c);
                            Console.WriteLine(x.Solution());
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
