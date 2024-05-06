using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод элементов массива:");
            
            string l = Console.ReadLine();
            string[] arrayStr = l.Split(' ');
            int[] array = new int[arrayStr.Length];
            int i;
            for (i = 0; i < arrayStr.Length; i++)
            {
                
                array[i] = int.Parse(arrayStr[i]);
            }
            Console.Write("вывод элементов массива:");
           
            for (i = 0; i < array.Length; i++)
            {
              
                Console.Write(array[i]+" ");
            }




            //Поиск максимального элемента

            int max = array[0];
            int imax = 0;
            for (i = 1; i < array.Length; i++)
            {

                if (array[i] > max)
                {
                    max = array[i];
                    imax = i;
                }

            }

            Console.WriteLine($"\n Максимальный элемент с индексом {imax}:{max}\t");


            //Поиск минимального элемента

            int min = array[0];
            int imin = 0;
            for (i = 1; i < array.Length; i++)
            {

                if (array[i] < min)
                {
                    min = array[i];
                    imin = i;
                }

            }

            Console.WriteLine($"\n Минимальный элемент с индексом {imin}:{min}\t");
            char k;
            Console.WriteLine("Ввод числа k:");
            k = char.Parse(Console.ReadLine());
            if (k == 'a')
            //сортировка по возрастанию 
            {
                int t;
                int j;
                for (i = 0; i < array.Length; i++)
                {
                    for (j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            t = array[i];
                            array[i] = array[j];
                            array[j] = t;
                        }
                    }
                }
                Console.WriteLine("\n по возрастанию:");
                for (i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }

                for (i = 0; i < array.Length; i++)
                {
                    for (j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] < array[j])
                        {
                            t = array[i];
                            array[i] = array[j];
                            array[j] = t;
                        }
                    }
                }
                Console.WriteLine("\n по убыванию:");
                for (i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
            if (k == 'b')
            {
                //сортировака методами Array.System
                Array.Sort(array);
                Console.Write("\n по возрастанию:\t");
                for (i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }

                {
                    Array.Reverse(array);
                    Console.Write("\n по убыванию:\t");
                    for (i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                }
            }
            if (k != 'a' & k != 'b')
            {
                Console.WriteLine("\nРежим не выбран, заканчиваю работу\t");
            }

            int p = 0;
            for (i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    p = p + 1;
                }
            }
            int[] NewArray = Array.FindAll(array, x => x % 2 == 0);
            Console.WriteLine("\nВывод нового массива:\t");
            for (i = 0; i < p; i++)
            {
                Console.Write(NewArray[i]+" ");
            }
            Console.ReadKey();
        }
    }
    }

