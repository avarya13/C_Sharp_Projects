using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;//
using System.IO;//
using System.Net;//
using System.Data.Common;//



namespace Lab7_rss
{
    public partial class Form1 : Form
    {
        private XmlDocument xmlNews;
        private string strNews;



        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)  //Загрузить RSS
        {
            string rssUrl = textBox1.Text;//"https://news.yandex.ru/games.rss";//"https://www.techworld.com/news/rss";



            xmlNews = new XmlDocument();  // инициализируем новый экземпляр класса XmlDocument



            // создаём объект запроса в который передается адрес запрашиваемого ресурса
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rssUrl);
            // создаем объект ответа путем вызова метода GetResponse у объекта запроса 
            // (при этом приводим его к типу HttpWebResponse)
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();



            // создается объект чтения потока StreamReader
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    strNews = reader.ReadToEnd();
                    richTextBox1.Text = strNews;
                }
            }



            response.Close();



            xmlNews.LoadXml(strNews);// загружаем xml документ из указанной строки
            // список узлов
            XmlNodeList childNodeList = xmlNews?.DocumentElement?.SelectSingleNode("channel")?.SelectNodes("item");
            // очищаем текстовое поле
            richTextBox2.Clear();
            // выводим результат XmlNode-узел XML
            // ChildNodesList - коллекция дочерних узлов
            foreach (XmlNode xmlNode in childNodeList)
            {
                richTextBox2.AppendText(new string('=', 65) + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("pubDate").InnerText + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("title").InnerText + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("link").InnerText + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("description").InnerText + "\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}