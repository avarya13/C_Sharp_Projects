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
using ConsoleApp8;

// Выполнили студентки группы БПМ-21-3 Косицына Е.Н., Карякина В.А.

namespace CalculatorOfNumSystems
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text!="" && comboBox1.Text!="" && comboBox2.Text != "")
            {
                if ( Program.IsNumCorrect(textBox1.Text, comboBox1.Text)==true)
                {
                    if (comboBox2.Text != "10" && textBox1.Text != "10")
                    {
                        string tmp = Program.ToDecimal(textBox1.Text, Convert.ToInt32(comboBox1.Text));
                        textBox2.Text = Program.FromDecimal(tmp, Convert.ToInt32(comboBox2.Text));
                    }
                    else if (comboBox1.Text == "10")
                        textBox2.Text = Program.FromDecimal(textBox1.Text, Convert.ToInt32(comboBox2.Text));
                    else if (comboBox1.Text == comboBox2.Text)
                        textBox2.Text = textBox1.Text;
                    else textBox2.Text = Program.ToDecimal(textBox1.Text, Convert.ToInt32(comboBox1.Text));
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Некорректный ввод!");
                }
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (comboBox5.Text != "" && comboBox6.Text != "")
                {
                    if (Program.IsNumCorrect(textBox4.Text, comboBox3.Text) && Program.IsNumCorrect(textBox5.Text, comboBox4.Text))
                    {
                        switch (comboBox5.Text)
                        {
                            case "+":
                                textBox3.Text = Program.Summary(textBox4.Text, Convert.ToInt32(comboBox3.Text), textBox5.Text, Convert.ToInt32(comboBox4.Text), Convert.ToInt32(comboBox6.Text));
                                break;
                            case "-":
                                textBox3.Text = Program.Subtraction(textBox4.Text, Convert.ToInt32(comboBox3.Text), textBox5.Text, Convert.ToInt32(comboBox4.Text), Convert.ToInt32(comboBox6.Text));
                                break;
                            case "*":
                                textBox3.Text = Program.Multiplication(textBox4.Text, Convert.ToInt32(comboBox3.Text), textBox5.Text, Convert.ToInt32(comboBox4.Text), Convert.ToInt32(comboBox6.Text));
                                break;
                            case "/":
                                textBox3.Text = Program.Division(textBox4.Text, Convert.ToInt32(comboBox3.Text), textBox5.Text, Convert.ToInt32(comboBox4.Text), Convert.ToInt32(comboBox6.Text));
                                break;
                            default:
                                string dgr = Program.ToDecimal(textBox5.Text, Convert.ToInt32(comboBox4.Text));
                                comboBox5.Text = "10";
                                comboBox5.SelectedItem = "10";
                                
                                textBox3.Text = Program.Exponentiate(textBox4.Text, Convert.ToInt32(comboBox3.Text), Convert.ToInt32(dgr), Convert.ToInt32(comboBox6.Text));
                                break;
                        }
                    }
                    else if (!Program.IsNumCorrect(textBox4.Text, comboBox3.Text) || !Program.IsNumCorrect(textBox5.Text, comboBox4.Text))
                    {
                        textBox4.Text = "";
                        textBox5.Text = "";
                        MessageBox.Show("Некорректный ввод!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }
            
        }
    }



   
}
