using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string PermutationVShet(int n, int k)//сочетание без возвращением здесь формула ее нужно отдельно чтобы использовать при комбинаторном сложении и умножении
        {
            long ans = 1;
            return ans.ToString();
        }
        static string PermutationV(int n, int k)//сочетание без возвращением здесь просто задача и вызывается формула
        {
            long ans = 1;
            return ans.ToString();
        }
        static long Fact(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        static string PermutationN()//перестановки без возвращения
        {
            try
            {
                Console.WriteLine("Сколькими способами можно рассадить n человек за столом? ");
                Console.WriteLine("Введите n:");
                int n = Convert.ToInt32(Console.ReadLine());
                long ans = 0;
                ans = Fact(n);
                return ans.ToString();
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }
        }
        static string PlacementN()//размещение без возвращения
        {
            try
            {
                long ans = 0;
                Console.WriteLine("В студенческой группе n человека. Сколькими способами можно выбрать m должностей? ");
                Console.WriteLine("Введите n, m:");
                int n = Convert.ToInt32(Console.ReadLine());
                int m = Convert.ToInt32(Console.ReadLine());
                if (n >= m)
                {
                    long l = n - m;
                    long k = Fact(n);
                    long k2 = Fact(l);
                    ans = (k / k2);

                }
                return ans.ToString();
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }
        }
        static string PermutationV()//перестановки c возвращением
        {
            try
            {
                Console.WriteLine("Алексей занимается спортом, причём n дня в неделю – лёгкой атлетикой, k дня – силовыми упражнениями и l день отдыхает. " +
                    "Сколькими способами он может составить себе расписание занятий на неделю? ");
                Console.WriteLine("Введите n, l, k:");
                long ans = 0;
                long n = Convert.ToInt32(Console.ReadLine());
                long k = Convert.ToInt32(Console.ReadLine());
                long l = Convert.ToInt32(Console.ReadLine());
                ans = Fact(n + k + l) / (Fact(n) * Fact(k) * Fact(l));
                return ans.ToString();
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }
        }

        static string PlacementV()//размещение c возвращением
        {
            try
            {
                Console.WriteLine("Сколько существует N-значных пин-кодов из k-символов? ");
                Console.WriteLine("Введите N, k:");
                int N = Convert.ToInt32(Console.ReadLine());
                int k = Convert.ToInt32(Console.ReadLine());
                int ans = 1;
                while (N != 0)
                {
                    ans *= k;
                    N--;
                }
                return ans.ToString();
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }
        }
        static string SummaryComb()//комбинаторное сложение
        {
            try
            {
                Console.WriteLine("Студенческая группа состоит из U юношей и D девушек. Сколькими способами можно выбрать h человек одного пола? ");
                Console.WriteLine("Введите U, D, k:");
                int U = Convert.ToInt32(Console.ReadLine());
                int D = Convert.ToInt32(Console.ReadLine());
                int k = Convert.ToInt32(Console.ReadLine());
                long ans = 1;
                long k1 = Convert.ToInt32(PermutationVShet(U, k));
                long k2 = Convert.ToInt32(PermutationVShet(D, k));
                ans = k1 + k2;
                return ans.ToString();
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }
        }
        static string MultuplyComb() //комбинаторное произведение
        {
            try
            {
                Console.WriteLine("Из города А в город В ведут n дорог, а из города В в город С - m дорог. " +
                    "Сколькими способами можно проехать из города А в город С?\n" +
                    "Введите n и m:");
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                return (n * m).ToString();
            }
            catch (Exception )
            {
                return "Ошибка ввода!";
            }
        }
        public static string CombinationsN() //сочетания без повторений
        {
            try
            {
                Console.WriteLine("Учащимся дали список из n книг, которые рекомендуется прочитать во время каникул. Сколькими способами ученик может выбрать из них m книг?\n" +
                    "Введите n и m:");
                long n = Convert.ToInt32(Console.ReadLine());
                long m = Convert.ToInt32(Console.ReadLine());
                long k1 = Fact(n);
                long k2 = Fact(m);
                long k3 = Fact(n - m);
                return (k1 / (k2 * k3)).ToString();
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }

        }
        public static string CombinationsV() //сочетания с повторениями
        {
            Console.WriteLine("В кондитерском магазине продаётся n видов пирожных. Сколькими способами можно купить m пирожных?\n" +
                "Введите n и m:");
            try
            {
                long n = Convert.ToInt32(Console.ReadLine());
                long m = Convert.ToInt32(Console.ReadLine());
                if (n < m)
                {
                    long k1 = Fact(n + m - 1);
                    long k2 = Fact(m);
                    long k3 = Fact(n - 1);
                    return (k1 / (k2 * k3)).ToString();
                }
                else return "n должно быть меньше m";
            }
            catch (Exception)
            {
                return "Ошибка ввода!";
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("Выберите задачу:\n" +
                    "1 - размещения без повторений\n" +
                    "2 - размещения с повторениями\n" +
                    "3 - перестановки без повторений\n" +
                    "4 - перестановки с повторениями\n" +
                    "5 - сочетания без повторений\n" +
                    "6 - сочетания с повторениями\n" +
                    "7 - комбинаторная сумма\n" +
                    "8 - комбинаторное произведение");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Ответ: "+ PlacementN());
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Ответ: "+ PlacementV());
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("Ответ: " + PermutationN());
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Ответ: " + PermutationV());
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine("Ответ: " + CombinationsN());
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine("Ответ: " + CombinationsV());
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine("Ответ: " + SummaryComb());
                        Console.WriteLine();
                        break;
                    case "8":
                        Console.WriteLine("Ответ: " + MultuplyComb());
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер задачи!");
                        Console.WriteLine();
                        break;
                }

                Console.ReadKey();
            }
            
        }
    }
}

