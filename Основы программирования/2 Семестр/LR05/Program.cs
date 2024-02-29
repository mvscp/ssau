using System;

namespace LR05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5. Выполнил Лукашевич Роман");
            Console.Write("Введите количество элементов 1-го массива: ");
            int n = int.Parse(Console.ReadLine());
            ArrayVector a = new ArrayVector(n);
            Console.WriteLine("Введите значения элементов 1-го массива:");
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                a[i] = x;
            }
            Console.WriteLine(a.ToString());
            Console.Write("Введите количество элементов 2-го массива: ");
            n = int.Parse(Console.ReadLine());
            LinkedListVector b = new LinkedListVector(n);
            Console.WriteLine("Введите значения элементов 2-го массива:");
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                b[i] = x;
            }
            Console.WriteLine(b.ToString());
            Console.WriteLine();
            ArrayVector a1 = new ArrayVector(new int[] {1, 3, 5, 7, 8});
            ArrayVector a2 = new ArrayVector(new int[] {11, 4, 3, 5, 7, 2});
            ArrayVector a3 = new ArrayVector(new int[] {3, -22, 1});
            LinkedListVector b1 = new LinkedListVector(new int[] {2, 7, -3, 4, 0});
            LinkedListVector b2 = new LinkedListVector(new int[] {3, 2});
            IVectorable[] vectors = new IVectorable[1];
            vectors = new IVectorable[] {a, b, a1, a2, b1, b2, a3};
            for (int i = 0; i < vectors.Length; i++)
            {
                Console.WriteLine(vectors[i].ToString());
            }
            Console.WriteLine();
            IVectorable temp = vectors[0];
            IVectorable temp1 = vectors[0];
            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].CompareTo(temp) < 0)
                {
                    temp = vectors[i];
                }
                if (vectors[i].CompareTo(temp1) > 0)
                {
                    temp1 = vectors[i];
                }
            }
            Console.WriteLine("Вектор с минимальным количеством координат: " + temp.ToString());
            Console.WriteLine("Вектор с максимальным количеством координат: " + temp1.ToString());
            VectorComparer comparer = new VectorComparer();
            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < vectors.Length - 1; j++)
                {
                    if (comparer.Compare(vectors[j], vectors[j+1]) > 0)
                    {
                        temp = vectors[j];
                        vectors[j] = vectors[j+1];
                        vectors[j+1] = temp;
                    }
                    
                }
            }
            Console.WriteLine("Отсортированный массив векторов: ");
            for (int i = 0; i < vectors.Length; i++)
            {
                Console.WriteLine(vectors[i].ToString() + " Модуль вектора: " + vectors[i].GetNorm());
            }
            Console.WriteLine("Выберите индекс вектора для клонирования: ");
            n = int.Parse(Console.ReadLine());
            object cloned = new object();
            if (n >= 0 && n < vectors.Length)
            {
                cloned = vectors[n].Clone();
            }
            else
                throw new IndexOutOfRangeException();
            IVectorable cloned1 = (IVectorable)cloned;
            Console.WriteLine("Исходный вектор: " + vectors[n].ToString());
            Console.WriteLine("Клонированный вектор: " + cloned1.ToString());
            Console.Write("Выберите индекс для замены элемента в клонированном векторе: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент для замены: ");
            int n1 = int.Parse(Console.ReadLine());
            if (n >= 0 && n < vectors.Length)
            {
                cloned1[n] = n1;
            }
            else
                throw new IndexOutOfRangeException();
            Console.WriteLine("Исходный вектор: " + vectors[n].ToString());
            Console.WriteLine("Клонированный вектор: " + cloned1.ToString());
        }
    }
}
