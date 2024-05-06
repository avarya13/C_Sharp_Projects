using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Stopwatch s = new Stopwatch();
            s.Restart();
            Func<int, int, int>[] operations = new Func<int, int, int>[2];
            operations[0] = (a, b) => a - b;
            operations[1] = (a, b) => a + b;

            int[] numbers = { 5, 4, -2, 4, 8, 34, 75, 0 };
            int signAmount = numbers.Length - 1;
            int combinationLen = (int)Math.Pow(2, signAmount);


            long bestResult = long.MaxValue;
            List<string> allExpressions = new List<string>();
            List<string> allBestExpressions = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < combinationLen; i++)
            {
                int result = numbers[0];

                stringBuilder.Clear();
                stringBuilder.Append(numbers[0]);

                for (int j = 0; j < signAmount; j++)
                {
                    int number = numbers[j + 1];
                    int opIndex = (i & (1 << j)) > 0 ? 1 : 0;
                    result = operations[opIndex](result, number);

                    stringBuilder.Append(opIndex > 0 ? "+" : "-");

                    if (number >= 0)
                        stringBuilder.Append(number);
                    else
                        stringBuilder.Append($"({number})");

                }

                stringBuilder.Append($" = {result}");
                allExpressions.Add(stringBuilder.ToString());


                if (Math.Abs(result) == Math.Abs(bestResult))
                {
                    allBestExpressions.Add(allExpressions.Last());
                }
                else if (Math.Abs(result) < Math.Abs(bestResult))
                {
                    bestResult = result;

                    allBestExpressions.Clear();
                    allBestExpressions.Add(allExpressions.Last());
                }

            }

            Console.WriteLine("Лучшие результаты:");
            Console.WriteLine(string.Join("\n", allBestExpressions));

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Все результаты:");
            Console.WriteLine(string.Join("\n", allExpressions));

            s.Stop();
            long x = s.ElapsedMilliseconds;
        }
    }
}
