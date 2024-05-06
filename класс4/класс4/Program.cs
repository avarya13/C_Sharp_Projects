using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace класс4
{
    class Program
    {
        class number1
        {
            static void ввод_с_клавиатуры()
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
                //сортировка по возрастанию методом пузырька

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

                    Console.WriteLine(NewArray[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод с клавиатуры или считывание из файла?");
            string s = Console.ReadLine();
            switch (s)
            {
                case "kb":
                    {
                        Console.WriteLine("Режим считывания с клавиатуры");

                        Console.Write("Ввод элементов массива:");

                        string t = Console.ReadLine();
                        string[] arrayStr1 = t.Split(' ');
                        int[] array1 = new int[arrayStr1.Length];
                        int i;
                        for (i = 0; i < arrayStr1.Length; i++)
                        {
                            array1[i] = Convert.ToInt32(arrayStr1[i]);
                        }
                        Console.Write("вывод элементов массива:");

                        for (i = 0; i < array1.Length; i++)
                        {
                            Console.Write($"\n Элемент с индексом {i}:\t");
                            Console.Write(array1[i]);
                        }

                        //Поиск максимального элемента

                        Max(array1);

                        //Поиск минимального элемента
                        Min(array1);

                        char k;

                        Console.WriteLine("Ввод числа k:");

                        k = char.Parse(Console.ReadLine());

                        if (k == 'a')

                            //сортировка по возрастанию методом пузырька
                            caseA(array1);

                        if (k == 'b')
                        {
                            //сортировака методами Array.System
                            Array.Sort(array1);

                            Console.Write("\n по возрастанию:\t");
                            for (i = 0; i < array1.Length; i++)
                            {
                                Console.Write(array1[i] + " ");
                            }

                            {

                                Array.Reverse(array1);
                                Console.Write("\n по убыванию:\t");
                                for (i = 0; i < array1.Length; i++)
                                {

                                    Console.Write(array1[i] + " ");
                                }
                            }
                        }



                        if (k != 'a' & k != 'b')
                        {
                            Console.WriteLine("\nРежим не выбран, заканчиваю работу\t");
                        }



                        int p = 0;

                        for (i = 0; i < array1.Length; i++)
                        {
                            if (array1[i] % 2 == 0)
                            {
                                p = p + 1;

                            }
                        }

                        int[] NewArray1 = Array.FindAll(array1, x => x % 2 == 0);

                        Console.WriteLine("\nВывод нового массива:\t");
                        for (i = 0; i < p; i++)
                        {

                            Console.WriteLine(NewArray1[i]);
                        }
                    }

                    break;



                case "fl":
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

                        //Поиск максимального элемента
                        Max(array);

                        //Поиск минимального элемента
                        Min(array);

                        FileStream file2 = new FileStream("file 2.txt", FileMode.Open);
                        StreamReader reader2 = new StreamReader(file2);
                        char k = char.Parse(reader2.ReadToEnd());

                        reader2.Close();



                        if (k == 'a')
                            //сортировка по возрастанию методом пузырька
                            caseA(array);

                        if (k == 'b')
                        {
                            //сортировака методами Array.System
                            Array.Sort(array);

                            Console.Write("\n по возрастанию:\t");
                            for (j = 0; j < array.Length; j++)
                            {
                                Console.Write(array[j] + " ");
                            }

                            {

                                Array.Reverse(array);
                                Console.Write("\n по убыванию:\t");
                                for (j = 0; j < array.Length; j++)
                                {

                                    Console.Write(array[j] + " ");
                                }
                            }
                        }



                        if (k != 'a' & k != 'b')
                        {
                            Console.WriteLine("\nРежим не выбран, заканчиваю работу\t");
                        }

                        int p = 0;

                        for (j = 0; j < array.Length; j++)
                        {
                            if (array[j] % 2 == 0)
                            {
                                p = p + 1;

                            }
                        }

                        int[] NewArray = Array.FindAll(array, x => x % 2 == 0);

                        Console.WriteLine("\nВывод нового массива:\t");
                        for (j = 0; j < p; j++)
                        {

                            Console.WriteLine(NewArray[j]);
                        }

                        break;
                    }
            }


        }
    }
}
