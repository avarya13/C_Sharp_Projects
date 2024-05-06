using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace уровень2__7
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
        /*После окончания соревнования по шахматам турнирная таблица содержит фамилии
участников и результаты сыгранных партий (выигрыш – 1 очко, ничья – 1/2 очка,
проигрыш – 0 очков). Составить итоговую таблицу в порядке убывания
полученных участниками очков.
         */

        public class Players
        {
            public string name { get; set; }
           

        }

        public class TableOfPlayers : Players
        {
            public double point1 { get; set; }
            public double point2 { get; set; }
            public double point3 { get; set; }
            

            public TableOfPlayers(string name, double point1, double point2, double point3)
            {
                this.name = name;
                this.point1 = point1;
                this.point2 = point2;
                this.point3 = point3;
                

            }

            public static string[] o1 = new string[4] { "Трофимова В. С.", "Соколов М. А.", "Герасимова А. Д.", "Романов С. Н." };


            public static TableOfPlayers[] players = new TableOfPlayers[4]
            {
                    new TableOfPlayers("Исаков Я. А.",1, 0.5, 0),
                    new TableOfPlayers("Трофимова В. С.",0, 0, 0.5),
                    new TableOfPlayers("Соколов М. А.",0.5, 1, 1),
                    new TableOfPlayers("Герасимова А. Д.",0.5, 0.5, 0.5)
                    


            };

            public double Sum(double[] p)
            {
                double a = 0;
                for (int i = 0; i < 7; i++)
                    a += p[0];
                return a;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 5;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[0].HeaderText = "Игрок";
            dataGridView1.Columns[1].HeaderText = "1 партия";
            dataGridView1.Columns[2].HeaderText = "2 партия";
            dataGridView1.Columns[3].HeaderText = "3 партия";
            dataGridView1.Columns[4].HeaderText = "Сумма баллов";
            for (int i = 0; i < 4; i++)
            {

                dataGridView1.Rows[i].Cells[0].Value = TableOfPlayers.players[i].name;
                dataGridView1.Rows[i].Cells[1].Value = TableOfPlayers.players[i].point1;
                dataGridView1.Rows[i].Cells[2].Value = TableOfPlayers.players[i].point2;
                dataGridView1.Rows[i].Cells[3].Value = TableOfPlayers.players[i].point3;
                dataGridView1.Rows[i].Cells[4].Value = TableOfPlayers.players[i].point1+ TableOfPlayers.players[i].point2+ TableOfPlayers.players[i].point3;
                
            }
            dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Red;
            dataGridView1.Rows[1].Cells[1].Style.BackColor = Color.Red;
            dataGridView1.Rows[2].Cells[1].Style.BackColor = Color.Green;
            dataGridView1.Rows[3].Cells[1].Style.BackColor = Color.Green;

            dataGridView1.Rows[0].Cells[2].Style.BackColor = Color.Blue;
            dataGridView1.Rows[1].Cells[2].Style.BackColor = Color.Yellow;
            dataGridView1.Rows[2].Cells[2].Style.BackColor = Color.Yellow;
            dataGridView1.Rows[3].Cells[2].Style.BackColor = Color.Blue;

            dataGridView1.Rows[0].Cells[3].Style.BackColor = Color.Cyan;
            dataGridView1.Rows[1].Cells[3].Style.BackColor = Color.Brown;
            dataGridView1.Rows[2].Cells[3].Style.BackColor = Color.Cyan;
            dataGridView1.Rows[3].Cells[3].Style.BackColor = Color.Brown;

            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Descending);
        }
    }
}

    

