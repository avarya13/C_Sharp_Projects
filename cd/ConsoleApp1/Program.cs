using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    

class CdCommand
        {
            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Usage: cd <directory>");
                }
                else
                {
                    string path = args[0];
                    if (!Directory.Exists(path))
                    {
                        Console.WriteLine("Directory not found: {0}", path);
                        return;
                    }
                    Environment.CurrentDirectory = path;
                }
            Console.ReadKey();
            }
        }


     }
    

