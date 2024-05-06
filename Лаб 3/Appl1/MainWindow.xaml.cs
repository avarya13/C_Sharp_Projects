using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using NLog;
using Appl1.Helper;
using NLog.Config;
using NLog.Targets.Wrappers;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Appl1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView cvsTasks;
        public MainWindow()
        {
            InitializeComponent();
            cvsTasks = CollectionViewSource.GetDefaultView(MyLibrary.MyLibrary.elements);
            try
            {
                if (cvsTasks != null)
                {
                    data1.ItemsSource = cvsTasks;
                    logger.Debug("DataGrid привязан к cvsTasks");
                    cvsTasks.Filter = TextFilter;
                    data1.AutoGenerateColumns = false;
                }
            }
            catch
            {
                logger.Error("DataGrid НЕ привязан к cvsTasks");
            }
            
        }
        public bool TextFilter(object o)
        {
            MyLibrary.MyLibrary p = o as MyLibrary.MyLibrary;
            if (p == null)
                return false;

            if (p.Text.Contains(textBox1.Text))
                return true;
            else
                return false;


        }


        Stack<MyLibrary.MyLibrary> stack = new Stack<MyLibrary.MyLibrary>();
        Queue<MyLibrary.MyLibrary> queue = new Queue<MyLibrary.MyLibrary>();
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                data.ItemsSource = MyLibrary.MyLibrary.elements;
                logger.Debug("DataGrid привязан к MyLibrary.MyLibrary.elements");
            }
            catch
            {
                logger.Error("DataGrid НЕ привязан к MyLibrary.MyLibrary.elements");
            }
        }

        private void Stack_Loaded(object sender, RoutedEventArgs e)
        { 
            try
            {
                stack_list.ItemsSource = stack;
                logger.Debug("DataGrid привязан к stack");
            }
            catch
            {
                logger.Error("DataGrid НЕ привязан к stack");
            }
        }

        private void Queue_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                queue_list.ItemsSource = queue;
                logger.Debug("DataGrid привязан к queue");
            }
            catch
            {
                logger.Error("DataGrid НЕ привязан к queue");
            }
            
        }
        private void AddToStack(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyLibrary.MyLibrary.elements.Count == 0)
                {
                    MessageBox.Show("The data to fill in has run out");
                    logger.Debug("Список MyLibrary.MyLibrary.elements, данные которого используются для заполнения стека, пустой");
                    logger.Warn("Для продожения сеанса необходимо добавить элементы в MyLibrary.MyLibrary.elements");
                }
                else if (MyLibrary.MyLibrary.elements.Count != 0)
                {
                    MyLibrary.MyLibrary.Add(stack);
                    logger.Debug("Список elements, идет добавление элемента в стек");
                    logger.Info($"Элемент успешно добавлен в стек, количество элементов - {stack.Count}");

                }
            }
            catch
            {
                logger.Error("Элемент НЕ добавлен в стек");
            }
            
            
        }
        private void DeleteFromStack(object sender, RoutedEventArgs e)
        {
            try
            {
                if (stack.Count == 0)
                {
                    MessageBox.Show("stack is empty");
                    logger.Debug("Список MyLibrary.MyLibrary.elements, данные которого используются для заполнения стека, пустой");
                    logger.Warn("Для продожения работы со стеком необходимо добавить элементы в MyLibrary.MyLibrary.elements");
                }
                else
                {
                    MyLibrary.MyLibrary.Delete(stack);
                    logger.Debug("Стек не пустой, идет удаление элемента");
                    logger.Info("Элемент успешно удален из стека");

                }
            }
            catch
            { logger.Error("Элемент НЕ удален из стека"); }
            
            
            
        }

        private void AddToQueue(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyLibrary.MyLibrary.elements.Count == 0)
                {
                    MessageBox.Show("The data to fill in has run out");
                    logger.Debug("Список MyLibrary.MyLibrary.elements, данные которого используются для заполнения очереди, пустой");
                    logger.Warn("Для продожения сеанса необходимо добавить элементы в MyLibrary.MyLibrary.elements");
                }

                else
                {
                    MyLibrary.MyLibrary.Add(queue);
                    logger.Info("Элемент успешно добавлен в очередь");
                    logger.Debug("Метод AddToQueue(object sender, RoutedEventArgs e) выполнен");
                }
            }
            catch
            { logger.Error("Элемент НЕ добавлен в очередь"); }
            
        }

        private void DeleteFromQueue(object sender, RoutedEventArgs e)
        {
            try
            {
                if (queue.Count == 0)
                {
                    MessageBox.Show("queue is empty");
                    logger.Debug("Список м, данные которого используются для заполнения стека, пустой");
                    logger.Warn("Для продожения работы с очередью необходимо добавить элементы в MyLibrary.MyLibrary.elements");
                }
                else
                {
                    MyLibrary.MyLibrary.Delete(queue);
                    logger.Debug("Очередь не пустая, идет удаление элемента");
                    logger.Info("Элемент успешно удален из очереди");
                }
            }
            catch
            { logger.Error("Элемент НЕ удален из очереди"); }
            
        }



        

        private Logger logger = LogManager.GetCurrentClassLogger();

        public string strlog;
        public string StrLog { get { return strlog; } set { strlog = value; } }

            public void Log(object sender, RoutedEventArgs e)
            {
                Logger log = LogManager.GetCurrentClassLogger();
            }

        }
    }

        
       
    



        
