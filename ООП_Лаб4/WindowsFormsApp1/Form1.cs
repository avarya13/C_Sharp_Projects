using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        int cell = 50;
        private static int xs = 0; 
        private static int os = 0;
        private static int step = 0; 
        private static int[,] arr = new int[10, 10]; 
        private static bool win = false; 
        private bool only_click = false;
        private bool increase_step = true;
        int i, j;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (win == false  ) 
            {

                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        
                        
                        if ( (e.X >= i * cell + cell) && (e.X <= cell + i * cell + cell) && (e.Y >= j * cell + cell) &&
                            (e.Y <= cell + j * cell + cell)
                        ) 

                        {
                            if (arr[i, j] != 0)
                            {
                                step = step + 1;
                                increase_step = false;
                            }
                            else
                                increase_step = true;

                            if ((step % 2 == 0) && (arr[i, j] == 0)) 
                            {

                                arr[i, j] = 1; draw_symbol = true;
                            }

                            else if ((step % 2 != 0) && (arr[i, j] == 0))
                            {
                                arr[i, j] = 2;  draw_symbol = true;
                            }
                           
                            
                        }
                    }
                }
               
                    Invalidate();
                    step++;
                if (increase_step == false)
                    increase_step = true;

            }
            /*else if (only_click == true)
            {
                draw_symbol = true;
                only_click = false;
            }*/
        }
        private bool draw_symbol = false;
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            
                Graphics g = e.Graphics;
                for (int k = 50; k <= 550; k += 50)
                {
                    g.DrawLine(new Pen(Color.Black, 3.0f), k, 50, k, 550);
                    g.DrawLine(new Pen(Color.Black, 3.0f), 50, k, 550, k);
                }
                if(draw_symbol==true && only_click==false)
            { 
            for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (arr[i, j] == 1)
                        {
                            g.DrawLine(new Pen(Color.Red, 3.0f), 50 + cell * i, 50 + cell * j, 50 + cell * (i + 1),
                                           50 + cell * (j + 1));
                            g.DrawLine(new Pen(Color.Red, 3.0f), 50 + cell * i, 50 + cell * (j + 1),
                                           50 + cell * (i + 1), 50 + cell * j);

                            Horizontal();
                            Vertical();
                            Main_Diagonal();
                            Diagonal();
                            No_Winner();
                            if (win == true)
                            {
                                g.DrawLine(new Pen(Color.Yellow, 3.0f), x1, y1, x2, y2);

                            }
                        }
                        else if (arr[i, j] == 2)
                        {
                            g.DrawEllipse(new Pen(Color.Green, 3.0f), 50 + cell * i, 50 + cell * j, cell, cell);
                            
                            Horizontal();
                            Vertical();
                            Main_Diagonal();
                            Diagonal();
                            No_Winner();
                            if (win == true)
                            {
                                g.DrawLine(new Pen(Color.Yellow, 3.0f), x1, y1, x2, y2);
                                
                            }

                        }
                    }
                    
                }
            }
            draw_symbol = false;

        }
        private int horiz = 0;
        private int vert = 0;
        private int main_diag = 0;
        private int diag = 0;


        private void button2_Click(object sender, EventArgs e)
        {
            xs = 0;
            os = 0;
            label1.Text = xs.ToString();
            label2.Text = os.ToString();

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    arr[i, j] = 0;
                }
            }
           // new_game = true;
            step = 0;win = false;
            Invalidate();
        }
        private int x1, y1, x2, y2;

        public void No_Winner()
        {
            if (step == 100)
            {
                win = true;
                Winner();
                MessageBox.Show("Ничья");
                step = 0;
            }
        }

        public void Vertical()
        {
            if (win == false )
            {

                for (int i = 0; i <= 9; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        vert = arr[i, j] * arr[i, j + 1] * arr[i, j + 2] * arr[i, j + 3] * arr[i, j + 4];
                        switch (vert)
                        {
                            case 1:
                                x1 = 75 + cell * i;
                                x2 = 75 + cell * i;
                                y1 = 50 + cell * j;
                                y2 = 100 + cell * (j + 4);
                                xs += 1; win = true;
                                MessageBox.Show("Результат раунда:" + " " + xs.ToString() + ":" + os.ToString()+ ". Победитель текущего раунда: игрок 1.");
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                            case 32:
                                x1 = 75 + cell * i;
                                x2 = 75 + cell * i;
                                y1 = 50 + cell * j;
                                y2 = 100 + cell * (j + 4);
                                os += 1; win = true;
                                MessageBox.Show("Результат раунда:" + " " + xs.ToString() + ":" + os.ToString() + ". Победитель текущего раунда: игрок 2.");
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                        }

                    }
                }
            }
            }

        public void Horizontal()
        {
            if (win == false)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        horiz = arr[i, j] * arr[i + 1, j] * arr[i + 2, j] * arr[i + 3, j] * arr[i + 4, j];
                        switch (horiz)
                        {
                            case 1:
                                x1 = 50 + cell * i;
                                x2 = 50 + cell * (i + 5);
                                y1 = 75 + cell * j;
                                y2 = 75 + cell * j;
                                win = true;
                                xs += 1;
                                MessageBox.Show("Результат раунда: 1 : 0. Победитель текущего раунда: игрок 1. Общий счет за все раунды:" + " " + xs.ToString() + ":" + os.ToString());
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                            case 32:
                                x1 = 50 + cell * i;
                                x2 = 50 + cell * (i + 5);
                                y1 = 75 + cell * j;
                                y2 = 75 + cell * j;
                                win = true;
                                os += 1;
                                MessageBox.Show("Результат раунда: 0 : 1. Победитель текущего раунда: игрок 2. Общий счет за все раунды:" + " " + xs.ToString() + ":" + os.ToString());
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                        }

                    }
                }
            }
           
            }
            
        
        
        public void Main_Diagonal()
        {
            if (win == false)
            {
                for (i = 5; i >= 0; i--)
                {
                    for (j = 0; j < 6; j++)
                    {
                        main_diag = arr[i, j] * arr[i + 1, j + 1] * arr[i + 2, j + 2] * arr[i + 3, j + 3] * arr[i + 4, j + 4];
                        switch (main_diag)
                        {
                            case 1:
                                x1 = 50 + cell * i;
                                x2 = 50 + cell * (i + 5);
                                y1 = cell * j + 50;
                                y2 = 100 + cell * (j + 4);
                                xs += 1; win = true; MessageBox.Show("Результат раунда: 1 : 0. Победитель текущего раунда: игрок 1. Общий счет за все раунды:" + " " + xs.ToString() + ":" + os.ToString()); MessageBox.Show("Результат раунда:" + " " + xs.ToString() + ":" + os.ToString() + ".Победил игрок 1.");
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                            case 32:
                                x1 = 50 + cell * i;
                                x2 = 50 + cell * (i + 5);
                                y1 = cell * j + 50;
                                y2 = 100 + cell * (j + 4);
                                os += 1; win = true;
                                MessageBox.Show("Результат раунда: 0 : 1. Победитель текущего раунда: игрок 2. Общий счет за все раунды:" + " " + xs.ToString() + ":" + os.ToString());
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                        }
                        
                    }

                }
            }

        }

        

        public void Diagonal()
        {
            if (win == false)
            {
                for (int i = 4; i < 10; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        diag = arr[i, j] * arr[i - 1, j + 1] * arr[i - 2, j + 2] * arr[i - 3, j + 3] * arr[i - 4, j + 4];
                        switch (diag)
                        {
                            case 1:
                                x1 = 100 + cell * i;
                                x2 = cell * (i + 5) - 400;
                                y1 = cell * j + 50;
                                y2 = 100 + cell * (j + 4);
                                xs += 1; win = true;
                                MessageBox.Show("Результат раунда: 1 : 0. Победитель текущего раунда: игрок 1. Общий счет за все раунды:" + " " + xs.ToString() + ":" + os.ToString());
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                            case 32:
                                x1 = 100 + cell * i;
                                x2 = cell * (i + 5) - 400;
                                y1 = cell * j + 50;
                                y2 = 100 + cell * (j + 4);
                                os += 1; win = true;
                                MessageBox.Show("Результат раунда: 0 : 1. Победитель текущего раунда: игрок 2. Общий счет за все раунды:" + " "+ xs.ToString() + ":" + os.ToString());
                                label1.Text = xs.ToString();
                                label2.Text = os.ToString();
                                Winner();
                                break;
                        }
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"1.txt");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sw.WriteLine(arr[i, j] + " ");
                }
            }
            sw.Close();
            //Invalidate();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"1.txt");
            string line = sr.ReadToEnd();
            string[] a = new string[] {"\n" };
            string[] result = line.Split(a, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[i, j] = Convert.ToInt32(result[i * 10 + j]);
                }
            }
            sr.Close();
            this.Invalidate();
           // only_click = true;
        }


        public void Winner()
        {
            if (xs>os)
            {
                //MessageBox.Show("Результат раунда:" + " " + xs.ToString() + ":" + os.ToString() + ".Победил игрок 1.");
                textBox1.Text = "1 игрок (Х)";
            }
            else if (xs < os)
            {
                textBox1.Text = "2 игрок (О)";
            }
            else if (xs == os)
            {
                textBox1.Text = "Ничья";
            }
        }

        
    }
}