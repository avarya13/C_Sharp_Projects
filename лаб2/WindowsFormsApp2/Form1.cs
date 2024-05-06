using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
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

        int a, b, min, max,n, points1,points2;
        int sum1, sum2;
        int raund = 0;
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            a = random.Next(0, 100);
            b = random.Next(0, 100);
            n = random.Next(100, 500);

            textBox3.AppendText(n.ToString());
            if (a < b)
            {
                min = a;
                max = b;
            }
            else
            {
                min = b; max = a;
            }
            textBox1.AppendText(min.ToString());
            textBox2.AppendText(max.ToString());
            raund++;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            sum1 = sum2 = 0;
            textBox7.AppendText("ИГРОК 1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            Random random = new Random();
            int x = random.Next(min, max);
            textBox4.Text = (sum1 + x).ToString();
            sum1+= x;
            if (sum1 > n)
            {
                textBox7.Clear();
                textBox7.AppendText("ИГРОК 2");
                Game_Over(sum1, sum2);
               
            }
            else
            {
                textBox7.Clear();
                textBox7.AppendText("ИГРОК 2");
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int x = random.Next(min, max);
            textBox5.Text = (sum2 + x).ToString();
            sum2 += x;
            if (sum2 > n)
            {
                button4.Enabled = false;
                textBox7.Clear();
                textBox7.AppendText("ИГРОК 1");
                Game_Over(sum1, sum2);

            }
            else
            {
                textBox7.Clear();
                textBox7.AppendText("ИГРОК 1");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Game_Over(sum1, sum2);
            button2.Enabled = false;
            button4.Enabled = false;
        }

        public void Game_Over( int sum1, int sum2)
        {
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            
            a = b = min = max=0;  
            if (sum1 > sum2)
            {
                richTextBox1.AppendText(1 + "\n");
                richTextBox2.AppendText(0 + "\n");
                points1++;
            }
            else if (sum1 < sum2)
            {
                richTextBox2.AppendText(1 + "\n");
                richTextBox1.AppendText(0 + "\n");
                points2++;
            }
            else if (sum1 == sum2)
            {
                if (textBox7.Text == "ИГРОК 1")
                {
                    richTextBox1.AppendText(1 + "\n");
                    richTextBox2.AppendText(0 + "\n");
                    points1++;
                }
                else
                {
                    richTextBox2.AppendText(1 + "\n");
                    richTextBox1.AppendText(0 + "\n");
                    points2++;
                }
            }
            textBox7.Clear();
            if (raund < 2)
            {
                button1.Enabled = true;
                
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                if (points1 > points2)
                    textBox6.AppendText("ИГРОК 1");
                else if (points1 < points2)
                    textBox6.AppendText("ИГРОК 2");
                else
                    textBox6.AppendText("НИЧЬЯ");
            }
        }
    }
}
