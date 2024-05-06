using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp3;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<string> Calc(int n)
        {
            Func<int, int, int>[] operations = new Func<int, int, int>[2];//инкапсулирует методы сложения и вычитания
            operations[0] = (a, b) => a - b;
            operations[1] = (a, b) => a + b;
            Random rnd = new Random();
            int[] numbers = new int[n]; //массив чисел, между которыми необходимо расставить знаки
            for (int i = 0; i < numbers.Length; i++) //заполнение массива случайными числами
            {
                numbers[i] = rnd.Next(-n, n);
            }
            int pow = numbers.Length - 1;
            int comb = (int)Math.Pow(2, pow);//число всех возможных комбинаций


            long bestResult = long.MaxValue;
            List<string> expr = new List<string>(); //хранит все возможные выражения с "+" и "-"
            List<string> best = new List<string>(); //хранит наиболее близкие к 0 выражения
            StringBuilder str = new StringBuilder(); //создает строку, которую можно изменять

            for (int i = 0; i < comb; i++)
            {
                int result = numbers[0];

                str.Clear();//строка очищается перед записью каждого нового выражения
                str.Append(numbers[0]);

                for (int j = 0; j < pow; j++) //цикл расставляет знаки внутри каждой комбинации
                {
                    int number = numbers[j + 1];
                    int oper_index = 0;
                    if ((i & (1 << j)) > 0)
                    {
                        oper_index = 1;
                        result = operations[oper_index](result, number);

                        str.Append( "+" );
                    }
                    else
                    {
                        result = operations[oper_index](result, number);

                        str.Append("-");
                    }
                        

                    if (number >= 0)
                        str.Append(number);//запись положительного числа
                    else
                        str.Append($"({number})");//запись отрицательного числа

                }

                str.Append($" = {result}");//запись результата
                expr.Add(str.ToString());//добавление очередного выражения


                if (Math.Abs(result) == Math.Abs(bestResult))
                {
                    best.Add(expr.Last());
                }
                else if (Math.Abs(result) < Math.Abs(bestResult))
                {
                    bestResult = result; //задание нового значения для bestResult

                    best.Clear();
                    best.Add(expr.Last());
                }

            }
            return best;
        }

        public static int[] FindCoins(int n, int[] nom, List<int> sum) //возвращает количество монет
        {
            int[,] mas = new int[n, 500];//создание двумерного массива с размером n*500
            Random r = new Random(); 
            for (int i = 0; i < n; i++)//наполнение массива случайными числами, соответствующими значениям номиналов
            {
                for (int j = 0; j < 500; j++)
                {
                    mas[i, j] = nom[r.Next(0, 4)];

                }
            }
            int[] count = new int[n] ; //хранит количество искомых монет
            int[,] nom_amount = new int[n,nom.Length];//количество монет каждого номинала
            for (int i = 0; i < nom.Length; i++)
            {
                for (int j = 0; j < mas.GetLength(0); j++)
                {
                    for (int k = 0; k < mas.GetLength(1); k++)
                    {
                        if (mas[j,k] == nom[i])

                            nom_amount[j,i] = nom_amount[j,i] + 1;
                    }
                }
            }

                for (int i=0; i<mas.GetLength(0);i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        for (int k = 0; k < sum.Count; k++)
                        {
                        
                            if (mas[i, j] == sum[k])
                            {
                                if (sum[k] == 2 && nom_amount[i,0] >= 2)
                                    count[i] = count[i] + 1;
                            
                                if (sum[k] == 10 && nom_amount[i, 3] >= 2)
                                    count[i] = count[i] + 1;
                            }
                        }
                    }

                }
                
            
            return count;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Stopwatch s = new Stopwatch();
            //калькулятор
            
            s.Restart();
            int n = 5;
            richTextBox1.Text = "n = 4" + "\n";
            richTextBox1.AppendText( string.Join("\n", Calc(n)));
            s.Stop();
            long time = s.ElapsedMilliseconds;
            
            chart1.Series[0].Points.AddXY(n, time);

            richTextBox1.AppendText("\n" + "n = " + n.ToString() + "\n");
            s.Restart();
            n = 8;
            richTextBox1.AppendText(string.Join("\n", Calc(n)));
            s.Stop();
            time = s.ElapsedMilliseconds;
            chart1.Series[0].Points.AddXY(n, time);

            richTextBox1.AppendText("\n" + "n = " + n.ToString() + "\n");
            s.Restart();
            n = 10;
            richTextBox1.AppendText(string.Join("\n", Calc(n)));
            s.Stop();

            time = s.ElapsedMilliseconds;
            chart1.Series[0].Points.AddXY(n, time);



            //Нумизмат

            s.Restart();
            int[] nom = new int[4] { 1, 2, 5, 10 };//массив номиналов

            List<int> sum = new List<int>();//содержит все возможные суммы 2-х номиналов
            for (int i = 0; i < 4; i++)//подсчет всех возможных сумм 2-х номиналов
            {
                for (int j = 0; j < 4; j++)
                {
                    foreach(var item in nom)
                        if (!sum.Contains(nom[i] + nom[j]) && (nom[i] + nom[j]==item))
                        {
                        sum.Add(nom[i] + nom[j]);

                        }
                }

            }
            s.Stop();
            long time0 = s.ElapsedMilliseconds;//время, затраченное на создание nom, sum, наполнение sum элементами
            

            s.Restart();
            richTextBox2.Text = "n = 2" + "\n";
            richTextBox2.AppendText(string.Join("\n", FindCoins(5, nom, sum)));
            s.Stop();
            time = s.ElapsedMilliseconds + time0;
            chart1.Series[1].Points.AddXY(5, time);

            s.Restart();
            richTextBox2.AppendText("\n" + "n = 3" + "\n");
            richTextBox2.AppendText(string.Join("\n", FindCoins(8, nom, sum)));
            s.Stop();
            time = s.ElapsedMilliseconds + time0;
            chart1.Series[1].Points.AddXY(8, time);

            s.Restart();
            richTextBox2.AppendText("\n" + "n = 4" + "\n");
            richTextBox2.AppendText(string.Join("\n", FindCoins(10, nom, sum)));
            s.Stop();
            time = s.ElapsedMilliseconds + time0;
            chart1.Series[1].Points.AddXY(10, time);



        }

        
    }
}
