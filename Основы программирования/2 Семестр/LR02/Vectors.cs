using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR02
{
    class Vectors
    {
        public static ArrayVector Sum(ArrayVector a, ArrayVector b)
        {
            if (a.x.Length == b.x.Length)
            {
                ArrayVector c = new ArrayVector(a.x.Length);
                for (int i = 0; i < a.x.Length; i++)
                {
                    c.x[i] = a.x[i] + b.x[i];
                }
                return c;
            }
            else
                throw new FormatException();
        }
        public static double Scalar(ArrayVector a, ArrayVector b)
        {
            if (a.x.Length == b.x.Length)
            {
                double res = 0;
                for (int i = 0; i < a.x.Length; i++)
                {
                    res += a.x[i] * b.x[i];
                }
                return res;
            }
            else
                throw new FormatException();
        }
        public static double GetNorm2(ArrayVector a)
        {
            double res = 0;
            for (int i = 0; i < a.x.Length; i++)
                res += Math.Pow(a.x[i], 2);
            res = Math.Sqrt(res);
            return res;
        }
        public static void Output(ArrayVector a)
        {
            for (int i = 0; i < a.x.Length; i++)
                Console.Write(a.x[i] + " ");
        }
    }
}
