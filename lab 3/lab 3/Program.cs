using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class Program
    {
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }

        public class NodeStack<T> : IEnumerable<T>
        {
            Node<T> head;
            int count;

            public bool IsEmpty
            {
                get { return count == 0; }
            }
            public int Count
            {
                get { return count; }
            }

            public void Push(T item)
            {
                // увеличиваем стек
                Node<T> node = new Node<T>(item);
                node.Next = head; // переустанавливаем верхушку стека на новый элемент
                head = node;
                count++;
            }
            public T Pop()
            {
                // если стек пуст, выбрасываем исключение
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                Node<T> temp = head;
                head = head.Next; // переустанавливаем верхушку стека на следующий элемент
                count--;
                return temp.Data;
            }
            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                return head.Data;
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
        }




        public class Queue<T> : IEnumerable<T>
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
        }


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
                public static void Menu()
                {
                    string l = Console.ReadLine();
                    switch (l)
                    {
                        case "stack":
                            NodeStack<string> stack = new NodeStack<string>();
                            stack.Push("Tom");
                            stack.Push("Alice");
                            stack.Push("Bob");
                            stack.Push("Kate");

                            foreach (var item in stack)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine();
                            string header = stack.Peek();
                            Console.WriteLine($"Верхушка стека: {header}");
                            Console.WriteLine();

                            header = stack.Pop();
                            foreach (var item in stack)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case "queue":
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
                            break;
                        case "deck":
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
                            break;

                    }
                }

            }
        public static void Main(string[] args)
        {
            Console.WriteLine("Выбор режима");
            string l = Console.ReadLine();
            switch (l)
            {

                case "stack":
                    NodeStack<string> stack = new NodeStack<string>();
                    stack.Push("Tom");
                    stack.Push("Alice");
                    stack.Push("Bob");
                    stack.Push("Kate");

                    foreach (var item in stack)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    string header = stack.Peek();
                    Console.WriteLine($"Верхушка стека: {header}");
                    Console.WriteLine();

                    header = stack.Pop();
                    foreach (var item in stack)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "queue":
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
                    break;
                case "deck":
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
                    break;

            }
            Console.ReadKey();
        }
    }
    }

