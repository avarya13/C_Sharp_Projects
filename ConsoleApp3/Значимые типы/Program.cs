using System;

namespace Значимые_типы
{
    struct Pet
    {
        public string animal;
        public Pet(string animal)
        {
            this.animal = animal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pet p1 = new Pet("dog");
            Pet p2 = p1; // (1, 2)
            Console.Write(p1.animal + " ");
            Console.WriteLine(p2.animal);
            p1.animal = "cat";
            Console.Write(p1.animal + " ");
            Console.WriteLine(p2.animal);
            // p2.animal всё ещё равно "dog"
        }
    }
}
