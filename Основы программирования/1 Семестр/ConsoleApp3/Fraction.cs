using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Fraction
    {
        private int numerator;
        private int denominator;
        public Fraction()
        {
            Denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        public int Numerator { get; set; }
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value != 0)
                    denominator = value;
                else
                {
                    Console.WriteLine("Знаменатель не может быть равен 0, будет присвоена 1");
                    denominator = 1;
                }
            }
        } 
        public Fraction Sum(Fraction x)
        {
            if (Denominator == x.Denominator)
            {
                Numerator += x.Numerator;
                Reduction();
                return this;
            }
            else
            {
                Numerator = Numerator * x.Denominator + x.Numerator * Denominator;
                Denominator *= x.Denominator;
                Reduction();
                return this;
            }  
        }
        public Fraction Subtraction(Fraction x)
        {
            if (Denominator == x.Denominator)
            {
                Numerator -= x.Numerator;
                Reduction();
                return this;
            }
            else
            {
                Numerator = Numerator * x.Denominator - x.Numerator * Denominator;
                Denominator *= x.Denominator;
                Reduction();
                return this;
            }
        }
        public Fraction Multiplication(Fraction x)
        {
            Numerator *= x.Numerator;
            Denominator *= x.Denominator;
            Reduction();
            return this;
        }
        public Fraction Division(Fraction x)
        {
            if (Denominator == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен 0, будет присвоена 1");
                Denominator = 1;
            }
            if (x.Denominator == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен 0, будет присвоена 1");
                x.Denominator = 1;
            }
            Numerator *= x.Denominator;
            Denominator *= x.Numerator;
            Reduction();
            return this;
        }
        public void Reduction()
        {
            int a = Numerator;
            int b = Denominator; 
            int t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            Numerator /= a;
            Denominator /= a;
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return SFraction.Sum(f1, f2);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return SFraction.Subtraction(f1, f2);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return SFraction.Multiplication(f1, f2);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return SFraction.Division(f1, f2);
        }
    }
}
