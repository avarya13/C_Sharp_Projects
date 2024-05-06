using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = new int[8] { 1,3,5,7,9,11,13,15};
            int[] a2 = new int[8] { 2,4,6,8,10,12,14,16 };
            int[] res = new int[16];
            for(int i = 0; i < a1.Length; i++)
            for(int j=0;j<res.Length;j++)
            {
                if(j %2==0)
                {
                    res[j] = a1[i];
                }
                else res[j] = a2[i];
                    Console.WriteLine(res[j]);
                }
                
            }
        }
    }

