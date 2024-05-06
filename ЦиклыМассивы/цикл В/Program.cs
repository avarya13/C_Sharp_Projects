using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace цикл_В
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод количества чисел");
            int N = int.Parse(Console.ReadLine()); //количество точек
            Console.WriteLine("Ввод шага");
            int M = int.Parse(Console.ReadLine()); //шаг
            Console.WriteLine("Ввод аргументов");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());
            double max = -10000;
            double f, f1, f2;
            int i;
            for (i = 1; i < N; i++)
            {
                f1 = Math.Pow((Math.Cos(y)), 3) + Math.Sin(z);
                f2 = Math.Pow(x, 3) + z - y;
                if (f2 == 0)
                {
                    Console.WriteLine("Точка вне области определения");
                }

                f = f1 / f2;
                if (f > max)
                {
                    max = f;
                }

                x = x + M * i;
                y = y + M * i;
                z = z + M * i;

                
                Console.WriteLine($"\nx={x},y={y},z={z}, f={f}\t");
            }
            Console.WriteLine($"max={max}");

            Console.ReadKey();


        }
    }
}

