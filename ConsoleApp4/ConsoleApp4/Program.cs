using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Exam // класс
    {
        public string Name; // фамилия студента
        private int grade; // оценка, закрытое поле
        public int Grade //объявление свойства
        {
            get // аксессор чтения поля с преобразованием
            {
                if (grade < 5) // если оценка ниже 5, то выставляется 2
                    return 2;
                else
                    return (grade + 1) / 2; // иначе к оценке по 10-балльной шкале прибаляется 1 и полученное число делится на 2
            }
            set // аксессор записи в поле
            {
                if (value < 0)
                    grade = 0;
                else if (value > 10)
                    grade = 10;
                else
                    grade = value;
            }
        }
        public Exam(string name)  // конструктор класса
        {
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Exam ex = new Exam("Иванов");    // создание объекта
            ex.Grade = 7;//оценка по 10-балльной шкале
            // записываем в поле, используя аксессор set
            // читаем поле, используя аксессор get
            Console.WriteLine("В ведомость: {0}", ex.Grade); //перевод в 5-балльную шкалу
            Console.ReadKey();
            //результат - 4

        }
    }
}
