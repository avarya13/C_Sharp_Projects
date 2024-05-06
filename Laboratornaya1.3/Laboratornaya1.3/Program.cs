using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ввод количества строк");
            int count0= int.Parse(Console.ReadLine());
            int[][] array = new int[count0][];
            Console.WriteLine("ввод массива:");
            int i,j;
            for (i=0;i<count0;i++)
            {
                string f = Console.ReadLine();
                string[] fStr = f.Split(' ');
                int count = fStr.Length;
                array[i] = new int[count];///!!!
                
                   for (j = 0; j < count; j++)
                   {
                    array[i][j] = int.Parse(fStr[j]);
                   }
            }
            Console.WriteLine("вывод массива:");
            for (i = 0; i < array.Length; i++)
            {
                for (j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }

            //Поиск максимального элемента
            Console.WriteLine("вывод максимального элемента:");
            int max = array[0][0];
            int imax = 0;
            int jmax = 0;
            for ( i = 0; i < count0; i++)
            {
                for (j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j]>max)
                    {
                        max = array[i][j];
                        imax = i;
                        jmax = j;
                    }
                }
            }

            Console.WriteLine($"\narray[{imax}][{jmax}]={array[imax][jmax]}");

            //Поиск минимального элемента
            Console.WriteLine("вывод минимального элемента:");
            int min = array[0][0];
            int imin = 0;
            int jmin = 0;
            for (i = 0; i < count0; i++)
            {
                for (j = 0; j < array[i].Length; j++)
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

            Console.WriteLine("ввод номера элемента");
            string x = Console.ReadLine();
            string[] xStr = x.Split(' ');
            int iInput = int.Parse(xStr[0]);
            int jInput = int.Parse(xStr[1]);
            Random value = new Random();
            for (i = 0; i < count0; i++)
            {
                for (j = 0; j < array[i].Length; j++)
                {
                    if (i==iInput && j==jInput)
                    {
                        Console.WriteLine( array[i][j] = value.Next());
                    }
                }
            }
          
            for (i = 0; i < array.Length; i++)
            {
                for (j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
     
        }
    }
    

