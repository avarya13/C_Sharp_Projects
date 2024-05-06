using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_лаб5_КарякинаВА_БИВТ_21_4
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            acc1 = new Account(1999.00);
            acc2 = new Account(999.00);
            textBox2.Text = "0,00";
            textBox4.Text = "0,00";
            for (int i = 0; i < c.Length; i++)
            {
                comboBox1.Items.Add(c[i].GetName());
                comboBox2.Items.Add(c[i].GetName());
                comboBox3.Items.Add(c[i].GetName());
                comboBox4.Items.Add(c[i].GetName());
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            

            ShowBalance();
        }
        private void ShowBalance() //задает начальный баланс и обновляет его при изменении
        {
            textBox1.Text = acc1.GetBalance();
            if(comboBox2.SelectedIndex!=-1)
                textBox3.Text = acc2.GetBalance();
        }
        
        public class Currency
        {
            private string name;
            private double rate;
            public Currency(string name, double rate)
            {
                this.name = name;
                this.rate = rate;
            }
            public string GetName() //возвращает название валюты
            {
                return name;
            }
            public double GetRate() //возвращает курс
            {
                return rate;
            }
        }
        private Currency[] c = //хранит наименования валют и курсы
            {
            new Currency("RUB",1.0),
            new Currency("ZAR",5.8),
            new Currency("CAD",68.5),
            };
       
        public class Account
        {
            private double balance;
            
            public Account (double balance)
            {
                this.balance = balance;
            }
            public string GetBalance() //возвращает баланс
            {
                return balance.ToString("N2");
            }
            
            public double Convert(Currency cur1, Currency p, double sum) //конвертирование
            {
                double a ;
                if (cur1.GetRate()<= p.GetRate())
                {
                    if (p.GetRate()*cur1.GetRate()==50)
                        a= sum / (p.GetRate()/ cur1.GetRate());
                    else
                        a =  sum/ p.GetRate();
                }
                else
                    if (p.GetRate() * cur1.GetRate() == 50)
                        a = sum * (cur1.GetRate() / p.GetRate());
                    else
                        a =  sum* p.GetRate();
                return a;
            }
            public double Convert(Currency cur, double sum) //конвертирование
            {
                return cur.GetRate() * sum;
            }
            public void Add( Currency cur2, double sum, Currency p) //перечисляет соответствующую сумму на счет
            {
                balance += Convert(cur2, p,sum);
            }
            public void Take(Currency cur1, Currency cur2, double value1, double value2, double sum,Currency p,int num) //снимает со счета
            {
                double a= Convert(cur1, p, sum);
                if (value1 >= a)
                {
                    Comission(cur1,cur2, value1, value2, p, num);
                    balance -= a;
                }
                else
                    MessageBox.Show("Недостаточно средств");
            }
          
            public void Comission(Currency cur1, Currency cur2, double value1, double value2, Currency p, int num) //комиссия
            {
                if (p.GetName() != cur1.GetName())
                {
                    MessageBox.Show($"Комиссия для счета {num } составляет {Convert(p, value1) * 0.01} {p.GetName()} ");
                    balance -= balance * 0.01;
                }
                if (p.GetName() != cur2.GetName() && num==1)
                {
                    MessageBox.Show($"Комиссия для счета {num +1} составляет {Convert(p, value2) * 0.01} {p.GetName()} ");
                    balance -= balance * 0.01;
                }
                else if(p.GetName() != cur2.GetName() && num == 2)
                {
                    MessageBox.Show($"Комиссия для счета {num-1 } составляет {Convert(p, value2) * 0.01} {p.GetName()} ");
                    balance -= balance * 0.01;
                }
            }
            public void Take(Currency cur, double value,double sum) //снимает сумму со счета
            {
                if (sum<=value)
                    balance -= Convert(cur, sum);
                else
                    MessageBox.Show("Недостаточно средств");
                
            }
        }

        private Account acc1; //хранит состояние счета 1
        private Account acc2; //хранит состояние счета 2
        int num; //номер счета
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            num = 1;
            if (textBox1.Text != "")
            {
                MessageBox.Show($"Комиссия составляет {double.Parse(textBox1.Text)*c[comboBox1.SelectedIndex].GetRate() * 0.01} {c[comboBox1.SelectedIndex].GetName() }");
                double a = double.Parse(textBox1.Text)*0.99;
                textBox1.Text = a.ToString();
               
            }
            ShowBalance();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                MessageBox.Show($"Комиссия составляет {double.Parse(textBox3.Text) * c[comboBox2.SelectedIndex].GetRate() * 0.01} {c[comboBox2.SelectedIndex].GetName() } ");

            }
            ShowBalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acc1.Take(c[comboBox1.SelectedIndex], c[comboBox2.SelectedIndex], double.Parse(textBox1.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text), c[comboBox3.SelectedIndex],num);
            acc2.Add(c[comboBox2.SelectedIndex], double.Parse(textBox4.Text), c[comboBox3.SelectedIndex]);
            ShowBalance();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            acc2.Take(c[comboBox2.SelectedIndex], c[comboBox1.SelectedIndex], double.Parse(textBox3.Text), double.Parse(textBox1.Text), double.Parse(textBox2.Text), c[comboBox4.SelectedIndex],num);
            acc1.Add( c[comboBox1.SelectedIndex], double.Parse(textBox2.Text), c[comboBox4.SelectedIndex]);
            ShowBalance();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowBalance();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowBalance();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            acc1.Take(c[comboBox1.SelectedIndex], double.Parse(textBox1.Text), double.Parse(textBox4.Text));
            ShowBalance();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            acc2.Take(c[comboBox2.SelectedIndex], double.Parse(textBox3.Text), double.Parse(textBox2.Text));
            ShowBalance();
        }
    }
}
