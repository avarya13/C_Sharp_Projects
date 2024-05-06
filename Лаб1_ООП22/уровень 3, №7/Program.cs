using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_3___7
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, a, s, y;
            const double xh = 0.1, xk = 1.0, h = 0.05;
            int n,i;
            n = (int)((xk-xh) / h+1);
            x = xh; 
            for (int j = 1; j <= n; j++)
            {
                a = 1; s = 1;i = 1;
                do
                {
                    a = a * Math.Pow(x,2) / (2 * i*(2*i-1));
                    s = s + a;
                    i++;
                } while (Math.Abs(a) >= 0.0001);
                
                y = (Math.Exp(x) + Math.Exp(-x)) / 2;
                
                Console.WriteLine("x= {0:f2} a={1:f6} s={2:f2} y={3:f2} ", x, a, s, y); //а - последнее слагаемое каждой суммы
                x = x + h;
            }
            Console.ReadKey();
        }
    }
}
