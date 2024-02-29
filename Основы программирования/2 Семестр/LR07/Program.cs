using System;

namespace LR07
{
    class Program
    {
        static IVectorable[] vectors;
        public delegate void MenuDelegate();
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №7. Выполнил Лукашевич Роман");
            string menu;
            MenuDelegate menuDelegate = null;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите действие:\n1 - Задать векторы автоматически\n2 - Задать векторы вручную\n0 - Выход");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        menuDelegate = CreateArrayAuto;
                        flag = false;
                        break;
                    case "2":
                        menuDelegate = CreateArray;
                        flag = false;
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
            menuDelegate += OutputArray;
            menuDelegate();
            menuDelegate = null;
            Console.WriteLine("Выберите действия, введя их в строку без пробела:\n1 - Поиск вектора с минимальным числом координат\n" +
                "2 - Поиск вектора с максимальным числом координат\n3 - Сортировка массива\n4 - Клонирование вектора");
            string menu1 = Console.ReadLine();
            char[] chars = menu1.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '1':
                        menuDelegate += VectorMin;
                        break;
                    case '2':
                        menuDelegate += VectorMax;
                        break;
                    case '3':
                        menuDelegate += SortArray;
                        break;
                    case '4':
                        menuDelegate += Cloned;
                        break;
                    default:
                        Console.WriteLine(chars[i] + " - некорректное значение");
                        break;
                }
            }
            menuDelegate();
        }
        public static void OutputArray()
        {
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < vectors.Length; i++)
            {
                Console.WriteLine(vectors[i].ToString());
            }
        }
        public static void CreateArrayAuto()
        {
            ArrayVector a1 = new ArrayVector(new int[] { 1, 3, 5, 7, 8 });
            ArrayVector a2 = new ArrayVector(new int[] { 11, 4, 3, 5, 7, 2 });
            ArrayVector a3 = new ArrayVector(new int[] { 3, -22, 1 });
            LinkedListVector b1 = new LinkedListVector(new int[] { 2, 7, -3, 4, 0 });
            LinkedListVector b2 = new LinkedListVector(new int[] { 3, 2 });
            vectors = new IVectorable[] { a1, a2, b1, b2, a3 };
        }
        public static void CreateArray()
        {
            while (true)
            {
                Console.Write("Введите длину массива: ");
                try
                {
                    int len = int.Parse(Console.ReadLine());
                    if (len <= 0)
                        throw new Exception();
                    vectors = new IVectorable[len];
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Некорректное значение длины");
                }
            }
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] = CreateVector();
            }
        }
        public static IVectorable CreateVector()
        {
            IVectorable vector;
            string menu;
            while (true)
            {
                Console.WriteLine("Выберите тип создаваемого вектора:\n1 - ArrayVector\n2 - LinkedListVector");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        while (true)
                        {
                            try
                            {
                                Console.Write("Введите размерность вектора: ");
                                int len = int.Parse(Console.ReadLine());
                                if (len <= 0)
                                    throw new Exception();
                                vector = new ArrayVector(len);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Размерность должна быть положительной");
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Введите элементы вектора");
                                for (int i = 0; i < vector.Length; i++)
                                {
                                    vector[i] = int.Parse(Console.ReadLine());
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Ошибка ввода");
                            }
                        }
                        return vector;
                    case "2":
                        while (true)
                        {
                            try
                            {
                                Console.Write("Введите размерность вектора: ");
                                int len = int.Parse(Console.ReadLine());
                                if (len <= 0)
                                    throw new Exception();
                                vector = new LinkedListVector(len);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Размерность должна быть положительной");
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Введите элементы вектора");
                                for (int i = 0; i < vector.Length; i++)
                                {
                                    vector[i] = int.Parse(Console.ReadLine());
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Ошибка ввода");
                            }
                        }
                        return vector;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
        public static void ChangeVector(IVectorable vector)
        {
            string menu;
            bool flag = true;
            Console.WriteLine("Изменение вектора");
            while (flag)
            {
                Console.WriteLine(vector.ToString());
                Console.WriteLine("Выберите действие:\n1 - Изменить элемент\n2 - Закончить");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        while (true)
                        {
                            try
                            {
                                Console.Write("Введите индекс элемента: ");
                                int index = int.Parse(Console.ReadLine());
                                Console.Write("Введите новое значение: ");
                                int num = int.Parse(Console.ReadLine());
                                vector[index] = num;
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Ошибка изменения");
                            }
                        }
                        break;
                    case "2":
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Cloned()
        {
            Console.WriteLine("Клонирование вектора");
            IVectorable clone;
            int index;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите индекс клонируемого вектора");
                    index = int.Parse(Console.ReadLine());
                    clone = (IVectorable)vectors[index].Clone();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка клонирования");
                }
            }
            Console.WriteLine("Исходные векторы:\n" + vectors[index].ToString() + '\n' + clone.ToString());
            ChangeVector(clone);
            Console.WriteLine("После изменения клона:\n" + vectors[index].ToString() + '\n' + clone.ToString());
        }
        public static void SortArray()
        {
            Console.WriteLine("Массив после сортировки:");
            IVectorable[] sorted = (IVectorable[])vectors.Clone();
            Array.Sort(sorted, new VectorComparer());
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.WriteLine(sorted[i].ToString() + " \tМодуль вектора: " + sorted[i].GetNorm());
            }
        }
        public static void VectorMin()
        {
            IVectorable[] sorted = (IVectorable[])vectors.Clone();
            Array.Sort(sorted);
            Console.WriteLine("Вектор с минимальным числом координат: " + sorted[0].ToString());
        }
        public static void VectorMax()
        {
            IVectorable[] sorted = (IVectorable[])vectors.Clone();
            Array.Sort(sorted);
            Console.WriteLine("Вектор с максимальным числом координат: " + sorted[vectors.Length - 1].ToString());
        }
    }
}
