using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Лабораторная_работа__2
{


    struct Student
    {

        public int Id;
        public string Full_Name;
        
        public DateTime BirthDate; 
        
        public string Institute;
        public string Group;
        public string Course;
        public float AvgMark;
        
       public Student(int Id,string Full_Name, DateTime BirthDate, string Institute, string Group, string Course, float AvgMark) // конструктор
        {
            this.Id = Id;
            this.Full_Name = Full_Name;
            this.BirthDate = BirthDate;
            this.Institute = Institute;
            this.Group = Group;
            this.Course = Course;
            this.AvgMark = AvgMark;
            
        }
        public void WriteInfo()   
    {
        Console.WriteLine("Номер:{0}, имя: {1}, дата рождения: {2}, институт: {3}, группа: {4}, курс: {5}, средний балл: {6}", Id, Full_Name, BirthDate.ToString("MMMM dd, yyyy") + ".", Institute, Group, Course, AvgMark);
    }
    

    }

    
        
class Program
    {
        public static void Menu()
        {
            bool c = true;
            while (c == true)
            {
                Console.WriteLine("Начать поиск?");
                string d = Console.ReadLine();
                while (d != "да" && d != "нет")
                {
                    Console.WriteLine("Режим не выбран");
                    d = Console.ReadLine();
                }
                switch (d)
                {
                    case "да":
                        Number1();
                        c = true;
                        break;
                    case "нет":
                        c = false;
                        break;
                }
            }
        }
        
        public static void Number1()
        {
           
            DateTime date1 = new DateTime(2003, 5, 14);
            DateTime date2 = new DateTime(2002, 3, 17);
            DateTime date3 = new DateTime(2003, 5, 7);
            DateTime date4 = new DateTime(2004, 3, 31);
            DateTime date5 = new DateTime(2002, 11, 20);
            Student[] students = new Student[5];

            students[0].Id = 301;
            students[0].Full_Name = "Сидоркин Олег Олегович";
            students[0].BirthDate = date1;
            students[0].Institute = "ТГУ";
            students[0].Group = "5";
            students[0].Course = "1";
            students[0].AvgMark =  3.7f;

            students[1].Id = 211;
            students[1].Full_Name = "Балясникова Екатерина Сергеевна";
            students[1].BirthDate = date2;
            students[1].Institute = "ВШЭ";
            students[1].Group = "8";
            students[1].Course = "2";
            students[1].AvgMark = 4.5f;

            students[2].Id = 355;
            students[2].Full_Name = "Гайбонюк Инна Александровна";
            students[2].BirthDate = date3;
            students[2].Institute = "МФЮА";
            students[2].Group = "9";
            students[2].Course = "1";
            students[2].AvgMark = 3.5f;

            students[3].Id = 427;
            students[3].Full_Name = "Гладич Елизавета Юрьевна";
            students[3].BirthDate = date4;
            students[3].Institute = "МАДИ";
            students[3].Group = "16";
            students[3].Course = "1";
            students[3].AvgMark = 3.2f;

            students[4].Id = 238;
            students[4].Full_Name = "Колодий Александр Михайлович";
            students[4].BirthDate = date5;
            students[4].Institute = "МИФИ";
            students[4].Group = "3";
            students[4].Course = "3";
            students[4].AvgMark = 4.8f;

            Console.WriteLine("Введите дату рождения");
            string bdate = Console.ReadLine();
            try
            {
                for (int j = 0; j < 5; j++)
                {

                    if (students[j].BirthDate == DateTime.Parse(bdate))
                    {
                        students[j].WriteInfo();
                        
                    }
                    else if (j == 4 & students[j].BirthDate != DateTime.Parse(bdate))
                    {

                        Console.WriteLine("Студент не найден");
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void Main(string[] args)
        {
            Menu();
            
            
            Console.ReadKey();
        }
    }
}

