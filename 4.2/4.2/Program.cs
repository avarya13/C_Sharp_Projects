using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count1, count2;
            //Console.WriteLine("Ввод количества строк и столбцов:");
            
            // count2 = int.Parse(Console.ReadLine());

            FileStream count_1 = new FileStream("count_1.txt", FileMode.Open);
            StreamReader reader3 = new StreamReader(count_1);
            count1 = int.Parse(reader3.ReadToEnd());
            reader3.Close();
            FileStream count_2 = new FileStream("count_2.txt", FileMode.Open);
            StreamReader reader4 = new StreamReader(count_2);
            count2 = int.Parse(reader4.ReadToEnd());
            reader4.Close();

            int[,] array = new int[count1, count2];

          
            FileStream file3 = new FileStream("file3.txt", FileMode.Open);
            StreamReader reader5 = new StreamReader(file3);
            string l = reader5.ReadToEnd();
            string[] array0 = l.Split(' ');
            reader5.Close();
            int i,j;
            for ( i=0;i<count1;i++ )
            {
                for (j = 0; j < count2; j++)
                {
                    for (int k = 0; k < count1 * count2; k++)
                    {
                        array[i, j] = int.Parse(array0[k]);
                    }
                }
            }
            reader5.Close();


            /*int[][] array0 = File.ReadAllText("file.txt").Split(' ')
                .Select(r => (r.Split(','))
                .Select(c => int.Parse(c)).ToArray()).ToArray();

             string l = reader3.ReadAllLines();
             int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
             for (int i = 0; i < lines.Length; i++)
             {
                 string[] temp = lines[i].Split(' ');
                 for (int j = 0; j < temp.Length; j++)
                     num[i, j] = Convert.ToInt32(temp[j]);
             }

            int i, j;
            int rows = array0.GetUpperBound(0) + 1;
            int columns = array0.Length / rows;
            int[,] array = new int[rows, columns];
            Console.WriteLine("ввод элементов массива");
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    for (int k=0;k<array0.Length;k++)
                    {
                        array[i, j] = array0[k];
                    }
                   
                }
            }*/
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
    



        
   

