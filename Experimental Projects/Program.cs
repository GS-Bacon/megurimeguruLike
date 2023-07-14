using System.Numerics;
using System.Windows;
using System;
using System.Diagnostics;
using System.IO.Pipes;

namespace test
{
    public class PlTest
    {
        public static int A(int x, int y)
        {
            Console.WriteLine("A1");
            Console.WriteLine("A2");
            int c = 0;
            c++;
            c = x + y;
            return x + y + c;
        }

        public static int C(int x, int y)
        {
            Console.WriteLine("C1");
            Console.WriteLine("C2");
            return x + y;
        }

        public void B()
        {

            int a = 0;
            Parallel.For(0, 100, i =>
            {
                Console.WriteLine("A1");
                Console.WriteLine("A2");
                Console.WriteLine("A3");
            });
        }
        static void Main() { }
    }
}