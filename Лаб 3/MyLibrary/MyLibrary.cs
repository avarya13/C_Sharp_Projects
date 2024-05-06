using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLibrary
{
    
    public class MyLibrary 
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string stack_txt;
        public string Stack_txt
        {
            get { return stack_txt; }
            set { stack_txt = value; }
        }

        private string queue_txt;
        public string Queue_txt
        {
            get { return queue_txt; }
            set { queue_txt = value; }
        }
        public static List<MyLibrary> elements = new List<MyLibrary>() { new MyLibrary { Text = "banana" }, new MyLibrary { Text = "apple" }, new MyLibrary { Text = "melon" }, new MyLibrary { Text = "raspberry" }, new MyLibrary { Text = "avocado " }, new MyLibrary { Text = "grapefruit" }, new MyLibrary { Text = "plum " }, new MyLibrary { Text = "papaya " }, new MyLibrary { Text = "kiwi" }, new MyLibrary { Text = "orange" }, new MyLibrary { Text = "grape" }, new MyLibrary { Text = "cherry" } };
       
        public static void Add(Stack<MyLibrary> Stack_list)
        {

            Stack_list.Push(elements[0]);
           
            elements.RemoveAt(0);
           
        }

        public static void Add(Queue<MyLibrary> queue)
        {
            queue.Enqueue(elements[0]);
            
            List<MyLibrary> Queue_list = new List<MyLibrary>{new MyLibrary { Queue_txt = Convert.ToString(elements[0]) }};
        Queue_list.Add(Queue_list[Queue_list.Count-1]);
            elements.RemoveAt(0);

        }

        public static void Delete(Stack<MyLibrary> stack)
        {
           
            MyLibrary header = stack.Peek();
            header = stack.Pop();
            elements.RemoveAt(0);
            
        }

      

        public static void Delete(Queue<MyLibrary> queue)
        {
            // if (queue.Count != 0)
            MyLibrary first = queue.Dequeue();
            elements.Remove(first);
        }

        //public List<string> Log_str = new List<string>();//14
        private string strlog;//14
        public string StrLog { get { return strlog; } set { strlog = value; } }//14
    }
}



        




       
    

