using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Лабораторная_2;
using Лабораторная_2._4;

namespace Лабораторная_2._2
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

        public Student(int Id, string Full_Name, DateTime BirthDate, string Institute, string Group, string Course, float AvgMark) // конструктор
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
            if (Id != 0 && Full_Name!=null && BirthDate !=DateTime.Parse( "01.01.0001 0:00:00") && Institute!=null && Group != null && Course != null && AvgMark!=0)
            {
                Console.WriteLine("Номер:{0}, имя: {1}, дата рождения: {2}, институт: {3}, группа: {4}, курс: {5}, средний балл: {6}", Id, Full_Name, BirthDate.ToString("MMMM dd, yyyy") + ".", Institute, Group, Course, AvgMark);
            }
        }
    }

    class Program
    {

        public static void ReadDB()
        {
            FileStream id = new FileStream("id.txt", FileMode.Open);
            StreamReader reader = new StreamReader(id);
            string i = reader.ReadToEnd();
            reader.Close();

            string[] iStr = i.Split(';');
            int[] idArr = new int[iStr.Length];
            Student[] students = new Student[iStr.Length];


            FileStream names = new FileStream("names.txt", FileMode.Open);
            StreamReader reader1 = new StreamReader(names);
            string n = reader1.ReadToEnd();
            reader1.Close();
            string[] namesArr = n.Split(';');


            FileStream birth = new FileStream("birth.txt", FileMode.Open);
            StreamReader reader2 = new StreamReader(birth);
            string b = reader2.ReadToEnd();
            reader2.Close();
            string[] bStr = b.Split(';');
            DateTime[] birthArr = new DateTime[iStr.Length];


            FileStream Inst = new FileStream("Inst.txt", FileMode.Open);
            StreamReader reader3 = new StreamReader(Inst);
            string ins = reader3.ReadToEnd();
            reader3.Close();
            string[] inArr = ins.Split(';');


            FileStream group = new FileStream("group.txt", FileMode.Open);
            StreamReader reader4 = new StreamReader(group);
            string g = reader4.ReadToEnd();
            reader4.Close();
            string[] grArr = g.Split(';');


            FileStream course = new FileStream("course.txt", FileMode.Open);
            StreamReader reader5 = new StreamReader(course);
            string c = reader5.ReadToEnd();
            reader5.Close();
            string[] courseArr = c.Split(';');


            FileStream mark = new FileStream("mark.txt", FileMode.Open);
            StreamReader reader6 = new StreamReader(mark);
            string m = reader6.ReadToEnd();
            reader6.Close();
            string[] mStr = m.Split(';');


            for (int j = 0; j < iStr.Length; j++)
            {
                students[j].Id = int.Parse(iStr[j]);
                students[j].Full_Name = namesArr[j];

                students[j].BirthDate = DateTime.Parse(bStr[j]);

                students[j].Institute = inArr[j];
                students[j].Group = grArr[j];
                students[j].Course = courseArr[j];
                students[j].AvgMark = float.Parse(mStr[j]);
            }
            DB.Menu(ref students);
        }


        static void Main(string[] args)
        {
            ReadDB();
            Console.ReadKey();
        }
    }
}
