using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР3_Структуры_данных
{

   public class Student  
    {
        private string name;
        private string patronymic;
        private string surname;
        private int age;
        private string gender;
        private DateTime birth_date;
        private string group;
        private int course;
        private int math_ex;
        private int rus_ex;
        private int inf_ex;
        public string Name { get { return name; }  }
        public string Gender { get {return gender; } }
        public DateTime Birth_date { get { return birth_date; } }
        public string Patronymic { get { return patronymic; } }
        public string Surname { get { return surname; } }
        public int Age { get { return age; } set { value = age; } }
        public string Group { get { return group; } }
        public int Course { get { return course; } set { value = course; } }
        public int Math_ex { get { return math_ex; } }
        public int Rus_ex { get { return rus_ex; } }
        public int Inf_ex { get { return inf_ex; } }

        public Student(string surname,string name, string patronymic, int age, string gender, DateTime birth_date,string group, int course, int math_ex, int rus_ex, int inf_ex)
        {
            this.name = name;
            this.patronymic = patronymic;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.birth_date = birth_date;
            this.group = group;
            this.course = course;
            this.math_ex = math_ex;
            this.rus_ex = rus_ex;
            this.inf_ex = inf_ex;
        }
        public int NewCourse()
        {
           return course = course + 1;
        }

        public int NewAge(DateTime date)
        {
            return age++;
        }

        

        public override string ToString()
        {
            return course+ " курс: "+surname + " " +  name + " " + patronymic + "," + " " +birth_date.ToShortDateString() + "," + " " + age+ " лет" + "," + " " + group + "," + " "+ "ЕГЭ математика: "+math_ex + "," + " " + "ЕГЭ русский язык: " + rus_ex + "," + " " + "ЕГЭ информатика: " + inf_ex;
        }




        public class CompareCourses : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a != null && b != null)
                    return a.Course - b.Course;

                else if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else
                    return 1;



            }
        }
    }
    


    class Program
    {
        public static void DisplayAllCourses(List<Student> students,int year)
        {
            Student.CompareCourses comparer = new Student.CompareCourses();
            students.Sort(comparer);
            Console.WriteLine($"Students of {year}");
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }
        public static void NewYear(List<Student> students, List<Student> new_students,int year)
        {
            
            foreach (var item in students.ToArray())
            {
                item.NewCourse();
                item.NewAge(new DateTime(year,9,1));
                if (item.Course > 4)
                    students.Remove(item);
            }
            students.AddRange(new_students);
        }

        public static void FindBrothers(List<Student> students, List<Student> brothers)
        {


            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < students.Count; j++)
                {
                    if (i != j && students[i].Gender == "мужской" && students[j].Gender == "мужской" && Math.Abs(students[i].Age - students[j].Age) <= 4 && students[i].Surname == students[j].Surname && students[i].Patronymic == students[j].Patronymic && (!brothers.Contains(students[i])))
                    {
                        brothers.Add(students[i]);
                        brothers.Add(students[j]);
                    }
                }

            }
            Console.WriteLine("Братья");
            foreach (var item in brothers)
            {
               
                    Console.WriteLine( item);
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() { 
                new Student("Иванов", "Иван", "Иванович", 18, "мужской", new DateTime(2002, 3, 31), "БИВТ-20-1", 1, 84, 76, 92) ,
                new Student("Иванов", "Николай", "Иванович", 18, "мужской", new DateTime(2002, 3, 31), "БИСТ-20-1", 1, 84, 76, 92),
                new Student("Петрова", "Анастасия", "Игоревна", 18, "женский", new DateTime(2002, 2, 17), "БПИ-20-3", 1, 76,78, 84) ,

                new Student("Крылов", "Сергей", "Вячеславович", 19, "мужской", new DateTime(2001, 7, 1), "БИВТ-19-2", 2, 94, 80, 96) ,
                new Student("Сидорова", "Екатерина", "Анатольевна", 19, "женский", new DateTime(2001, 10, 5), "БИСТ-19-3", 2, 76, 70, 95),
                new Student("Коновалова", "Анна", "Игоревна", 19, "женский", new DateTime(2001, 5, 18), "БПИ-19-1", 2, 76, 98, 88),

                new Student("Наумов ", "Владислав", "Максимович", 20, "мужской", new DateTime(2000, 11, 1), "БИСТ-18-1", 3, 96, 100, 98),
                new Student("Рогова", "Кристина", "Анатольевна", 20, "женский", new DateTime(2000, 4, 15), "БИВТ-18-3", 3, 90, 94,85),
                new Student("Смирнов", "Иван", "Тимофеевич", 20, "мужской", new DateTime(2000, 7, 21), "БПИ-18-2", 3, 76, 80, 88),

                new Student("Кошелев", "Михаил", "Фёдорович", 21, "мужской", new DateTime(1999, 6, 14), "БИСТ-18-1", 4, 96, 100, 98),
                new Student("Румянцева ", "Виктория", "Михайловна", 21, "женский", new DateTime(1999, 4, 6), "БИВТ-17-3", 4, 84, 94,88),
                new Student("Смирнов", "Петр", "Тимофеевич", 21, "мужской", new DateTime(1999, 3, 21), "БПИ-17-1", 4, 92, 84, 86),

            };
            List<Student> brothers = new List<Student>();
            int year = 2020;

            FindBrothers(students, brothers);
            DisplayAllCourses(students,year);
            year++;
            
            NewYear(students, new List<Student> {
                new Student("Гончарова", "Александра", "Фёдоровна", 18, "женский", new DateTime(2004, 3, 1), "БИВТ-21-2", 1, 84, 96, 82),
                new Student("Зайцев", "Иван", "Леонидович", 18, "мужской", new DateTime(2004, 3, 30), "БИСТ-21-1", 1, 74, 76, 92),
                new Student("Ефремова", "Александра", "Романовна", 18, "женский", new DateTime(2004, 2, 28), "БПИ-21-2", 1, 76, 98, 84) }, year);
            DisplayAllCourses(students, year);

            year++;
            NewYear(students, new List<Student> {
                new Student("Крылова ", "Милана", "Артёмовна", 18, "женский", new DateTime(2005, 3, 1), "БИВТ-22-2", 1, 84, 96, 82),
                new Student("Зайцев", "Андрей", "Леонидович", 18, "мужской", new DateTime(2005, 3, 30), "БИСТ-22-1", 1, 74, 76, 92),
                new Student("Ефремов", "Дмитрий", "Романович", 18, "мужской", new DateTime(2005, 2, 28), "БПИ-22-2", 1, 76, 98, 84) }, year);
            DisplayAllCourses(students, year);

            year++;
            NewYear(students, new List<Student> {
                new Student("Калинина ", "Кира", "Викторовна", 18, "женский", new DateTime(2006, 3, 1), "БИВТ-23-2", 1, 84, 96, 82),
                new Student("Бычков", "Александр ", "Андреевич", 18, "мужской", new DateTime(2006, 3, 30), "БИСТ-23-1", 1, 74, 76, 92),
                new Student("Васильева", "София", "Романовна", 18, "женский", new DateTime(2006, 2, 28), "БПИ-23-2", 1, 76, 98, 84) }, year);
            DisplayAllCourses(students, year);

            year++;
            NewYear(students, new List<Student> {
                new Student("Розанова ", "Анастасия", "Максимовна", 18, "женский", new DateTime(2007, 3, 1), "БИВТ-24-2", 1, 84, 96, 82),
                new Student("Васильев", "Марк ", "Владиславович", 18, "мужской", new DateTime(2007, 3, 30), "БИСТ-24-1", 1, 74, 76, 92),
                new Student("Беляева", "Алина", "Никитична", 18, "женский", new DateTime(2007, 2, 28), "БПИ-24-2", 1, 76, 98, 84) }, year);
            DisplayAllCourses(students, year);

            Console.ReadKey();
        }
    }
}
