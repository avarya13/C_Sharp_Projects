using System;
using System.IO;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = new int[3] { 1, 3, 5 };
            StreamWriter sw = new StreamWriter(@"1.txt");
            for (int i = 0; i < 3; i++)
            {
                
                    sw.WriteLine(a[i] + " ");
                
            }
            sw.Close();

            StreamReader sr = new StreamReader(@"1.txt");
            string line = sr.ReadToEnd();
            int[] b = new int[3];
            string[] result = line.Split(" ");
            for (int i = 0; i < 3; i++)
            {
               
                    b[i] = Convert.ToInt32(result[i ])*2;
                    Console.WriteLine(b[i]);
                        
                
            }
            sr.Close();

        }
    }
}
