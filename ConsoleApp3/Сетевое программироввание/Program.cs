using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Сетевое_программироввание
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlNews = new XmlDocument();
            string site = "https://news.yandex.ru/games.rss";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (Stream stream = resp.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    site = reader.ReadToEnd();
                }
            }
            resp.Close();
            xmlNews.LoadXml(site);// загружаем xml документ из указанной строки
                                     // список узлов
            XmlNodeList childNodeList = xmlNews?.DocumentElement?.SelectSingleNode("channel")?.SelectNodes("item");
            
            // выводим результат XmlNode-узел XML
            // ChildNodesList - коллекция дочерних узлов
            foreach (XmlNode xmlNode in childNodeList)
            {
                Console.WriteLine(new string('*', 60) + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("pubDate").InnerText + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("link").InnerText + "\n");
                Console.WriteLine(xmlNode.SelectSingleNode("description").InnerText + "\n");
            }
        }
    }
    }

