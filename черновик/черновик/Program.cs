using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace черновик
{
    class Program
    {
        
            
           
        
        public static void Output(int[,] array1, int count1, int count2)
        {
            Console.WriteLine("вывод элементов 1 массива");

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    Console.Write(array1[i, j] + "\t");
                }
                Console.WriteLine();

            }
        }
        public static int[,] SolveProblem2(int count1, int count2)
        {
            bool check = false;
            int i, j;
            int[,] arrayEx1 = new int[count1, count2];
            int[] arrayEx01 = new int[count1];
            int[,] array1 = new int[count1, count2];
            int[] array01 = new int[count1];
            while (check == false)
            {
                Console.WriteLine("Ошибка конвертации. Введите целочисленнный массив ещё раз.");
                Console.WriteLine("ввод элементов 1 массива");

                for (i = 0; i < count1; i++)
                {
                    string p = Console.ReadLine();
                    string[] pStr = p.Split(' ');
                    bool c1 = int.TryParse(pStr[i], out arrayEx01[i]);
                    if (c1 == true)
                    {
                        array01[i] = arrayEx01[i];
                        for (j = 0; j < count2; j++)
                        {
                            bool c2 = int.TryParse(pStr[j], out arrayEx1[i, j]);
                            if (c2 == true)
                            {
                                array1[i, j] = arrayEx1[i, j];
                                if ((i == count1 - 1) & (j == count2 - 1))
                                {
                                    if (int.TryParse(pStr[i], out arrayEx01[i]))
                                    {
                                        check = true;
                                    }
                                }
                            }

                            else
                            {
                                Array.Clear(array01, 0, array01.Length);

                                Console.ReadKey();
                                //Console.Clear();
                                check = false;
                            }

                        }
                    }

                }
            }
            return array1;
        }

        public static int fun()
        {
            int Choice;
            try
            {
                Choice = int.Parse(Console.ReadLine());
                Console.WriteLine(Choice);
                return Choice;
            }
            catch (Exception)
            {
                Console.WriteLine("mistake");
                return fun();
            }
        }
        /*public static void setX()
        {
            /*
             * Console.WriteLine("ввод элементов 1 массива");
                                    for (i = 0; i < count1; i++)
                                    {
                                        string p = Console.ReadLine();
                                        string[] pStr = p.Split(' ');
                                        array01[i] = int.Parse(pStr[i]);//!!!
                                        for (j = 0; j < count2; j++)
                                        {
                                            array1[i, j] = int.Parse(pStr[j]);//!!!
                                        }
                                    }
             

            bool check = false;

            while (check == false)
            {
                
                    for (int i = 0; i < count1; i++)
                {
                    string p = Console.ReadLine();
                    string[] pStr = p.Split(' ');
                    if (!int.TryParse(pStr[i], out array01[i]))


                        }
                    }
                }*/
        
        static void Main(string[] args)
        {
        SolveProblem2(2, 3);
            Console.WriteLine("вывод элементов 1 массива");

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array1[i, j] + "\t");
                }
                Console.WriteLine();
                //Console.WriteLine("+");
            Console.ReadKey();
        }
        
    }
}
