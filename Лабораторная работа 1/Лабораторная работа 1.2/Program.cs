using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count1, count2;
            Console.WriteLine("Ввод количества строк и столбцов:");
            count1 = int.Parse(Console.ReadLine());
            count2 = int.Parse(Console.ReadLine());
            int[,] array = new int[count1, count2];
            int i, j;

            Console.WriteLine("ввод элементов массива");
            for (i = 0; i < count1; i++)
            {
                for (j = 0; j < count2; j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("вывод элементов 1 массива");

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();




            // Console.WriteLine($"Вывод элементов  массива:{array[i, j]}");

            int max = array[0, 0];
            int imax = 0; int jmax = 0;
            for (i = 1; i < count1; i++)
            {
                for (j = 1; j < count2; j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        imax = i;
                        jmax = j;
                    }
                }

            }

            Console.WriteLine($"\nМаксимальный элемент: array[{imax},{jmax}]={max} \t");


            int min = array[0, 0];
            int imin = 0; int jmin = 0;
            for (i = 1; i < count1; i++)
            {
                for (j = 1; j < count2; j++)

                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        imin = i;
                        jmin = j;
                    }
                }
            }
            Console.WriteLine($"\nМинимальный элемент: array[{imin},{jmin}]={min}\t");


            int count3, count4;
            Console.WriteLine("Ввод количества строк и столбцов:");
            count3 = int.Parse(Console.ReadLine());
            count4 = int.Parse(Console.ReadLine());
            int[,] array2 = new int[count3, count4];
            int i2, j2;

            Console.WriteLine("ввод элементов массива");
            for (i2 = 0; i2 < count3; i2++)
            {
                for (j2 = 0; j2 < count4; j2++)
                {
                    array2[i2, j2] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("вывод элементов 2 массива");

            foreach (var item in array2)
            {
                Console.Write(item + "\t ");
            }



            if (count1 != count3 && count2 != count4)
            {
                Console.WriteLine("Операция Add недопустима!");
                Console.WriteLine("Операция Subtract недопустима!");

            }

            if (count1 != count4 && count2 != count3)
            {

                Console.WriteLine("Операция Multiply недопустима!");
            }


            int[,] sum = new int[count1, count2];

            Console.WriteLine("\n sum =\t ");
            for (i = 0; i < count1; i++)
            {
                for (j = 0; j < count2; j++)
                {
                    sum[i, j] = array[i, j] + array2[i, j];
                }
            }
            foreach (var item in sum)
            {
                Console.Write(item + "\t ");
            }

            int[,] sub = new int[count1, count2];
            Console.WriteLine("\n sub =\t ");
            for (i = 0; i < count1; i++)
            {
                for (j = 0; j < count2; j++)
                {
                    sub[i, j] = array[i, j] - array2[i, j];
                }
            }
            foreach (var item in sub)
            {
                Console.Write(item + "\t ");
            }


            int[,] mult = new int[count1, count4];
            Console.WriteLine("\n mult =\t ");
            for (i = 0; i < count1; i++)
            {
                for (j = 0; j < count4; j++)
                {
                    mult[i, j] = 0;
                    for (int k = 0; k < count4; k++)
                    {
                        mult[i, j] += array[i, k] * array2[k, j];
                    }
                }
            }
            foreach (var item in mult)
            {
                Console.Write(item + "\t ");



                Console.ReadKey();
            }
        }
    }
}
