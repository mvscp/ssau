using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR02
{
    class ArrayVector
    {
        public double[] x;
        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < x.Length)
                    return x[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < x.Length)
                    x[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
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
            x = new double[a];
        }
        public ArrayVector()
        {
            x = new double[5];
        }
        public double GetNorm()
        {
            double res = 0;
            for (int i = 0; i < x.Length; i++)
                res += Math.Pow(this[i], 2);
            res = Math.Sqrt(res);
            return res;
        }
    }
}
