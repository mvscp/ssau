using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR07
{
    internal class ArrayVector : IVectorable
    {
        public int[] x;
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
        public ArrayVector(int[] array)
        {
            x = array;
        }
        public int Length
        {
            get
            {
                return x.Length;
            }
        }
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
        public double GetNorm()
        {
            double res = 0;
            for (int i = 0; i < x.Length; i++)
                res += Math.Pow(this[i], 2);
            res = Math.Sqrt(res);
            return res;
        }
        public int CompareTo(object obj)
        {
            if (obj is IVectorable s)
            {
                return Length.CompareTo(s.Length);
            }
            throw new ArgumentException();
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
        public override bool Equals(object obj)
        {
            if (obj.GetType().GetInterface("IVectorable") == null)
            {
                return false;
            }
            IVectorable vector = (IVectorable)obj;
            if (Length != vector.Length)
                return false;
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (this[i] != vector[i])
                        return false;
                }
                return true;
            }
        }
        public override int GetHashCode()
        {
            return x.GetHashCode();
        }
        public object Clone()
        {
            ArrayVector arrayVector = new ArrayVector(Length);
            for (int i = 0; i < Length; i++)
            {
                arrayVector[i] = this[i];
            }
            return arrayVector;
        }
    }
}
