using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    class Program
    {
        public static string GetPath(string path)
        {
            string deflt = Environment.CurrentDirectory;
            char[] separator = { ' ' };
            string[] arr = path.Split(separator, 2);
            if (arr[0] == "cd")
            {
                try
                {

                    string tmp = arr[1].Replace("/", @"\");
                    if (tmp.Contains("~"))
                    {
                        tmp = tmp.Replace("~", @"C:\Users\HONOR");
                        return tmp;
                    }

                    if (tmp[0] != '\\' && tmp[0] != 'C' && tmp[0] != 'D')
                        tmp = "/" + tmp;
                    if (tmp[0] == 'C')
                        return tmp;

                    if (tmp.Contains(".."))
                    {
                        string[] arr_tmp = tmp.Split('\\');
                        for (int i = 0; i < arr_tmp.Length; i++)
                        {

                            if (arr_tmp[i] == "/..")//&& i!= arr_tmp.Length-1)
                            {
                                tmp = (Path.GetFullPath(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).Replace("/", @"\");
                                Environment.CurrentDirectory = tmp;
                            }
                            else tmp += "/" + arr_tmp[i];


                        }
                        return tmp;
                    }

                    return Environment.CurrentDirectory + tmp;
                }
                catch (Exception)
                {
                    Console.WriteLine($"-bash: {path}: команда не найдена");
                    Environment.CurrentDirectory = deflt;
                }
                return "";
            }
            else return "";
        }

            public static string ShowPath(string path)
        {
            if (path == @"C:\Users\HONOR")
                return "~";
            
            else if (path == @"C:\")
                return "/";
            else
            {
                string[] tmp = path.Split('\\');
                return "/" + tmp[tmp.Length - 1];
            }
        }
        static void Main(string[] args)
        {
           
            string default_path = @"C:\Users\HONOR";
            Environment.CurrentDirectory = default_path;
            string prev_path = null;
           

            while (true)
            {
                Console.Write($"user@astra:{ShowPath(Environment.CurrentDirectory)}$ ");
                string com = Console.ReadLine();
                switch (com)
                {
                    case "cd":
                        break;
                    case "cd -":
                        if (prev_path == null)
                            Console.WriteLine($"-bash: {com}: Не задана переменная OLDPWD");
                        else Environment.CurrentDirectory= prev_path;
                        break;
                    case "cd ..":
                        try
                        {
                            prev_path = Environment.CurrentDirectory;
                            Environment.CurrentDirectory = Directory.GetParent(Environment.CurrentDirectory).ToString();
                        }
                        catch(NullReferenceException)
                        {
                            Environment.CurrentDirectory = @"C:\";
                        }
                        break;
                    case "cd ../":
                        prev_path = Environment.CurrentDirectory;
                        Environment.CurrentDirectory = Directory.GetParent(Environment.CurrentDirectory).ToString();
                        break;
                    case "cd ~":
                        prev_path = Environment.CurrentDirectory;
                        Environment.CurrentDirectory = default_path;
                        break;
                    case "cd /~":
                        prev_path = Environment.CurrentDirectory;
                        Environment.CurrentDirectory = default_path;
                        break;
                  case "cd --help":
                        Console.WriteLine("cd - changing the current directory\n\n" +
                            "SYNOPSIS\n\n" +
                            "cd[catalog]\n\n" +
                            "DESCRIPTION\n\n" +
                            "The cd command is used to make the specified directory current.\n" +
                            "If the directory is not specified, the value of the $HOME environment\n" +
                            "variable is used (usually this is the directory you get to immediately after logging in).\n" +
                            "If the directory is given a full route name, it becomes the current one.\n" +
                            "If the route name is incomplete, the cd command tries to find the directory\n " +
                            "using one of the route specified by the $CDPATH environment variable.\n" +
                            "The method of setting and semantics of this variable are the same as for $PATH.\n" +
                            "In relation to the new directory, you need to have the right to execute,\n" +
                            "which in this case is interpreted as a search permission.\n" +
                            "Since a separate process is created to execute each command,\n" +
                            "cd cannot be a regular command; it is recognized and executed by the shell.");
                        break;
                    default:
                        
                        string path = GetPath(com);
                        if (Directory.Exists(path))
                        {
                            prev_path = Environment.CurrentDirectory;
                            Environment.CurrentDirectory = path;
                           
                        }
                        else if (File.Exists(path))
                            Console.WriteLine($"-bash: {com}: Это не каталог");

                        else if (!Directory.Exists(path) && !File.Exists(path) && path!="")
                            Console.WriteLine($"-bash: {com}: Нет такого файла или каталога");
                        else if (path == "")
                            Console.WriteLine($"-bash: {com}: команда не найдена");

                        break;
                }
            }
        }
    }
}