using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClass
{
    class Vector
    {
        double x, y;
        public Vector()
        {}
        public Vector(double x, double y)
        {
            this.x = x;
            this.x = y;
        }
        public double Dlina()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public void Summa(Vector v)
        {
            x = x + v.x;
            y = y + v.y;
        }
        public Vector Summa2(Vector v)
        {
            Vector v0 = new Vector();
            v0.x = x + v.x;
            v0.y = y + v.y;
            return v0;
        }
        static public Vector SummaSt(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }
    }
}
