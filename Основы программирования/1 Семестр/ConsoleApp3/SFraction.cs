using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class SFraction
    {
        public static Fraction Sum(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();
            f.Denominator = f1.Denominator * f2.Denominator;
            f.Numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            f.Reduction();
            return f;
        }
        public static Fraction Subtraction(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();
            f.Denominator = f1.Denominator * f2.Denominator;
            f.Numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            f.Reduction();
            return f;
        }
        public static Fraction Multiplication(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();
            f.Denominator = f1.Denominator * f2.Denominator;
            f.Numerator = f1.Numerator * f2.Numerator;
            f.Reduction();
            return f;
        }
        public static Fraction Division(Fraction f1, Fraction f2)
        {
            if (f1.Denominator == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен 0, будет присвоена 1");
                f1.Denominator = 0;
            }
            if (f2.Denominator == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен 0, будет присвоена 1");
                f2.Denominator = 0;
            }
            Fraction f = new Fraction();
            f.Numerator = f1.Numerator * f2.Denominator;
            f.Denominator = f1.Denominator * f2.Numerator;
            f.Reduction();
            return f;
        }
        public static void Write(Fraction f)
        {
            string s1 = f.Numerator.ToString();
            string s2 = f.Denominator.ToString();
            string s = s1 + '/' + s2;
            Console.WriteLine(s);
        }
    }
}
