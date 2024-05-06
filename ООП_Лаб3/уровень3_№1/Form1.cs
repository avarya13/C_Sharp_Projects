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

namespace уровень3__1
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
        /*Результаты сессии содержат оценки 5 экзаменов по каждой группе. Определить
средний балл для трех групп студентов одного потока и выдать список групп в
порядке убывания среднего бала. Результаты вывести в виде таблицы с
заголовком.
         */
        class Student
        {
            public string name { get; set; }
            public string group { get; set; }

        }
        class Exam:Student
        {
            public int math, progr,phys,eng,econ;
            public Exam(string name,string group,int math, int progr,int phys,int eng,int econ)
            {
                this.name = name;
                this.group = group;
                this.math = math;
                this.progr = progr;
                this.phys = phys;
                this.eng = eng;
                this.econ = econ;
            }
            
            public static Exam[] st = new Exam[18]
            {
                new Exam("Богдан Гордеев","БИВТ-21-1",4,4,3,4,5),
                new Exam("Владимир Матвеев","БИВТ-21-1",5,5,4,4,5),
                new Exam("Кирилл Ульянов","БИВТ-21-1",3,3,4,3,4),
                new Exam("Яна Харитонова","БИВТ-21-1",3,3,4,3,4),
                new Exam("Анастасия Жданова","БИВТ-21-1",5,5,4,3,4),
                new Exam("Святослав Волков","БИВТ-21-1",3,4,4,4,4),
                new Exam("Алексей Калинин","БИВТ-21-2",5,3,5,4,3),
                new Exam("Тимофей Одинцов","БИВТ-21-2",5,4,5,4,4),
                new Exam("Мирослава Борисова","БИВТ-21-2",5,5,5,5,5),
                new Exam("Лилия Соловьева","БИВТ-21-2",5,4,4,5,4),
                new Exam("Глеб Королев","БИВТ-21-2",5,5,5,5,5),
                new Exam("Георгий Миронов","БИВТ-21-2",3,4,5,4,5),
                new Exam("Амалия Некрасова","БИВТ-21-3",4,5,4,5,4),
                new Exam("Бронислав Пахомов","БИВТ-21-3",4,3,4,3,4),
                new Exam("Мия Прохорова","БИВТ-21-3",4,5,4,5,5),
                new Exam("Марк Захаров","БИВТ-21-3",5,3,4,3,4),
                new Exam("Бронислав Пахомов","БИВТ-21-3",4,4,4,4,5),
                new Exam("Алина Герасимова","БИВТ-21-3",3,4,5,4,4)
            };
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.RowCount = 18;
            dataGridView1.ColumnCount = 8;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].HeaderText = "Студент";
            dataGridView1.Columns[1].HeaderText = "Группа";
            dataGridView1.Columns[2].HeaderText = "Балл по математике";
            dataGridView1.Columns[3].HeaderText = "Балл по ООП";
            dataGridView1.Columns[4].HeaderText = "Балл по физике";
            dataGridView1.Columns[5].HeaderText = "Балл по английскому языку";
            dataGridView1.Columns[6].HeaderText = "Балл по экономике";
            dataGridView1.Columns[7].HeaderText = "Средний балл";
            for (int i = 0; i < 18; i++)
            {

                dataGridView1.Rows[i].Cells[0].Value = Exam.st[i].name;
                dataGridView1.Rows[i].Cells[1].Value = Exam.st[i].group;
                dataGridView1.Rows[i].Cells[2].Value = Exam.st[i].math;
                dataGridView1.Rows[i].Cells[3].Value = Exam.st[i].progr;
                dataGridView1.Rows[i].Cells[4].Value = Exam.st[i].phys;
                dataGridView1.Rows[i].Cells[5].Value = Exam.st[i].eng;
                dataGridView1.Rows[i].Cells[6].Value = Exam.st[i].econ;
                
                dataGridView1.Rows[i].Cells[7].Value = (double)(Exam.st[i].math + Exam.st[i].progr + Exam.st[i].phys + Exam.st[i].eng + Exam.st[i].econ)/5;
            }
            dataGridView1.Sort(dataGridView1.Columns[7], ListSortDirection.Descending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch s = new Stopwatch();
            //калькулятор

            s.Restart();
            dataGridView2.RowCount = 3;
            dataGridView2.ColumnCount = 2;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.Columns[0].HeaderText = "Группа";
            dataGridView2.Columns[1].HeaderText = "Средний балл";
            dataGridView2.Rows[0].Cells[0].Value = "БИВТ-21-1";
            dataGridView2.Rows[1].Cells[0].Value = "БИВТ-21-2";
            dataGridView2.Rows[2].Cells[0].Value = "БИВТ-21-3";
            double[] sum = new double[3];

            for (int i = 0; i < 6; i++)
            {
                sum[0] = (double)(Exam.st[i].math + Exam.st[i].progr + Exam.st[i].phys + Exam.st[i].eng + Exam.st[i].econ) / 5;
            }
            for (int i = 6; i < 12; i++)
            {
                sum[1] = (double)(Exam.st[i].math + Exam.st[i].progr + Exam.st[i].phys + Exam.st[i].eng + Exam.st[i].econ) / 5;
            }
            for (int i = 12; i < 18; i++)
            {
                sum[2] = (double)(Exam.st[i].math + Exam.st[i].progr + Exam.st[i].phys + Exam.st[i].eng + Exam.st[i].econ) / 5;
            }
            for (int i = 0; i < 3; i++)
            {
                dataGridView2.Rows[i].Cells[1].Value = sum[i];
                
            }
            dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
            s.Stop();
            int n = 5;
            long time = (long)Math.Ceiling(Convert.ToDouble(s.ElapsedMilliseconds));
            chart1.Series[0].Points.AddXY(5, (double)time);
            chart1.Series[0].Points.AddXY(20, (double)time);
            chart1.Series[0].Points.AddXY(15, (double)time);
        }
    }
}
