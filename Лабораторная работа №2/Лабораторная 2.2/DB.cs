using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Лабораторная_2._2;



namespace Лабораторная_2._4
{
    class DB
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
        }
        public static void Del(ref Student[] students, int j, int i, string file, int obj)
        {
            string tempPath = Path.GetTempFileName();
            using (var sw = new StreamWriter(tempPath))
            {
                for (i = 0; i < students.Length; i++)
                {
                    if ((i == 0 && i != j) || (i == 1 && j == 0))
                    {
                        sw.Write($"{obj}");
                    }
                    if (i != j && i != 0 && i != 1)
                    {
                        sw.Write($";{obj}");
                    }
                }
            }
            File.Delete(file);
            File.Move(tempPath, file);
        }

        public static void Del(ref Student[] students, int j, int i, string file, DateTime obj)
        {
            string tempPath = Path.GetTempFileName();
            using (var sw = new StreamWriter(tempPath))
            {
                for (i = 0; i < students.Length; i++)
                {
                    if ((i == 0 && i != j) || (i == 1 && j == 0))
                    {
                        sw.Write($"{obj}");
                    }
                    if (i != j && i != 0 && i != 1)
                    {
                        sw.Write($";{obj}");
                    }
                }
            }
            File.Delete(file);
            File.Move(tempPath, file);
        }

        public static void Del(ref Student[] students, int j, int i, string file, string obj)
        {
            string tempPath = Path.GetTempFileName();
            using (var sw = new StreamWriter(tempPath))
            {
                for (i = 0; i < students.Length; i++)
                {
                    if ((i == 0 && i != j) || (i == 1 && j == 0))
                    {
                        sw.Write($"{obj}");
                    }
                    if (i != j && i != 0 && i != 1)
                    {
                        sw.Write($";{obj}");
                    }
                }
            }
            File.Delete(file);
            File.Move(tempPath, file);
        }

        public static void Del(ref Student[] students, int j, int i, string file, float obj)
        {
            string tempPath = Path.GetTempFileName();
            using (var sw = new StreamWriter(tempPath))
            {
                for (i = 0; i < students.Length; i++)
                {
                    if ((i == 0 && i != j) || (i == 1 && j == 0))
                    {
                        sw.Write($"{obj}");
                    }
                    if (i != j && i != 0 && i != 1)
                    {
                        sw.Write($";{obj}");
                    }
                }
            }
            File.Delete(file);
            File.Move(tempPath, file);
        }


        public static void Delete0(ref Student[] students)
        {
            try
            {
                Console.WriteLine("Введите дату рождения студента (формат dd.mm.yyyy), данные которого необходимо удалить");

                string bdate = Console.ReadLine();
                for (int j = 0; j < students.Length; j++)
                {

                    if (students[j].BirthDate == DateTime.Parse(bdate))
                    {
                        int i = 0;
                        Del(ref students, j, i, "id.txt", students[i].Id);
                        Del(ref students, j, i, "names.txt", students[i].Full_Name);
                        Del(ref students, j, i, "birth.txt", students[i].BirthDate);
                        Del(ref students, j, i, "Inst.txt", students[i].Institute);
                        Del(ref students, j, i, "group.txt", students[i].Group);
                        Del(ref students, j, i, "course.txt", students[i].Course);
                        Del(ref students, j, i, "mark.txt", students[i].AvgMark);


                        for (i = 0; i < students.Length; i++)
                        {
                            Array.Clear(students, j, 1);
                        }
                    }

                }
                for (int i = 0; i < students.Length; i++)
                {
                    students[i].WriteInfo();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void Delete(ref Student[] students)
        {
            try
            {

                Console.WriteLine("Введите дату рождения студента (формат dd.mm.yyyy), данные которого необходимо удалить");

                string bdate = Console.ReadLine();
                for (int j = 0; j < students.Length; j++)
                {

                    if (students[j].BirthDate == DateTime.Parse(bdate))
                    {

                        string tempPath = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Id}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Id}");
                                }
                            }
                        }
                        File.Delete("id.txt");
                        File.Move(tempPath, "id.txt");

                        string tempPath2 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath2))
                        {

                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].BirthDate}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].BirthDate}");
                                }
                            }

                        }
                        File.Delete("birth.txt");
                        File.Move(tempPath2, "birth.txt");

                        string tempPath1 = Path.GetTempFileName();

                        using (var sw = new StreamWriter(tempPath1))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Full_Name}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Full_Name}");
                                }

                            }
                        }
                        File.Delete("names.txt");
                        File.Move(tempPath1, "names.txt");

                        string tempPath3 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath3))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Institute}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Institute}");
                                }
                            }
                        }
                        File.Delete("Inst.txt");
                        File.Move(tempPath3, "Inst.txt");


                        string tempPath4 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath4))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Group}");
                                }

                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Group}");
                                }
                            }
                        }
                        File.Delete("group.txt");
                        File.Move(tempPath4, "group.txt");

                        string tempPath5 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath5))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Course}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Course}");
                                }
                            }
                        }
                        File.Delete("course.txt");
                        File.Move(tempPath5, "course.txt");

                        string tempPath6 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath6))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].AvgMark}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].AvgMark}");
                                }
                            }
                        }
                        File.Delete("mark.txt");
                        File.Move(tempPath6, "mark.txt");
                        for (int i = 0; i < students.Length; i++)
                        {
                            Array.Clear(students, j, 1);
                        }
                    }
                }

                for (int i = 0; i < students.Length; i++)
                {
                    students[i].WriteInfo();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void BirthSearch(ref Student[] students)
        {
            DateTime bdate;
            bool w = false;
            while (w == false)
            {
                Console.WriteLine("Введите дату рождения");
                try
                {
                    bdate = DateTime.Parse(Console.ReadLine());
                    for (int j = 0; j < students.Length; j++)
                    {
                        if (students[j].BirthDate == bdate)
                        {
                            students[j].WriteInfo();
                            break;
                        }
                        else if (j == students.Length - 1 & students[j].BirthDate != bdate)
                        {
                            Console.WriteLine("Студент не найден");
                        }
                    }
                    w = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    w = false; ;
                }
            }

        }

        public static void SortMarks(ref Student[] students)
        {
            float[] marks = new float[students.Length];
            for (int i = 0; i < students.Length; i++)
            {
                marks[i] = students[i].AvgMark;
            }

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
        public static void Menu(ref Student[] students)
        {
            bool c = true;
            while (c == true)
            {
                Console.WriteLine("Начать работу?");
                string d = Console.ReadLine();
                while (d != "да" && d != "нет")
                {
                    Console.WriteLine("Режим не выбран. Повторите попытку.");
                    d = Console.ReadLine();
                }

                switch (d)
                {
                    case "да":
                        Console.WriteLine("Выберите: поиск по дате, удалить или сортировка ");
                        string z = Console.ReadLine();
                        while ( z != "поиск по дате"  && z != "удалить" && z != "сортировка" )
                        {
                            Console.WriteLine("Режим не выбран");
                            z = Console.ReadLine();
                        }

                        switch (z)
                        {

                            case "поиск по дате":

                                BirthSearch(ref students);

                                break;
                            
                            case "удалить":
                                Delete(ref students);
                                break;
                            case "сортировка":
                                SortMarks(ref students);
                                break;
                        }
                        c = true;

                        break;
                    case "нет":
                        c = false;
                        break;
                }
            }
        }
    }
}
