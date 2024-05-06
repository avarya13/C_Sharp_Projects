using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        public static int FindCoins(int n, int[]nom, List<int> sum )
        {
            int[,] mas = new int[n, 500];
            

            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    mas[i, j] = nom[r.Next(0, 3)];

                }
            }
            int count = 0;
            for (int i = 0; i < sum.Count; i++)
            {
                foreach (var item in mas)
                {
                    if (item == sum[i])
                        count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            int[] nom = new int[4] { 1, 2, 5,10 };

            List<int> sum = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!sum.Contains(nom[i] + nom[j]))
                    {
                        sum.Add(nom[i] + nom[j]);

                    }
                }

            }

           
            Console.WriteLine(FindCoins(2, nom, sum));
            FindCoins(3, nom, sum);
            FindCoins(4, nom, sum);


            Console.ReadKey();

                //int n = 25;
                //    //Convert.ToInt32(Console.ReadLine());
                //if (n > 1000) Console.WriteLine("Число слишком большое");
                //else
                //    Console.WriteLine(getCountOfWays(n, 2));
                //Console.ReadKey();
                //Func<int, int, int>[] operations = new Func<int, int, int>[2];
                //operations[0] = (a, b) => a - b;
                //operations[1] = (a, b) => a + b;

                //int[] numbers = { 5, 4, -2, 4, 8, 34, 75, 0 };
                //int signAmount = numbers.Length - 1;
                //int combinationLen = (int)Math.Pow(2, signAmount);


                //long bestResult = long.MaxValue;
                //List<string> allExpressions = new List<string>();
                //List<string> allBestExpressions = new List<string>();
                //StringBuilder stringBuilder = new StringBuilder();

                //for (int i = 0; i < combinationLen; i++)
                //{
                //    int result = numbers[0];

                //    stringBuilder.Clear();
                //    stringBuilder.Append(numbers[0]);

                //    for (int j = 0; j < signAmount; j++)
                //    {
                //        int number = numbers[j + 1];
                //        int opIndex = (i & (1 << j)) > 0 ? 1 : 0;
                //        result = operations[opIndex](result, number);

                //        stringBuilder.Append(opIndex > 0 ? "+" : "-");

                //        if (number >= 0)
                //            stringBuilder.Append(number);
                //        else
                //            stringBuilder.Append($"({number})");

                //    }

                //    stringBuilder.Append($" = {result}");
                //    allExpressions.Add(stringBuilder.ToString());


                //    if (Math.Abs(result) == Math.Abs(bestResult))
                //    {
                //        allBestExpressions.Add(allExpressions.Last());
                //    }
                //    else if (Math.Abs(result) < Math.Abs(bestResult))
                //    {
                //        bestResult = result;

                //        allBestExpressions.Clear();
                //        allBestExpressions.Add(allExpressions.Last());
                //    }

                //}



                //Console.WriteLine("-----------------------------------");
                //Console.WriteLine("Все результаты:");
                //Console.WriteLine(string.Join("\n", allExpressions));
            }
        }
    }

