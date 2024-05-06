using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laboratornaya1._2
{
    class Задание2
    {
        public static int[,] array1;
        public static int[,] array2;
        public static int count1;
        public static int count2;
        public static int count3;
        public static int count4;
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
        public static int[,] Mass1()
        {
            Console.WriteLine("Задание 2");
            //string d = Console.ReadLine();
            //string[] dStr = d.Split(' ');
            bool c1 = false;
            bool c2 = false;
            bool c;
            while (c1 == false || c2 == false)
            {
                Console.WriteLine("Введите целочисленный размер массива");
                string d0 = Console.ReadLine();
                string[] dStr0 = d0.Split(' ');
                c1 = int.TryParse(dStr0[0], out count1);
                c2 = int.TryParse(dStr0[1], out count2);
                if (c1 == true && c2 == true)
                    break;
            }
            Задание2.array1 = new int[Задание2.count1, Задание2.count2];

                int[] array01 = new int[Задание2.count1];
                int i, j;
                Console.WriteLine("ввод элементов 1 массива");
                for (i = 0; i < Задание2.count1; i++)
                {

                    string p = Console.ReadLine();
                    string[] pStr = p.Split(' ');
                    c = int.TryParse(pStr[i], out array01[i]);
                    if (c == false)
                    {
                        SolveProblem1(Задание2.count1, Задание2.count2);
                        break;
                    }

                    for (j = 0; j < Задание2.count2; j++)
                    {
                        c = int.TryParse(pStr[j], out Задание2.array1[i, j]);
                        if (c == false)
                        {
                            SolveProblem1(Задание2.count1, Задание2.count2);
                            break;
                        }
                        else if ((i== Задание2.count1) & (j== Задание2.count2))
                    {
                        if (c == true)
                        {
                            break;
                        }
                    }
                    }
                }
            return Задание2.array1;
        }

        public static int[,] Mass2()
        {
            //string d = Console.ReadLine();
            //string[] dStr = d.Split(' ');
            bool c1 = false;
            bool c2 = false;
            bool c;
            while (c1 == false || c2 == false)
            {
                Console.WriteLine("Введите целочисленный размер массива");
                string d0 = Console.ReadLine();
                string[] dStr0 = d0.Split(' ');
                c1 = int.TryParse(dStr0[0], out count3);
                c2 = int.TryParse(dStr0[1], out count4);
                if (c1 == true && c2 == true)
                    break;
            }
            Задание2.array2 = new int[Задание2.count3, Задание2.count4];

            int[] array02 = new int[Задание2.count4];
            int i, j;
            Console.WriteLine("ввод элементов 2 массива");
            for (i = 0; i < Задание2.count3; i++)
            {

                string p = Console.ReadLine();
                string[] pStr = p.Split(' ');
                c = int.TryParse(pStr[i], out array02[i]);
                if (c == false)
                {
                    SolveProblem1(Задание2.count3, Задание2.count4);
                    break;
                }

                for (j = 0; j < Задание2.count4; j++)
                {
                    c = int.TryParse(pStr[j], out Задание2.array2[i, j]);
                    if (c == false)
                    {
                        SolveProblem1(Задание2.count3, Задание2.count4);
                        break;
                    }
                    else if ((i == Задание2.count3) & (j == Задание2.count4))
                    {
                        if (c == true)
                        {
                            break;
                        }
                    }
                }
            }
            return Задание2.array2;
        }



        //Console.WriteLine("ввод элементов 1 массива");
        //bool checkArr1 = false;
        //while (checkArr1 == false)
        //{
        // for (i = 0; i < count1; i++)
        //{
        //string p = Console.ReadLine();
        //string[] pStr = p.Split(' ');
        //bool checkArr1;
        //checkArr1=int.TryParse(pStr[0], out array01[i]);
        // = int.Parse(pStr[i]);//!!!

        //while (checkArr1 == false)
        //{
        // string p = Console.ReadLine();
        // string[] pStr = p.Split(' ');
        //p = Console.ReadLine();
        //Array.Resize(pStr,)

        /* checkArr1 = int.TryParse(pStr[0], out array01[i]);

         for (j = 0; j < count2; j++)
         {
             array1[i, j] = int.Parse(pStr[j]);
             if (checkArr1 == false)
             {
                 break;
             }
             //!!!
         }
         //}*/

        /*Задание2.Output(array1, count1, count2);
Задание2.Max(array1);
Задание2.Min(array1);
Console.WriteLine("Ввод количества строк и столбцов:");
string e = Console.ReadLine();
string[] eStr = e.Split(' ');
int count3, count4;
bool check1 = int.TryParse(eStr[0], out count3);
bool check2 = int.TryParse(eStr[0], out count4);
while (check1 == false && check2 == false)
{
//check1 = int.TryParse(eStr[0], out count3);
Console.WriteLine("Ошибка конвертации. Введите число.");
string e0 = Console.ReadLine();
string[] eStr0 = e0.Split(' ');
check1 = int.TryParse(eStr0[0], out count3);
check2 = int.TryParse(eStr0[0], out count4);
}

//int count3 = int.Parse(eStr[0]);
//int count4 = int.Parse(eStr[1]);
int[,] array2 = new int[count3, count4];
int[] array02 = new int[count3];

Console.WriteLine("ввод элементов 2 массива");
for (i = 0; i < count1; i++)
{
string p = Console.ReadLine();
string[] pStr = p.Split(' ');
array02[i] = int.Parse(pStr[i]);//!!!
for (j = 0; j < count2; j++)
{

 array2[i, j] = int.Parse(pStr[j]);//!!!
}
}

Console.WriteLine("вывод элементов 2 массива");

for (i = 0; i < count3; i++)
{
for (j = 0; j < count4; j++)
{
 Console.Write(array2[i, j] + "\t");
}
Console.WriteLine();*/



        //Задание2.MatrixOperations(array1, array2);
        //}
        public static int[,] SolveProblem1(int count1, int count2)
        {
            bool check = false;
            int i, j;
            int[,] arrayEx1 = new int[count1, count2];
            int[] arrayEx01 = new int[count1];
            Задание2.array1 = new int[count1, count2];
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
                                Задание2.array1[i, j] = arrayEx1[i, j];
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
            return Задание2.array1;
        }

        public static int[,] SolveProblem2(int count1, int count2)
        {
            bool check = false;
            int i, j;
            int[,] arrayEx1 = new int[count1, count2];
            int[] arrayEx01 = new int[count1];
            Задание2.array2 = new int[count1, count2];
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
                                Задание2.array2[i, j] = arrayEx1[i, j];
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
            return Задание2.array2;
        }
        public static void Max(int[,] array)
    {
            int max = array[0, 0];
            int imax = 0; 
            int jmax = 0;
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

public static void Min(int[,] array1)
{
int min = array1[0, 0];
int imin = 0;
int jmin = 0;
           int i = 0;
           int j = 0;
for (i = 0; i < array1.GetUpperBound(0)+1 ; i++)
{
 for (j = 0; j < array1.GetUpperBound(1)+1 ; j++)
 {
     if (min > array1[i, j])
     {
         min = array1[i, j];
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

 for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
 {
     for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
     {
         sum[i, j] = array[i, j] + array2[i, j];
     }
 }
 Console.WriteLine("Сумма матриц:");
 for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
 {
     for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
     {
         Console.Write(sum[i, j] + "\t");
     }
     Console.WriteLine();
 }

 int[,] sub = new int[array.GetUpperBound(0) + 1, array.Length];
 
 for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
 {
     for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
     {
         sub[i, j] = array[i, j] - array2[i, j];
     }
 }
 Console.WriteLine("Разность матриц:");
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
 Console.WriteLine("Произведение матриц:");
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
public static void Read()
{
int i, j;
Console.WriteLine();
Console.WriteLine("Задание 2");
FileStream count_1 = new FileStream(@"count_1.txt", FileMode.Open);
StreamReader reader3 = new StreamReader(count_1);
int count1 = int.Parse(reader3.ReadToEnd());
reader3.Close();
FileStream count_2 = new FileStream(@"count_2.txt", FileMode.Open);
StreamReader reader4 = new StreamReader(count_2);
int count2 = int.Parse(reader4.ReadToEnd());
reader4.Close();

int[,] array1 = new int[count1, count2];
FileStream file3 = new FileStream(@"file3.txt", FileMode.Open);
StreamReader reader5 = new StreamReader(file3);
string p = reader5.ReadToEnd();
reader5.Close();
string[] array0 = p.Split(' ');
for (i = 0; i < count1; i++)
{
 for (j = 0; j < count2; j++)
 {
     array1[i, j] = int.Parse(array0[i * count1 + j]);
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
//Задание2.Max(array1);
Задание2.Min(array1);

int[,] array2 = new int[count1, count2];
FileStream file4 = new FileStream(@"file4.txt", FileMode.Open);
StreamReader reader6 = new StreamReader(file4);
string p0 = reader6.ReadToEnd();
reader6.Close();
string[] array00 = p0.Split(' ');

for (i = 0; i < count1; i++)
{
 for (j = 0; j < count2; j++)
 {
     array2[i, j] = int.Parse(array00[i * count1 + j]);
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

}
}
}

