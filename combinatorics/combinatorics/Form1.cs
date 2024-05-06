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

namespace combinatorics
{
    //Выполнили студентки БПМ-21-3 Косицына Е.Н., Карякина В.А.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //расчет факториала
        public static int Factorial(int n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        //сочетания без поторений из n по m
        public static int Combinations(int n, int m) 
        {
            int c = Factorial(m);
            int tmp = Placements(n, m);
            return tmp/c;

        }

        //сочетания с поторениями из n по m
        public static int CombWithRepetitions(int n, int m)
        {
            return Factorial(n + m - 1) / (Factorial(m) * Factorial(n - 1));
        }

        //размещения без повторений из n по m
        public static int Placements(int n, int m)
        {
            int c = Factorial(n);
            int z = Factorial(n - m);
            return c / z;
        }

        //размещения с повторениями из n по m
        public static int PlaceWithRepetitions(int n, int m)
        {
            return Convert.ToInt32(Math.Pow(n, m));
        }

        //перестановки  без повторений из n по m
        public static int Permutations(int n)
        {

            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        //перестановки  с повторениями из n по m
        public static int PermWithRepetitions(int n, int[] m)
        {
            int temp = 1;
            for (int i = 0; i < m.Length; i++)
            {
                temp *= Factorial(m[i]);
            }

            return Factorial(n) / temp;
        }

        public static bool IsCorrect(string num)
        {
            if (num == "")
                return false;
            Regex incorrect_nums = new Regex(@"[A-Za-zА-Яа-я.,'!@#$%^&*()=_+?/]");
            foreach (char j in num)
            {
                if (Regex.IsMatch(("" + j).ToString(), incorrect_nums.ToString()))
                    return false;
            }
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "В элементов из А")
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
            else 
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
            } 
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (IsCorrect(textBox1.Text) && IsCorrect(textBox2.Text))
            {
                try
                {
                    switch (comboBox1.Text)
                    {
                        //комбинаторное произведение

                        case "Выбор А и В элементов":
                            textBox3.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();
                            break;

                        //комбинаторная сумма

                        case "Выбор А или В элементов":
                            textBox3.Text = (int.Parse(textBox1.Text) + int.Parse(textBox2.Text)).ToString();
                            break;

                        case "В элементов из А":
                            if (checkBox1.Checked)
                            {
                                if (textBox2.Text.Contains(" ") && !checkBox2.Checked)
                                {
                                    string[] temp = textBox2.Text.Split(' ');
                                    int[] temp_int = new int[temp.Length];
                                    for (int i = 0; i < temp.Length; i++)
                                        temp_int[i] = int.Parse(temp[i]);
                                    textBox3.Text = PermWithRepetitions(int.Parse(textBox1.Text), temp_int).ToString();
                                }
                                else if (checkBox2.Checked && int.Parse(textBox1.Text)<= int.Parse(textBox2.Text))
                                {
                                    textBox3.Text = CombWithRepetitions(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
                                }
                                else if(!textBox2.Text.Contains(" ") && checkBox2.Checked || int.Parse(textBox1.Text) < int.Parse(textBox2.Text))
                                    MessageBox.Show("Введите корректные данные!");
                                else 
                                    
                                    textBox3.Text = PlaceWithRepetitions(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
                                
                            }
                            else
                            {
                                if (textBox1.Text == textBox2.Text && !checkBox2.Checked )
                                    textBox3.Text = Permutations(int.Parse(textBox1.Text)).ToString();
                                else if (checkBox2.Checked && int.Parse(textBox1.Text) >= int.Parse(textBox2.Text) && !textBox2.Text.Contains(" "))
                                    textBox3.Text = Combinations(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
                                else if( textBox2.Text.Contains(" ") && !checkBox2.Checked || (int.Parse(textBox1.Text) <= int.Parse(textBox2.Text)))
                                    MessageBox.Show("Введите корректные данные!");
                               
                                else
                                    textBox3.Text = Placements(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
                            }
                            break;
                    }

                }
                catch (StackOverflowException)
                {
                    MessageBox.Show("Введите корректные данные!");
                }
            }
            else MessageBox.Show("Введите корректные данные!");
        }

    }
}
