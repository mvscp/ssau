using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LR06
{
    internal class Vectors
    {
        public static IVectorable Sum(IVectorable a, IVectorable b)
        {
            if (a.Length == b.Length)
            {
                IVectorable c = new ArrayVector(a.Length);
                for (int i = 0; i < a.Length; i++)
                {
                    c[i] = a[i] + b[i];
                }
                return c;
            }
            else
                throw new FormatException("Количество координат векторов должно быть равным");
        }
        public static double Scalar(IVectorable a, IVectorable b)
        {
            if (a.Length == b.Length)
            {
                double res = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    res += a[i] * b[i];
                }
                return res;
            }
            else
                throw new FormatException("Количество координат векторов должно быть равным");
        }
        public static double GetNorm2(IVectorable a)
        {
            double res = 0;
            for (int i = 0; i < a.Length; i++)
                res += Math.Pow(a[i], 2);
            res = Math.Sqrt(res);
            return res;
        }
        public static void Output(IVectorable a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
        }
        public static void InputByteVector(IVectorable v, out BinaryWriter vector)
        {
            using (vector = new BinaryWriter(File.Open("DataFile.dat", FileMode.Truncate)))
            {
                vector.Write(v.Length);
                for (int i = 0; i < v.Length; i++)
                {
                    vector.Write(v[i]);
                }
            }
        }
        public static IVectorable OutputByteVector(in BinaryReader vector)
        {
            int[] array;
            using (vector)
            {
                int length = vector.ReadInt32();
                array = new int[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = vector.ReadInt32();
                }
            }
            return new ArrayVector(array);
        }
        public static void WriteVector(IVectorable v, out StreamWriter vector)
        {
            using (vector = new StreamWriter("DataFile.dat"))
            {
                vector.Write(Convert.ToString(v.GetType()) + " ");
                vector.WriteLine(v.ToString());
            }
        }
        public static IVectorable ReadVector(in StreamReader vector)
        {
            using (vector)
            {
                string str = vector.ReadLine();
                string[] type = str.Split(' ', 2);
                str = str.Remove(0, type[0].Length + 1);
                string[] array = str.Split(" ");
                int length = Convert.ToInt32(array[0]);
                int[] array1 = new int[length];
                for (int i = 0; i < length; i++)
                {
                    array1[i] = Convert.ToInt32(array[i+1]);
                }
                switch (type[0])
                {
                    case "LR06.ArrayVector":
                        return new ArrayVector(array1);
                    default:
                        return new LinkedListVector(array1);
                }
            }
        }
    }
}