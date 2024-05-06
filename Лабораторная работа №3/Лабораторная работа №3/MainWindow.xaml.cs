using System;
using System.Collections;
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

namespace Лабораторная_работа__3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
    public partial class MainWindow : Window
    {
        Stack app;
        private List<Personne> persons;
        ICollectionView cvPersonnes;

        public MainWindow()
        {
            InitializeComponent();
            

        persons = new List<Personne>();

        persons.Add(new Personne() { Id = 1, Nom = "Jean-Michel", Prenom = "BADANHAR" });
        persons.Add(new Personne() { Id = 1, Nom = "Gerard", Prenom = "DEPARDIEU" });
        persons.Add(new Personne() { Id = 1, Nom = "Garfild", Prenom = "THECAT" });
        persons.Add(new Personne() { Id = 1, Nom = "Jean-Paul", Prenom = "BELMONDO" });

        cvPersonnes = CollectionViewSource.GetDefaultView(persons);

        if (cvPersonnes != null)
        {
            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.ItemsSource = cvPersonnes;
            cvPersonnes.Filter = TextFilter;
        }
}
        public bool TextFilter(object o)
        {
            Personne p = (o as Personne);
            if (p == null)
                return false;

            if (p.Nom.Contains(textBox1.Text))
                return true;
            else
                return false;
        }
        internal class Program
        {

            
            
            
            
            
            
            
            
            
            
            
            
            //stack
            
                //queue
                /*public class Queue<T> : IEnumerable<T>
                {
                    Node<T> head; // головной/первый элемент
                    Node<T> tail; // последний/хвостовой элемент

                    int count;

                    // добавление в очередь
                    public void Enqueue(T data)
                    {
                        Node<T> node = new Node<T>(data);
                        Node<T> tempNode = tail;
                        tail = node;
                        if (count == 0)
                            head = tail;
                        else
                            tempNode.Next = tail;
                        count++;
                    }

                    // удаление из очереди
                    public T Dequeue()
                    {
                        if (count == 0)
                            throw new InvalidOperationException();
                        T output = head.Data;
                        head = head.Next;
                        count--;
                        return output;
                    }

                    // получаем первый элемент
                    public T First
                    {
                        get
                        {
                            if (IsEmpty)
                                throw new InvalidOperationException();
                            return head.Data;
                        }
                    }

                    // получаем последний элемент
                    public T Last
                    {
                        get
                        {
                            if (IsEmpty)
                                throw new InvalidOperationException();
                            return tail.Data;
                        }
                    }

                    public int Count
                    {
                        get { return count; }
                    }

                    public bool IsEmpty
                    {
                        get { return count == 0; }
                    }

                    public void Clear()
                    {
                        head = null;
                        tail = null;
                        count = 0;
                    }

                    public bool Contains(T data)
                    {
                        Node<T> current = head;
                        while (current != null)
                        {
                            if (current.Data.Equals(data))
                                return true;
                            current = current.Next;
                        }

                        return false;
                    }

                    IEnumerator IEnumerable.GetEnumerator()
                    {
                        return ((IEnumerable)this).GetEnumerator();
                    }

                    IEnumerator<T> IEnumerable<T>.GetEnumerator()
                    {
                        Node<T> current = head;
                        while (current != null)
                        {
                            yield return current.Data;
                            current = current.Next;
                        }
                    }
                    static void Main1(string[] args)
                    {
                        //queue
                        Queue<string> queue = new Queue<string>();
                        queue.Enqueue("Kate");
                        queue.Enqueue("Sam");
                        queue.Enqueue("Alice");
                        queue.Enqueue("Tom");

                        foreach (string item in queue)
                            Console.WriteLine(item);
                        Console.WriteLine();

                        Console.WriteLine();
                        string firstItem = queue.Dequeue();
                        Console.WriteLine($"Извлеченный элемент: {firstItem}");
                        Console.WriteLine();

                        foreach (string item in queue)
                            Console.WriteLine(item);
                    }

                    //deck
                    public class DoublyNode<T>
                    {
                        public DoublyNode(T data)
                        {
                            Data = data;
                        }

                        public T Data { get; set; }
                        public DoublyNode<T> Previous { get; set; }
                        public DoublyNode<T> Next { get; set; }
                    }

                    public class Deque<T> : IEnumerable<T> // двусвязный список
                    {
                        DoublyNode<T> head; // головной/первый элемент
                        DoublyNode<T> tail; // последний/хвостовой элемент
                        int count; // количество элементов в списке

                        // добавление элемента
                        public void AddLast(T data)
                        {
                            DoublyNode<T> node = new DoublyNode<T>(data);

                            if (head == null)
                                head = node;
                            else
                            {
                                tail.Next = node;
                                node.Previous = tail;
                            }

                            tail = node;
                            count++;
                        }

                        public void AddFirst(T data)
                        {
                            DoublyNode<T> node = new DoublyNode<T>(data);
                            DoublyNode<T> temp = head;
                            node.Next = temp;
                            head = node;
                            if (count == 0)
                                tail = head;
                            else
                                temp.Previous = node;
                            count++;
                        }

                        public T RemoveFirst()
                        {
                            if (count == 0)
                                throw new InvalidOperationException();
                            T output = head.Data;
                            if (count == 1)
                            {
                                head = tail = null;
                            }
                            else
                            {
                                head = head.Next;
                                head.Previous = null;
                            }

                            count--;
                            return output;
                        }

                        public T RemoveLast()
                        {
                            if (count == 0)
                                throw new InvalidOperationException();
                            T output = tail.Data;
                            if (count == 1)
                            {
                                head = tail = null;
                            }
                            else
                            {
                                tail = tail.Previous;
                                tail.Next = null;
                            }

                            count--;
                            return output;
                        }

                        public T First
                        {
                            get
                            {
                                if (IsEmpty)
                                    throw new InvalidOperationException();
                                return head.Data;
                            }
                        }

                        public T Last
                        {
                            get
                            {
                                if (IsEmpty)
                                    throw new InvalidOperationException();
                                return tail.Data;
                            }
                        }

                        public int Count
                        {
                            get { return count; }
                        }

                        public bool IsEmpty
                        {
                            get { return count == 0; }
                        }

                        public void Clear()
                        {
                            head = null;
                            tail = null;
                            count = 0;
                        }

                        public bool Contains(T data)
                        {
                            DoublyNode<T> current = head;
                            while (current != null)
                            {
                                if (current.Data.Equals(data))
                                    return true;
                                current = current.Next;
                            }

                            return false;
                        }

                        IEnumerator IEnumerable.GetEnumerator()
                        {
                            return ((IEnumerable)this).GetEnumerator();
                        }

                        IEnumerator<T> IEnumerable<T>.GetEnumerator()
                        {
                            DoublyNode<T> current = head;
                            while (current != null)
                            {
                                yield return current.Data;
                                current = current.Next;
                            }
                        }




                        //deck
                        static void Main2(string[] args)
                        {
                            Deque<string> usersDeck = new Deque<string>();
                            usersDeck.AddFirst("Alice");
                            usersDeck.AddLast("Kate");
                            usersDeck.AddLast("Tom");

                            foreach (string s in usersDeck)
                                Console.WriteLine(s);

                            string removedItem = usersDeck.RemoveFirst();
                            Console.WriteLine("\n Удален: {0} \n", removedItem);

                            foreach (string s in usersDeck)
                                Console.WriteLine(s);
                        }
                    }
                }
            }*/
        }
    }
    }




