using System;

namespace ConsoleApp1
{
    class Person
    {
        private string _name;
        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Person(string Name)
        {
            this.Name = Name;
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
    class Child : Person//производный класс
    {
        public Child (string Name):base(Name)
        {
            this.Name = Name;
        }
        public void Play()
        {
            Console.WriteLine("Ребенок играет");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("Vanya");
            //(person as Child).Play();

            Child c1 = new Child("Vanya");
            c1.Play();
            c1.Print();

        }
    }
}
