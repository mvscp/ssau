using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 6. Массивы");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            while (true)
            {
                Console.WriteLine("Выберите нужное задание:");
                Console.WriteLine("1 - Сортировка\n" + "2 - Двумерный массив\n" + "3 - Ступенчатый массив\n" + "4 - Выход");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Console.Write("Укажите длину массива: ");
                            Sort mas = new Sort(Int32.Parse(Console.ReadLine()));
                            mas.Input();
                            Console.WriteLine("Выберите сортировку:");
                            Console.WriteLine("1 - Пузырьком\n" + "2 - Сортировка Шелла\n" + "3 - Вставками\n" + "4 - Выход");
                            string menu1 = Convert.ToString(Console.ReadLine());
                            switch (menu1)
                            {
                                case "1":
                                    {
                                        Sort.BubbleSort(mas.x);
                                        mas.Output();
                                    }
                                    break;
                                case "2":
                                    {
                                        Sort.ShellSort(mas.x);
                                        mas.Output();
                                    }
                                    break;
                                case "3":
                                    {
                                        Sort.InsertionSort(mas.x);
                                        mas.Output();
                                    }
                                    break;
                                case "4":
                                    return;
                                default:
                                    Console.WriteLine("Некорректное значение");
                                    break;
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Укажите количество строк: ");
                            int m = Int32.Parse(Console.ReadLine());
                            Console.Write("Укажите количество столбцов: ");
                            int n = Int32.Parse(Console.ReadLine());
                            MyMas a = new MyMas(m, n);
                            a.Fill();
                            Console.WriteLine("Сортировка по возрастанию суммы элементов столбцов:");
                            a.SortUp(a.x);
                            a.Output();
                            Console.WriteLine("Сортировка по убыванию суммы элементов столбцов:");
                            a.SortDown(a.x);
                            a.Output();
                        }
                        break;
                    case "3":
                        {
                            Console.Write("Введите число строк массива: ");
                            int m = Int32.Parse(Console.ReadLine());
                            Mas a = new Mas(m);
                            a.Input();
                            Console.WriteLine();
                            a.Output();
                            Console.WriteLine("Сортировка по возрастанию:");
                            a.SortMax();
                            a.Output();
                            Console.WriteLine("Сортировка по убыванию:");
                            a.SortMin();
                            a.Output();
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
