using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        public class TreeNode
        {
            private Node _root;

            public Node Root { get => _root; set => _root = value; }

            public Node AddNode(int inputDataNode, Node root)
            {
                if (root == null)
                {
                    root = new Node(inputDataNode);
                }
                else
                {
                    if (inputDataNode < root.Data)
                    {
                        root.Left = AddNode(inputDataNode, root.Left);
                    }
                    else
                    {
                        root.Right = AddNode(inputDataNode, root.Right);
                    }
                }

                return root;
            }
            //public bool Contains(int data)
            //{
            //    if (data == 0) return false;
            //    else
            //        return Contains(data,Root);
            //}

            public bool Contains(int data,Node current )
            {
                if (current == null) return false;
                else
                {
                    if (data.CompareTo(current.Data) == 0) return true;
                    //else if (current == null) return false;
                    else if (data.CompareTo(current.Data) == -1)
                    {
                        return Contains(data, current.Left);
                    }
                    else
                    {
                        return Contains(data, current.Right);
                    }
                }
            }


            //public Node FindElement(int findData, Node root)
            //{
            //    if (root == null || findData == root.Data)
            //        return root;
            //    else if (root.Data < findData)
            //        return FindElement(findData, root.Left);
            //    else
            //        return FindElement(findData, root.Right);
            //}
           
            public Node Minimum(Node root)
            {
                if (root != null)
                {
                    if (root.Left != null) root = Minimum(root.Left);
                }
                return root;
            }

            public Node DeleteNode(int deleteData, Node root)
            {
                if (root == null)
                    return root;
                if (deleteData < root.Data)
                {
                    root.Left = DeleteNode(deleteData, root.Left);
                }
                else if (deleteData > root.Data)
                {
                    root.Right = DeleteNode(deleteData, root.Right);
                }
                else if (root.Left != null && root.Right != null)
                {
                    root.Data = Minimum(root.Right).Data;
                    root.Right = DeleteNode(root.Data, root.Right);
                }
                else if (root.Left != null)
                {
                    return root.Left;
                }
                else
                {
                    return root.Right;
                }

                return root;

            }

            public void PrintTree(int x, int y, Node root, int delta = 0)
            {
                if (root != null)
                {
                    if (delta == 0) delta = x / 2;
                    Console.SetCursorPosition(x, y);
                    Console.Write(root.Data);
                    PrintTree(x - delta, y + 3, root.Left, delta / 2);
                    PrintTree(x + delta, y + 3, root.Right, delta / 2);
                }

            }

            public void ClearTree()
            {
                _root = null;
            }

            public int CountElements(Node root)
            {
                if (root == null)
                    return 0;
                else
                {
                    int count = 0;
                    count += CountElements(root.Left);
                    count += CountElements(root.Right);

                    return count + 1;
                }
            }

          
            public bool IsEmpty()
            {
                return _root == null ? true : false;
            }

        }

        public class Node
        {
            private int _data;
            private Node _left;
            private Node _right;

            public Node()
            {
            }

            public Node(int inputDataNode)
            {
                Data = inputDataNode;
            }
            

            public Node(int data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }

            public int Data { get => _data; set => _data = value; }
            public Node Left { get => _left; set => _left = value; }
            public Node Right { get => _right; set => _right = value; }
        }
    

        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode();

            tree.Root = tree.AddNode(9, tree.Root);
            tree.Root = tree.AddNode(0, tree.Root);
            tree.Root = tree.AddNode(44, tree.Root);
            tree.Root = tree.AddNode(45, tree.Root);
            tree.Root = tree.AddNode(6, tree.Root);
            tree.Root = tree.AddNode(10, tree.Root);
            tree.Root = tree.AddNode(-7, tree.Root);
            tree.Root = tree.AddNode(-12, tree.Root);
            tree.Root = tree.AddNode(-1, tree.Root);
            tree.Root = tree.AddNode(5, tree.Root);
            tree.Root = tree.AddNode(8, tree.Root);
            tree.Root = tree.AddNode(4, tree.Root);
            tree.Root = tree.AddNode(6, tree.Root);
            tree.Root = tree.AddNode(9, tree.Root);
            tree.Root = tree.AddNode(20, tree.Root);
            
            tree.Root = tree.AddNode(-1, tree.Root);
            tree.Root = tree.AddNode(-5, tree.Root);
            tree.Root = tree.AddNode(8, tree.Root);
            tree.Root = tree.AddNode(19, tree.Root);
            tree.PrintTree(Console.WindowWidth / 2, 0, tree.Root);
            tree.DeleteNode(6, tree.Root);
            tree.PrintTree(Console.WindowWidth / 2, 0, tree.Root);


            //while (Console.ReadLine() != "s")
            //{
            //    try
            //    {
            //        if (Console.ReadLine() != "s")
            //        {
            //            tree.Root = tree.AddNode(int.Parse(Console.ReadLine()), tree.Root);
            //        }
            //        else break;
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Ошибка ввода!");
            //    }
            //}
            //tree.PrintTree(Console.WindowWidth / 2, 0, tree.Root);


            //tree.Root = tree.AddNode(45, tree.Root);
            //tree.Root = tree.AddNode(0, tree.Root);
            //tree.Root = tree.AddNode(-44, tree.Root);
            //tree.Root = tree.AddNode(48, tree.Root);
            //tree.Root = tree.AddNode(46, tree.Root);
            //tree.Root = tree.AddNode(130, tree.Root);
            //tree.Root = tree.AddNode(-17, tree.Root);
            //tree.Root = tree.AddNode(-1, tree.Root);
            //tree.Root = tree.AddNode(-31, tree.Root);
            //tree.Root = tree.AddNode(5, tree.Root);
            //tree.Root = tree.AddNode(-45, tree.Root);
            //tree.PrintTree(Console.WindowWidth / 4, 0, tree.Root);

            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Количество элементов:");
            Console.WriteLine(tree.CountElements(tree.Root).ToString());
            Console.WriteLine("Есть ли элемент 9?");
            Console.WriteLine(tree.Contains(9, tree.Root).ToString());
            Console.WriteLine("Есть ли элемент 19?");
            Console.WriteLine(tree.Contains(19, tree.Root).ToString());
            Console.ReadKey();
        }
    }
}
