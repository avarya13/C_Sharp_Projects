using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {

    
    public static double Sh(int x, int n)
    {
            if (x % 2 == 1)
            {
                double s = Math.Pow(x, n) / Factorial(n) + Sh(x, n - 1);
                return s;

            }
            else return 0;
    }

        public static int Factorial(int n)
    {
            if (n == 1) return 1;
            else if (n > 1) return n * Factorial(n - 1);
            else return 0;
    }
    

    static void Main(string[] args)
        {
            int n = 9;
            int x = 5;
            Console.WriteLine("x={0}:{1}", x.ToString(), Sh(x, n).ToString());
            Console.ReadKey();
        }
    }
}
