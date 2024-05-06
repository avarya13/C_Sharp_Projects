using System;
using System.Runtime;
using System.Collections.Generic;

namespace Library
{
    public static class MyLib
    {
        public static List<string> elements = new List<string>() { "banana", "apple", "raspberry", "nut", "pineapple", "melon" };
        public static List<string> Stack_list = new List<string>(Library.MyLib.elements.Count);
        public static List<string> Queue_list = new List<string>(Library.MyLib.elements.Count);
        public static void Add(Stack<string> stack)
       {
            
                stack.Push(elements[0]);
            if (Stack_list == null)
                Stack_list[0] = "zero";
            Stack_list.Add(elements[0]);
            elements.RemoveAt(0);
            //stack_dg.ItemsSource = stack_list;
            
        }

        public static void Add(Queue<string> queue)
        {
            queue.Enqueue(elements[0]);
            if (Queue_list == null)
                Queue_list[0] = "zero";
            Queue_list.Add(elements[0]);
            elements.RemoveAt(0);
            
        }

        public static void Delete(Stack<string> stack)
       {
            //if (stack.Count != 0)
            //{
                string header = stack.Peek();
                header = stack.Pop();
            Stack_list.RemoveAt(0);
            //}
            //else
            //throw new InvalidOperationException("Stack is empty");
        }

        public static void Delete(Queue<string> queue)
        {
            // if (queue.Count != 0)
            string first = queue.Dequeue();
            Queue_list.RemoveAt(queue.Count);

            //else
            //throw new InvalidOperationException("Stack is empty");
        }
        public static void Sort(List<string> elements)
        {
            elements.Sort();
        }

       /* public static void AddToList(List<string> elements)
        {
            string item = Console.ReadLine();
            elements.Add(item);
        }*/

        public static void DeleteFromList(List<string> elements)
        {
            string item = Console.ReadLine();
            elements.Remove(item);
        }

        /*public static void SearchInList(List<string> elements)
        {
            //string element = Console.ReadLine();
            //foreach (string item in elements)

            
        }*/
    }

}
