using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_1___12
{
    class Program
    {
        static void Main(string[] args)
        {
            double s=1;
            double res = 1;
            Console.WriteLine("Введите х");
            double x = double.Parse(Console.ReadLine());
           while(s<=10)
            {
                res = res + 1 / Math.Pow(x, s);
                s++;
            }
            Console.WriteLine("При х={0:f2} сумма равна {1:f2}", x, res);
            Console.ReadKey();

        }
    }
}
