using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;
using System.Data.SQLite;
using System.Data.Common;

namespace ConsoleApp2
{
    class Program
    {
        private static XmlDocument xml_dock; // экземпляр класса XmlDocument

        private static string str; //переменная строкового типа, в которую будет записана считанная информация
        private static SQLiteConnection data_base = new SQLiteConnection("Data Source = data_Base.db;"); // создание базы и подключения к ней

        static void Main(string[] args)
        {
            string Url = "https://news.yandex.ru/health.rss";//адрес ресурса
            xml_dock = new XmlDocument();  // инициализация нового экземпляра класса XmlDocument

            // объект запроса, в который передается адрес ресурса
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //  вызов метода GetResponse у объекта запроса для создания объекта ответа
            // приведение объекта к типу HttpWebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // объект чтения потока StreamReader
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    str = reader.ReadToEnd();
                    Console.WriteLine(str);
                }
            }
            response.Close(); //закрытие объекта ответа
            xml_dock.LoadXml(str);// загрузка xml документ из указанной строки
                                     // список узлов
            XmlNodeList childNodeList = xml_dock?.DocumentElement?.SelectSingleNode("channel")?.SelectNodes("item");

            // вывод результата XmlNode-узел XML
            // ChildNodesList - коллекция дочерних узлов
            //перебор коллекции и вывод информации в консоль
            foreach (XmlNode xmlNode in childNodeList)
            {
                Console.WriteLine(new string('*', 60) + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("pubDate").InnerText + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("link").InnerText + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("description").InnerText + "\n");
            }
            data_base.Open(); //открытие БД
            SQLiteCommand command; //  экземпляр объекта «SQLiteCommand» для выполнения SQL запросов к базе данных
            // создание в базе данных таблицы «News», содержащую столбцы «Id», «Title», «Link», «Description», «PubDate»
            command = new SQLiteCommand("PRAGMA synchronous = 1;" +
                "CREATE TABLE IF NOT EXISTS News (Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "Title,Link,Description,PubDate);", data_base);
            command.ExecuteNonQuery();// метод для выполнение SQL-команды без возвращения данных

            command = new SQLiteCommand("DELETE FROM News", data_base);// удаление всей таблицы
            command.ExecuteNonQuery();// метод для выполнение SQL-команды, не предполагающей возвращения данных
            Console.WriteLine("Произведена запись в БД");
            //перебор коллекции и извлечение из каждого объекта «item» необходимой информации
            foreach (XmlNode xmlNode in childNodeList)
            {
                command = new SQLiteCommand("INSERT INTO News(Title,Link,Description,PubDate) " +
                    "VALUES(@title,@link,@description,@pubDate)", data_base);// запрос для записи информации в базу данных
                command.Parameters.AddWithValue("@title", xmlNode.SelectSingleNode("title").InnerText);// добавление значения переменныех в запрос
                command.Parameters.AddWithValue("@link", xmlNode.SelectSingleNode("link").InnerText);
                command.Parameters.AddWithValue("@description", xmlNode.SelectSingleNode("description").InnerText);
                command.Parameters.AddWithValue("@pubDate", xmlNode.SelectSingleNode("pubDate").InnerText);
                command.ExecuteNonQuery();// метод для выполнение SQL-команды, не предполагающей возвращения данных
            }
            command.Dispose(); //высвобождение ресурсов, занятых объектом
            SQLiteDataReader reader1;// Предоставляет способ чтения потока строк из базы данных SQL Server
            // новый объект класса SQLiteCommand создается вызовом метода CreateCommand() 
            // ранее созданного объекта класса SQLiteConnection
            command = new SQLiteCommand("SELECT * FROM News", data_base);// используется sql-выражение SELECT мы выбираем все столбцы всех строк таблицы
            reader1 = command.ExecuteReader(); 
            Console.WriteLine("Считывание из БД");
            //перебор коллекции и вывод информации в консоль
            foreach (DbDataRecord item in reader1)
            {
                Console.WriteLine(new string('=', 65) + "\n");
                Console.WriteLine(item["PubDate"].ToString().TrimEnd(new char[] { '+', '0' }) + "\n");
                Console.WriteLine(item["Title"].ToString() + "\n");
                Console.WriteLine(item["Link"].ToString() + "\n\n");
                Console.WriteLine(item["Description"].ToString() + "\n");
            }
            command.Dispose(); //высвобождение ресурсов, занятых объектом
            Console.ReadKey();
        }

        
        }
        
    }

    


