#include <iostream>
#include <algorithm>
#include <vector>

using namespace std;

void print_permutation(const vector<int>& permutation) {
    for (int i : permutation) {
        cout << i << " ";
    }
    cout << endl;
}

void generate_permutations(vector<int>& permutation) {
    const int n = permutation.size();
    vector<int> directions(n, -1); // направления движения для каждого элемента  
    int current_element = 0; // текущий элемент  
    while (current_element < n) {
        print_permutation(permutation);
        const int current_direction = directions[current_element];
        const int next_element = current_element + current_direction;
        if (next_element < 0 || next_element == n || permutation[next_element] > permutation[current_element]) {
            // меняем направление движения элемента и меняем сам элемент со следующим  
            directions[current_element] = -current_direction;
            if (next_element >= 0 && next_element < n) {
                swap(permutation[current_element], permutation[next_element]);
            }
            current_element = 0; // начинаем с начала  
        }
        else {
            ++current_element;
        }
    }
}

int main() {
    int n;
    cin >> n;
    vector<int> permutation(n);
    for (int i = 0; i < n; ++i) {
        permutation[i] = i + 1;
    }
    generate_permutations(permutation);
    return 0;
}















































//# include <stdio.h>
//# include <stdlib.h>
//# include <time.h>
//# include <ctime>
//#include <fstream>
//#include <iostream>
//using namespace std;
//void main() { //Генерация перестановок
//// z[l], z[2], ..., z[n]
//	int n=5;
//	int* z = new int[n];
//	int* p = new int[n];
//	int* d = new int[n];
//	fstream f;
//	tm t, tnew;
//	// преобразование в тип, используемый в С
//	// dostime_t t = { tnew.tm_sec, new_time.tm_min, new_time.tm_hour, new_time.tm_mday, new_time.tm_mon, new_time.tm_year - 80, 0 };
//
//	long delta;
//	unsigned long k;
//	int pm, dm, zpm;
//	int i, m, w;
//	//gmtime(&t);
//	f.open("primer.in");
//	f >> n;
//	z = (int*)malloc((n + 2) * sizeof(int)); //Перестановка 
//	p = (int*)malloc((n + 2) * sizeof(int)); //Обратная 
//	d = (int*)malloc((n + 2) * sizeof(int)); //Смещение 
//	f.close();
//	f.open("primer.out");
//	for (i = 1; i <= n; i++) {
//		z[i] = i; p[i] = i; d[i] = -1;
//	}
//	d[1] = 0; z[0] = z[n + 1] = m = n + 1; k = 0;
//	while (m != 1) {
//		//Печать перестановки 
//		k++;
//		cout << endl << k << ") ";
//		for (i = 1; i <= n; i++) cout << z[i];
//		m = n;
//		while (z[p[m] + d[m]] > m) {
//			d[m] = -d[m]; m--;
//		}
//		pm = p[m]; dm = pm + d[m]; w = z[pm]; z[pm] = z[dm]; z[dm] = w;
//		zpm = z[pm]; w = p[zpm]; p[zpm] = pm; p[m] = w;
//	}
//
//	delete[] z;
//	delete[] p;
//	delete[] d;
//
//	
//	/*free(z);
//	free(p);
//	free(d);*/
//	//gmtime(&tnew);
//	delta = tnew.tm_hour; delta -= t.tm_hour; delta *= 60;
//
//	delta += tnew.tm_min; delta -= t.tm_min; delta *= 60;
//	delta += tnew.tm_sec; delta -= t.tm_sec; delta *= 100;
//	//delta += tnew.tm_hsec; delta -= t.hsecond;
//	cout << "\nВремя счета " << delta / 1000 << "." << delta % 1000 << " сек\n";
//
//	f.close();
//}
//
//
//
//
//
////#include <stdio.h>
////#define N 4
////
////int main()
////{
////    char s[N + 1], t; int i, j, r, k;
////
////    for (i = 0; i < N; i++) s[i] = '1' + i;
////    s[N] = '\0';
////
////    while (1) {
////        printf("%s\n", s);
////
////        // Находим самое правое место, где s[i] < s[i+1]
////
////        for (i = N - 1; i >= 0 && s[i] > s[i + 1]; i--);
////
////        if (i < 0) break; // Уже получили "654321" - самую старшую перестановку
////
////            // Находим s[j] - наименьший элемент справа от s[i] и больший его
////
////        for (j = N - 1; s[i] > s[j]; j--);
////
////        // Меняем s[i] <-> s[j]
////
////        t = s[j];
////        s[j] = s[i];
////        s[i] = t;
////
////        // То, что за "i" - переворачиваем
////
////        for (k = i + 1, r = N - 1; r > k; k++, r--) {
////            t = s[r];
////            s[r] = s[k];
////            s[k] = t;
////        }
////    }
////    return 0;
////}
////
////
////
////
////// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
////// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"
////
////// Советы по началу работы 
//////   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//////   2. В окне Team Explorer можно подключиться к системе управления версиями.
//////   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//////   4. В окне "Список ошибок" можно просматривать ошибки.
//////   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//////   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
