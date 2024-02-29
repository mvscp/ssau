using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 1. Повторение");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            Console.WriteLine("Введите длину массива");
            int x = Int32.Parse(Console.ReadLine());
            ArrayVector a = new ArrayVector(x);
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Установка элемента по индексу\n" + "2 - Чтение элемента по индексу\n" + "3 - Получение длины вектора\n" +
                    "4 - Сумма всех положительных элементов с четным индексом\n" + "5 - Сумма элементов с нечетным индексом и < среднего значения модулей всех элементов\n" +
                    "6 - Произведение четных положительных элементов\n" + "7 - Произведение нечетных элементов, не делящихся на 3\n" +
                    "8 - Сортировка по возрастанию\n" + "9 - Сортировка по убыванию\n" + "10 - Сложение двух векторов\n" + "11 - Скалярное произведение двух векторов\n" +
                    "12 - Умножение вектора на число\n" + "13 - Получение длины вектора\n" + "14 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Console.Write("Введите индекс элемента: ");
                            int ind = Int32.Parse(Console.ReadLine());
                            Console.Write("Введите элемент, на который нужно заменить: ");
                            double elem = Convert.ToDouble(Console.ReadLine());
                            a.SetElement(ind, elem);
                            Vectors.Output(a);
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Введите индекс элемента: ");
                            int ind = Int32.Parse(Console.ReadLine());
                            a.GetElement(ind);
                        }
                        break;
                    case "3":
                        {
                            double res = a.GetNorm();
                            Console.WriteLine("Длина вектора = " + res);
                        }
                        break;
                    case "4":
                        {
                            double res = a.SumPositivesFromChetIndex();
                            Console.WriteLine("Результат: " + res);
                        }
                        break;
                    case "5":
                        {
                            double res = a.SumLessFromNechetIndex();
                            Console.WriteLine("Результат: " + res);
                        }
                        break;
                    case "6":
                        {
                            double res = a.MultChet();
                            Console.WriteLine("Результат: " + res);
                        }
                        break;
                    case "7":
                        {
                            double res = a.MultNechet();
                            Console.WriteLine("Результат: " + res);
                        }
                        break;
                    case "8":
                        {
                            a.SortUp();
                            Vectors.Output(a);
                        }
                        break;
                    case "9":
                        {
                            a.SortDown();
                            Vectors.Output(a);
                        }
                        break;
                    case "10":
                        {
                            Console.Write("Введите размерность второго вектора: ");
                            int y = Int32.Parse(Console.ReadLine());
                            ArrayVector b = new ArrayVector(y);
                            for (int i = 0; i < y; i++)
                            {
                                Console.Write("Введите {0} элемент: ", i);
                                double elem = Convert.ToDouble(Console.ReadLine());
                                b.SetElement(i, elem);
                            }
                            ArrayVector c = Vectors.Sum(a, b);
                            Vectors.Output(c);
                        }
                        break;
                    case "11":
                        {
                            Console.Write("Введите размерность второго вектора: ");
                            int y = Int32.Parse(Console.ReadLine());
                            ArrayVector b = new ArrayVector(y);
                            for (int i = 0; i < y; i++)
                            {
                                Console.Write("Введите {0} элемент: ", i);
                                double elem = Convert.ToDouble(Console.ReadLine());
                                b.SetElement(i, elem);
                            }
                            double res = Vectors.Scalar(a, b);
                            Console.WriteLine("Результат: " + res);
                        }
                        break;
                    case "12":
                        {
                            Console.Write("Введите число: ");
                            double num = Convert.ToDouble(Console.ReadLine());
                            ArrayVector c = Vectors.NumberMult(a, num);
                            Vectors.Output(c);
                        }
                        break;
                    case "13":
                        {
                            double res = Vectors.GetNorm(a);
                            Console.WriteLine("Длина вектора = " + res);
                        }
                        break;
                    case "14":
                        return;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}
