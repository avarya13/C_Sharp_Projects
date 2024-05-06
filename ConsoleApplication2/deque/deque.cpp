// deque.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

struct deque
{public:
    int x;
    deque* last,*head, * next_up,*next_down;
};
void push_back(int a, deque*& q)
{
    deque* temp = new deque;
    temp->x = a;
    temp->next_up = q->last;
    q->last = temp;
}
void push_front(int a, deque*& l)
{
    deque* temp = new deque;
    temp->x = a;
    temp->next_down = l->head;
    l->head = temp;

}


void show_front(deque*& l)
{
    deque* temp = new deque;
    temp = l->head;
    while (temp != NULL)
    {
        cout << temp->x << " ";

        temp = temp->next_down;
    }
}
void show_back(deque*& l)
{
    deque* temp = new deque;
    temp = l->last;
    while (temp != NULL)
    {
        cout << temp->x << " ";

        temp = temp->next_up;
    }
}

void pop_back(deque*& q)
{
    deque* temp = q->last->next_up;
    delete q->last;
    q->last = temp;
}
void pop_front( deque*& l)
{
    deque* temp = l->head->next_down;                    //Временная переменная для хранения адреса следующего элемента
    delete l->head;                                //Освобождаем адрес обозначающий начало
    l->head = temp;

}
void clear(deque*& l)
{
    while (l->head != NULL)
    {
        deque* temp = l->head->next_down;                    //Временная переменная для хранения адреса следующего элемента
        delete l->head;                                //Освобождаем адрес обозначающий начало
        l->head = temp;
    }
}
int main()
{
    deque* q = new deque();
    q->last = NULL; //Во избежание ошибок инициализируем первый элемент

    for (int i = 10; i > 0; i--) 
        push_back(i, q);
    show_back(q);
    pop_back(q);
    cout << endl;
    show_back(q);
    cout << endl;
    clear(q);
    delete q->last;
   //deque* q = new deque();
   q->head = NULL; //Во избежание ошибок инициализируем первый элемент

   for (int i = 0; i < 10; i++) 
        push_front(i, q); //Заносим данные в стек
    show_front(q); //Выводим стек на экран
    cout << endl;
    pop_front(q);
    show_front(q);

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
