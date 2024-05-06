using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cd
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/home/user";
            string def_path = "/home/user";
            string def_win_path = @"home\user\";
            string path_sh = "~";
            string path_win = @"home\user\";
            string[] tmp;

            while (true)
            {
                
                //ArrayList path_arr = new ArrayList() { "/home","/user" };
                
                Console.Write($"user@astra:{path_sh}$ ");
                string com = Console.ReadLine();
                switch (com)
                {
                    case "cd":
                        break;
                    case "cd ..":
                        tmp = path.Split('/');
                        if (tmp[tmp.Length - 2] == "user")
                            path_sh = "~";
                        else if (tmp[tmp.Length - 2] == "")
                            path_sh = "/";
                        else path_sh = "/" + tmp[tmp.Length - 2];

                        path=path.Replace("/"+tmp[tmp.Length - 1], "");
                        break;
                    case "cd ~":
                        break;
                    case "cd --help":

                        break;
                    default:
                        tmp = com.Split('/');
                        if( Directory.Exists(path_win +@"\"  +tmp[1]))
                        {
                            string[] tmp_path = tmp[1].Split('/');
                            path_win +=  @"\" + tmp_path[tmp_path.Length - 1];
                            Directory.SetCurrentDirectory(path_win);
                            //path_win = def_win_path + tmp[1];

                            path_sh ="/"+ tmp_path[tmp_path.Length-1];
                        }
                        else
                            Console.WriteLine($"-bash: {com}: команда не найдена");
                        break;
                }
            }
            
        }
    }
}
