using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
//using Newtonsoft.Json;



namespace ConsoleApp1
{
    struct Students
    {
        public int ID;
        public string Full_Name;
        public DateTime Birthday;
        public string Institute;
        public string Group;
        public string Course;
        public float AvgMark;
    }

   
    struct Person
    {
        static List<Students> students = new List<Students>();
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string Name, int Age)
        {
            this.Age = Age;
            this.Name = Name;
        }
        public static void Info()
        {
            Console.WriteLine("{ Age},{ Name}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students student1 = new Students();
            student1.ID = 1;
            student1.Full_Name = "Павел Александрович Печкин";
            student1.Birthday = new DateTime(2002, 02, 08);
            student1.Institute = "ИТКН";
            student1.Group = "бивт-12";
            student1.Course = "первый курс";
            student1.AvgMark = 23;
            //Students.Add(student1);

            Students student2 = new Students();
            student2.ID = 1;
            student2.Full_Name = "Павел Александрович Печкин";
            student2.Birthday = new DateTime(2003, 03, 30);
            student2.Institute = "ИТКН";
            student2.Group = "Бивт-34";
            student2.Course = "первый курс";
            student2.AvgMark = 25;
            //students.Add(student2);


            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1. Поиск по дате рождения");
            Console.WriteLine("2. Выйти из программы");
            Console.ReadKey();


            string  input = Console.ReadLine();
            switch (input)
            {
                case "search":
                    Console.WriteLine("Введите дату рождения");
                    break;
                case "end":
                    System.Environment.Exit(0);
                    break;
                //default:
                   // Console.WriteLine("Введены неккоректные данные");
                   // break;
            }


            Console.ReadKey();
            }
        }
    }

