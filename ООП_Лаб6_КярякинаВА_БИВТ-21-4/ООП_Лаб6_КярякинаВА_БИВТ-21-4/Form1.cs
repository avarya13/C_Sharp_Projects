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

namespace ООП_Лаб6_КарякинаВА_БИВТ_21_4
{
    public partial class Form1 : Form
    {
        public int s_square; //площадь квадрата
        public int s_circle; //площадь круга
        public int s_triag; //площадь треугольника
        public int square_count = 3; //начальное количество квадратов
        public int circle_count = 3;
        public int triag_count = 2;

        public Form1()
        {
            InitializeComponent();
            
            shapes=new List<Shape> //список фигур
            {
                new Square(this,"квадрат",70,Color.Red,Color.Black),
                new Circle(this,"круг",100,Color.Blue,Color.Black),
                new Circle(this,"круг",92,Color.Blue,Color.Black),
                new Triangle(this, "треугольник",105, Color.Green, Color.Black)
            };
            label1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<Shape> shapes;
       
    public class Shape
        {
            protected Point CenterPoint; //координаты центра
            protected int size; 
            protected string name; 
            protected float lineThickness; //толщина границы
            private Color fillColor; 
            private Color lineColor;
            public Color FillColor //цвет фигуры
            {
                get
                {
                    return fillColor;
                }
            }
            public Color LineColor //цвет границы
            {
                get => lineColor;
            }
            public string Name //вид фигуры
            {
                get=> name;
                
            }
            public int Size //размер
            {
                get => size;

            }
            public Shape(string name, int size,Color fillColor, Color lineColor) //конструктор базового класса
            {
                this.name = name;
                this.size = size;
                this.fillColor = fillColor;
                this.lineColor = lineColor;
            }
            protected void ChangeColor(Color fillColor, Color lineColor)
            {
                this.fillColor = fillColor;
                this.lineColor = lineColor;
            }
            public virtual void Draw(bool fillRandom = false) //построение со случайным цветом и толщиной (в случае нажатия на фигуру)
            {

            }
            public virtual void Draw() //построение фигуры
            {

            }
            public virtual int CalcArea(int s) //расчет площади
            {
                return s;
            }
            
            public virtual bool CheckPoint(Point point) //проверка принадлежности точки фигуре
            {
                return true;
            }
            public virtual void ChooseShape(string s) //выводит информацию о фигуре
            {

            }
        }

        public class Square: Shape
        {
            private Form form;
            private Graphics graphics;
            private Random random;
            public Square(Form form,string name, int size, Color fillColor, Color lineColor):base (name,size,fillColor,lineColor)
            {
                this.form = form;
                this.name = name;
                this.size = size; //сторона квадрата
                random = new Random(size);
                CenterPoint = new Point()
                {
                    X = random.Next(0 + size / 20, form.ClientSize.Width - size / 20),
                    Y = random.Next(0 + size / 20, form.ClientSize.Height - size / 20)

                };
                lineThickness = 1;
                graphics = form.CreateGraphics();
            }
            public override void Draw(bool fillRandom=false)
            {
                if (fillRandom) //изменение цвета и толщины фигуры (в случае нажатия на квадрат)
                {
                    int x = CenterPoint.X - size/2;
                    int y = CenterPoint.Y - size / 2;
                    ChangeColor(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
                    
                    lineThickness = random.Next(2, 11);
                    graphics.FillRectangle(new SolidBrush(FillColor), x + (int)lineThickness / 2, y + (int)lineThickness / 2, size, size);
                    graphics.DrawRectangle(new Pen(LineColor, lineThickness), x, y, size, size); 
                }
                else
                {
                    Draw();
                }
            }
            public override void Draw() //построение квадрата
            {
                int x = CenterPoint.X - size / 2;
                int y = CenterPoint.Y - size / 2;
                lineThickness = random.Next(2, 11);
                graphics.FillRectangle(new SolidBrush(FillColor), x + (int)lineThickness / 2, y + (int)lineThickness / 2, size, size);
                graphics.DrawRectangle(new Pen(LineColor, lineThickness), x, y, size, size);
            }
            
            public override int CalcArea(int s) //расчет площади
            {
                s= size * size;
                return s;
            }
            public override bool CheckPoint(Point point) //проверка принадлежности точки квадрату
            {
                if ((point.X >= CenterPoint.X - size / 2) && (point.X <= CenterPoint.X + size / 2))
                {
                    if ((point.Y >= CenterPoint.Y - size / 2) && (point.Y <= CenterPoint.Y + size / 2))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override void ChooseShape(string s)
            {
                RectangleF r = new RectangleF(CenterPoint.X - size /3, CenterPoint.Y - size / 4, size, size);
                    graphics.DrawString($"квадрат,\n S={s}", new Font("Arial",10), Brushes.Black, r);
                
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(var item in shapes)
            {
                item.Draw();

                if (get_info == true && item.Size==draw_size) //построение строки с информацией внутри фигуры
                {
                    if (item.Name == "квадрат")
                        item.ChooseShape(item.CalcArea(s_circle).ToString());
                    else if (item.Name == "круг")
                        item.ChooseShape(item.CalcArea(s_circle).ToString());
                    else if (item.Name == "треугольник")
                        item.ChooseShape(item.CalcArea(s_triag).ToString());
                }
                
            }
            get_info = false;
        }
        bool get_info = false; //если истинно, то появляется информация о фигуре
        int draw_size; //размер фигуры, информацию о которой необходимо получить
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
            foreach (var item in shapes)
            {
                if (item.CheckPoint(new Point(e.X, e.Y)) == true)
                {
                    if (item.Name == "квадрат")
                    {
                        item.Draw(true);
                        get_info = true;
                        draw_size = item.Size;
                    }
                    else if (item.Name == "круг")
                    {
                        item.Draw(true);
                        get_info = true;
                        draw_size = item.Size;
                    }
                    else if (item.Name == "треугольник")
                    {
                        item.Draw(true);
                        get_info = true;
                        draw_size = item.Size;
                    }
                }
            }
            Invalidate();

        }
        public class Circle: Shape
        {
            private const double pi = 3.14;
            private Form form;
            private Random random;
            private Graphics graphics;
            public Circle(Form form,string name,int size,Color fillColor, Color lineColor) : base(name,size,fillColor, lineColor)
            {
                this.form = form;
                this.name = name;
                this.size = size;
                random = new Random(size);
                CenterPoint = new Point()
                {
                    X = random.Next(0 + size , form.ClientSize.Width - size),
                    Y = random.Next(0 + size , form.ClientSize.Height - size )

                };
                lineThickness = 1;
                graphics = form.CreateGraphics();
            }
            public override void Draw(bool fillRandom = false)
            {
                if (fillRandom)
                {
                    int x = CenterPoint.X - size / 2;
                    int y = CenterPoint.Y - size / 2;
                    ChangeColor(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));

                    lineThickness = random.Next(2, 11);
                    graphics.FillEllipse(new SolidBrush(FillColor), x + (int)lineThickness / 2, y + (int)lineThickness / 2, size , size );
                    graphics.DrawEllipse(new Pen(LineColor, lineThickness), x, y, size , size );
                }
                else
                {
                    Draw();
                }
            }
            public override void Draw()
            {
                int x = CenterPoint.X - size / 2;
                int y = CenterPoint.Y - size / 2;
                lineThickness = random.Next(2, 11);
                graphics.FillEllipse(new SolidBrush(FillColor), x + (int)lineThickness / 2, y + (int)lineThickness / 2, size, size);
                graphics.DrawEllipse(new Pen(LineColor, lineThickness), x, y, size, size);
            }

            public override int CalcArea(int s)
            {
                s= (int)Math.Round(pi * size * size);
                return s;
            }
            public override bool CheckPoint(Point point)
            {
                int x = Math.Abs(CenterPoint.X - point.X);
                int y = Math.Abs(CenterPoint.Y - point.Y);
                double hypotenuse = Math.Sqrt(x * x + y * y);


                if ( hypotenuse <= size/2)
                    {
                        return true;
                    }
                
                else return false;
            }
            public override void ChooseShape(string s)
            {
                RectangleF r = new RectangleF(CenterPoint.X-size/4 , CenterPoint.Y - size / 4, size, size);
                graphics.DrawString($"круг,\n S={s}",new Font("Arial",10),Brushes.Black, r);
            }
        }


        public class Triangle: Shape
        {
            private Form form;
            private Random random;
            private Graphics graphics;
            public Triangle(Form form,string name,int size,Color fillColor, Color lineColor) : base(name,size,fillColor, lineColor)
            {
                this.form = form;
                this.name = name;
                this.size = size;
                random = new Random(size);
                CenterPoint = new Point()
                {
                    X = random.Next(0 + size/10, form.ClientSize.Width - size/10 ),
                    Y = random.Next(0 + size /10, form.ClientSize.Height - size/10)

                };
                lineThickness = 1;
                graphics = form.CreateGraphics();
            }
            public override void Draw(bool fillRandom = false)
            {
                if (fillRandom)
                {
                    int x = CenterPoint.X - size / 2;
                    int y = CenterPoint.Y - size / 2;
                    ChangeColor(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));

                    lineThickness = random.Next(2, 11);
                    graphics.FillPolygon(new SolidBrush(FillColor), new PointF[]
                { new PointF((float)(x- (int)lineThickness / 2-(size/Math.Sqrt(3))),y-(int)lineThickness / 2-(size/3)), new PointF((float)(x+ (int)lineThickness / 2+(size/Math.Sqrt(3))),y- (int)lineThickness / 2-(size/3)),new PointF(x+ (int)lineThickness / 2,y+ (int)lineThickness / 2+2*(size/3))});
                    graphics.DrawPolygon(new Pen(LineColor, lineThickness), new PointF[]
                    { new PointF((float)(x-(size/Math.Sqrt(3))),y-(size/3)), new PointF((float)(x+(size/Math.Sqrt(3))),y-(size/3)),new PointF(x,y+2*(size/3))});
                }
                else
                {
                    Draw();
                }
            }
            public override void Draw()
            {
                int x = CenterPoint.X - size / 2;
                int y = CenterPoint.Y - size / 2;
                lineThickness = random.Next(2, 11);
                graphics.FillPolygon(new SolidBrush(FillColor), new PointF[]
                { new PointF((float)(x- (int)lineThickness / 2-(size/Math.Sqrt(3))),y-(int)lineThickness / 2-(size/3)), new PointF((float)(x+ (int)lineThickness / 2+(size/Math.Sqrt(3))),y- (int)lineThickness / 2-(size/3)),new PointF(x+ (int)lineThickness / 2,y+ (int)lineThickness / 2+2*(size/3))});
                graphics.DrawPolygon(new Pen(LineColor, lineThickness), new PointF[] 
                { new PointF((float)(x-(size/Math.Sqrt(3))),y-(size/3)), new PointF((float)(x+(size/Math.Sqrt(3))),y-(size/3)),new PointF(x,y+2*(size/3))});
            }

            public override int CalcArea(int s)
            {
                s= (int)Math.Round(size * size/Math.Sqrt(3));
                return s;
            }
           public override bool CheckPoint(Point point)
            {
                int x = CenterPoint.X - size / 2;
                int y = CenterPoint.Y - size / 2;
                int[] xp = new int[3] { (int)(x - (size / Math.Sqrt(3))), (int)(x + (size / Math.Sqrt(3))), x};
                int[] yp = new int[3] { (y - (size / 3)), (y - (size / 3)), y + 2 * (size / 3) };
                int a = (xp[0] - point.X) * (yp[1] - yp[0]) - (xp[1] - xp[0]) * (yp[0] - point.Y);
                int b = (xp[1] - point.X) * (yp[2] - yp[1]) - (xp[2] - xp[1]) * (yp[1] - point.Y);
                int c = (xp[2] -point.X) * (yp[0] - yp[2]) - (xp[0] - xp[2]) * (yp[2] - point.Y);
                if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                {
                    return true;
                }
                else 
                    return false;
            }
            public override void ChooseShape(string s)
            {
                RectangleF r = new RectangleF(CenterPoint.X - 5*size/6, CenterPoint.Y - 3*size /4, size, size);
                graphics.DrawString($"треугольник,\n S={s}", new Font("Arial", 10), Brushes.Black, r);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Shape sh;
            Random random = new Random();
            int p = random.Next(1, 4);
            switch(p) //выбор случайной фигуры для построения
            {
                case 1:
                    sh = new Square(this, "квадрат", random.Next(25, 100), Color.Yellow, Color.Black);
                    shapes.Add(sh);
                    square_count++;
                    break;
                case 2:
                    sh = new Circle(this, "круг", random.Next(25, 100), Color.Yellow, Color.Black);
                    shapes.Add(sh);
                    circle_count++;
                    break;
                case 3:
                    sh = new Triangle(this, "треугольник", random.Next(25, 100), Color.Yellow, Color.Black);
                    shapes.Add(sh);
                    triag_count++;
                    break;
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"1.txt"); //запись в файл
            foreach(var item in shapes)
            {
                 sw.WriteLine(item.Name+","+item.Size.ToString() + "," + item.FillColor.ToString() + "," + item.LineColor.ToString());
            }
            sw.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"1.txt"); //чтение из файла
            string line = sr.ReadToEnd();
            string[] a = line.Split('\n');
            for (int i=0;i<a.Length;i++)
            {
                string[] b = a[i].Split(',');
                switch(b[0])
                {
                    case "квадрат":
                        Square sq = new Square(this,b[0], int.Parse(b[1]), Color.DarkRed, Color.Black);
                        shapes.Add(sq);
                        sq.Draw();
                        break;
                    case "круг":
                        Circle cr = new Circle(this, b[0], int.Parse(b[1]), Color.DarkGreen, Color.Black);
                        shapes.Add(cr);
                        cr.Draw();
                        break;
                    case "треугольник":
                        Triangle tr = new Triangle(this, b[0], int.Parse(b[1]), Color.DarkBlue, Color.Black);
                        shapes.Add(tr);
                        tr.Draw();
                        break;
                }
                
            };
            
            sr.Close();

        }
    }
}
