using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public unsafe struct node // структура для представления узлов дерева
    {
        public int key; // номер вершины
        public unsafe  char height; // высота поддерева
        public node* left; // cсылка на левого сына
        public node* right; // ссылка на правого сына
        public node(int k) { key = k; left = right = (node*)0; height = (char)1; } //  пустая вершина без детей
    };
    public class Tree {
        unsafe char height(node* p) // получение высоты вершины
        {
            if (p == null) return p->height;
            else
            {
                return '0'; //получим высоту следующим способом : если вершины нет, ответ 0 иначе высота поддерева этой вершины
            }
        }

        unsafe int bfactor(node* p) // разность высот между сыновьями
        {
            return height(p->right) - height(p->left); // вручную посчитаем разницу
        }

        unsafe void fixheight(node* p) // обновим высоту, если сбалансированность нарушена
        {
             char hl = height(p->left); // высота левого сына
             char hr = height(p->right); // высота правого сына
            p->height = (char)((hl > hr ? hl : hr) + 1); // высота вершины - это высота сына с макс высотой плюс 1
        }

        unsafe node* rotateright(node* p) // правый поворот вокруг p
        {
            node* q = p->left;  // обменяем левого и правого сына
            p->left = q->right;
            q->right = p;
            fixheight(p); //починим дерево
            fixheight(q);
            return q;
        }

        unsafe node* rotateleft(node* q) // левый поворот вокруг q
        {
            node* p = q->right; // обменяем правого и левого сына
            q->right = p->left;
            p->left = q;
            fixheight(q);
            fixheight(p);
            return p;
        }

        unsafe node* balance(node* p) // балансировка узла p
        {
            fixheight(p);
            if (bfactor(p) == 2) //если левый сын сильно больше правого сделаем правый поворот
            {
                if (bfactor(p->right) < 0)
                    p->right = rotateright(p->right);
                return rotateleft(p);
            }
            if (bfactor(p) == -2) // если правый сын сибно больше левого сделаем левый поворот
            {
                if (bfactor(p->left) > 0)
                    p->left = rotateleft(p->left);
                return rotateright(p);
            }
            return p; // балансировка не нужна
        }

        unsafe node* insert(node* p, int k) // вставка ключа k в дерево с корнем p
        {
            if (p == null) 
            {
                node new_item = new node(k);
                return p->new_item; }// если дерево пустое создадим его
            if (k < p->key) //если ключ больше вершины, вызомем это рекурсивно от левого сына
                p->left = insert(p->left, k);
            else
                p->right = insert(p->right, k); // если ключ меньше вершины, вызовем рекурсию от правго сына
            return balance(p); // отбалансируем вершину
        }

        unsafe node* findmin(node* p) // поиск узла с минимальным ключом в дереве p 
        {
            if (p->left != null) return findmin(p->left);
            else return p; //если есть левый сын, идем в него иначе ответ в этой вершине
        }

        unsafe node* removemin(node* p) // удаление узла с минимальным ключом из дерева p
        {
            if (p->left ==null) // если нет левого сына удалим эту вершину
                return p->right;
            p->left = removemin(p->left); // иначе идем в левого сына
            return balance(p); //балансируем дерево
        }

        unsafe node* remove(node* p, int k) // удаление ключа k из дерева p
        {
            if (p==null) return (node*)0; // если дерево пустое, уходим
            if (k < p->key) //если элемент меньше вершины идем в левого сына
                p->left = remove(p->left, k);
            else if (k > p->key)
                p->right = remove(p->right, k);  // если элемент больше вершины, идем в правого сына
            else //  мы пришли в вершину, которую надо удалить
            {
                node* q = p->left;
                node* r = p->right;
                 p=null; //удалим физически эту вершину
                if (r==null) return q;
                node* min = findmin(r);
                min->right = removemin(r); //правый сын минимальной вершины - это правое поддерево удаляемой без минимума
                min->left = q; // левый сын минимальной вершины - левый сын удаляемой
                return balance(min); // балансируем меньшую вершину
            }
            return balance(p); // мы ничего не нашли, балансируем дерево
        } 
    }

    class Program
    {
        

        static void Main(string[] args)
        {
        }
    }
}
