using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Polynominal
    {
        public int a, b, c;
        public Polynominal()
        { }
        public Polynominal(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public string Solution()
        {
            string res = "";
            if ((a == 0) && (b == 0) && (c == 0))
            {
                res = "x - любое число";
                return res;
            }
            else if ((a == 0) && (b == 0))
            {
                res = "Нет решений";
                return res;
            }
            else if ((a == 0) && (c == 0))
            {
                res = "x = 0";
                return res;
            }
            else if (a == 0)
            {
                double x = (-c) / b;
                res = "x = " + x;
                return res;
            }
            else
            {
                double D = b * b - 4 * a * c;
                if (D < 0)
                    res = "Нет решений";
                else if (D > 0)
                {
                    double x1 = ((-b) + Math.Sqrt(D)) / (2 * a);
                    double x2 = ((-b) - Math.Sqrt(D)) / (2 * a);
                    res = "x1 = " + x1 + " x2 = " + x2;
                    return res;
                }
                else
                {
                    double x = (-b) / (2 * a);
                    res = "x = " + x;
                    return res;
                }
                return res;
            }
        }
    }
}
