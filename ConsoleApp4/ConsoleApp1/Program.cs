using System;

namespace Полиморфизм
{

    abstract class Shape //базовый абстрактный класс
    {
        public abstract void Calculate(float widht, float height, float s);//абстрактный метод для расчета площади

    }

    class Rectangle : Shape //класс прямоугольник
    {
        public override void Calculate(float widht, float height, float s)//переопределенный метод
        {
            //поиск площади прямоугольника и вывод результата 
            s = widht * height;
            Console.WriteLine(s);
        }
    }

    class Triangle : Shape // класс треугольник
    {
        public override void Calculate(float widht, float height, float s)//переопределенный метод
        {
            //поиск площади треугольника и вывод результата
            s = widht * height / 2;
            Console.WriteLine(s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            float s = 0; //начальное значение площади
                         //экземпляры классов
            Rectangle rc = new Rectangle();
            Triangle tr = new Triangle();
            //вызов методов
            rc.Calculate(1, 2, s);
            tr.Calculate(3, 4, s);
            Console.ReadKey();
        }
    }
}
