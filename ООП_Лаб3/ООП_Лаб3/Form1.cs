using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_Лаб3
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
        /*Составить программу для обработки результатов кросса на 500 м для женщин. Для
каждой участницы ввести фамилию, группу, фамилию преподавателя, результат.
Получить результирующую таблицу, упорядоченную по результатам, в которой
содержится также информация о выполнении норматива. Определить суммарное
количество участниц, выполнивших норматив.
         */

        public const double norm = 1.50;
        class Woman
        {
            public string surname { get; set; }
        }
        class Participant: Woman
        {
            public string couch { get; set; }
            public double result { get; set; }
            public int group { get; set; }
            public Participant(string surname, int group, string couch, double result)
            {
                this.surname = surname;
                this.group = group;
                this.couch = couch;
                this.result = result;
            }

            
            public static Participant[] p = new Participant[7]
                {
                    new Participant("Федорова",1,"Данилова", 1.43),
                    new Participant("Антонова",1,"Данилова", 1.38),
                    new Participant("Князева",2,"Шаповалова", 1.53),
                    new Participant("Лукьянова",2,"Шаповалова", 1.58),
                    new Participant("Кузьмина",3,"Мельникова", 1.44),
                    new Participant("Романова",3,"Мельникова", 1.27),
                    new Participant("Чернова",4,"Павлова", 1.59)

                };


        }
            
            private void button1_Click(object sender, EventArgs e)
            {
                textBox1.Text = Participant.p.Count().ToString();
                dataGridView1.RowCount = 7;
                dataGridView1.ColumnCount = 5;
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns[0].HeaderText = "Участница забега";
                dataGridView1.Columns[1].HeaderText = "Группа";
                dataGridView1.Columns[2].HeaderText = "Тренер";
                dataGridView1.Columns[3].HeaderText = "Результат, мин";
                dataGridView1.Columns[4].HeaderText = "Зачет/незачет";
            for (int i = 0; i < 7; i++)
                {
                   
                        dataGridView1.Rows[i].Cells[0].Value = Participant.p[i].surname;
                        dataGridView1.Rows[i].Cells[1].Value = Participant.p[i].group;
                        dataGridView1.Rows[i].Cells[2].Value = Participant.p[i].couch;
                        dataGridView1.Rows[i].Cells[3].Value = Participant.p[i].result;
                if (Participant.p[i].result <= norm)
                    dataGridView1.Rows[i].Cells[4].Value = "зачет";
                else
                    dataGridView1.Rows[i].Cells[4].Value = "незачет";
            }
            dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
        }

        
    }
    }

