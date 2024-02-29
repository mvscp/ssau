using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClass
{
    class Complex
    {
        double a, i;
        public Complex()
        { }
        public Complex(double a, double i)
        {
            A = a;
            I = i;
        }
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public double I
        {
            get
            {
                return i;
            }
            set
            {
                i = value;
            }
        }
        public Complex Summa(Complex x, Complex y)
        {
            Complex res = new Complex();
            res.a = x.a + y.a;
            res.i = x.i + y.i;
            return res;
        }
        static public Complex SummaSt(Complex x, Complex y)
        {
            return new Complex(x.a + y.a, x.i + y.i);
        }
        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x.a + y.a, x.i + y.i);
        }
    }
}
