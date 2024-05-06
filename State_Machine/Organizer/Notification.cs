using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Notification : Form
    {
        public static bool IsPutOff = false;
        public Notification()
        {
            InitializeComponent();
        }
        public Notification(Form1 f)
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IsPutOff = true;
            Form1.fsm.OnEvent(Form1.Event.EventIsPutOff);
        }
        
        private void Notification_Load(object sender, EventArgs e)
        {
            if(!IsPutOff)
                richTextBox1.Text =$"Напоминание о событии \nДата: {Form1.date.ToString("g")} \nОписание: {Form1.text}";
            else richTextBox1.Text = $"Напоминание об отложенном событии \nДата: {Form1.date.ToString("g")} \nОписание: {Form1.text}";
            Form1.fsm.OnEvent(Form1.Event.EventStarted);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Form1.fsm.OnEvent(Form1.Event.CalendarOpened);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.fsm.OnEvent(Form1.Event.WindowClosed);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Form1.fsm.State.ToString();
            
        }
    }
}
