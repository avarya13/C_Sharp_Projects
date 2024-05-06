using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program

    {
        //private static void GetCombination<T>(List<T> set, List<List<T>> result)
        //{

            //    for (int i = 0; i < set.Count; i++)
            //    {
            //        List<T> temp = new List<T>(set.Where((s, index) => index != i));

            //        if (temp.Count > 0 && !result.Where(l => l.Count == temp.Count).Any(l => l.SequenceEqual(temp)))
            //        {
            //            result.Add(temp);

            //            GetCombination<T>(temp, result);
            //        }
            //    }
            //}

            static void Main(string[] args)
            {
                //    List<List<long>> result = new List<List<long>>();

                //    List<long> set = new List<long>() { 0,1};

                //    GetCombination<long>(set, result);

                //    result.Add(set);

                //    //IOrderedEnumerable<List<long>> sorted = result.OrderByDescending(s => s.Count);

                //    //sorted.ToList().ForEach(l => { l.ForEach(l1 => Console.Write(l1 + " ")); Console.WriteLine(); });
                int size = 3;
                int[][] result =
                    Enumerable.Range(0, 1 << size)
                    .Select(i => new BitArray(new int[] { i }).Cast<int>().Take(size).ToArray())
                    .ToArray();

                foreach (var item in result[0])
                {
                    Console.WriteLine(item);
                }
            foreach (var item in result[0])
            {
                Console.WriteLine(item);
            }
            foreach (var item in result[1])
            {
                Console.WriteLine(item);
            }
            foreach (var item in result[2])
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            }
        }
    }

