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
        public static int[][] array3;
    //  public static int count;
        public static int count0;
        public static void Output(int[][] array3, int count0)
        {
            //Задание3.array3[i] = new int[Задание3.array3[i].Length];
            Console.WriteLine("вывод массива:");
            for (int i = 0; i < count0; i++)
            {
                
                for (int j = 0; j < Задание3.array3[i].Length; j++)
                {

                    Console.Write(array3[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /*
         * Console.WriteLine("вывод массива:");
            for (i = 0; i < array.Length; i++)
            {
                for (j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }
         */
        public static void Mass()
        {
            Console.WriteLine("ввод количества строк");
            
           //int count0 = int.Parse(Console.ReadLine());
           while (!int.TryParse(Console.ReadLine(),out Задание3.count0))
            {
                Console.WriteLine("Ошибка конвертации. Введите число.");
                if (int.TryParse(Console.ReadLine(), out Задание3.count0))
                    break;
            }
            Задание3.array3 = new int[Задание3.count0][];
            Console.WriteLine("ввод массива:");
            int i, j;
            bool check = false;
            while (check == false)
            {
                for (i = 0; i < Задание3.count0; i++)
                {
                    string f = Console.ReadLine();
                    string[] fStr = f.Split(' ');
                    int count = fStr.Length;

                    array3[i] = new int[count];///!!!

                    for (j = 0; j < count; j++)
                    {
                        check = int.TryParse(fStr[j], out array3[i][j]);
                        
                    }

                }
            }
            
        }
        public static void Max(int[][] array)
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
            int iInput = 0; 
            int jInput=0;
            bool c1 = false;
            bool c2 = false;
            while (!(c1 == true) && !(c2 == true))
                {
                string h = Console.ReadLine();
                Console.WriteLine("Введите целочисленные индексы элемента");
                string[] hStr = h.Split(' ');
                c1 = int.TryParse(hStr[0], out iInput);
                if (c1 == true)
                {
                    c2 = int.TryParse(hStr[1], out jInput);
                }
                if (c1 == true && c2 == true)
                    break;
                }
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

        public static void NewArray(int[][] array)
        {
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
            FileStream index1 = new FileStream(@"index1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(index1);
            int iInput = int.Parse(reader.ReadToEnd());
            reader.Close();

            FileStream index2 = new FileStream(@"index2.txt", FileMode.Open);
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

        public static void Read()
        {
            Console.WriteLine("Задание 3");
            FileStream size = new FileStream(@"size.txt", FileMode.Open);
            StreamReader reader7 = new StreamReader(size);
            string q = reader7.ReadToEnd();

            reader7.Close();

            string[] qStr = q.Split(' ');
            int count0 = int.Parse(qStr[0]);
            int[] columns = new int[qStr.Length - 1];
            for (int i = 0; i < qStr.Length - 1; i++)
            {
                columns[i] = int.Parse(qStr[i]);
            }
            FileStream file5 = new FileStream(@"file5.txt", FileMode.Open);
            StreamReader reader9 = new StreamReader(file5);
            string h = reader9.ReadToEnd();
            reader9.Close();
            string[] arrayStr3 = h.Split(' ');

            int[][] array3 = new int[count0][];

            for (int i = 0; i < count0; i++)
            {
                array3[i] = new int[columns[i]];
                for (int j = 0; j < columns[i]; j++)
                {
                    for (int t = 0; t < i * count0 + j + 1; t++)
                    {
                        array3[i][j] = int.Parse(arrayStr3[t]);
                    }
                }
            }
            Console.WriteLine("вывод массива:");
            for (int i = 0; i < count0; i++)
            {
                for (int j = 0; j < columns[i]; j++)
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
        }
    }
}

