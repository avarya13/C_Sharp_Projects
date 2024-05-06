using System;

namespace ConsoleApp3
{
    public class Complex  //производный класс, алгебраическая форма
    {
        public double Real { get; set; } //действительная часть комплексного числа
        public double Image { get; set; } //мнимая часть комплексного числа

        public Complex(double r, double im) //конструтор
        {
            Real = r;
            Image = im;
        }

        //Переопределение метода ToString();
        public override string ToString()
        {
            if (Image >= 0)
                return string.Format("{0:f2}+{1:f2}*i", Real, Image);
            else
                return string.Format("{0:f2}-{1:f2}*i", Real, Math.Abs(Image));
        }

        //Перегрузка оператора "+" для двух комплексных чисел
        public static Complex operator +(Complex a1, Complex a2)
        {
            return new Complex(a1.Real + a2.Real, a1.Image + a2.Image);
        }

        //Перегрузка оператора "-" для двух комплексных чисел
        public static Complex operator -(Complex a1, Complex a2)
        {
            return new Complex(a1.Real - a2.Real, a1.Image - a2.Image);
        }

        public static Complex Sum(Complex c1, Complex c2) //сумма (операция выполнятеся только для алгебраической формы записи)
        {

            return c1 + c2;
        }
        public static Complex Subtract(Complex c1, Complex c2) //разность (операция выполнятеся только для алгебраической формы записи)
        {

            return c1 - c2;
        }
        

    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(1,2);
            Complex b = new Complex(3, 4);
            Console.WriteLine(Complex.Sum(a, b));
            Console.WriteLine(Complex.Subtract(a, b));
        }
    }
}
