using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox3.AppendText("Сумма массивов:" + "\n");

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            int[] c1 = new int[6];
            string s1 = richTextBox1.Text;
            string s2 = richTextBox2.Text;
            string[] st1 = s1.Split('\n');
            string[] st2 = s2.Split('\n');
            
            for (int i = 0; i < 6; i++)
            {

                c1[i] = int.Parse(st1[i])+ int.Parse(st2[i]);


                if (i == 0)
                    richTextBox3.AppendText(c1[i].ToString() + '\n');
                else
                    richTextBox3.AppendText(c1[i].ToString()+ "\n");

                
            }
        }

       
    }
}
