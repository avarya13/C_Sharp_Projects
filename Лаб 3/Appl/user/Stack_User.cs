using System;
using System.Collections;
using System.Collections.Generic;

namespace Appl.user
{
    public class Stack_User
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

                Node<T> temp = head;
                try
                {

                    head = head.Next; // переустанавливаем верхушку стека на следующий элемент
                    count--;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
    }
}
