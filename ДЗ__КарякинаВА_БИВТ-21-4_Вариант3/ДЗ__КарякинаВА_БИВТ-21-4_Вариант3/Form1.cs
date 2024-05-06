using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace ДЗ__КарякинаВА_БИВТ_21_4_Вариант3
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
        public class Complex
        {
            public double Imaginary { get; private set; }
            public double Real { get; private set; }
            public Complex(double Imaginary, double Real)
            {
                this.Imaginary = Imaginary;
                this.Real = Real;
            }
            public Complex()
            { }
            public Complex Sum(Complex a)
            {
                var complex = new Complex();
                complex.Imaginary = a.Imaginary + Imaginary;
                complex.Real = a.Real + Real;
                return complex;
            }
            public Complex Minus(Complex a)
            {
                var complex = new Complex();
                complex.Imaginary = a.Imaginary + Imaginary;
                complex.Real = a.Real - Real;
                return complex;
            }

        }
        public static void Calculate()
       {
        Complex c1 = new Complex(1, 1);
        Complex c2 = new Complex(1, 2);
        
        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Complex result = Complex.c1.Sum(c2);
        }
    }
}
