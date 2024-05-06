using System;

namespace Ref_Out
{
    class Program
    {
        public static void Increment(ref int n)
        {
            n++;
            Console.WriteLine($"n в методе Increment: {n}");
        }
        public static void Calculate(int i,int j, out int res1,out int res2)
        {
            res1 = i + j;
            res2 = i*j;
            Console.WriteLine($"n+8={res1}, n*8= {res2}");
        }
        static void Main(string[] args)
        {
            int number = 5;
            Console.WriteLine($"n до метода Increment: {number}");
            Increment(ref number);
            Console.WriteLine($"n после метода Increment: {number}");
            int sum; int mult;
            Calculate(number,8, out sum,out mult);

        }
    }
}
