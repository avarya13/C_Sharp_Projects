using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦиклыМассивы
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i=1;i<=N; i++)
            {
                if (N % i == 0)
                    Console.WriteLine(i);

            }
            Console.ReadKey();
        }
    }
}
