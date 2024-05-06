using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_bin_tree
{


    public struct itemTree
    {
        public byte valueFild;
        public unsafe itemTree* parent;
        public unsafe itemTree* leftChild;
        public unsafe itemTree* centrChild;
        public unsafe itemTree* rightChild;
    }
    class Tree
    {
        unsafe itemTree* root;
        public unsafe Tree() //Конструктор по умолчанию
        {
            root = null;
        }

        public enum SideChild
        {
            Left,
            Centr,
            Right
        }

        public unsafe void ShowTree()// Рекурсивный обход всего дерева  и вывода эго на экран
        {
            if (root != null)
            {
                if (root->leftChild != null & root->centrChild != null & root->rightChild != null)
                {
                    Console.WriteLine(root->valueFild = 4);
                }
                else if (
                    (root->leftChild == null & root->centrChild != null & root->rightChild != null) ||
                    (root->leftChild != null & root->centrChild == null & root->rightChild != null) ||
                    (root->leftChild != null & root->centrChild != null & root->rightChild == null)
                        )
                {
                    Console.WriteLine(root->valueFild = 3);
                }
                else if
                    (
                     (root->leftChild == null & root->centrChild == null & root->rightChild != null) ||
                     (root->leftChild != null & root->centrChild == null & root->rightChild == null) ||
                     (root->leftChild == null & root->centrChild != null & root->rightChild == null)

                    )
                {
                    Console.WriteLine(root->valueFild = 2);
                }
                else
                {
                    Console.WriteLine(root->valueFild = 1);
                }

                ShowTree(root->leftChild);

                ShowTree(root->centrChild);

                ShowTree(root->rightChild);



            }
        }
        public unsafe void ShowTree(itemTree* item)// Рекурсивный обход дерева начиная с указаного елемента и вывода эго на экран
        {
            if (item != null)
            {

                if (item->leftChild != null & item->centrChild != null & item->rightChild != null)
                {
                    Console.WriteLine(item->valueFild = 4);
                }
                else if (
                    (item->leftChild == null & item->centrChild != null & item->rightChild != null) ||
                    (item->leftChild != null & item->centrChild == null & item->rightChild != null) ||
                    (item->leftChild != null & item->centrChild != null & item->rightChild == null)
                        )
                {
                    Console.WriteLine(item->valueFild = 3);
                }
                else if
                    (
                     (item->leftChild == null & item->centrChild == null & item->rightChild != null) ||
                     (item->leftChild != null & item->centrChild == null & item->rightChild == null) ||
                     (item->leftChild == null & item->centrChild != null & item->rightChild == null)

                    )
                {
                    Console.WriteLine(item->valueFild = 2);
                }
                else
                {
                    Console.WriteLine(item->valueFild = 1);
                }

                ShowTree(item->leftChild);
                ShowTree(item->centrChild);
                ShowTree(item->rightChild);



            }
        }

        public unsafe void InsertItem(itemTree* element, itemTree* parent = null, SideChild sideAdd = SideChild.Left) //Метод вставки потомка или предка в общюю структуру древа
        {

            if (parent == null)
            {
                root = element;
            }

            else
            {
                if (sideAdd == SideChild.Left & parent->leftChild == null)
                {
                    parent->leftChild = element;
                }
                else if (sideAdd == SideChild.Centr)
                {
                    parent->centrChild = element;
                }
                else if (sideAdd == SideChild.Right & parent->rightChild == null)
                {
                    parent->rightChild = element;
                }
                else
                {
                    Console.WriteLine("Данная ветвь уже занята!");
                }

            }

        }


        public unsafe void CorrectSideItemTree(itemTree* element, itemTree* parent, SideChild side) // Метод изменение положения листа в общей структуре древа
        {
            if (parent != null)
            {
                if (side == SideChild.Left)
                {
                    parent->leftChild = element;
                }
                else if (side == SideChild.Centr)
                {
                    parent->centrChild = element;
                }
                else if (side == SideChild.Right)
                {
                    parent->rightChild = element;
                }
                else
                {
                    Console.WriteLine("Неправильно указанна ветвь");
                }
            }
            else
            {
                Console.WriteLine("Не указан предок элемента!");
            }
        }

        private unsafe itemTree* FreeBranch()
        {

            return FreeBranch(root);


        }

        private unsafe itemTree* FreeBranch(itemTree* temp)
        {

            if (temp != null)
            {
                FreeBranch(temp->leftChild);
                FreeBranch(temp->centrChild);
                FreeBranch(temp->rightChild);
                return null;
            }
            else
            {
                return temp;
            }


        }

        public unsafe void DeleteItem(ref itemTree* item, itemTree* pRoot) // Удаление елемента с древа
        {

            if (item != null)
            {
                if (pRoot != null)
                {

                    if (item == pRoot->leftChild)
                    {
                        pRoot->leftChild = null;
                        return;
                    }
                    if (item == pRoot->centrChild)
                    {
                        pRoot->centrChild = null;
                        return;
                    }
                    if (item == pRoot->rightChild)
                    {
                        pRoot->rightChild = null;
                        return;
                    }


                }
                DeleteItem(ref item, pRoot->leftChild);

                DeleteItem(ref item, pRoot->centrChild);

                DeleteItem(ref item, pRoot->rightChild);


            }


        }
    }

        class Program
    {
        
        static void Main(string[] args)
        {
            unsafe
            {
                // передаем адрес указателя, тоесть указатель на указатель
                
                //unsafe struct itemTree *root = itemTree(1);
                itemTree it = new itemTree();
                it.valueFild = 1;
                Tree tr = new Tree();
                tr.InsertItem((itemTree *) 1, null, Tree.SideChild.Centr);
                tr.ShowTree();
                Console.ReadKey();
            }
        }
    }
}
