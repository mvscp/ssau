using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите нужное задание:");
                Console.WriteLine("1 - Расчет по формулам\n" + "2 - График функции\n" + "3 - Стрельба по мишени\n" + "4 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Console.Write("Введите угол a в градусах: ");
                            double a = double.Parse(Console.ReadLine());
                            double z1 = Math.Cos(a * Math.PI / 180) + Math.Sin(a * Math.PI / 180) + Math.Cos(a * Math.PI / 60) + Math.Sin(a * Math.PI / 60);
                            double z2 = 2 * Math.Pow(2, 0.5) * Math.Cos(a * Math.PI / 180) * Math.Sin(Math.PI / 4 + a * Math.PI / 90);
                            Console.WriteLine("z1 = " + z1);
                            Console.WriteLine("z2 = " + z2);
                        }
                        break;
                    case "2":
                        {
                            double y;
                            Console.Write("Введите значение x: ");
                            double x = Convert.ToDouble(Console.ReadLine());
                            if (x >= -7 && x <= 11)
                            {
                                if (x <= -3)
                                {
                                    y = 3;
                                }
                                else if (x <= 3)
                                {
                                    y = 3 - Math.Sqrt(9 - Math.Pow(x, 2));
                                }
                                else if (x <= 6)
                                {
                                    y = 9 - 2 * x;
                                }
                                else
                                {
                                    y = x - 9;
                                }
                                Console.WriteLine("y = " + y);
                            }
                            else
                                Console.WriteLine("Функция не определена ");
                        }
                        break;
                    case "3":
                        {
                            double x, y, R = 2;
                            Console.Write("Введите координату x: ");
                            x = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введите координату y: ");
                            y = Convert.ToDouble(Console.ReadLine());
                            if (x * x + y * y <= R * R && ((x <= 0 && y <= x + 2) || (x > 0 && y >= 0)))
                                Console.WriteLine("Вы попали в мишень! ");
                            else
                                Console.WriteLine("Вы не попали в мишень ");
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
