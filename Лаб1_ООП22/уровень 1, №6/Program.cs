using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_1___6
{
    class Program
    {
        static void Main(string[] args)
        {
            const double min = -4, max = 4, step = 0.5;
            double x, y;
            int i, n;
            n = (int)((max - min) / step + 1);
            x = min;
            for (i = 1; i <= n; i = i + 1)
            {
                y = Math.Pow(x, 2) / 2 - 7 * x;
                Console.WriteLine("x={0:f1}\ty={1:f2}", x, y);
                x = x + step;
            }
            Console.ReadKey();

        }
    }
}
