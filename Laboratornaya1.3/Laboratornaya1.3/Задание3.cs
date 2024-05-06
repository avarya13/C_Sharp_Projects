using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laboratornaya1._3
{
    class Задание3
    {
        public static void Max(int [][]array)
        {
            Console.WriteLine("вывод максимального элемента:");
            int max = array[0][0];
            int imax = 0;
            int jmax = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                        imax = i;
                        jmax = j;

                    }

                }

            }
            Console.WriteLine($"\narray[{imax}][{jmax}]={array[imax][jmax]}");
        }

        public static void Min(int[][] array)
        {
            Console.WriteLine("вывод минимального элемента:");
            int min = array[0][0];
            int imin = 0;
            int jmin = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                        imin = i;
                        jmin = j;

                    }
                }
            }

            Console.WriteLine($"\narray[{imin}][{jmin}]={array[imin][jmin]}");
        }

        public static void RandomMember(int[][] array)
        {
            Console.WriteLine("ввод номера элемента");
            string x = Console.ReadLine();
            string[] xStr = x.Split(' ');
            int iInput = int.Parse(xStr[0]);
            int jInput = int.Parse(xStr[1]);
            Random value = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (i == iInput && j == jInput)
                    {
                        Console.WriteLine(array[i][j] = value.Next());

                    }
                }
            }
        }

        public static void NewArray (int [][]array)
        {
            Console.WriteLine("Новый массив:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void RandomMember_fl(int[][] array)
        {
            FileStream index1 = new FileStream("index1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(index1);
            int iInput = int.Parse(reader.ReadToEnd());
            reader.Close();

            FileStream index2 = new FileStream("index2.txt", FileMode.Open);
            StreamReader reader1 = new StreamReader(index2);
            int jInput = int.Parse(reader1.ReadToEnd());
            reader1.Close();

            Random value = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (i == iInput && j == jInput)
                    {
                        Console.WriteLine(array[i][j] = value.Next());

                    }
                }
            }
        }
    }

}
