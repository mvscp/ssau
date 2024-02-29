using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 7. Работа со строками");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            Console.Write("Введите строку: ");
            string x = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Выберите нужное задание:");
            Console.WriteLine("1 - Подсчет букв\n" + "2 - Средняя длина слова\n" + "3 - Замена слов\n" + "4 - Количество вхождений подстроки\n" + "5 - Палиндром\n" + "6 - Дата\n" + "7 - Выход");
            string menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    {
                        int c = Str.CountLetter(x);
                        Console.WriteLine("Количество букв: {0}", c);
                    }
                    break;
                case "2":
                    {
                        float l = Str.MidLength(x);
                        Console.WriteLine("Средняя длина слова: {0}", l);
                    }
                    break;
                case "3":
                    {
                        Console.Write("Введите заменяемое слово: ");
                        string y = Convert.ToString(Console.ReadLine());
                        Console.Write("Введите слово, на которое нужно заменить: ");
                        string z = Convert.ToString(Console.ReadLine());
                        Console.WriteLine(Str.Replace(x, y, z));
                    }
                    break;
                case "4":
                    {
                        Console.Write("Введите проверяемую подстроку: ");
                        string y = Convert.ToString(Console.ReadLine());
                        int c = Str.CountString(x, y);
                        Console.WriteLine("Количество вхождений подстроки: {0}", c);
                    }
                    break;
                case "5":
                    {
                        if (Str.Palindrome(x))
                            Console.WriteLine("Строка является палиндромом");
                        else
                            Console.WriteLine("Строка не является палиндромом");
                    }
                    break;
                case "6":
                    {
                        if (Str.Data(x))
                            Console.WriteLine("Строка является датой");
                        else
                            Console.WriteLine("Строка не является датой");
                    }
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Некорректное значение");
                    break;
            }
            Console.ReadKey();
        }
    }
}
