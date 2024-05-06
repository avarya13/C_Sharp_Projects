using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_2___7
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = 10;
            double day_dist = 10;
            double dist7 = 0;
            int days = 1;
            while(days<7)
            {
                day_dist = day_dist * 1.1;
                dist7 =s+ day_dist ;
                if (dist7>=100)
                    Console.WriteLine("через {0} дней спортсмен пробежит суммарный путь 100 км", days);
                s = dist7;
                days++;
            }
            Console.WriteLine("путь за 7 дней - {0:f3}", dist7);

            while (dist7 < 100) 
            {
                day_dist = day_dist * 1.1;
                dist7 = s + day_dist;
                s = dist7;
                days++;
            }
            Console.WriteLine("через {0} дней спортсмен пробежит суммарный путь 100 км", days);
            day_dist = 10;
            s = 10;
            days = 1;
            while (day_dist < 20)
            {
                day_dist = s * 1.1;
                s = day_dist;
                days++;
            }
            Console.WriteLine("через {0} дней спортсмен будет пробегать в день больше 20 км", days);
            Console.ReadKey();
        }

    }
}

