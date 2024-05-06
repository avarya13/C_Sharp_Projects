using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Лабораторная_2._4
{
    class DB
    {
        public static void MinMax(ref Student[] students)
        {
            float min = students[0].AvgMark;
            float max = students[0].AvgMark;
            int imin = 0;
            int i;
            int imax = 0;
            for (i = 0; i < students.Length; i++)
            {
                if (min > students[i].AvgMark)
                {
                    min = students[i].AvgMark;
                    imin = i;
                }
            }
            Console.WriteLine("Минимальный балл:");
            students[imin].WriteInfo();

            for (i = 0; i < students.Length; i++)
            {
                if (max < students[i].AvgMark)
                {
                    max = students[i].AvgMark;
                    imax = i;
                }
            }
            Console.WriteLine("Максимальный балл:");
            students[imax].WriteInfo();
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
                    students[i].WriteInfo();
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

            for (int i = 0; i < students.Length; i++)
            {

                for (int j = 0; j < students.Length; j++)
                {


                    if (i != students.Length)
                    {

                        Del0(ref students, j, i, "id.txt", students[i].Id, ref names);
                        Del0(ref students, j, i, "names.txt", students[i].Full_Name, ref names);
                        Del0(ref students, j, i, "birth.txt", students[i].BirthDate, ref names);
                        Del0(ref students, j, i, "Inst.txt", students[i].Institute, ref names);
                        Del0(ref students, j, i, "group.txt", students[i].Group, ref names);
                        Del0(ref students, j, i, "course.txt", students[i].Course, ref names);
                        Del0(ref students, j, i, "mark.txt", students[i].AvgMark, ref names);


                        for (i = 0; i < students.Length; i++)
                        {
                            Array.Clear(students, j, 1);
                            
                        }

                    }

                    else if (i == students.Length - 1 && j == students.Length - 1)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Очищенная от повторов база данных:");
            for (int i = 0; i < students.Length; i++)
            {
                students[i].WriteInfo();
            }
        }

        public static void Del0(ref Student[] students, int j, int i, string file, int obj, ref string[] names)
        {
            if (names[i] == names[j] && i != j && i == 0)
            {
                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($"{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
            else if (names[i] == names[j] && i != j && i != 0)
            {

                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($";{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
        }

        public static void Del0(ref Student[] students, int j, int i, string file, string obj, ref string[] names)
        {
            if (names[i] == names[j] && i != j && i == 0)
            {
                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($"{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
            else if (names[i] == names[j] && i != j && i != 0)
            {

                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($";{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
        }

        public static void Del0(ref Student[] students, int j, int i, string file, DateTime obj, ref string[] names)
        {
            if (names[i] == names[j] && i != j && i == 0)
            {
                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($"{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
            else if (names[i] == names[j] && i != j && i != 0)
            {

                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($";{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
        }

        public static void Del0(ref Student[] students, int j, int i, string file, float obj, ref string[] names)
        {
            if (names[i] == names[j] && i != j && i == 0)
            {
                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($"{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
            else if (names[i] == names[j] && i != j && i != 0)
            {

                string tempPath = Path.GetTempFileName();
                using (var sw = new StreamWriter(tempPath))
                {
                    sw.Write($";{obj}");
                }

                File.Delete(file);
                File.Move(tempPath, file);
            }
        }


        public static void Del(ref Student[] students,int j, int i, string file, int obj)
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
                for ( i = 0; i < students.Length; i++)
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

        public static void Delete(ref Student[] students, int k)
        {
            string tempPath = Path.GetTempFileName();
            using (var sw = new StreamWriter(tempPath))
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (i != k)
                    {
                        sw.Write($";{students[i].Id}");
                    }
                    if ((i == 0 && i != k) || (i == 1 && k == 0))
                    {
                        sw.Write($"{students[i].Id}");
                    }
                    if (i != k && i != 0 && i != 1)
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
                    if (i != k)
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
                    if (i != k)
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
                    if (i != k)
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
                    if (i != k)
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
                    if (i != k)
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
                    if (i != k)
                    {
                        sw.Write($";{students[i].AvgMark}");
                    }
                }
            }
            File.Delete("mark.txt");
            File.Move(tempPath6, "mark.txt");

            

            for (int i = 0; i < students.Length; i++)
            {
                Array.Clear(students, i, 1);
            }


            for (int i = 0; i < students.Length; i++)
            {
                students[i].WriteInfo();
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

        public static void Note(ref Student[] students, string file, int content)
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
                Console.WriteLine("Введите последовательно через точку с запятой ИД, ФИО, дату рождения, институт, группу, курс, средний балл");
                string noteStr = Console.ReadLine();
                string[] note = noteStr.Split(';');
                    try
                {
                    Array.Resize(ref students, students.Length + 1);
                    int j = students.Length-1;
                    Note(ref students, "id.txt", int.Parse(note[0]));
                    Note(ref students, "names.txt", note[1]);
                    Note(ref students, "birth.txt", DateTime.Parse(note[2]));
                    Note(ref students, "Inst.txt", note[3]);
                    Note(ref students, "group.txt", note[4]);
                    Note(ref students, "course.txt", note[5]);
                    Note(ref students, "mark.txt", float.Parse(note[6]));
                    students[students.Length - 1].Id = int.Parse(note[0]);
                    students[students.Length - 1].Full_Name = note[1];
                    students[students.Length - 1].BirthDate = DateTime.Parse(note[2]);
                    students[students.Length - 1].Institute = note[3];
                    students[students.Length - 1].Group = note[4];
                    students[students.Length - 1].Course = note[5];
                    students[students.Length - 1].AvgMark = float.Parse(note[6]);
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
                students[i].WriteInfo();
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
                        Console.WriteLine("Выберите: мин/макс балл, сортировка, поиск по ФИО, поиск по дате, удалить, удалить повтор, запись");
                        string z = Console.ReadLine();
                        while (z != "мин/макс балл" && z != "сортировка" && z != "поиск по ФИО" && z != "поиск по дате" &&  z != "удалить" && z != "удалить повтор"  && z != "запись")
                        {
                            Console.WriteLine("Режим не выбран");
                            z = Console.ReadLine();
                        }

                        switch (z)
                        {

                            case "поиск по дате":

                                BirthSearch(ref students);

                                break;
                            case "поиск по ФИО":

                                NameSearch(ref students);

                                break;
                            case "мин/макс балл":

                                MinMax(ref students);

                                break;
                            case "запись":

                                AddNote(ref students);
                                break;
                            case "удалить повтор":
                                DoubleSearch(ref students);
                                break;

                            case "удалить":
                                Delete(ref students);
                                break;
                            case "сортировка":
                                OutputSortedDB(ref students);
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
