using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin_Tree
{
    public class Node<T> : IComparable<T>
    where T : IComparable<T>
    {

        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public int CompareTo(T obj)
        {
            return Data.CompareTo(obj);

        }

        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }


        public override string ToString()
        {
            return Data.ToString();
        }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {

                if (Left == null)
                {
                    Left = node;

                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }




    }




    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public int Count { get; private set; }


        public void Add(T data)
        {

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;
        }




        //public void Display(Node<T> node)
        //{
        //    if (node == null) return;
        //    Console.WriteLine(node.Left);
        //    listForPrint.Add(node);
        //    Console.WriteLine(node + " ");
        //    if (node.Right != null)
        //        Display(node.Right);
        //}



        public IEnumerable<T> Inorder()
        {
            if (Root == null) yield break;

            var stack = new Stack<Node<T>>();
            var node = Root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Data;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public bool Contains(T data)
        {
            if (data == null) return false;
            else
                return Contains(Root, data);
        }

        public bool Contains(Node<T> current, T data)
        {
            if (current == null) return false;
            else
            {
                if (data.CompareTo(current.Data) == 0) return true;
                //else if (current == null) return false;
                else if (data.CompareTo(current.Data) == -1)
                {
                    return Contains(current.Left, data);
                }
                else
                {
                    return Contains(current.Right, data);
                }
            }
        }



        public void Remove(T data)
        {

            Node<T> node = new Node<T>(data);
            if (!this.Contains(data))
                return;
            else
            {


                if (node.Left.Data != null && node.Right.Data == null)
                {
                    node.Data = node.Left.Data;
                    node.Left.Data = default(T);
                }
                else if (node.Left.Data.CompareTo(data) != 0 && node.Right.Data.CompareTo(data) == 0 && node.Right.Left.Data.CompareTo(data) != 0)
                {
                    node.Data = node.Right.Data;
                    node.Right.Data = default(T);
                }
                else if (node.Left.Data.CompareTo(data) != 0 && node.Right.Data.CompareTo(data) == 0 && node.Right.Left.Data.CompareTo(data) == 0)
                {
                    node.Data = node.Right.Left.Data;
                    node.Right.Left.Data = default(T);
                }

                node.Data = default(T);

            }
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
                BinaryTree<int> tree = new BinaryTree<int>();
                tree.Add(5);
                tree.Add(3);
                tree.Add(7);
                tree.Add(1);
                tree.Add(2);
                tree.Add(8);
                tree.Add(6);
                tree.Add(9);
                tree.Add(10);
                foreach (var i in tree)
                    Console.WriteLine(i + " ");
                Console.WriteLine();
                Console.WriteLine("Наличие элемента {0} в дереве: {1}", 5, tree.Contains(5));
                Console.WriteLine("Наличие элемента {0} в дереве: {1}", 15, tree.Contains(15));
                Console.WriteLine("Наличие элемента {0} в дереве: {1}", 10, tree.Contains(10));
                Console.WriteLine("Наличие элемента {0} в дереве: {1}", 100, tree.Contains(100));

                Console.ReadKey();
            }
        }
    
}