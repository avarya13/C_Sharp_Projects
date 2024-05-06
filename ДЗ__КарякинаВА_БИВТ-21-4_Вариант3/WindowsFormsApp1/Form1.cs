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
            textBox6.Text = "2"; //задание начальных значений 
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox7.Text = "0";
            textBox12.Text = "0";
            textBox11.Text = "0";
            textBox8.Text = "0";
            textBox13.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            radioButton8.Enabled = true;
        }

        public string form; //хранит форму записи комплексного числа
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        StreamWriter wr = new StreamWriter(@"1.txt"); //создание потока для записи в файл
        public class Complex //базовый класс
        {
            
            //ниже приведены методы, выполняющие арифметические операции над двумя комплексными числами
            public static  Complex Sum(Algebraic c1, Algebraic c2) //сумма (операция выполнятеся только для алгебраической формы записи)
            {

                return c1 + c2;
            }
            public static Complex Subtract(Algebraic c1, Algebraic c2) //разность (операция выполнятеся только для алгебраической формы записи)
            {

                return c1 - c2;
            }
            public static Complex Multiply(Algebraic c1, Algebraic c2) //умножение для алгебраической формы записи
            {

                return c1 * c2;
            }
            public static Complex Multiply(Trigonometric c1, Trigonometric c2) //умножение для тринометрической записи
            {

                return c1 * c2;
            }
            public static Complex Multiply(Exponential c1, Exponential c2) //умножение для показательной записи
            {

                return c1 * c2;
            }
            public static Complex Divide(Algebraic c1, Algebraic c2) //деление для алгебраической формы записи
            {

                return c1 / c2;
            }
            public static Complex Divide(Trigonometric c1, Trigonometric c2) //деление для тринометрической формы
            {

                return c1 / c2;
            }
            public static Complex Divide(Exponential c1, Exponential c2) //деление для показательной формы
            {

                return c1 / c2;
            }
            //для возведения в степень числа в алгебраической форме, необходимо привести его к тринометрической/показательной форме

            public static Complex Int_Pow(Trigonometric c1, int n) //возведение в степень для тринометрической формы
            {

                return c1 ^ n;
            }
            public static Complex Int_Pow(Exponential c1, int n) //возведение в степень для показательной формы
            {

                return c1 ^ n;
            }
        }

        public class Algebraic : Complex //производный класс, алгебраическая форма
        {
            public double Real { get; set; } //действительная часть комплексного числа
            public double Image { get; set; } //мнимая часть комплексного числа

            public Algebraic(double r, double im) //конструтор
            {
                Real = r;
                Image = im;
            }

            //Переопределение метода ToString();
            public override string ToString()
            {
                if(Image>=0)
                    return string.Format("{0:f2}+{1:f2}*i", Real, Image);
                else
                    return string.Format("{0:f2}-{1:f2}*i", Real, Math.Abs(Image));
            }

            //Перегрузка оператора "+" для двух комплексных чисел
            public static Algebraic operator +(Algebraic a1, Algebraic a2)
            {
                return new Algebraic(a1.Real + a2.Real, a1.Image + a2.Image);
            }
           
            //Перегрузка оператора "-" для двух комплексных чисел
            public static Algebraic operator -(Algebraic a1, Algebraic a2)
            {
                return new Algebraic(a1.Real - a2.Real, a1.Image - a2.Image);
            }
            
            //Перегрузка оператора "*" для двух комплексных чисел
            public static Algebraic operator *(Algebraic a1, Algebraic a2)
            {
                return new Algebraic(a1.Real * a2.Real - a1.Image * a2.Image, a1.Real * a2.Image + a2.Real * a1.Image);
            }

            //Перегрузка оператора "^" для комплексного числа и числа типа int (возведение в целую степень)
            public static Algebraic operator ^(Algebraic c, int n)
            {
                return new Algebraic(c.Real * n, c.Image);
            }
            //Перегрузка оператора / для двух комплексных чисел
            public static Algebraic operator /(Algebraic a1, Algebraic a2)
            {
                return new Algebraic((a1.Real * a2.Real + a1.Image * a2.Image) / (Math.Pow(a2.Real, 2) + Math.Pow(a2.Image, 2)), (a2.Real * a1.Image - a1.Real * a2.Image) / (Math.Pow(a2.Real, 2) + Math.Pow(a2.Image, 2)));
            }


        }
        public class Trigonometric : Complex //производный класс, тринометрическая форма
        {
            public double Mod { get; set; } //модуль числа в тринометрической форме
            public double Arg_Cos { get; set; } //аргумент числа в тринометрической форме
            public double Arg_Sin { get; set; } //аргумент числа в тринометрической форме
            public Trigonometric(double m, double acos, double asin) //конструктор класса 
            {
                Mod = m;
                Arg_Cos = acos;
                Arg_Sin = asin;

            }
            public override string ToString() //формат вывода числа в тригонометрической форме
            {
                if (Arg_Sin>=0)
                    return string.Format("{0:f2}*(cos{1:f2}+i*sin{2:f2})", Mod, Arg_Cos, Arg_Sin);
                else
                    return string.Format("{0:f2}*(cos{1:f2}-i*sin{2:f2})", Mod, Arg_Cos, Math.Abs(Arg_Sin));
            }

            //Перегрузка оператора "*" для двух комплексных чисел
            public static Trigonometric operator *(Trigonometric t1, Trigonometric t2)
            {
                return new Trigonometric(t1.Mod * t2.Mod, t1.Arg_Cos + t2.Arg_Cos, t1.Arg_Cos + t2.Arg_Cos);
            }
            //Перегрузка оператора "^" 
            public static Trigonometric operator ^(Trigonometric t1, int n)
            {
                return new Trigonometric(Math.Pow(t1.Mod, n), n * t1.Arg_Cos, n * t1.Arg_Sin);
            }


            //Перегрузка оператора "/" для двух комплексных чисел
            public static Trigonometric operator /(Trigonometric t1, Trigonometric t2)
            {
                return new Trigonometric(t1.Mod / t2.Mod, t1.Arg_Cos - t2.Arg_Cos, t1.Arg_Cos - t2.Arg_Cos);
            }
        }

        public class Exponential : Complex //производный класс, показательная форма
        {
            public double Mod { get; set; } //модуль
            public double Arg { get; set; } //аргумент

            public Exponential(double m, double a)  //конструктор
            {
                Mod = m;
                Arg = a;
            }
            public override string ToString() //переопределение ToString() 
            {
                if(Arg>=0)
                    return string.Format("{0:f2}*e^(i*{1:f2})", Mod, Arg);
                else
                    return string.Format("{0:f2}*e^(-i*{1:f2})", Mod, Math.Abs(Arg));
            }

            //Перегрузка оператора * для двух комплексных чисел
            public static Exponential operator *(Exponential e1, Exponential e2)
            {
                return new Exponential(e1.Mod * e2.Mod, e1.Arg + e2.Arg);
            }

            //Перегрузка оператора ^ для комплексного числа и числа типа int
            public static Exponential operator ^(Exponential e1, int n)
            {
                return new Exponential(Math.Pow(e1.Mod, n), n * e1.Arg);
            }
            //Перегрузка оператора / для двух комплексных чисел
            public static Exponential operator /(Exponential e1, Exponential e2)
            {
                return new Exponential(e1.Mod / e2.Mod, e1.Arg - e2.Arg);
            }
        }

        static double a, b, c, d, z1, z2, f1, f2, g1, g2; //поля, хранящие значения для инициализации экземпляров классов
        int n =2; //степень, по умолчанию число возводится в квадрат
        public Algebraic a1 = new Algebraic(a, b); //создание экземпляров классов
        public Algebraic a2 = new Algebraic(c, d);
        public Trigonometric t1 = new Trigonometric(z1, f1, f1);
        public Trigonometric t2 = new Trigonometric(z2, f2, f2);
         public Exponential e1 = new Exponential(z1, g1);
        public Exponential e2 = new Exponential(z2, g2);

        private void radioButton6_CheckedChanged(object sender, EventArgs e) //калькулятор выполняет действия над алгебраической формой
        {
            form = "alg";
            Main();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) //калькулятор выполняет действия над тригонометрической формой
        {
            form = "trig"; Main();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e) //калькулятор выполняет действия над экспоненциальной формой
        {
            form = "exp"; Main();
        }

        
        private void radioButton9_CheckedChanged(object sender, EventArgs e) 
        {
            textBox3.Clear(); //предварительная очистка строки для вывода результата
            Add_Value();
            switch (form)
            {
                case "trig":
                    a1.Real = t1.Mod * Math.Cos(t1.Arg_Cos); //перевод из тригонометрической в алгебраическую форму
                    a1.Image= t1.Mod * Math.Sin(t1.Arg_Cos);
                    textBox3.AppendText(a1.ToString());
                    wr.WriteLine("t1 приведено к алгебраической форме: {0:f2}+{1:f2}*i \r\n", a1.Real, a1.Image);//запись в файл
                    break;
                case "exp":
                    a1.Real = e1.Mod * Math.Cos(e1.Arg);
                    a1.Image = e1.Mod * Math.Sin(e1.Arg);
                    textBox3.AppendText(a1.ToString());
                    wr.WriteLine("e1 приведено к алгебраической форме: {0:f2}+{1:f2}*i \r\n", a1.Real, a1.Image);//запись в файл
                    break;
            }
            
            textBox1.Text = a1.Real.ToString(); //запись полученных коэффициентов в текстбоксы
            textBox4.Text = a2.Real.ToString();
            textBox2.Text = a1.Image.ToString();
            textBox5.Text = a2.Image.ToString();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)//приведение к тригонометрической форме
        {
            textBox3.Clear(); 
            Add_Value();
            switch (form)
            {
                case "alg":
                    t1.Mod = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    t1.Arg_Cos = Math.Atan(b / a);
                    t1.Arg_Sin = t1.Arg_Cos;
                    textBox3.AppendText(t1.ToString());
                    wr.WriteLine("a1 приведено к тригонометрическому виду: {0:f2}(cos{1:f2}+i*sin{2:f2}\r\n", t1.Mod, t1.Arg_Cos, t1.Arg_Sin);//запись в файл
                    break;
                case "exp":
                    t1.Mod = e1.Mod;
                    t1.Arg_Cos = e1.Arg;
                    t1.Arg_Sin = t1.Arg_Cos;
                    textBox3.AppendText(t1.ToString());
                    wr.WriteLine("е1 приведено к тригонометрическому виду: {0:f2}(cos{1:f2}+i*sin{2:f2}\r\n", t1.Mod, t1.Arg_Cos, t1.Arg_Sin);//запись в файл
                    break;
            }
            
            textBox7.Text = t1.Mod.ToString(); //запись полученных коэффициентов в текстбоксы
            textBox8.Text = t2.Mod.ToString();
            textBox12.Text = t1.Arg_Cos.ToString();
            textBox11.Text = t1.Arg_Sin.ToString();
            textBox8.Text = t2.Arg_Cos.ToString();
            textBox13.Text = t2.Arg_Sin.ToString();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e) //приведение к показательной форме
        {
            textBox3.Clear(); //очищение строки результата от предыдущих ответов
            Add_Value();
            switch (form)
            {
                case "alg":
                    e1.Mod = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    e1.Arg = Math.Atan(b / a);
                    textBox3.AppendText(e1.ToString());
                    wr.WriteLine("а1 приведено к экспоненциальному виду: {0:f2}*e^(i*{1:f2}\r\n", e1.Mod, e1.Arg);//запись в файл
                    
                    break;
                case "trig":
                    e1.Mod = t1.Mod;
                    e1.Arg = t1.Arg_Cos;
                    textBox3.AppendText(e1.ToString());
                    
                    wr.WriteLine("а1 приведено к экспоненциальному виду: {0:f2}*e^(i*{1:f2}\r\n", e1.Mod, e1.Arg); //запись в файл
                    break;
            }
            
            textBox10.Text = e1.Mod.ToString(); //запись полученных коэффициентов в текстбоксы
            textBox15.Text = e2.Mod.ToString();
            textBox14.Text = e1.Arg.ToString();
            textBox16.Text = e2.Arg.ToString();
        }

        private void button3_Click(object sender, EventArgs e) //запись в файл и открытие файла
        {
            wr.Close(); //закрытие потока StreamWriter
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получение выбранного файла
            string filename = openFileDialog1.FileName;
            // считывание файла в строку
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
            radioButton1.Enabled = false; //делает неактивным выбор операций в связи с завершением работы приложения
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            radioButton8.Enabled = false;
            radioButton9.Enabled = false;
            radioButton10.Enabled = false;
            radioButton11.Enabled = false;
            radioButton7.Enabled = false;
            button1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)//сброс результата
        {
            textBox3.Clear(); //очищение строки результата от предыдущих ответов
            wr.WriteLine("Результат сброшен");//запись в файл
        }
        public void Main() //в данном методе устанавляваются режимы ButtonClick и TextBox
        {
            //button4.Enabled = false;
            if (form == "alg")
            {
                radioButton1.Enabled = true; //разрешение операции сложения
                radioButton2.Enabled = true; //разрешение операции вычитания
                textBox1.ReadOnly = false; //разрешение редактировать только текстбоксы, относящиеся к алгебраической форме
                textBox2.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                radioButton5.Enabled = false; //поскольку для алгебраической формы нет отдельной формы возведение в степень, целесообразнее выполнять эту операцию для других форм 
                radioButton9.Enabled = false; //запрет на перевод в алгебраическую форму
                radioButton10.Enabled = true;//разршение перевода в тригонометрическую форму
                radioButton11.Enabled = true;//разрешение перевода в показательную форму

            }
            else if (form == "trig")
            {
                textBox7.ReadOnly = false;//разрешение редактировать только текстбоксы, относящиеся к тригонометрической форме
                textBox12.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox13.ReadOnly = false;
                radioButton9.Enabled = true;//разршение перевода в алгебраическую форму
                radioButton11.Enabled = true;//разрешение перевода в показательную форму
                radioButton10.Enabled = false;//запрет перевода в тригонометрическую форму
                radioButton1.Enabled = false;//для данной формы нет операции сложения
                radioButton2.Enabled = false;//для данной формы нет операции вычитания
                radioButton5.Enabled = true;//разрешение возводить в степень

            }
            else if (form == "exp")
            {
                textBox10.ReadOnly = false;//разрешение редактировать только текстбоксы, относящиеся к показательной форме
                textBox14.ReadOnly = false;
                textBox15.ReadOnly = false;
                textBox16.ReadOnly = false;
                radioButton9.Enabled = true;//разршение перевода в алгебраическую форму
                radioButton10.Enabled = true;//разршение перевода в тригонометрическую форму
                radioButton11.Enabled = false;//запрет перевода в показательную форму
                radioButton1.Enabled = false;//для данной формы нет операции сложения
                radioButton2.Enabled = false;//для данной формы нет операции вычитания
                radioButton5.Enabled = true; //разрешение возводить в степень
            }

        }
        public void Add_Value() //присваивание значений полям
        {
            switch (form)
            {
                case "alg":
                    try //попытка преобразования строки к типу double
                    {
                        a = double.Parse(textBox1.Text);
                        b = double.Parse(textBox2.Text);

                    }
                    catch (Exception ex) //сообщение об ошибке
                    {
                        MessageBox.Show(ex.Message);
                        wr.WriteLine(ex.Message + "\r\n");
                    }
                    try//попытка преобразования строки к типу double
                    {
                        c = double.Parse(textBox4.Text);
                        d = double.Parse(textBox5.Text);
                    }
                    catch (Exception ex)//сообщение об ошибке
                    {
                        MessageBox.Show(ex.Message);
                        wr.WriteLine(ex.Message + "\r\n");
                    }
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                    {
                        a1.Real = a;
                        a1.Image = b;
                        a2.Real = c;
                        a2.Image = d;
                        wr.WriteLine("Введено в алгебраической форме:a1={0},a2={1}", a1.ToString(), a2.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные");
                        wr.WriteLine("Некорректные данные\r\n");
                    }
                    break;
                case "trig":
                    try //попытка преобразования строки к типу double
                    {
                        z1 = double.Parse(textBox7.Text);
                        f1 = double.Parse(textBox12.Text);
                    }
                    catch (Exception ex)//сообщение об ошибке
                    {
                        MessageBox.Show(ex.Message);
                        wr.WriteLine(ex.Message + "\r\n");
                    }
                    try//попытка преобразования строки к типу double
                    {
                        z2 = double.Parse(textBox8.Text);
                        f2 = double.Parse(textBox13.Text);

                    }
                    catch (Exception ex)//сообщение об ошибке
                    {
                        MessageBox.Show(ex.Message);
                        wr.WriteLine(ex.Message + "\r\n");
                    }
                    if (textBox7.Text != "" && textBox12.Text != "" && textBox8.Text != "" && textBox13.Text != "")
                    {
                        t1.Mod = z1;
                        t1.Arg_Cos = f1;
                        t1.Arg_Sin = f2;
                        textBox11.Text = t1.Arg_Cos.ToString();
                        t1.Arg_Sin = t1.Arg_Cos;
                        t2.Mod = z2;
                        t2.Arg_Cos = f2;
                        textBox9.Text = t2.Arg_Cos.ToString();
                        t2.Arg_Sin = t2.Arg_Cos;
                        wr.WriteLine("Введено в тригонометрической форме:t1={0},t2={1}", t1.ToString(), t2.ToString());
                    }
                    else//сообщение об ошибке
                    {
                        MessageBox.Show("Введите корректные данные");
                        wr.WriteLine("Некорректные данные\r\n");//запись в файл
                    }
                    break;

                case "exp":
                    try//попытка преобразования строки к типу double
                    {
                        z1 = double.Parse(textBox10.Text);
                        g1 = double.Parse(textBox14.Text);

                    }
                    catch (Exception ex)//сообщение об ошибке
                    {
                        MessageBox.Show(ex.Message);
                        wr.WriteLine(ex.Message + "\r\n");
                    }
                    try//попытка преобразования строки к типу double
                    {
                        z2 = double.Parse(textBox15.Text);
                        g2 = double.Parse(textBox16.Text);

                    }
                    catch (Exception ex)//сообщение об ошибке
                    {
                        MessageBox.Show(ex.Message);
                        wr.WriteLine(ex.Message + "\r\n");
                    }
                    
                   
                    if (textBox10.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "")
                    {
                        e1.Mod = z1;
                        e1.Arg = g1;
                        e2.Mod = z2;
                        e2.Arg = g2;
                        wr.WriteLine("Введено в экспоненциальной форме:e1={0},e2={1}", e1.ToString(), e2.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные");
                        wr.WriteLine("Некорректные данные\r\n");//запись в файл
                    }
                    break;
            }
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e) //сложение, только для алгебраической формы
        {

            Add_Value();

            if (a1.Image + a1.Real + a2.Real + a2.Image > 0)
            {
                textBox3.Clear(); //поле для вывода результата необходимо предварительно очистить
                textBox3.AppendText(Complex.Sum(a1, a2).ToString());
                wr.WriteLine("Результат сложения: {0}", textBox3.Text);//запись в файл
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //вычитание, только для алгебраической формы
        {
            Add_Value();
            if (a1.Image + a1.Real + a2.Real + a2.Image > 0)
            {
                textBox3.Clear(); //очищение строки результата от предыдущих ответов
                textBox3.AppendText(Complex.Subtract(a1, a2).ToString());
                wr.WriteLine("Результат вычитания: {0}", textBox3.Text);//запись в файл
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) //умножение
        {
            Add_Value();
            textBox3.Clear();//очищение строки результата от предыдущих ответов
            switch (form)
            {
                case "alg": //алгебраическая форма
                    if (a1.Image + a1.Real + a2.Real + a2.Image > 0)
                    {
                        textBox3.AppendText(Complex.Multiply(a1, a2).ToString());
                    }
                    break;
                case "trig": //тригонометрическая форма
                    textBox3.AppendText(Complex.Multiply(t1, t2).ToString());

                    break;
                case "exp": //показательная форма
                    textBox3.AppendText(Complex.Multiply(e1, e2).ToString());
                    break;
            }
            wr.WriteLine("Результат умножения: {0}", textBox3.Text);//запись в файл
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) //деление
        {
            Add_Value();
            textBox3.Clear();//очищение строки результата от предыдущих ответов
            switch (form)
            {
                case "alg": //алгебраическая форма
                    if (a2.Real == 0)
                    {
                        MessageBox.Show("Деление на ноль не допускается.");
                        wr.WriteLine("Деление на ноль не допускается." + "\r\n");
                    }
                    else
                    {
                        textBox3.AppendText(Complex.Divide(a1, a2).ToString());
                        wr.WriteLine("Результат деления: {0}", textBox3.Text); //запись в файл
                    }
                        break;
                case "trig": //тригонометрическая форма
                    if (double.IsInfinity(t1.Mod / t2.Mod) == true || t2.Mod + t1.Mod == 0)
                    {
                        MessageBox.Show("Деление на ноль не допускается.");
                        wr.WriteLine("Деление на ноль не допускается." + "\r\n");
                    }
                    else
                    {
                        textBox3.AppendText(Complex.Divide(t1, t2).ToString());
                        wr.WriteLine("Результат деления: {0}", textBox3.Text); //запись в файл
                    }
                        break;
                case "exp": //показательная форма
                    if (double.IsInfinity(t1.Mod / t2.Mod) == true || t2.Mod + t1.Mod == 0)
                    {
                        MessageBox.Show("Деление на ноль не допускается.");
                        wr.WriteLine("Деление на ноль не допускается." + "\r\n");
                    }
                    else
                    {
                        textBox3.AppendText(Complex.Divide(e1, e2).ToString());
                        wr.WriteLine("Результат деления: {0}", textBox3.Text); //запись в файл
                    }
                        break;
            }
            
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
            textBox3.Clear();//очищение строки результата от предыдущих ответов
            bool success = int.TryParse(textBox6.Text, out n); //проверка корректности ввода степени
            if (success == true) //возведение в степень при правильном вводе степени
            {
                Add_Value();
                switch (form)
                {
                    case "trig": //тригонометрическая форма
                        
                        textBox3.AppendText(Complex.Int_Pow(t1, n).ToString());
                        
                        break;
                    case "exp": //показательная форма
                        textBox3.AppendText(Complex.Int_Pow(e1, n).ToString());
                        break;
                }
                wr.WriteLine("Результат возведения в степень: {0}", textBox3.Text);
            }
            else
            {
                MessageBox.Show("Введите корректные данные"); //сообщение об ошибке при неправильном вводе
                wr.WriteLine("Некорректные данные"); //запись в файл
            }
        }
    }
}
            
        

        
    

