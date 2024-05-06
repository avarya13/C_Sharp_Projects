using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeCalculator
{
    //выполнили студентки группы БПМ-21-3 Косицына Е.Н., Карякина В.А.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //проверка корректности ввода числа в данной СС
        public static bool IsCorrect(string num)
        {
            
            Regex incorrect_nums = new Regex(@"[A-Za-zА-Яа-я!@#$%^&*()_+?/]");
            foreach (char j in num)
            {
                if (Regex.IsMatch(("" + j).ToString(), incorrect_nums.ToString()))
                    return false;
            }
            return true;
        }
        // находим разницу между индексами и определяем домножать или делить
        public static double Conversion(double lhs, string lhs_name, string rhs_name)
        {
            int ind_1 = FindTimes(lhs_name);
            int ind_2 = FindTimes(rhs_name);
            int ind = ind_2 - ind_1;
            if (ind > 0)
            {
                double ing;
                int ost;
                while (ind != 0)
                {
                    ing = (double)lhs / 60;
                    ost = (int)lhs % 60;
                    lhs = ing + (double)(ost / 60); //не выдает с запятой
                    ind--;
                }
               // lhs = Math.Round(lhs, 3);
            }
            else if (ind < 0)
            {
                while (ind != 0)
                {
                    lhs = lhs * 60;
                    ind++;
                }
            }
            return lhs;
        }
        // находим индексы в массиве, чтобы определить домножать на 60 или делить
        public static int FindTimes(string lhs_name)
        {
            List<string> names = new List<string>();
            string[] name_time = new string[] { "сек", "мин", "часы" };
            for (int i = 0; i < 3; i++)
            {
                if (name_time[i] == lhs_name)
                {
                    return i;
                }
            }
            return -100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""  && comboBox1.Text != "")
            {
                double h_temp = 0;
                double m_temp = 0;
                
                if (IsCorrect(textBox1.Text))
                {
                    switch (comboBox1.Text)
                    {
                        case "часы":
                            
                            textBox2.Text = Math.Truncate(double.Parse(textBox1.Text)).ToString();
                            m_temp = (Conversion(Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox2.Text), "мин", "сек"));
                            textBox3.Text = (Math.Truncate(m_temp).ToString());
                            textBox4.Text = (Conversion(m_temp - Convert.ToDouble(textBox3.Text), "мин", "сек")).ToString();
                            break;
                        case "минуты":
                            h_temp = Conversion(Convert.ToDouble(textBox1.Text), "мин", "часы");
                            textBox2.Text = (Math.Truncate(h_temp).ToString());
                            m_temp = (Conversion(h_temp - Convert.ToDouble(textBox2.Text), "мин", "сек"));
                            textBox3.Text = (Math.Round(m_temp).ToString());
                            textBox4.Text = Math.Round(Conversion(m_temp - Convert.ToDouble(textBox3.Text), "мин", "сек")).ToString();
                            break;
                        case "секунды":
                            h_temp = Conversion(Convert.ToDouble(textBox1.Text), "сек", "часы");
                            textBox2.Text = (Math.Truncate(h_temp).ToString());
                            m_temp = (Conversion(h_temp - Convert.ToDouble(textBox2.Text), "мин", "сек"));
                            textBox3.Text = (Math.Round(m_temp).ToString());
                            textBox4.Text = Math.Round(Conversion(m_temp - Convert.ToDouble(textBox3.Text), "мин", "сек")).ToString();
                            break;

                    }
                    
                }
                else MessageBox.Show("Введены некорректные данные!");
            }
            else MessageBox.Show("Введите данные!");

        }


        
    }
}
