using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR04
{
    class ArrayVector : IVectorable
    {
        public int[] x;
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < x.Length)
                    return x[index];
                else
                    throw new ArgumentOutOfRangeException("Недопустимое значение индекса.");
            }
            set
            {
                if (index >= 0 && index < x.Length)
                    x[index] = value;
                else
                    throw new ArgumentOutOfRangeException("Недопустимое значение индекса.");
            }
        }
        public int Length
        {
            get
            {
                return x.Length;
            }
        }
        public ArrayVector(int a)
        {
            if (a > 0)
            {
                x = new int[a];
            }
            else
            {
                throw new ArgumentException("Длина вектора меньше 0");
            }
        }
        public ArrayVector()
        {
            x = new int[5];
        }
        public double GetNorm()
        {
            double res = 0;
            for (int i = 0; i < x.Length; i++)
                res += Math.Pow(this[i], 2);
            res = Math.Sqrt(res);
            return res;
        }
        public override string ToString()
        {
            string res = Length.ToString();
            for (int i = 0; i < Length; i++)
            { 
                res += " " + this[i];
            }
            return res;
        }
    }
}
