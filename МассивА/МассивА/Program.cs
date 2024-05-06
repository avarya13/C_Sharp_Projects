using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МассивА
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ввод размера");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("ввод элементов в виде строки");

            string s = Console.ReadLine();

            string[] myArray = s.Split(' ');

            int[] array = new int[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = Convert.ToInt32(myArray[i]);
            }

            for (int i = 0; i < N; i++)
            {

                Array.Reverse(myArray);

                for (i = 0; i < N; i++)
                {

                    Console.WriteLine(myArray[i]);
                }
                int sum = 0;
                for (i = 0; i < N; i++)
                {

                    sum = sum + array[i];
                }
                Console.WriteLine($"sum={sum}"); 
                Console.ReadKey();
            }
        }
    }
}
