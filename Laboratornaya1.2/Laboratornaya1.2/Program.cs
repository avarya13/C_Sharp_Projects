using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laboratornaya1._2
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
            if (Id != 0 && Full_Name != null && BirthDate != DateTime.Parse("01.01.0001 0:00:00") && Institute != null && Group != null && Course != null && AvgMark != 0)
            {
                Console.WriteLine("Номер:{0}, имя: {1}, дата рождения: {2}, институт: {3}, группа: {4}, курс: {5}, средний балл: {6}", Id, Full_Name, BirthDate.ToString("MMMM dd, yyyy") + ".", Institute, Group, Course, AvgMark);
            }
        }
    }

    class BD
    {
        public static void OutputSortedDB(ref Student[] students, float[] marks)
        {
            Array.Sort(marks);
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = 0; j < students.Length; j++)
                {
                    if (students[j].AvgMark == marks[i])
                        students[j].WriteInfo();
                }
            }
        }

        public static void Note(ref Student[] students, string file, int content,int j, int arr)
        {
            Array.Resize(ref students, students.Length + 1);
            File.AppendAllText(@file, $";{content}");
            arr = content;
        }
        public static void Note(ref Student[] students, string file, string content, int j, string arr)
        {
            Array.Resize(ref students, students.Length + 1);
            File.AppendAllText(@file, $";{content}");
            arr = content;
        }
        public static void Note(ref Student[] students, string file, DateTime content, int j, DateTime arr)
        {
            Array.Resize(ref students, students.Length + 1);
            File.AppendAllText(@file, $";{content}");
            arr = content;
        }
        public static void Note(ref Student[] students, string file, float content, int j, float arr)
        {
            Array.Resize(ref students, students.Length + 1);
            File.AppendAllText(@file, $";{content}");
            arr = content;
        }

        public static void AddNote(ref Student[] students)
        {

            bool w = false;
            while (w == false)
            {
                Console.WriteLine("Введите последовательно через точку с запятой ИД, ФИО, дату рождения, институт, группу, курс, средний балл");
                string noteStr = Console.ReadLine();
                string[] note = noteStr.Split(';');
                int j= students.Length + 1;
                try
                {
                    Note(ref students, "id.txt", int.Parse(note[0]),j, students[j].Id);
                    Note(ref students, "names.txt", note[1], j, students[j].Full_Name);
                    Note(ref students, "birth.txt", DateTime.Parse(note[2]), j, students[j].BirthDate);
                    Note(ref students, "Inst.txt", note[3], j, students[j].Institute);
                    Note(ref students, "group.txt", note[4], j, students[j].Group);
                    Note(ref students, "course.txt", note[5], j, students[j].Course);
                    Note(ref students, "mark.txt", float.Parse(note[6]), j, students[j].AvgMark);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    w = false;
                }
            }
        }

        public static void AddNote0(ref Student[] students)
        {

            bool w = false;
            while (w == false)
            {
                Console.WriteLine("Введите последовательно через точку с запятой ИД, ФИО, дату рождения, институт, группу, курс, средний балл");
                string noteStr = Console.ReadLine();
                string[] note = noteStr.Split(';');
                try
                {
                    Array.Resize(ref students, students.Length + 1);
                    File.AppendAllText(@"id.txt", $";{int.Parse(note[0])}");
                    students[students.Length - 1].Id = int.Parse(note[0]);

                    File.AppendAllText(@"birth.txt", $";{DateTime.Parse(note[2])}");

                    students[students.Length - 1].BirthDate = DateTime.Parse(note[2]);

                    File.AppendAllText(@"names.txt", ';' + note[1]);
                    students[students.Length - 1].Full_Name = note[1];

                    File.AppendAllText(@"Inst.txt", ';' + note[3]);
                    students[students.Length - 1].Institute = note[3];

                    File.AppendAllText(@"group.txt", ';' + note[4]);
                    students[students.Length - 1].Group = note[4];

                    File.AppendAllText(@"course.txt", ';' + note[5]);
                    students[students.Length - 1].Course = note[5];

                    File.AppendAllText(@"mark.txt", $";{float.Parse(note[6])}");
                    Console.WriteLine("Запись выполнена");
                    students[students.Length - 1].AvgMark = float.Parse(note[6]);
                    w = true;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    w = false;
                }
            }


            for (int i = 0; i < students.Length; i++)
            {
                students[i].WriteInfo();
            }
        }

    }


    class Program

    {

        static void Sort(ISort sort, ref Student[] students, float[] marks)
        {
            sort.OutputSortedDB(ref students, marks);
        }



        static void Main(string[] args)
        {




            //BD.OutputSortedDB(ref students, marks);
            /* FileStream id = new FileStream("id.txt", FileMode.Open);
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
             for (int j = 0; j < bStr.Length; j++)
             {
                 birthArr[j] = DateTime.Parse(bStr[j]);
             }

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

             float[] marks = new float[students.Length];
             for (int j = 0; j < students.Length; j++)
             {
                 marks[j] = students[j].AvgMark;
             }


             for (int j = 0; j < iStr.Length; j++)
             {
                 students[j].Id = int.Parse(iStr[j]);
                 students[j].Full_Name = namesArr[j];

                 students[j].BirthDate = DateTime.Parse(bStr[j]);

                 students[j].Institute = inArr[j];
                 students[j].Group = grArr[j];
                 students[j].Course = courseArr[j];
                 students[j].AvgMark = float.Parse(mStr[j]);

                 BD.AddNote(ref students);*/

            string[] a = new string[2];
            a[1] = "ехать по дороге";
            a[0] = "ехать по до";
            string b = "рог";
            //int result; //сюда пишем результат
            for (int i = 0; i < 2; i++)
            {
                if (a[i].Contains(b))
                    Console.WriteLine(a[i]);
            }
            
        }
        }
    }

    


    

    


            
        
    

    


