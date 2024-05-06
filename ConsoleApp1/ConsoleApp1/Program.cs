using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Laboratornaya1._2;
//using Laboratornaya1._3;
using Лабораторная1._4;

namespace ConsoleApp1
{
    class Program
    {
        static void Output(int[] array)
        {
            Console.Write("вывод элементов массива:");

            for (int i = 0; i < array.Length; i++)
            {

                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        static void Mass1()
        {
            Console.WriteLine("ввод элементов массива:");
            bool check = true;
            string y = Console.ReadLine();
            int i;
            string[] arrayStr = y.Split(' ');
            int[] array = new int[arrayStr.Length];

            for (i = 0; i < arrayStr.Length; i++)
            {
                check = int.TryParse(arrayStr[i], out array[i]);
                if (check == false)
                {

                    SolveProblem();
                }
            }
            Output(array);
            Задание1.Max(Задание1.array);
            Задание1.Min(Задание1.array);
            Console.WriteLine("Ввод числа k:");
            char k = char.Parse(Console.ReadLine());
            Задание1.Sort(k, Задание1.array);
            Задание1.Even(Задание1.array);
        }

        static void SolveProblem()
        {

            bool check = false;
            while (check == false)
            {
                Console.Write("Ошибка конвертации. Введите целочисленнный массив ещё раз.");
                Console.WriteLine();
                Console.WriteLine("ввод элементов массива:");
                string y = Console.ReadLine();
                int i;
                string[] arrayStr = y.Split(' ');
                int[] array = new int[arrayStr.Length];

                for (i = 0; i < arrayStr.Length; i++)
                {
                    check = int.TryParse(arrayStr[i], out array[i]);
                }

                if (check == true)
                {
                    Output(array);
                }
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
