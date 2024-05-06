using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_1___7
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 6;
            int p = 1;
            for (int i = 2; i <= n; i++)
            {
                p = p * i;
            }
            Console.WriteLine(p);
            Console.ReadKey();

        }
    }
}
