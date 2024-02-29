using System;

namespace ConsoleAppClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex x = new Complex(1, 1);
            Complex y = new Complex(2, 2);
            Console.WriteLine("x= {0} + {1}", x.A, x.I);
            Complex c = x + y;
            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
