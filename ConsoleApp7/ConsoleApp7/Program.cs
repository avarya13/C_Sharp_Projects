using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
 
    class Program
    {
        //расчет факториала
        public static int Factorial(int n)
        {
            if (n == 1) 
                return 1;
            return n * Factorial(n - 1);
        }

        //сочетания без поторений из n по m
        public static int Combinations(int n, int m)
        {
            return Factorial(n)/(Factorial(m) * Factorial(n - m));
        }

        //сочетания с поторениями из n по m
        public static int CombWithRepetitions(int n, int m)
        {
            return Factorial(n+m-1) / (Factorial(m) * Factorial(n - 1));
        }

        //размещения без повторений из n по m
        public static int Placements(int n, int m)
        {
            return Factorial(n) /  Factorial(n - m);
        }

        //размещения с повторениями из n по m
        public static int PlaceWithRepetitions(int n, int m)
        {
            return Convert.ToInt32(Math.Pow(n, m));
        }

        //перестановки  без повторений из n по m
        public static int Permutations(int n)
        {
            return Factorial(n);
        }

        //перестановки  с повторениями из n по m
        public static int PermWithRepetitions(int n, int[] m)
        {
            int temp = 1;
            for(int i=0; i < m.Length;i++)
            {
                temp *= Factorial(m[i]);
            }
            
            return Factorial(n) / temp;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(3));
            Console.WriteLine(Combinations(20,2));
            Console.WriteLine(CombWithRepetitions(2, 6));
            Console.WriteLine(Placements(5, 3));
            Console.WriteLine(PlaceWithRepetitions(3, 5));
            Console.WriteLine(Permutations(4));
            Console.WriteLine(PermWithRepetitions(9,new int[4] {1,4,3,1 }));
            Console.ReadKey();
            }
        }

    }

