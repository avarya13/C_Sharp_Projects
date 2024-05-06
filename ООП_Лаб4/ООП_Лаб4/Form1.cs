using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_Лаб4
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
        public int step = 0;
        int x1,x2,y1,y2,_x1,_x2,_y1,_y2;
        public int[,] arr = new int[3, 3];
        int a,i,j;
        bool p = false;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int k = 100; k <= 400; k += 100)
            {
                g.DrawLine(new Pen(Color.Black, 3.0f), k, 100, k, 400);
                g.DrawLine(new Pen(Color.Black, 3.0f), 100, k, 400, k);
                
            }
            
                
                if (arr[0, 0] == 1)

                {
                    g.DrawLine(new Pen(Color.Red, 3.0f), x1, y1, x2, y2);
                    g.DrawLine(new Pen(Color.Red, 3.0f), _x2, _y1, _x1, _y2);
                }
                else if (arr[0, 0] == 2)

                {
                    g.DrawEllipse(new Pen(Color.Green, 3.0f), x2, y2, 100, 100);
                    Invalidate();
                    //p = false;
                }
            

            /* if (arr[0, 0] == 1 && arr[0, 0] != 0)

             {
                 g.DrawLine(new Pen(Color.Red, 3.0f), x1, y1, x2, y2);
                 g.DrawLine(new Pen(Color.Red, 3.0f), _x2, _y1, _x1, _y2);
             }
             else if (arr[0, 0] == 2) g.DrawEllipse(new Pen(Color.Green, 3.0f), x2, y2, 100, 100);

             else if (arr[0, 0] == 0) return;*/


            // if(step!=0)
            //{

            /*   switch (a)
               {

                   case 1:
                       {
                           g.DrawLine(new Pen(Color.Red, 3.0f), x1, y1, x2, y2);
                           g.DrawLine(new Pen(Color.Red, 3.0f), _x2, _y1, _x1, _y2);
                           break;
                       }
                   case 2:

                       g.DrawEllipse(new Pen(Color.Green, 3.0f), x2, y2, 100, 100);

                       break;
               }
               step++;*/


            //break;
            // }

            //g.DrawLine(new Pen(Color.Red, 3.0f), 200, 200, 100, 100);

            /* if (arr[0, 0] == 1 && ang == 1)
             {
                 g.DrawLine(new Pen(Color.Red, 3.0f), 200, 200, 100, 100);
                 g.DrawLine(new Pen(Color.Red, 3.0f), 100, 200, 200, 100);
             }
             else if (arr[0, 0] == 2 && ang == 1)
             {
                 g.DrawEllipse(new Pen(Color.Green, 3.0f), 100, 100, 80, 80);
             }*/


        }


        

            private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // var g = CreateGraphics();
            //for (int i = 0; i < 3; i++)
            //{
            // for (int j = 0; j < 3; j++)
            //{
            //p = true;
            if ((e.X > 100) && (e.X < 200) && (e.Y > 100) && (e.Y < 200))
                    {
                        x1 = 200; y1 = 200; x2 = 100; y2 = 100;
                        _x1 = 100; _y1 = 200; _x2 = 200; _y2 = 100;
                if (step % 2 == 0)
                {
                    arr[0, 0] = 1;
                }
                else arr[0, 0] = 2;
                       // Game(arr[0, 0]);

                    }
                    else if ((e.X > 200) && (e.X < 300) && (e.Y > 100) && (e.Y < 200))
                    {

                        x1 = 200; y1 = 100; x2 = 300; y2 = 200;
                        _x1 = 200; _y1 = 200; _x2 = 300; _y2 = 100;
                        if (step % 2 == 1) { arr[0, 1] = 1;  }
                        else { arr[0, 1] = 2; }
                        a = arr[0, 1];
               
                //Game(arr[0, 1]);
                    }
            step++;
            this.Invalidate();
        }



     /*   public void Game(int a)
        {
            var g1 = CreateGraphics();
            var g2 = CreateGraphics();

            switch (a)
            {
                case 1:
                    {
                        g1.DrawLine(new Pen(Color.Red, 3.0f), x1, y1, x2, y2);
                        g1.DrawLine(new Pen(Color.Red, 3.0f), _x2, _y1, _x1, _y2);
                        break;
                    }
                case 2:

                    g1.DrawEllipse(new Pen(Color.Green, 3.0f), x2, y2, 100, 100);

                    break;


            }
            step++;
        }*/

    

                private void button1_Click(object sender, EventArgs e)
                {
                }

                private void button2_Click(object sender, EventArgs e)
                {
                    arr[0, 0] = 0;
                    Invalidate();

                }
            }
        }
   
