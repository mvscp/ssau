using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR01
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
        public ArrayVector(int a)
        {
            x = new double[a];
        }
        public ArrayVector()
        {
            x = new double[5];
        }
        public void SetElement(int index, double el)
        {
            this[index] = el;
        }
        public double GetElement(int index)
        {
            return this[index];
        }
        public double GetNorm()
        {
            double res = 0;
            for (int i = 0; i < x.Length; i++)
                res += Math.Pow(this[i], 2);
            res = Math.Sqrt(res);
            return res;
        }
        public double SumPositivesFromChetIndex()
        {
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (this[i] > 0)
                    sum += this[i];
                i++;
            }
            return sum;
        }
        public double SumLessFromNechetIndex()
        {
            double sum = 0;
            double abs = 0;
            for (int i = 0; i < x.Length; i++)
            {
                abs += Math.Abs(this[i]);
            }
            abs /= x.Length;
            for (int i = 1; i < x.Length; i++)
            {
                if (this[i] < abs)
                    sum += this[i];
                i++;
            }
            return sum;
        }
        public double MultChet()
        {
            double res = 1;
            for (int i = 0; i < x.Length; i++)
            {
                if (this[i] > 0)
                    res *= this[i];
                i++;
            }
            if (res != 1)
                return res;
            else
                return 0;
        }
        public double MultNechet()
        {
            double res = 1;
            for (int i = 0; i < x.Length; i++)
            {
                if (this[i] % 2 != 0 & this[i] % 3 != 0)
                    res *= this[i];
            }
            if (res != 1)
                return res;
            else
                return 0;
        }
        public void SortUp()
        {
            int step = x.Length / 2;
            while (step > 0)
            {
                int distance;
                for (int i = step; i < x.Length; i++)
                {
                    distance = i - step;
                    while ((distance >= 0) && (this[distance] > this[i]))
                    {
                        double swap = this[i];
                        this[i] = this[distance];
                        this[distance] = swap;
                        i = distance;
                        distance = i - step;
                    }
                }
                step /= 2;
            }
        }
        public void SortDown()
        {
            int step = x.Length / 2;
            while (step > 0)
            {
                int distance;
                for (int i = step; i < x.Length; i++)
                {
                    distance = i - step;
                    while ((distance >= 0) && (this[distance] < this[i]))
                    {
                        double swap = this[i];
                        this[i] = this[distance];
                        this[distance] = swap;
                        i = distance;
                        distance = i - step;
                    }
                }
                step /= 2;
            }
        }
    }
}
