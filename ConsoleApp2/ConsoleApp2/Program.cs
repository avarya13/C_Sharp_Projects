using System;

namespace ConsoleApp2
{
    class Person //базовый класс
    {
        private string _name ;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
    class Employee : Person //производный класс
    {
        public void Job()
        {
            Console.WriteLine("Сотрудник работает");
        }
    }
    class Student : Person//производный класс
    {
        public void Study()
        {
            Console.WriteLine("Студент учится");
        }
    }
    class Child : Person//производный класс
    {
        public void Play()
        {
            Console.WriteLine("Ребенок играет");
        }
    }
    class Program
    {
        static void Main()
        {
            Child p1 = new Child();
            p1.Name = "Ivan";//экземпляру производного класса доступно свойство базового класса
            Employee p2 = new Employee();
            p2.Name = "Maria";
            p1.Print();//экземпляру производного класса доступен метод базового класса
            p2.Print(); 
            Student p3 = new Student();
            p3.Study();//у экземляра производного класса есть собственный метод, который доступен только ему

        }
    }
}

