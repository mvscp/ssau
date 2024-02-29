using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LR06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №6. Выполнил Лукашевич Роман");
            while (true)
            {
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine("1 - Байтовый поток\n2 - Символьный поток\n3 - Сериализация\n0 - Выход");
                string n = Console.ReadLine();
                switch (n)
                {
                    case "1":
                        Console.WriteLine("Выберите тип объекта: ");
                        Console.WriteLine("1 - ArrayVector\n2 - LinkedListVector");
                        string n1 = Console.ReadLine();
                        switch (n1)
                        {
                            case "1":
                                Console.WriteLine("Выберите способ создания вектора:");
                                Console.WriteLine("1 - Автоматически\n2 - Вручную");
                                string nn = Console.ReadLine();
                                switch (nn)
                                {
                                    case "1":
                                        int[] array = new int[] { 6, 1, 5, 7, 2 };
                                        ArrayVector vector = new ArrayVector(array);
                                        Vectors.InputByteVector(vector, out BinaryWriter writevector);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector.ToString());
                                        BinaryReader readvector = new BinaryReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output = Vectors.OutputByteVector(in readvector);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output.ToString());
                                        if (vector.Equals(output))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    case "2":
                                        Console.Write("Введите количество координат вектора: ");
                                        int nn1 = int.Parse(Console.ReadLine());
                                        ArrayVector vector2 = new ArrayVector(nn1);
                                        Console.WriteLine("Введите значения координат вектора:");
                                        for (int i = 0; i < nn1; i++)
                                        {
                                            vector2[i] = int.Parse(Console.ReadLine());
                                        }
                                        Vectors.InputByteVector(vector2, out BinaryWriter writevector2);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector2.ToString());
                                        BinaryReader readvector2 = new BinaryReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output2 = Vectors.OutputByteVector(in readvector2);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output2.ToString());
                                        if (vector2.Equals(output2))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Выберите способ создания вектора:");
                                Console.WriteLine("1 - Автоматически\n2 - Вручную");
                                string nn2 = Console.ReadLine();
                                switch (nn2)
                                {
                                    case "1":
                                        int[] array1 = new int[] { 6, 1, 5, 7, 2 };
                                        LinkedListVector vector1 = new LinkedListVector(array1);
                                        Vectors.InputByteVector(vector1, out BinaryWriter writevector1);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector1.ToString());
                                        BinaryReader readvector1 = new BinaryReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output1 = Vectors.OutputByteVector(in readvector1);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output1.ToString());
                                        if (vector1.Equals(output1))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    case "2":
                                        Console.Write("Введите количество координат вектора: ");
                                        int nn1 = int.Parse(Console.ReadLine());
                                        LinkedListVector vector2 = new LinkedListVector(nn1);
                                        Console.WriteLine("Введите значения координат вектора:");
                                        for (int i = 0; i < nn1; i++)
                                        {
                                            vector2[i] = int.Parse(Console.ReadLine());
                                        }
                                        Vectors.InputByteVector(vector2, out BinaryWriter writevector2);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector2.ToString());
                                        BinaryReader readvector2 = new BinaryReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output2 = Vectors.OutputByteVector(in readvector2);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output2.ToString());
                                        if (vector2.Equals(output2))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Некорректное значение");
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Выберите тип объекта: ");
                        Console.WriteLine("1 - ArrayVector\n2 - LinkedListVector");
                        string n2 = Console.ReadLine();
                        switch (n2)
                        {
                            case "1":
                                Console.WriteLine("Выберите способ создания вектора:");
                                Console.WriteLine("1 - Автоматически\n2 - Вручную");
                                string nn2 = Console.ReadLine();
                                switch (nn2)
                                {
                                    case "1":
                                        int[] array = new int[] { 6, 1, 5, 7, 2 };
                                        ArrayVector vector = new ArrayVector(array);
                                        Vectors.WriteVector(vector, out StreamWriter writevector);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector.ToString());
                                        StreamReader readvector = new StreamReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output = Vectors.ReadVector(in readvector);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output.ToString());
                                        if (vector.Equals(output))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    case "2":
                                        Console.Write("Введите количество координат вектора: ");
                                        int nn1 = int.Parse(Console.ReadLine());
                                        ArrayVector vector2 = new ArrayVector(nn1);
                                        Console.WriteLine("Введите значения координат вектора:");
                                        for (int i = 0; i < nn1; i++)
                                        {
                                            vector2[i] = int.Parse(Console.ReadLine());
                                        }
                                        Vectors.WriteVector(vector2, out StreamWriter writevector2);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector2.ToString());
                                        StreamReader readvector2 = new StreamReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output2 = Vectors.ReadVector(in readvector2);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output2.ToString());
                                        if (vector2.Equals(output2))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Выберите способ создания вектора:");
                                Console.WriteLine("1 - Автоматически\n2 - Вручную");
                                string nn = Console.ReadLine();
                                switch (nn)
                                {
                                    case "1":
                                        int[] array1 = new int[] { 6, 1, 5, 7, 2 };
                                        LinkedListVector vector1 = new LinkedListVector(array1);
                                        Vectors.WriteVector(vector1, out StreamWriter writevector1);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector1.ToString());
                                        StreamReader readvector1 = new StreamReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output1 = Vectors.ReadVector(in readvector1);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output1.ToString());
                                        if (vector1.Equals(output1))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    case "2":
                                        Console.Write("Введите количество координат вектора: ");
                                        int nn1 = int.Parse(Console.ReadLine());
                                        LinkedListVector vector2 = new LinkedListVector(nn1);
                                        Console.WriteLine("Введите значения координат вектора:");
                                        for (int i = 0; i < nn1; i++)
                                        {
                                            vector2[i] = int.Parse(Console.ReadLine());
                                        }
                                        Vectors.WriteVector(vector2, out StreamWriter writevector2);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector2.ToString());
                                        StreamReader readvector2 = new StreamReader(File.OpenRead("DataFile.dat"));
                                        IVectorable output2 = Vectors.ReadVector(in readvector2);
                                        Console.Write("Вектор в файле: ");
                                        Console.WriteLine(output2.ToString());
                                        if (vector2.Equals(output2))
                                            Console.WriteLine("Векторы равны");
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Некорректное значение");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Выберите тип объекта: ");
                        Console.WriteLine("1 - ArrayVector\n2 - LinkedListVector");
                        string n3 = Console.ReadLine();
                        switch (n3)
                        {
                            case "1":
                                Console.WriteLine("Выберите способ создания вектора:");
                                Console.WriteLine("1 - Автоматически\n2 - Вручную");
                                string nn = Console.ReadLine();
                                switch (nn)
                                {
                                    case "1":
                                        int[] array = new int[] { 6, 1, 5, 7, 2 };
                                        ArrayVector vector = new ArrayVector(array);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector.ToString());
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.OpenOrCreate))
                                        {
                                            BinaryFormatter module = new BinaryFormatter();
                                            module.Serialize(fs, vector);
                                        }
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.Open))
                                        {
                                            BinaryFormatter module1 = new BinaryFormatter();
                                            IVectorable v = (IVectorable)module1.Deserialize(fs);
                                            Console.Write("Вектор в файле: ");
                                            Console.WriteLine(v.ToString());
                                            if (vector.Equals(v))
                                                Console.WriteLine("Векторы равны");
                                        }
                                        break;
                                    case "2":
                                        Console.Write("Введите количество координат вектора: ");
                                        int nn1 = int.Parse(Console.ReadLine());
                                        ArrayVector vector2 = new ArrayVector(nn1);
                                        Console.WriteLine("Введите значения координат вектора:");
                                        for (int i = 0; i < nn1; i++)
                                        {
                                            vector2[i] = int.Parse(Console.ReadLine());
                                        }
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector2.ToString());
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.OpenOrCreate))
                                        {
                                            BinaryFormatter module = new BinaryFormatter();
                                            module.Serialize(fs, vector2);
                                        }
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.Open))
                                        {
                                            BinaryFormatter module1 = new BinaryFormatter();
                                            IVectorable v = (IVectorable)module1.Deserialize(fs);
                                            Console.Write("Вектор в файле: ");
                                            Console.WriteLine(v.ToString());
                                            if (vector2.Equals(v))
                                                Console.WriteLine("Векторы равны");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Выберите способ создания вектора:");
                                Console.WriteLine("1 - Автоматически\n2 - Вручную");
                                string nn2 = Console.ReadLine();
                                switch (nn2)
                                {
                                    case "1":
                                        int[] array1 = new int[] { 6, 1, 5, 7, 2 };
                                        LinkedListVector vector1 = new LinkedListVector(array1);
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector1.ToString());
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.OpenOrCreate))
                                        {
                                            BinaryFormatter module2 = new BinaryFormatter();
                                            module2.Serialize(fs, vector1);
                                        }
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.Open))
                                        {
                                            BinaryFormatter module3 = new BinaryFormatter();
                                            IVectorable v = (IVectorable)module3.Deserialize(fs);
                                            Console.Write("Вектор в файле: ");
                                            Console.WriteLine(v.ToString());
                                            if (vector1.Equals(v))
                                                Console.WriteLine("Векторы равны");
                                        }
                                        break;
                                    case "2":
                                        Console.Write("Введите количество координат вектора: ");
                                        int nn1 = int.Parse(Console.ReadLine());
                                        LinkedListVector vector2 = new LinkedListVector(nn1);
                                        Console.WriteLine("Введите значения координат вектора:");
                                        for (int i = 0; i < nn1; i++)
                                        {
                                            vector2[i] = int.Parse(Console.ReadLine());
                                        }
                                        Console.Write("Исходный вектор: ");
                                        Console.WriteLine(vector2.ToString());
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.OpenOrCreate))
                                        {
                                            BinaryFormatter module2 = new BinaryFormatter();
                                            module2.Serialize(fs, vector2);
                                        }
                                        using (FileStream fs = new FileStream("DataFile.dat", FileMode.Open))
                                        {
                                            BinaryFormatter module3 = new BinaryFormatter();
                                            IVectorable v = (IVectorable)module3.Deserialize(fs);
                                            Console.Write("Вектор в файле: ");
                                            Console.WriteLine(v.ToString());
                                            if (vector2.Equals(v))
                                                Console.WriteLine("Векторы равны");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Некорректное значение");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Некорректное значение");
                                break;
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}
