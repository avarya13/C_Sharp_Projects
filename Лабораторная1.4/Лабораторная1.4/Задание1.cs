using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Лабораторная1._4
{
    class Задание1
    {
        
        public static void Input()
        {
            Console.WriteLine("Ввод элементов массива:");
            //count = int.Parse(Console.ReadLine());
            string l = Console.ReadLine();
            string[] arrayStr = l.Split(' ');
            int[] array = new int[arrayStr.Length];
            int i;
            for (i = 0; i < arrayStr.Length; i++)
            {
                //array[i] = Convert.ToInt32(arrayStr[i]);
                array[i] = int.Parse(arrayStr[i]);
            }
            Console.Write("вывод элементов массива:");

            for (i = 0; i < array.Length; i++)
            {
                //  Console.Write($"\n Элемент с индексом {i}:\t");
                Console.WriteLine(array[i] + ' ');
            }
        }

        public static void ReadFile()
        {
            Console.WriteLine("Режим считывания из файла");
            //вывод элементов массива

            FileStream file1 = new FileStream("file 1.txt", FileMode.Open);
            StreamReader reader1 = new StreamReader(file1);

            string l = reader1.ReadToEnd();

            reader1.Close();

            string[] arrayStr = l.Split(' ');
            int[] array = new int[arrayStr.Length];
            int j;
            for (j = 0; j < arrayStr.Length; j++)
            {
                array[j] = Convert.ToInt32(arrayStr[j]);
            }
            Console.Write("вывод элементов массива:");

            for (j = 0; j < array.Length; j++)
            {
                Console.Write($"\n Элемент с индексом {j}:\t");
                Console.Write(array[j]);
            }
        }

        public static void Mas1(int[]a)
        {

        }

        public static void Max(int[] a)
        {
            //int[] a;
            int max = a[0];
            int imax = 0;
            int i;
            for (i = 1; i < a.Length; i++)
            {

                if (a[i] > max)
                {
                    max = a[i];
                    imax = i;
                }
            }
            Console.WriteLine($"\n Максимальный элемент с индексом {imax}:{max}\t");
        }

        static public void Min(int[] a)
        {
            int min = a[0];
            int imin = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                    imin = i;
                }

            }
            Console.WriteLine($"\n Минимальный элемент с индексом {imin}:{min}\t");
        }


        public static void CaseA(int []array)
        {
            //int[] array;
            int t;
            int z;
            for (int j = 0; j < array.Length; j++)
            {
                for (z = j + 1; z < array.Length; z++)
                {
                    if (array[j] > array[z])
                    {
                        t = array[j];
                        array[j] = array[z];
                        array[z] = t;
                    }
                }
            }
            Console.WriteLine("\n по возрастанию:");
            for (int j = 0; j < array.Length; j++)
            {

                Console.Write(array[j] + " ");
            }

            for (int j = 0; j < array.Length; j++)
            {
                for (z = j + 1; z < array.Length; z++)
                {
                    if (array[j] < array[z])
                    {
                        t = array[j];
                        array[j] = array[z];
                        array[z] = t;
                    }
                }
            }
            Console.WriteLine("\n по убыванию:");
            for (int j = 0; j < array.Length; j++)
            {
                Console.Write(array[j] + " ");
            }
        }


        public static void CaseB(int[] array)
        {
            Array.Sort(array);

            Console.Write("\n по возрастанию:\t");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            {

                Array.Reverse(array);
                Console.Write("\n по убыванию:\t");
                for (int i = 0; i < array.Length; i++)
                {

                    Console.Write(array[i] + " ");
                }
            }
        }


        public static void CaseC(int[] array)
        {
            Console.WriteLine("\nРежим не выбран, заканчиваю работу\t");
        }


        public static void Even(int[] array)
        {
            int p = 0;

            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] % 2 == 0)
                {
                    p = p + 1;

                }
            }

            int[] NewArray = Array.FindAll(array, x => x % 2 == 0);
            Console.WriteLine("\nВывод нового массива:\t");
            for (int j = 0; j < p; j++)
            {

                Console.Write(NewArray[j]+" ");
            }
        }

        public static void Sort(char k, int []array)
        {
            switch (k)
                {
                case 'a':
                    {
                    int t;
                    int z;
                    for (int j = 0; j < array.Length; j++)
                    {
                        for (z = j + 1; z < array.Length; z++)
                        {
                            if (array[j] > array[z])
                            {
                                t = array[j];
                                array[j] = array[z];
                                array[z] = t;
                            }
                        }
                    }
                    Console.WriteLine("\n по возрастанию:");
                    for (int j = 0; j < array.Length; j++)
                    {

                        Console.Write(array[j] + " ");
                    }

                    for (int j = 0; j < array.Length; j++)
                    {
                        for (z = j + 1; z < array.Length; z++)
                        {
                            if (array[j] < array[z])
                            {
                                t = array[j];
                                array[j] = array[z];
                                array[z] = t;
                            }
                        }
                    }
                    Console.WriteLine("\n по убыванию:");
                    for (int j = 0; j < array.Length; j++)
                    {
                        Console.Write(array[j] + " ");
                    }
                    break;
                }
                case 'b':
                    {
                        Array.Sort(array);

                        Console.Write("\n по возрастанию:\t");
                        for (int i = 0; i < array.Length; i++)
                            Console.Write(array[i] + " ");
                        }

                        {

                            Array.Reverse(array);
                            Console.Write("\n по убыванию:\t");
                            for (int i = 0; i < array.Length; i++)
                            {

                                Console.Write(array[i] + " ");
                            }
                        }
                        break;
                    }
            

            if (k != 'a' & k != 'b')
            {
                Console.WriteLine("\nРежим не выбран, заканчиваю работу\t");
            }
        }
}
    }

    

