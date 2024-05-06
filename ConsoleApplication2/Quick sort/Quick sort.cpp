// Quick sort.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <vector>
using namespace std;
void quickSort(int* data, int const len)
{
    int const lenD = len;
    int pivot = 0;
    int ind = lenD / 2;
    int i, j = 0, k = 0;
    if (lenD > 1) 
    {
        int* L = new int[lenD];
        int* R = new int[lenD];
        pivot = data[ind];
        for (i = 0;i < lenD;i++) 
        {
            if (i != ind) 
            {
                if (data[i] < pivot) 
                {
                    L[j] = data[i];
                    ++j;
                }
                else 
                {
                    R[k] = data[i];
                    ++k;
                }
            }
        }
        quickSort(L, j);
        quickSort(R, k);
        for (int cnt = 0;cnt < lenD;cnt++) {
            if (cnt < j) {
                data[cnt] = L[cnt];
            }
            else if (cnt == j) {
                data[cnt] = pivot;
            }
            else {
                data[cnt] = R[cnt - (j + 1)];
            }
        }
    }
}
int main()
{
    int data[7] = { 54,5785,89,3,0,-1,78 };
    size_t lenD = 7;
    quickSort( data, lenD);
    for (auto i : data) cout << i << " ";
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
