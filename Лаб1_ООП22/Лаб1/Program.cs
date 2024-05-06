using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_ООП
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 10000;
            int years = 0;
            while(sum<20000)
            {
                sum = sum * 1.08;
                years++;
            }
            Console.WriteLine("сумма удвоится через {0} лет", years);
            Console.ReadKey();
        }
    }
}
