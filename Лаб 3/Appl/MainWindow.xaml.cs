using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Appl.user;
//using Stack_Queue_Deck;

namespace Appl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack_User.NodeStack<string> stack = new Stack_User.NodeStack<string>();
        //BindingList<string> stack_list;
        
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
       public static List<string> elements = new List<string>() { "banana", "apple", "raspberry", "nut", "pineapple", "melon" };
        List<string> stack_list = new List<string>(elements.Count);
        List<string> queue_list = new List<string>(elements.Count);
        List<string> list_settings = new List<string>(elements.Count);
        private void AddToStack(object sender, RoutedEventArgs e)
         {
            if (elements.Count == 0)
                MessageBox.Show("The data to fill in has run out");
            else
            {
                stack.Push(elements[0]);
                if (stack_list == null)
                    stack_list[0] = "zero";
                stack_list.Add(elements[0]);
                elements.RemoveAt(0);
                //stack_dg.ItemsSource = stack_list;
                for (int i = 0; i < stack_list.Count; i++)
                {
                    MessageBox.Show(Convert.ToString($"\nЭлемент {i + 1}: {stack_list[i]}"));

                }
            }
                
            
        }

         private void DeleteFromStack(object sender, RoutedEventArgs e)
         {
            try
            {
                //stack_dg.ItemsSource = stack;
                string header = stack.Peek();
                header = stack.Pop();
                stack_list.Remove(header);
                for (int i = 0; i < stack_list.Count; i++)
                {
                    MessageBox.Show(Convert.ToString($"\nЭлемент {i+1}: {stack_list[i]}"));
                }
                if (stack.IsEmpty)
                {
                    MessageBox.Show("stack is empty"); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("stack is empty" + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

         Queue_User.Queue<string> queue = new Queue_User.Queue<string>();
         private void AddToQueue(object sender, RoutedEventArgs e)
         {
            if (elements.Count == 0)
                MessageBox.Show("The data to fill in has run out");
            else
            {
                queue.Enqueue(elements[0]);
            
            if (queue_list == null)
                queue_list[0] = "zero";
            queue_list.Add(elements[0]);
             elements.RemoveAt(0);
                //queue_dg.ItemsSource = queue_list;
                for (int i = 0; i < queue_list.Count; i++)
                {
                    MessageBox.Show(Convert.ToString($"\nЭлемент {i + 1}: {queue_list[i]}"));
                    
                }
            }
            }

         private void DeleteFromQueue(object sender, RoutedEventArgs e)
         {
             //queue_dg.ItemsSource = queue;
             //if (queue.IsEmpty)
                // MessageBox.Show("queue is empty");
            try
            {
                string first = queue.Dequeue();
                queue_list.Remove(first);
                for (int i = 0; i < queue_list.Count; i++)
                {
                    MessageBox.Show(Convert.ToString($"\nЭлемент {i+1}: {queue_list[i]}"));
                }
                if (queue.IsEmpty)
                {
                    MessageBox.Show("queue is empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("queue is empty" + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

         Deck_User.Deque<string> deque = new Deck_User.Deque<string>();
        private void AddFirst(object sender, RoutedEventArgs e)
        {
            if (elements.Count == 0)
                MessageBox.Show("The data to fill in has run out");
            else
            {
                deque.AddFirst(elements[0]);
            if (list_settings == null)
                    list_settings[0] = "zero";
                list_settings.Add(elements[0]);
            elements.RemoveAt(0);
                //deque_dg.ItemsSource = deque_list;
                for (int i = 0; i < list_settings.Count; i++)
                {
                    MessageBox.Show(Convert.ToString($"\nЭлемент {i + 1}: {list_settings[i]}"));
                }
            }

            }
        private void AddLast(object sender, RoutedEventArgs e)
        {
            if (elements.Count == 0)
                MessageBox.Show("The data to fill in has run out");
            else
            {
                deque.AddLast(elements[0]);
            if (list_settings == null)
                    list_settings[0] = "zero";
                list_settings.Insert(0, elements[0]);
            elements.RemoveAt(0);
            deque_dg.ItemsSource = list_settings;
                for (int i = 0; i < list_settings.Count; i++)
                {
                    MessageBox.Show(Convert.ToString($"\nЭлемент {i + 1}: {list_settings[i]}"));
                }
            }
        }

        private void RemoveFirst(object sender, RoutedEventArgs e)
        {

            string removed = deque.RemoveFirst();
            list_settings.Remove(removed);
            for (int i = 0; i < list_settings.Count; i++)
            {
                MessageBox.Show(Convert.ToString($"\nЭлемент {i+1}: {list_settings[i]}"));
            }
            if (deque.IsEmpty)
            {
                MessageBox.Show("deque is empty");
            }

        }

        private void RemoveLast(object sender, RoutedEventArgs e)
        {
            string removed = deque.RemoveLast();
            list_settings.Remove(removed);
            for (int i = 0; i < list_settings.Count; i++)
            {
                MessageBox.Show(Convert.ToString($"\nЭлемент {i+1}: {list_settings[i]}"));
            }
            if (deque.IsEmpty)
            {
                MessageBox.Show("deque is empty");
            }

        }

         
    }
}
