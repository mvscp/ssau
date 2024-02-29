using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR05
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
    }
}
