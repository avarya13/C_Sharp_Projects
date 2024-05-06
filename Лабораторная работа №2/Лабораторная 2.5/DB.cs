using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

using Лабораторная_2._5;
using System.Text.RegularExpressions;

namespace Лабораторная_2._4
{
    
    class DB

    {
        
        public static void Json(ref Student[] students)
        {
            

                Console.WriteLine("Сериализация выполнена");
            string json = JsonSerializer.Serialize(students);
            Console.WriteLine(json);
            Console.WriteLine("Десериализация:");
            Student[] students0 = JsonSerializer.Deserialize<Student[]>(json);
            for (int i = 0; i < students.Length; i++)
            {

                if (students0[i].BirthDate !=  DateTime.Parse("01.01.0001 0:00:00"))
                {
                    Console.WriteLine(students0[i].ToString());
                }
                
            }
        }
        public static void MinMax(ref Student[] students)
        {
            float min = 10;
            float max = -10;
            int imin = 0;
            int i;
            int imax = 0;
            for (i = 0; i < students.Length; i++)
            {
                if (min > students[i].AvgMark && students[i].AvgMark!=0)
                {
                    min = students[i].AvgMark;
                    imin = i;
                }
            }
            Console.WriteLine("Минимальный балл:");
            Console.WriteLine(students[imin].ToString());

            for (i = 0; i < students.Length; i++)
            {
                if (max < students[i].AvgMark)
                {
                    max = students[i].AvgMark;
                    imax = i;
                }
            }
            Console.WriteLine("Максимальный балл:");
            Console.WriteLine(students[imax].ToString()); ;
        }
        public static void NameSearch(ref Student[] students)
        {
            Console.WriteLine("Введите часть ФИО");
            string l = Console.ReadLine();
            int replays = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Full_Name.Contains(l))
                {
                    Console.WriteLine(students[i].ToString());
                    replays = replays + 1;
                }
                else if (i == students.Length - 1 && replays == 0)
                {
                    Console.WriteLine("Совпадений не найдено");
                }
            }
        }

        public static void DoubleSearch(ref Student[] students)
        {
            string[] names = new string[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                names[i] = students[i].Full_Name;
            }
            Console.WriteLine("Исходная база данных:");
            for (int i = 0; i < students.Length; i++)
            {
                students[i].WriteInfo();
            }

            Student[] st0 = students.Distinct().ToArray();
            Array.Clear(students, 0, students.Length);
            Array.Resize(ref students, st0.Length);
            for (int i = 0; i < st0.Length; i++)
            {

                students[i] = st0[i];

            }
            File.Delete(@"id.txt");
            File.Delete(@"names.txt");
            File.Delete(@"birth.txt");
            File.Delete(@"Inst.txt");
            File.Delete(@"group.txt");
            File.Delete(@"course.txt");
            File.Delete(@"mark.txt");
            File.Delete(@"form.txt");
            File.Delete(@"level.txt");
            File.Delete(@"debts.txt");

            for (int i = 0; i < students.Length; i++)
            {



                Note0(ref students, i, "id.txt", students[i].Id);
                Note0(ref students, i, "names.txt", students[i].Full_Name);
                Note0(ref students, i, "birth.txt", students[i].BirthDate);
                Note0(ref students, i, "Inst.txt", students[i].Institute);
                Note0(ref students, i, "group.txt", students[i].Group);
                Note0(ref students, i, "course.txt", students[i].Course);
                Note0(ref students, i, "mark.txt", students[i].AvgMark);
                Note0(ref students, i, "form.txt", students[i].EdForm);
                Note0(ref students, i, "level.txt", students[i].Level);
                Note0(ref students, i, "debts.txt", students[i].Debts);
            }
            Console.WriteLine("Очищенная от повторов база данных:");
            for (int i = 0; i < students.Length; i++)
            {
                students[i].WriteInfo();

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
            File.Delete(@file);
            File.Move(tempPath, @file);
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
            File.Delete(@file);
            File.Move(tempPath, @file);
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
            File.Delete(@file);
            File.Move(tempPath, @file);
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
            File.Delete(@file);
            File.Move(tempPath, @file);
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
                        File.Delete(@"id.txt");
                        File.Move(tempPath, @"id.txt");

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
                        File.Delete(@"birth.txt");
                        File.Move(tempPath2, @"birth.txt");

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
                        File.Delete(@"names.txt");
                        File.Move(tempPath1, @"names.txt");

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
                        File.Delete(@"Inst.txt");
                        File.Move(tempPath3, @"Inst.txt");


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
                        File.Delete(@"group.txt");
                        File.Move(tempPath4, @"group.txt");

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
                        File.Delete(@"course.txt");
                        File.Move(tempPath5, @"course.txt");

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
                        File.Delete(@"mark.txt");
                        File.Move(tempPath6, @"mark.txt");

                        string tempPath7 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath7))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].EdForm}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].EdForm}");
                                }
                            }
                        }
                        File.Delete(@"form.txt");
                        File.Move(tempPath7, @"form.txt");


                        string tempPath8 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath8))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Level}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Level}");
                                }
                            }
                        }
                        File.Delete(@"level.txt");
                        File.Move(tempPath8, @"level.txt");


                        string tempPath9 = Path.GetTempFileName();
                        using (var sw = new StreamWriter(tempPath9))
                        {
                            for (int i = 0; i < students.Length; i++)
                            {
                                if ((i == 0 && i != j) || (i == 1 && j == 0))
                                {
                                    sw.Write($"{students[i].Debts}");
                                }
                                if (i != j && i != 0 && i != 1)
                                {
                                    sw.Write($";{students[i].Debts}");
                                }
                            }
                        }
                        File.Delete(@"debts.txt");
                        File.Move(tempPath9, @"debts.txt");


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

        public static void Note0(ref Student[] students, int i, string file, int content)
        {
            if (i!=0)
            File.AppendAllText(@file, $";{content}");
            else
                File.AppendAllText(@file, $"{content}");
        }
        public static void Note0(ref Student[] students, int i, string file, string content)
        {
            if (i != 0)
                File.AppendAllText(@file, $";{content}");
            else
                File.AppendAllText(@file, $"{content}");
        }
        public static void Note0(ref Student[] students, int i, string file, DateTime content)
        {

            if (i != 0)
                File.AppendAllText(@file, $";{content}");
            else
                File.AppendAllText(@file, $"{content}");
        }
        public static void Note0(ref Student[] students, int i,string file, float content)
        {

            if (i != 0)
                File.AppendAllText(@file, $";{content}");
            else
                File.AppendAllText(@file, $"{content}");
        }

        public static void Note0(ref Student[] students, string file, int content)
        {
            
            File.AppendAllText(@file, $";{content}");
        }
        public static void Note(ref Student[] students, string file, string content)
        {
            File.AppendAllText(@file, $";{content}");
        }
        public static void Note(ref Student[] students, string file, DateTime content)
        {

            File.AppendAllText(@file, $";{content}");
        }
        public static void Note(ref Student[] students, string file, float content)
        {

            File.AppendAllText(@file, $";{content}");
        }

        public static void AddNote(ref Student[] students)
        {

            bool w = false;
            while (w == false)
            {
                Console.WriteLine("Введите последовательно через точку с запятой ИД, ФИО, дату рождения, институт, группу, курс, средний балл, форму обучения, уровень подготовки и долги");
                string noteStr = Console.ReadLine();
                string[] note = noteStr.Split(';');
                try
                {
                    Array.Resize(ref students, students.Length + 1);
                    int j = students.Length - 1;
                    Note(ref students, "id.txt", int.Parse(note[0]));
                    Note(ref students, "names.txt", note[1]);
                    Note(ref students, "birth.txt", DateTime.Parse(note[2]));
                    Note(ref students, "Inst.txt", note[3]);
                    Note(ref students, "group.txt", note[4]);
                    Note(ref students, "course.txt", note[5]);
                    Note(ref students, "mark.txt", float.Parse(note[6]));
                    Note(ref students, "form.txt", note[7]);
                    Note(ref students, "level.txt", note[8]);
                    Note(ref students, "debts.txt", int.Parse(note[9]));

                    students[students.Length - 1].Id = int.Parse(note[0]);
                    students[students.Length - 1].Full_Name = note[1];
                    students[students.Length - 1].BirthDate = DateTime.Parse(note[2]);
                    students[students.Length - 1].Institute = note[3];
                    students[students.Length - 1].Group = note[4];
                    students[students.Length - 1].Course = note[5];
                    students[students.Length - 1].AvgMark = float.Parse(note[6]);
                    students[students.Length - 1].EdForm = note[7];
                    students[students.Length - 1].Level = note[8];
                    students[students.Length - 1].Debts = int.Parse(note[9]);
                    Console.WriteLine("Запись выполнена");
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
                if (students[i].Id != 0)
                {
                    Console.WriteLine(students[i].ToString());
                }
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
                            Console.WriteLine(students[j].ToString());
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

        public static void OutputSortedDB(ref Student[] students)
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
                            Console.WriteLine(students[j].ToString());
                    }
                }
            }
        
        public static void Menu(ref Student[] students)
        {
            bool c = true;
            while (c == true)
            {
                
                    Console.WriteLine("Выберите: мин/макс балл, сортировка, json поиск по ФИО, поиск по дате, удалить, запись, удалить повтор или выход");
                    string z = Console.ReadLine();
                    while (z != "поиск по ФИО" && z != "поиск по дате" && z != "мин/макс балл" && z != "удалить" && z != "удалить повтор" && z != "сортировка" && z != "запись" && z != "json" && z != "вывести")
                    {
                        Console.WriteLine("Режим не выбран. Повторите попытку.");
                        z = Console.ReadLine();
                    }

                    switch (z)
                    {

                        case "поиск по дате":

                            BirthSearch(ref students);
                            c = true;
                            break;
                        case "поиск по ФИО":

                            NameSearch(ref students);
                            c = true;

                            break;
                        case "мин/макс балл":

                            MinMax(ref students);
                            c = true;
                            break;
                        case "запись":
                            c = true;
                            AddNote(ref students);
                            break;
                        case "удалить повтор":
                            DoubleSearch(ref students);
                            c = true;
                            break;

                        case "удалить":
                            Delete(ref students);
                            c = true;
                            break;
                        case "сортировка":
                            OutputSortedDB(ref students);
                            c = true;
                            break;
                        case "json":
                            Json(ref students);
                            c = true;
                            break;
                        
                        case "выход":
                            c = false;
                            break;
                    }
                }
                        
            }
        }
    }

