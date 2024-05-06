// ConsoleApplication2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
#include <cstring>
#include <vector>
#include <stdexcept>
#include <exception>
#include <cmath>
#include <initializer_list>
#include <cassert>
#include <algorithm>
#include <list>
using namespace std;
struct Stack
{
    int x;
    Stack* next;
    Stack* head;
};
void push(int a,Stack* &l)
{
    Stack* temp=new Stack;
    temp->x = a;
    temp->next = l->head;
    l->head = temp;

}
void pop(int a, Stack*& l)
{
    Stack* temp = l->head->next;                    //Временная переменная для хранения адреса следующего элемента
    delete l->head;                                //Освобождаем адрес обозначающий начало
    l->head = temp;

}
void clear(Stack*& l)
{
    while (l->head != NULL)
    {
        Stack* temp = l->head->next;                    //Временная переменная для хранения адреса следующего элемента
        delete l->head;                                //Освобождаем адрес обозначающий начало
        l->head = temp;
    }
    

}

void show(Stack*& l)
{
    Stack* temp = new Stack;
    temp=l->head;
    while (temp != NULL)
    {
        cout << temp->x << " ";
                                                         
        temp = temp->next;
    }
}

int main()
{
    Stack* l = new Stack; //Выделяем память для стека


    l->head = NULL; //Во избежание ошибок инициализируем первый элемент

    for (int i = 0; i < 10; i++) push(i, l); //Заносим данные в стек
    show(l); //Выводим стек на экран

    clear(l); //Очищаем память.
    delete l->head;
    delete l;

    
    return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
