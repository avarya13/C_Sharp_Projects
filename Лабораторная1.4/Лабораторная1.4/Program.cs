using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Laboratornaya1._2;
using Laboratornaya1._3;

namespace Лабораторная1._4
{


    class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод с клавиатуры или считывание из файла?");
            string s = Console.ReadLine();
            
            switch (s)
            {
                case "kb":
                    {
                        //Задание 1
                        Console.WriteLine("Задание 1");
                        Console.WriteLine("Ввод элементов массива:");
                        
                        string y = Console.ReadLine();
                        int i;
                        string[] arrayStr = y.Split(' ');
                        int[] array = new int[arrayStr.Length];
                        for (i = 0; i < arrayStr.Length; i++)
                        {
                            array[i] = Convert.ToInt32(arrayStr[i]);
                        }
                       
                        Console.Write("вывод элементов массива:");
                        
                        for (i = 0; i < arrayStr.Length; i++)
                        {

                            Console.Write(array[i] + " ");
                        }
                        Задание1.Max(array);
                        Задание1.Min(array);
                        Console.WriteLine("Ввод числа k:");

                        char k = char.Parse(Console.ReadLine());
                        Задание1.Sort(k,array);
                        Задание1.Even(array);

                        //Задание 2
                        Console.WriteLine();
                        Console.WriteLine("Задание 2");
                        Console.WriteLine("Ввод количества строк и столбцов:");
                        string d = Console.ReadLine();
                        string[] dStr = d.Split(' ');
                        int count1 = int.Parse(dStr[0]);
                        int count2 = int.Parse(dStr[1]);
                        int[,] array1 = new int[count1, count2];
                        int[] array01 = new int[count1];
                        int j;
                        Console.WriteLine("ввод элементов 1 массива");
                        for (i = 0; i < count1; i++)
                        {
                            string p = Console.ReadLine();
                            string[] pStr = p.Split(' ');
                            array01[i] = int.Parse(pStr[i]);
                            for (j = 0; j < count2; j++)
                            {
                                array1[i, j] = int.Parse(pStr[j]);
                            }
                        }
                        Console.WriteLine("вывод элементов 1 массива");

                        for (i = 0; i < count1; i++)
                        {
                            for (j = 0; j < count2; j++)
                            {
                                Console.Write(array1[i, j] + "\t");
                            }
                            Console.WriteLine();

                        }
                        Задание2.Max(array1);
                        Задание2.Min(array1);
                        Console.WriteLine("Ввод количества строк и столбцов:");
                        string e = Console.ReadLine();
                        string[] eStr = e.Split(' ');
                        int count3 = int.Parse(eStr[0]);
                        int count4 = int.Parse(eStr[1]);
                        int[,] array2 = new int[count3, count4];
                        int[] array02 = new int[count3];

                        Console.WriteLine("ввод элементов 2 массива");
                        for (i = 0; i < count1; i++)
                        {
                            string p = Console.ReadLine();
                            string[] pStr = p.Split(' ');
                            array02[i] = int.Parse(pStr[i]);
                            for (j = 0; j < count2; j++)
                            {

                                array2[i, j] = int.Parse(pStr[j]);
                            }
                        }

                        Console.WriteLine("вывод элементов 2 массива");

                        for (i = 0; i < count3; i++)
                        {
                            for (j = 0; j < count4; j++)
                            {
                                Console.Write(array2[i, j] + "\t");
                            }
                            Console.WriteLine();

                        }

                        Задание2.MatrixOperations(array1, array2);

                        //Задание 3
                        Console.WriteLine("ввод количества строк");
                        int count0 = int.Parse(Console.ReadLine());
                        int[][] array3 = new int[count0][];
                        Console.WriteLine("ввод массива:");
                        
                        for (i = 0; i < count0; i++)
                        {
                            string f = Console.ReadLine();
                            string[] fStr = f.Split(' ');
                            int count = fStr.Length;
                            array3[i] = new int[count];///!!!

                            for (j = 0; j < count; j++)
                            {
                                array3[i][j] = int.Parse(fStr[j]);
                            }

                        }

                        Console.WriteLine("вывод массива:");
                        for (i = 0; i < array3.Length; i++)
                        {
                            for (j = 0; j < array3[i].Length; j++)
                            {
                                Console.Write(array3[i][j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Задание3.Max(array3);
                        Задание3.Min(array3);
                        Задание3.RandomMember(array3);
                        Задание3.NewArray(array3);



                        break;
                    }
                case "fl":
                    {
                        Console.WriteLine("Режим считывания из файла");

                        //Задание 1
                        Console.WriteLine("Задание 1");

                        FileStream file1 = new FileStream("file 1.txt", FileMode.Open);
                        StreamReader reader1 = new StreamReader(file1);

                        string l = reader1.ReadToEnd();

                        reader1.Close();

                        string[] arrayStr = l.Split(' ');
                        int[] array = new int[arrayStr.Length];
                        int i,j;
                        for (j = 0; j < arrayStr.Length; j++)
                        {
                            array[j] = Convert.ToInt32(arrayStr[j]);
                        }
                        Console.Write("вывод элементов массива:");

                        for (i = 0; i < array.Length; i++)
                        {

                            Console.Write(array[i] + " ");
                        }
                        Console.WriteLine();
                        Задание1.Max(array);
                        Задание1.Min(array);
                        Console.WriteLine("Ввод числа k:");
                        FileStream file2 = new FileStream("file 2.txt", FileMode.Open);
                        StreamReader reader2 = new StreamReader(file2);
                        char k = char.Parse(reader2.ReadToEnd());

                        reader2.Close();
                        Задание1.Sort(k, array);
                        Задание1.Even(array);

                        //Задание 2
                        Console.WriteLine();
                        Console.WriteLine("Задание 2");
                        FileStream count_1 = new FileStream("count_1.txt", FileMode.Open);
                        StreamReader reader3 = new StreamReader(count_1);
                        int count1 = int.Parse(reader3.ReadToEnd());
                        reader3.Close();
                        FileStream count_2 = new FileStream("count_2.txt", FileMode.Open);
                        StreamReader reader4 = new StreamReader(count_2);
                        int count2 = int.Parse(reader4.ReadToEnd());
                        reader4.Close();

                        int[,] array1 = new int[count1, count2];
                        FileStream file3 = new FileStream("file3.txt", FileMode.Open);
                        StreamReader reader5 = new StreamReader(file3);
                        string p = reader5.ReadToEnd();
                        reader5.Close();
                        string[] array0 = p.Split(' ');
                        for (i = 0; i < count1; i++)
                        {
                            for (j = 0; j < count2; j++)
                            {
                                array1[i, j] = int.Parse(array0[i*count1+j]);
                            }
                        }
                        
                        Console.WriteLine("вывод элементов 1 массива");

                        for (i = 0; i < count1; i++)
                        {
                            for (j = 0; j < count2; j++)
                            {
                                Console.Write(array1[i, j] + "\t");
                            }
                            Console.WriteLine();

                        }
                        Console.WriteLine();
                        Задание2.Max(array1);
                        Задание2.Min(array1);

                        int[,] array2 = new int[count1, count2];
                        FileStream file4 = new FileStream("file4.txt", FileMode.Open);
                        StreamReader reader6 = new StreamReader(file4);
                        string p0 = reader6.ReadToEnd();
                        reader6.Close();
                        string[] array00 = p0.Split(' ');

                        for (i = 0; i < count1; i++)
                        {
                            for (j = 0; j < count2; j++)
                            {
                                    array2[i, j] = int.Parse(array00[i*count1+j]);
                            }
                        }
                        
                        Console.WriteLine("вывод элементов 2 массива");

            for (i = 0; i < count1; i++)
            {
                for (j = 0; j < count2; j++)
                {
                    Console.Write(array2[i, j] + "\t");
                }
                Console.WriteLine();

            }
                        Console.WriteLine();
                        Задание2.MatrixOperations(array1, array2);

                        //Задание 3
                        Console.WriteLine();
                        Console.WriteLine("Задание 3");
                        FileStream size = new FileStream("size.txt", FileMode.Open);
                        StreamReader reader7 = new StreamReader(size);
                        string q = reader7.ReadToEnd();
                        
                        reader7.Close();

                        string[] qStr = q.Split(' ');
                        int count0 = int.Parse(qStr[0]);
                        int[] columns = new int [qStr.Length-1];
                        for (i = 0; i < qStr.Length - 1; i++)
                        {
                            columns[i]= int.Parse(qStr[i]);
                        }
                            FileStream file5 = new FileStream("file5.txt", FileMode.Open);
                        StreamReader reader9 = new StreamReader(file5);
                        string h = reader9.ReadToEnd();
                        reader9.Close();
                        string[] arrayStr3 = h.Split(' ');

                        int[][] array3 = new int[count0][];
                        
                        for (i = 0; i < count0; i++)
                        {
                            array3[i] = new int[columns[i] ];
                            for (j = 0; j < columns[i] ; j++)
                            {
                                for (int t = 0; t < i * count0 + j+1; t++)
                                {
                                    array3[i][j] = int.Parse(arrayStr3[t]);
                                }
                            }
                        }
                        Console.WriteLine("вывод массива:");
                        for (i = 0; i < count0; i++)
                        {
                            for (j = 0; j < columns[i]; j++)
                            {
                                Console.Write(array3[i][j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Задание3.Max(array3);
                        Задание3.Min(array3);
                        Задание3.RandomMember_fl(array3);
                        Задание3.NewArray(array3);
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}





                