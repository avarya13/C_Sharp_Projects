using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6б
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = new int[2, 3] { { 7, 6, 3 }, { 9, 4, 5 } };
            int rows = array1.GetLength(0);
            int columns = array1.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int c = array1[i, j];
                    array1[i, j] = array1[i, columns - j - 1];
                    array1[i, columns - j - 1] = c;
                }
            }
            /* for (int i = 0; i < rows; i++)
             {
                 for (int j = 0; j < columns; j++)
                 {
                     Console.WriteLine(array1[i,j]);
                 }
             }*/

            int[] array2 = new int[rows * columns];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    array1[i, j] = array2[k++];

                }

            }

            for (k = 0; k < array2.Length; k++)
            {
                Console.WriteLine(array2[k]);
            }


            Console.ReadKey();
        }
    }
}
