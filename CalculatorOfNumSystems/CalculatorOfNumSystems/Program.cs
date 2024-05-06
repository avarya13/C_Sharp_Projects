using CalculatorOfNumSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp8
{
    class Program
    {
        //проверка корректности ввода числа в данной СС
        public static bool IsNumCorrect(string num, string num_sys)
        {
            string[] nums = new string[2];

            if (num.Contains(','))// если есть дробная часть

                nums = num.Split(',');
            else
            {
                nums[0] = num;
                nums[1] = "";
            }
            Regex incorrect_nums = new Regex(@"[A-Za-zА-Яа-я!@#$%^&*()_+?/]");
            for (int i = 0; i < 2; i++)
            {
                foreach (char j in nums[i])
                {
                    if (Convert.ToInt32(num_sys) <= 10)
                    {
                        if (Regex.IsMatch(("" + j).ToString(), incorrect_nums.ToString()))
                            return false;
                        if (Convert.ToInt32("" + j) >= Convert.ToInt32(num_sys))
                            return false;

                    }

                    else
                    {

                        switch (Convert.ToInt32(num_sys))
                        {
                            case 11:
                                incorrect_nums = new Regex(@"[B-Za-zА-Яа-я!@#$%^&*()_+?/]");

                                break;
                            case 12:
                                incorrect_nums = new Regex(@"[C-Za-zА-Яа-я!@#$%^&*()_+?/]");

                                break;
                            case 13:
                                incorrect_nums = new Regex(@"[D-Za-zА-Яа-я!@#$%^&*()_+?/]");

                                break;
                            case 14:
                                incorrect_nums = new Regex(@"[E-Za-zА-Яа-я!@#$%^&*()_+?/]");

                                break;
                            case 15:
                                incorrect_nums = new Regex(@"[F-Za-zА-Яа-я!@#$%^&*()_+-?/]");

                                break;
                            default:
                                incorrect_nums = new Regex(@"[G-Za-zА-Яа-я!@#$%^&*()_+?/]");
                                break;
                        }

                        if (Regex.IsMatch(("" + j).ToString(), incorrect_nums.ToString()))
                            return false;
                        else if (Regex.IsMatch(("" + j).ToString(), incorrect_nums.ToString()))
                            return false;

                    }
                }


            }
            return true;
        }

        //возвращает целую или дробную часть десятичного числа
        public static List<int> GetDecNum(string num, bool is_integer)
        {

            List<int> nums = new List<int>();//добавить какая система счисления чтобы не было прохождения
            //каждый раз с foreach
            {

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

                if (is_integer)
                    nums = Enumerable.Reverse(nums).ToList();
                return nums;
            }
        }

        //переводит в десятичную СС
        public static string ToDecimal(string num, int num_sys)
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
            return Math.Round(res, 5).ToString();
        }

        //переводит из десятичной системы счисления в любую другую
        public static string FromDecimal(string num, int num_sys)
        {
            string integer = null;
            string fract = null;
            int nums_integer;
            if (num.Contains(','))// если есть дробная часть
            {
                fract = ",";
                string[] temp_arr = num.Split(',');
                nums_integer = Convert.ToInt32(temp_arr[0]);
                double nums_fract = Convert.ToDouble(temp_arr[1]) / Math.Pow(10, temp_arr[1].Length); //дробная часть запись 0,45
                double temp = 0;
                int temp_int = 0;
                double temp_fr = 0;
                int decpt = 7;
                for (int i = 0; i < decpt; i++)//вычисление дробной части числа в другой системе счисления
                {
                    temp = (nums_fract * num_sys);
                    temp_int = (int)temp;
                    temp_fr = temp - temp_int;
                    nums_fract = temp_fr;
                    if (temp_int >= 10)//если система отсчета больше 10 изменение цифр на буквы
                    {
                        fract += GetChardecmore(temp_int);
                    }
                    else fract += temp_int.ToString();
                }
            }
            else
            {
                nums_integer = Convert.ToInt32(num);
            }
            int nums_integerint;
            int nums_integerrem;
            while (nums_integer != 0)//вычисление целой части числа в другой системе отсчета
            {
                nums_integerint = (int)(nums_integer / num_sys);
                nums_integerrem = (int)nums_integer % num_sys;
                nums_integer = nums_integerint;
                if (nums_integerrem >= 10)//если система отсчета больше 10 изменение цифр на буквы
                {
                    integer = (GetChardecmore(nums_integerrem) + integer);
                }
                else integer = (nums_integerrem.ToString() + integer);
            }
            return Math.Round(double.Parse(integer + fract), 3).ToString();
        }


        //изменение цифр на буквы
        public static char GetChardecmore(int temp_int)
        {
            char temp;
            switch (temp_int)
            {
                case 10:
                    temp = 'A';
                    break;
                case 11:
                    temp = 'B';
                    break;
                case 12:
                    temp = 'C';
                    break;
                case 13:
                    temp = 'D';
                    break;
                case 14:
                    temp = 'E';
                    break;
                case 15:
                    temp = 'F';
                    break;
                default:
                    temp = 'N';
                    break;
            }
            return temp;
        }

        //Сложение
        public static string Summary(string lhs, int num_lhs, string rhs, int num_rhs, int num_ret)
        //два числа и их системы счисления, и последний параметр это та система в которой надо вывести ответ
        {
            string ans = null;
            if (num_lhs != 10 && num_rhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = (num1 + num2).ToString();
            }
            else if (num_lhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(rhs);
                ans = (num1 + num2).ToString();
            }
            else if (num_rhs != 10)
            {
                double num1 = Convert.ToDouble(lhs);
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = (num1 + num2).ToString();
            }
            else
            {
                double ans_int = Convert.ToInt32(lhs) + Convert.ToInt32(rhs);
                ans = ans_int.ToString();
            }
            return FromDecimal(ans, num_ret);
        }

        //Вычитание
        public static string Subtraction(string lhs, int num_lhs, string rhs, int num_rhs, int num_ret)
        //два числа и их системы счисления, и последний параметр это та система в которой надо вывести ответ
        {
            string ans = null;
            if (num_lhs != 10 && num_rhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = (num1 - num2).ToString();
            }
            else if (num_lhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(rhs);
                ans = (num1 - num2).ToString();
            }
            else if (num_rhs != 10)
            {
                double num1 = Convert.ToDouble(lhs);
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = (num1 - num2).ToString();
            }
            else
            {
                double ans_int = Convert.ToDouble(lhs) - Convert.ToDouble(rhs);
                ans = ans_int.ToString();
            }
            return FromDecimal(ans, num_ret);
        }

        //Деление
        public static string Division(string lhs, int num_lhs, string rhs, int num_rhs, int num_ret)
        //два числа и их системы счисления, и последний параметр это та система в которой надо вывести ответ
        {
            string ans = null;
            if (num_lhs != 10 && num_rhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = Math.Round((double)(num1 / num2), 3).ToString();
            }
            else if (num_lhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(rhs);
                ans = Math.Round((double)(num1 / num2), 3).ToString();
            }
            else if (num_rhs != 10)
            {
                double num1 = Convert.ToDouble(lhs);
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = Math.Round((double)(num1 / num2), 3).ToString();
            }
            else
            {
                double ans_dob = Convert.ToDouble(lhs) - Convert.ToDouble(rhs);
                ans = Math.Round(ans_dob, 3).ToString();
            }
            return FromDecimal(ans, num_ret);
        }

        //Умножение
        public static string Multiplication(string lhs, int num_lhs, string rhs, int num_rhs, int num_ret)
        //два числа и их системы счисления, и последний параметр это та система в которой надо вывести ответ
        {
            string ans = null;
            if (num_lhs != 10 && num_rhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = (num1 * num2).ToString();
            }
            else if (num_lhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                double num2 = Convert.ToDouble(rhs);
                ans = (num1 * num2).ToString();
            }
            else if (num_rhs != 10)
            {
                double num1 = Convert.ToDouble(lhs);
                double num2 = Convert.ToDouble(ToDecimal(rhs, num_rhs));
                ans = (num1 * num2).ToString();
            }
            else
            {
                double ans_dob = Convert.ToDouble(lhs) * Convert.ToDouble(rhs);
                ans = ans_dob.ToString();
            }
            return FromDecimal(ans, num_ret);
        }

        //Возведение в степень
        public static string Exponentiate(string lhs, int num_lhs, int dgr, int num_ret)
        //число , его система счисления, степень в которую возводить, последний параметр это та система в которой надо вывести ответ
        {
            string ans = null;
            if (num_lhs != 10)
            {
                double num1 = Convert.ToDouble(ToDecimal(lhs, num_lhs));
                ans = (Math.Pow(num1, dgr)).ToString();
            }
            else
            {
                double ans_dob = (Math.Pow(Convert.ToDouble(lhs), dgr));
                ans = ans_dob.ToString();
            }
            return FromDecimal(ans, num_ret);
        }
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
