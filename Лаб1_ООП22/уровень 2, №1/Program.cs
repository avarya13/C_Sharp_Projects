using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_2___1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0.5;
            const double eps = 0.0001;
            double s = 0, a;
            int n = 1;
            do
            {
                a = Math.Cos(n * x) / Math.Pow(n, 2);
                s = s + a;
                n = n + 1;
            }
            while (Math.Abs(a) > eps);
            Console.WriteLine("Сумма равна {0:f4}", s);
            Console.ReadKey();

        }
    }
}
