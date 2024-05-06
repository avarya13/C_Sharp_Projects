using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
                Graphics g = e.Graphics;
                 int xc = this.Width / 2;
                 int yc = this.Height / 2;
                 g.TranslateTransform(xc, yc);
                 g.DrawEllipse(new Pen(Color.Red, 8.0f), 0, 0, 1, 1);
                 float x, y;

                 g.DrawLine(new Pen(Color.Brown, 0.5f), -200, 0, 200, 0);
                 g.DrawLine(new Pen(Color.Brown, 0.5f), 0, -200, 0, 200);
                 for (x = 0.5f; x <= 1; x=x+0.025f)
                 {
                     y = (float)(Math.Pow(x - 1, 1 / 2) -1/ x);
                    
                     g.DrawEllipse(new Pen(Color.Blue, 1.5f), (float)(x*150 ), (float)(-y*20), 1, 1); 
            }


        }

    }
}
