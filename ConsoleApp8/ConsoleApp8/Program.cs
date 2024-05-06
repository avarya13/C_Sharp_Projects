using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        //возвращает целую или дробную часть десятичного числа
        public static List<int> GetDecNum(string num, bool is_integer)
        {
            List<int> nums = new List<int>();
            foreach (char item in num)
            {
                int temp;
                switch (item)
                {
                    case 'A':
                        temp = 10;
                        break;
                    case 'B':
                        temp = 11;
                        break;
                    case 'C':
                        temp = 12;
                        break;
                    case 'D':
                        temp = 13;
                        break;
                    case 'E':
                        temp = 14;
                        break;
                    case 'F':
                        temp = 15;
                        break;
                    default:
                        temp = Convert.ToInt32("" + item);
                        break;
                }

                nums.Add(temp);
            }
            if(is_integer)
                nums = Enumerable.Reverse(nums).ToList();
            return nums;
        }

        


        //переводит в десятичную СС
        public static double ToDecimal(string num, int num_sys)
        {
            double res = 0;
            List<int> nums_integer; //целая часть

            if (num.Contains(','))// если есть дробная часть
            {
                string[] temp_arr = num.Split(',');
                nums_integer = GetDecNum(temp_arr[0], true); 
                List<int> nums_fract = GetDecNum(temp_arr[1], false); //дробная часть
                int i_temp = -1;
                for (int i = 0; i < nums_fract.Count; i++)
                {
                    res += nums_fract[i] * Math.Pow(num_sys, i_temp);
                    i_temp--;
                }
            }
            else
            {
                nums_integer = GetDecNum(num, true); 
            }


            for (int i = 0; i < nums_integer.Count; i++)
            {
                res += nums_integer[i] * Math.Pow(num_sys, i);
            }
            
            return Math.Round(res, 3);
        }
        
        static void Main(string[] args)
        {
            string num = Console.ReadLine(); // число

            int num_sys = Convert.ToInt32(Console.ReadLine()); //система счисления

            Console.WriteLine(ToDecimal(num, num_sys));

            //string num1 = Console.ReadLine(); // число

            //Console.WriteLine(FromDecimal(num1, 2));

            Console.ReadKey();
        }

    }
}
