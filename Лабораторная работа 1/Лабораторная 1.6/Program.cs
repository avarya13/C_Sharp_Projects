using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Laboratornaya1._2;
using Laboratornaya1._3;
using Лабораторная1._4;

namespace Лабораторная_1._6
{
    class Program
    {
        public static void Menu()
        {
            bool c = true;
            while (c==true)
            {
                Console.WriteLine("Выбор режима");
                string l = Console.ReadLine();
                while (l != "t1" && l != "t2" && l != "t3")
                {
                    Console.WriteLine("Задание не найдено");
                    l = Console.ReadLine();
                }
                switch (l)
                { 
                    case "t1":
                            Console.WriteLine("Ввод с клавиатуры или считывание из файла?");
                            string s = Console.ReadLine();
                            while (s != "fl" && s != "kb")
                            {
                                Console.WriteLine("Режим не найден. Введите fl или kb");
                                s = Console.ReadLine();

                            }
                        switch (s)
                        {
                            case "kb":

                                Задание1.Mass1();
                                break;

                            case "fl":

                                Задание1.Read();
                                break;
                        }
                                break;
                         
                    case "t2":
                        
                            Console.WriteLine("Ввод с клавиатуры или считывание из файла?");
                            s = Console.ReadLine();
                            while (s != "fl" && s != "kb")
                            {
                                Console.WriteLine("Режим не найден. Введите fl или kb");
                                s = Console.ReadLine();

                            }
                        switch (s)
                        {
                            case "kb":

                                Задание2.Mass1();
                                Задание2.Output(Задание2.array1, Задание2.count1, Задание2.count2);
                                Задание2.Max(Задание2.array1);
                                Задание2.Min(Задание2.array1);
                                Задание2.Mass2();
                                Задание2.Output(Задание2.array2, Задание2.count3, Задание2.count4);
                                Задание2.MatrixOperations(Задание2.array1, Задание2.array2);
                                break;

                            case "fl":

                                Задание2.Read();
                                break;
                        }       
                                    break;
                            
                    case "t3":
                        
                            Console.WriteLine("Ввод с клавиатуры или считывание из файла?");
                            s = Console.ReadLine();
                            while (s != "fl" && s != "kb")
                            {
                                Console.WriteLine("Режим не найден. Введите fl или kb");
                                s = Console.ReadLine();

                            }
                        switch (s)
                        {
                            case "kb":

                                Задание3.Mass();
                                Задание3.Output(Задание3.array3, Задание3.count0);
                                Задание3.Max(Задание3.array3);
                                Задание3.Min(Задание3.array3);
                                Задание3.RandomMember(Задание3.array3);
                                Задание3.NewArray(Задание3.array3);
                                break;

                            case "fl":

                                Задание3.Read();
                                break;
                        }       
                                    break;
                        }
                Console.WriteLine("Остановить работу приложения?");
                string d = Console.ReadLine();
                while (d != "да" && d != "нет")
                {
                    Console.WriteLine("Режим не выбран");
                    d = Console.ReadLine();
                }
                switch (d)
                {
                    case "да":
                        c =false;
                        break;
                    case "нет":
                        c = true;
                        break;
                }
                }

                }
                static void Main(string[] args)
                {
                    Menu();
                    Console.ReadKey();
                }
            }
        }
    
