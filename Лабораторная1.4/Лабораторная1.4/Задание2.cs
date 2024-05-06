using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya1._2
{
    class Задание2
    {
        public static void Max(int[,] array)
        {
            int max = array[0, 0];
            int imax = 0; int jmax = 0;
            for (int i = 1; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 1; j < array.GetUpperBound(1) + 1; j++)

                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        imax = i;
                        jmax = j;
                    }
                }
            }
            Console.WriteLine($"\nМаксимальный элемент: array[{imax},{jmax}]={max}\t");
        }

        public static void Min(int[,] array)
        {
            int min = array[0, 0];
            int imin = 0;
            int jmin = 0;
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    if (min > array[i, j])
                    {
                        min = array[i, j];
                        imin = i;
                        jmin = j;
                    }
                }
                
            }
            Console.WriteLine($"\nМинимальный элемент: array[{imin},{jmin}]={min}\t");
        }
        public static void MatrixOperations(int[,] array, int[,] array2)
        {
            if (array.GetUpperBound(0) != array2.GetUpperBound(0) && array.GetUpperBound(1) != array2.GetUpperBound(1) + 1)
            {
                Console.WriteLine("Операция Add недопустима!");
                Console.WriteLine("Операция Subtract недопустима!");

            }
            else
            {
                int[,] sum = new int[array.GetUpperBound(0) + 1, array.Length];

                Console.WriteLine("\n sum =\t ");
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    {
                        sum[i, j] = array[i, j] + array2[i, j];
                    }
                }
                
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    {
                        Console.Write(sum[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                int[,] sub = new int[array.GetUpperBound(0) + 1, array.Length];
                Console.WriteLine("\n sub =\t ");
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    {
                        sub[i, j] = array[i, j] - array2[i, j];
                    }
                }
              
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    {
                        Console.Write(sub[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            if ((array.GetUpperBound(0) + 1) != (array2.GetUpperBound(1) + 1) && (array.GetUpperBound(1) + 1) != (array2.GetUpperBound(0) + 1))
            {

                Console.WriteLine("Операция Multiply недопустима!");
            }
            else
            {
                int[,] mult = new int[array.GetUpperBound(0) + 1, array2.Length];
                Console.WriteLine("\n mult =\t ");
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array2.GetUpperBound(1) + 1; j++)
                    {
                        mult[i, j] = 0;
                        for (int k = 0; k < array2.GetUpperBound(1) + 1; k++)
                        {
                            mult[i, j] += array[i, k] * array2[k, j];
                        }
                    }
                }
                
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array2.GetUpperBound(1) + 1; j++)
                    {
                        Console.Write(mult[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
