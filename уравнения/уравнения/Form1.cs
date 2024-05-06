using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace уравнения
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
        class Newton
        {
             double a, b, x, m, eps, en;

             int i;

            public void Main()
            {
                
                eps = double.Parse(Console.ReadLine());
                
                for (m = -79.5; m <= 79.5; m++)
                {
                    a = -2;
                    b = 1;
                    en = Math.Abs(a - b);
                    x = b;
                    i = 1;
                    Console.WriteLine("m = {0}", m);
                    while (Math.Abs(en) > eps)
                    {
                        x = x - f(x, m) / f1(x);
                        Console.WriteLine("     {0}        {1}", i++, x);
                        en = Math.Abs(x - b);
                        b = x;
                    }
                    
                }

                textBox1.AppendText (x.ToString());
            }

            private double f(double x, double m)
            {
                return Math.Tan(x) - (m / x);
            }

            private double f1(double x)
            {
                return 1 / (Math.Sqrt(Math.Cos(x)) + 1 / Math.Sqrt(x));
            }
        }

        public  double func(double x)
        {
            double f = -5.0 / (Math.Pow(x, 2) + 2);
            return f;
        }

        class Del
        {
            static float f(float x)
            {
                return x - 2;
            }

            static float n(float a, float b)
            {
                float x = (a + b) / 2;
                while (Math.Abs(f(x)) > 0.001)
                {
                    if (f(x) * f(a) > 0)
                        a = x;
                    else
                        b = x;
                    x = (a + b) / 2;
                }
                return x;
            }

            static void Main()
            {
                Console.WriteLine("Otvet=" + n(0, 100));
                Console.ReadLine();
            }
        }

        class Iter
        {
            const double eps = 1e-4;
            double x0 = 0, x1 = 0;
            int iter = 0;
            bool error = false;
  public void Operation()
            { 
            do
            {
                x1 = func(x0);
            iter++;
                if (Math.Abs(x1 - x0) >= eps && iter == 1000)
                {
                    error = true;
                    break;
                }
        x0 = x1;
            } while (Math.Abs(x0 - func(x0)) > eps);
                if (error)
                {
                    Console.WriteLine("Не найдено");
                }
                else
                {
                    Console.WriteLine("Ответ: X = {0} ", Math.Round(x1, 3));
                    Console.WriteLine("Итераций пройдено: {0}", iter);
                }
}

        }

        
    }
    }

