using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CopyNumber(textBox2);
        }


    }
    
    public static class FormsExtensions

    {
       
        static char[] tmp = { '8', '(', '9', '*', '*', ')', '*', '*', '*', '-', '*', '*', '-', '*', '*' };
        public static void CopyNumber(this TextBox textBox1, TextBox textBox2 )

        {

            PhoneNumber num;

            int k = 4;
            bool input = true;
            
            tmp[3] = textBox1.Text.First();
            textBox1.TextChanged += (object sender, EventArgs e) =>
            {
               
                if (input==true)
                {
                    num = textBox1.Text.Last();

                   

                    for (int i = k; i < tmp.Length; i++)
                    {
                      
                        if (tmp[i] == '*')
                        {
                            if ((i > 2 && i < 5) || (i > 5 && i < 10) || (i > 9 && i < 12) || i > 12)
                            {
                                tmp[i] = num;
                                k = i + 1;
                                input = false;
                                break;

                            }
                           
                        }

                        else k++;
                    }
                }
                textBox2.Text = new string(tmp);
                
            };
            
           
        }

    }
    public class PhoneNumber

    {
        
        public char Num { get; set; }
        public PhoneNumber()

        {
            
        }
        public PhoneNumber(char number)
        {
            Num = number;
        }

       

        public static implicit operator PhoneNumber(char value)

        {

            return new PhoneNumber(value);

        }

        

        public static implicit operator char(PhoneNumber value)
        {
            return value.Num;
        }

        
    }
}
