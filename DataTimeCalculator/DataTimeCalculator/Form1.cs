using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTimeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // находим разницу между индексами и определяем домножать или делить
        public static List<int> Conversion(int year, int month, int num, int hour, int min, int sec)
        {
            List<int> times = new List<int>
            {
                year,
                month, num,
                hour,
                min,
                sec
            };
            return times;
        }

        // разница между датами на выдаче массив гдн 1 - сколько дней и время сколько
        //принимает два числа в порядке от года к секундам
        public static int[] Differ(int year_lhs, int month_lhs, int num_lhs, int hour_lhs, int min_lhs, int sec_lhs, int year_rhs, int month_rhs, int num_rhs, int hour_rhs, int min_rhs, int sec_rhs)
        {
            List<int> time1 = new List<int>();
            List<int> time2 = new List<int>();
            time1 = Conversion(year_lhs, month_lhs, num_lhs, hour_lhs, min_lhs, sec_lhs);
            time2 = Conversion(year_rhs, month_rhs, num_rhs, hour_rhs, min_rhs, sec_rhs);
            int[] array_1 = new int[]
            { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] time = new int[4];
            //высчитываем сколько было высокосных лет в заданном интервале
            int some = time2[0];
            int countv = 0;
            while (some <= time1[0])
            {
                if (some % 4 == 0 && some % 100 != 0 || some % 400 == 0)
                {
                    countv = countv + 1;
                }
                some++;
            }
            time[0] = time1[0] - time2[0];
            time[1] = time1[1] - time2[1];
            time[2] = time1[2] - time2[2];
            time[0] = time1[0] - time2[0];
            int x = time1[2];
            for (int i = 1; i < time1[1]; i++)
            {
                x += array_1[i - 1];
            }
            int y = time2[2];
            for (int i = 1; i < time2[1]; i++)
            {
                y += array_1[i - 1];
            }

            if ((time1[0] % 4 == 0 && some % 100 != 0 || some % 400 == 0) && time1[1] > 2) { countv--; } //если начальная дата высокосный год больше 29 февраля то отнимаем 1 от кол-во высокосных лет
            if ((time2[0] % 4 == 0 && some % 100 != 0 || some % 400 == 0) && time2[2] <= 29 && time2[1] < 3) { countv--; } //если конечная дата до 29 февраля то отнимаем 1 от высокосных лет
            if (time1[0] == time2[0])
            {
                time[0] = (x - y) + countv;
            }
            else
                time[0] = (time1[0] - time2[0]) * 365 + ((x - y) + countv);
            time[1] = time1[3] - time2[3];
            if (time[1] < 0)
            {
                time[0]--;
                time[1] += 24;
            }
            time[2] = time1[4] - time2[4];
            if (time[2] < 0)
            {
                time[1]--;
                time[2] += 60;
            }
            time[3] = time1[5] - time2[5];
            if (time[3] < 0)
            {
                time[2]--;
                time[3] += 60;
            }
            return time;
        }
        // прибавление к дате количество дней и времени на выдаче массив из даты и времени в порядке от года к секундам
        //принимает два числа в порядке от года к секундам
        public static int[] Summary(int year_lhs, int month_lhs, int num_lhs, int hour_lhs, int min_lhs, int sec_lhs,int year_rhs,int month_rhs, int num_rhs, int hour_rhs, int min_rhs, int sec_rhs)
        {
            int[] time = new int[6];
            List<int> time1 = new List<int>();
            List<int> time2 = new List<int>(){year_rhs, month_rhs, num_rhs, hour_rhs, min_rhs, sec_rhs
            };
            time1 = Conversion(year_lhs, month_lhs, num_lhs, hour_lhs, min_lhs, sec_lhs);
            int[] array_1 = new int[]
            { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            time[5] = time1[5] + time2[5];
            time[4] = time1[4] + time2[4];
            if (time[5] / 60 >= 1) { time[5] -= 60; time[4]++; }
            ;
            time[3] = time1[3] + time2[3];
            if (time[4] / 60 >= 1) { time[4] -= 60; time[3]++; }

            time[2] = time1[2] + time2[2];
            if (time[3] / 24 >= 1) { time[3] -= 24; time[2]++; }

            int k = time1[1] - 1;
            time[1] = time1[1];
            while (time[2] > array_1[k % 12])
            {
                if (time1[0] % 4 == 0 && k == 2 % 12)
                {
                    time[2] -= 29;

                }
                else { time[2] -= array_1[k % 12]; }
                k++;
                time[1]++;
            }
            time[1] += time2[1];
            time[0] = time1[0];
            while (time[1] > 12)
            {
                time[1] -= 12; time[0]++;
            }
            
            time[0] +=  time2[0]; 
            return time;
        }
        // выдача записи после прибавление к дате количество дней и времени тк там просто дата
        public static string Show(int[] ans)
        {
            string str = null;
            int k = 0;

            while (k < 2)
            {
                str += ans[k].ToString();
                str += "/";
                k++;
            }
            str += ans[k].ToString();
            str += " ";
            k++;
            while (k < 5)
            {
                str += ans[k].ToString();
                str += ":";
                k++;
            }
            str += ans[k].ToString();
            return str;
        }
        // выдача записи после разницы в датах и  времени тк там идет число количество дней и время
        public static string Showdays(int[] ans)
        {
            string str = null;

            int k = 1;

            str += ans[0].ToString(); str += " дней ";

            while (k < 3)
            {
                str += ans[k].ToString();
                str += ":";
                k++;
            }
            str += ans[k].ToString();
            return str;
        }

        //проверка правильности ввода
        public static bool IsCorrect(string num)
        {
            if(num=="")
                return false;
            Regex incorrect_nums = new Regex(@"[A-Za-zА-Яа-я!@#$%^&*()_+?/]");
            foreach (char j in num)
            {
                if (Regex.IsMatch(("" + j).ToString(), incorrect_nums.ToString()))
                    return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsCorrect(textBox1.Text) && IsCorrect(textBox2.Text) && IsCorrect(textBox3.Text) && IsCorrect(textBox4.Text) && IsCorrect(textBox5.Text) && IsCorrect(textBox6.Text) &&

              IsCorrect(textBox8.Text) && IsCorrect(textBox9.Text) && IsCorrect(textBox10.Text) && IsCorrect(textBox11.Text) && IsCorrect(textBox12.Text) && IsCorrect(textBox13.Text))
            {
                switch (comboBox1.Text)
                {
                    case "Прибавить":
                        int[] temp = Summary(int.Parse(textBox9.Text), int.Parse(textBox8.Text),
                        int.Parse(textBox13.Text), int.Parse(textBox12.Text), int.Parse(textBox11.Text),
                        int.Parse(textBox10.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text),
                        int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                        textBox7.Text = Show(temp);
                        break;
                    case "Вычесть":
                        
                        int[] tmp = Differ(int.Parse(textBox9.Text), int.Parse(textBox8.Text),
                        int.Parse(textBox13.Text), int.Parse(textBox12.Text), int.Parse(textBox11.Text),
                        int.Parse(textBox10.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text),
                        int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                        foreach (var item in tmp)
                        {
                            if (item < 0)
                            {
                                MessageBox.Show("Введите большую дату первой!");
                                tmp = new int[4];
                                break;
                            }
                        }
                        textBox7.Text = Showdays(tmp);
                        break;
                    default:
                        MessageBox.Show("Выберите операцию!");
                        break;

                }
            }
            else MessageBox.Show("Введены некорректные данные!");
        }

        
    }
}
