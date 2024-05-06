#include <stdio.h>
#include <stdlib.h>
#include <float.h>
#include <iostream> 

#define COMMON_NUM_OF_VARIABLES 9      // Количество переменных целевой функции (с учетом дополнительных)
#define NUM_OF_CONSTRAINTS 3           // Количество ограничений
#define NUM_OF_VARIABLES 6             // Количество переменных целевой функции (без учета дополнительных)

// Вывод задачи в канонической форме
void printCanonicalForm(const int coefficients[], const double mat[][COMMON_NUM_OF_VARIABLES], const double constants[], const int coeffLength, const int len2);

// Вывод оригинальной задачи
void printTask(const int coefficients[], const double mat[][COMMON_NUM_OF_VARIABLES], const double constants[], const int coeffLength); 

// Вывод двойственной задачи
void printDuality(const int coefficients[], const double mat[][COMMON_NUM_OF_VARIABLES], const double constants[], const int coeffLength, const int constsLength); // вывод двойствеоон задачи

// Симплекс-метод
double simplex(double constraints[NUM_OF_CONSTRAINTS][COMMON_NUM_OF_VARIABLES], double constants[]); 

// Вывод таблицы симплекс-метода
void printSimplexTable(int[], int[], int[], int[], double[], double[], double[][NUM_OF_CONSTRAINTS], int, double); //вывод симлекс-таблицы

// Поиск индекса минимального отрицательного числа
int findNegativeMinIndex(double[], int); // минимальный отрицательный, позиция, -1 в случае отсутвия отриц.

// Поиск индекса минимального положительного частного
int findPositiveMinIndex(double[], double[], int); 

// Вычисление скалярного произведения
double calculateScalarProduct(int[], double[], int); 

// Обмен значений
void swap(int*, int*);

// Коэффициенты целевой функции
const int f[COMMON_NUM_OF_VARIABLES] = {10, 12, 40, 42, 30, 35}; 

int main()
{
    setlocale(LC_ALL, "Russian");

    double A[NUM_OF_CONSTRAINTS][COMMON_NUM_OF_VARIABLES] = { {1, 1, 0, 0, 0, 0, 1, 0, 0},
                                                              {0, 0, 1, 1, 0, 0, 0, 1, 0},
                                                              {0, 0, 0, 0, 1, 1, 0, 0, 1},
                                                            };

    double b[NUM_OF_CONSTRAINTS] = { 60, 70, 80 }; 

    printTask(f, A, b, NUM_OF_VARIABLES);
    printCanonicalForm(f, A, b, NUM_OF_VARIABLES, NUM_OF_CONSTRAINTS);
    printDuality(f, A, b, NUM_OF_VARIABLES, NUM_OF_CONSTRAINTS);
    

    simplex(A, b);
    return 0;

}


void printTask(const int coefficients[], const double mat[][COMMON_NUM_OF_VARIABLES], const double constraints[], const int coeffLength)
{
    int i, j;
    printf("##################################\n");
    printf("            Прямая задача         \n");

    printf("f(x) = ");
    for (i = 0; i < coeffLength; i++)
        printf("%c%d*x%d", (i > 0 && coefficients[i] > 0 && coefficients[i] != 1) ? '+' : ' ', coefficients[i], i + 1);
    printf("-> min\n");

    printf("Ограничения: \n");
    for (i = 0; i < NUM_OF_CONSTRAINTS; i++) {
        for (j = 0; j < coeffLength; j++)
            printf("%c%.lf*x%d", (j > 0 && mat[i][j] >= 0) ? '+' : ' ', mat[i][j], j + 1);
        printf(" >= %.lf\n", constraints[i]);
    }
    putchar('\n');
}


// Вывод задачи в канонической форме
void printCanonicalForm(const int coefficients[], const double mat[][COMMON_NUM_OF_VARIABLES], const double constants[], const int coeffLength, const int constsLength)
{
    int i, j;
    // Вывод заголовка задачи
    printf("#######################################\n");
    printf("      Задача в канонической форме      \n");

    // Вывод целевой функции
    printf("f(x) = ");
    for (i = 0; i < coeffLength; i++)
        printf("%c%dx%d", (i > 0 && coefficients[i] > 0) ? '+' : ' ', coefficients[i], i + 1);
    printf("-> min\n");

    // Вывод ограничений
    printf("Ограничения: \n");
    for (i = 0; i < constsLength; i++) {
        for (j = 0; j < 5; j++)
            printf("%c%.lfx%d", (j > 0 && mat[i][j] >= 0) ? '+' : ' ', mat[i][j], j + 1);
        printf(" = %.lf\n", constants[i]);
    }
    putchar('\n');
}

// Вывод двойственной задачи
void printDuality(const int coefficients[], const double mat[][COMMON_NUM_OF_VARIABLES], const double constants[], const int coeffLength, const int constsLength)
{
    int i, j;

    // Вывод заголовка двойственной задачи
    printf("#########################################\n");
    printf("            Двойственная задача          \n");

    // Вывод целевой функции двойственной задачи
    printf("g(y) = ");
    for (i = 0; i < constsLength; i++)
        printf("%c%.lf*y%d", (i > 0 && constants[i] > 0) ? '+' : ' ', constants[i], i + 1);
    printf("-> max\n");

    printf("Ограничения: \n");
    for (i = 0; i < coeffLength; i++) {
        for (j = 0; j < constsLength; j++)
            printf("%c%.lf*x%d", (j > 0 && mat[j][i] >= 0) ? '+' : ' ', mat[j][i], j + 1);
        printf(" <= %d\n", coefficients[i]);
    }
    putchar('\n');
}

// Симплекс-метод
double simplex(double constraints[NUM_OF_CONSTRAINTS][COMMON_NUM_OF_VARIABLES], double constants[])
{
    // Инициализация переменных
    int Cbasis[NUM_OF_CONSTRAINTS] = { 0, 0, 0 };   // Базисные позиции
    int basis[NUM_OF_CONSTRAINTS] = { 7, 8, 9 };    // Небазисные позиции
    int notbase[NUM_OF_VARIABLES] = { 1, 2, 3, 4, 5, 6 };   // Небазисные переменные
    int Cj[NUM_OF_VARIABLES] = { f[0], f[1], f[2], f[3], f[4], f[5]}; // Коэффициенты целевой функции

    double fstr[NUM_OF_VARIABLES];   // Cтрока, соответствующая функции f в симплекс-таблице
    double matrix[COMMON_NUM_OF_VARIABLES][NUM_OF_CONSTRAINTS], commonMatrix[COMMON_NUM_OF_VARIABLES][NUM_OF_CONSTRAINTS], Q; // Матрицы для вычислений
    
    // matrix: Это двумерный массив, используемый для хранения значений коэффициентов переменных в системе ограничений в контексте симплекс-метода.

    // commonMatrix: Это также двумерный массив, который используется для вычислений и временного хранения значений при выполнении шагов симплекс-метода.

    // Q: Представляет собой значение функции Q, которое используется в симплекс-методе для оптимизации целевой функции и проверки условий остановки и сходимости метода.

    int r, s, i, j, counter = 0;    // Итерационные переменные

    // Заполнение матрицы ограничений
    for (i = 0; i < COMMON_NUM_OF_VARIABLES; i++)
        for (j = 0; j < NUM_OF_CONSTRAINTS; j++)
            matrix[i][j] = constraints[j][i];

    // Вычисление строки целевой функции дял таблицы
    for (i = 0; i < NUM_OF_VARIABLES; i++)
        fstr[i] = calculateScalarProduct(Cbasis, matrix[i], NUM_OF_CONSTRAINTS) - f[i];
    Q = calculateScalarProduct(Cbasis, constants, NUM_OF_CONSTRAINTS);  // Вычисление значения функции Q

     // Вывод исходной симплекс-матрицы
    printf("\nСимплекс-матрица:\n");
    printSimplexTable(Cbasis, basis, Cj, notbase, fstr, constants, matrix, NUM_OF_VARIABLES, Q);

    while ((r = findNegativeMinIndex(fstr, NUM_OF_VARIABLES)) != -1) { 
        counter++;

        // Поиск минимального положительного частного
        if ((s = findPositiveMinIndex(matrix[r], constants, NUM_OF_CONSTRAINTS)) == -1)
            return -1;

        // Работа с матрицей для симплекс-метода
        for (i = 0; i < COMMON_NUM_OF_VARIABLES; i++)
            for (j = 0; j < NUM_OF_CONSTRAINTS; j++)
                commonMatrix[i][j] = matrix[i][j];

        // Вычисление новой матрицы
        matrix[r][s] = 1 / commonMatrix[r][s];

        for (i = 0; i < NUM_OF_CONSTRAINTS; i++)
            if (i != s) matrix[r][i] = -commonMatrix[r][i] / commonMatrix[r][s]; // Вычисление значений для строки r, исключая s-ый столбец

        for (i = 0; i < 2; i++)
            if (i != r) matrix[i][s] = commonMatrix[i][s] / commonMatrix[r][s]; // Вычисление значений для столбца s, исключая r-ую строку

        for (i = 0; i < NUM_OF_CONSTRAINTS; i++)
            for (j = 0; j < 2; j++)
                if ((i != r) && (j != s))
                    matrix[i][j] = (commonMatrix[i][j] * commonMatrix[r][s] - commonMatrix[r][j] * commonMatrix[i][s]) / commonMatrix[r][s]; // Вычисление оставшихся значений

        // Выполнение замены значений
        for (i = 0; i < NUM_OF_CONSTRAINTS; i++) {
            if (i != s)
                constants[i] = (constants[i] * commonMatrix[r][s] - commonMatrix[r][i] * constants[s]) / commonMatrix[r][s];
        }
        constants[s] /= commonMatrix[r][s];

        // Вычисление f-строки
        for (i = 0; i < 2; i++) {
            if (i != r)
                fstr[i] = (fstr[i] * commonMatrix[r][s] - commonMatrix[i][s] * f[r]) / commonMatrix[r][s];
        }
        fstr[r] /= (-commonMatrix[r][s]);

        // Обмен значениями базисных коэффициентов и коэффициентов целевой функции
        swap(&Cbasis[s], &Cj[r]);
        swap(&basis[s], &notbase[r]);

        // Пересчет значения функции Q с учетом обновленной симплекс-таблицы
        Q = calculateScalarProduct(Cbasis, constants, NUM_OF_CONSTRAINTS);
        
                // Вывод симплекс-таблицы после очередной итерации
        printf("\nСимплекс-матрица после %d итерации:\n", counter);
        printSimplexTable(Cbasis, basis, Cj, notbase, fstr, constants, matrix, NUM_OF_VARIABLES, Q);
    }
    printf("\nИтоговое значение функции:\n");
    printf("Q = %.2lf\n", Q);
    

    return Q;
}

// Обмен значений
void swap(int* x, int* y)
{
    int temp = *x; 
    *x = *y;
    *y = temp;
}

// Функция для поиска индекса переменной с наименьшим положительным значением частного
int findPositiveMinIndex(double coefficients[], double constants[], int length)
{
    int index = -1;
    double minRatio = DBL_MAX; // Инициализация минимального частного максимальным значением типа double
    for (int i = 0; i < length; i++) {
        if ((coefficients[i] > 0) && (constants[i] / coefficients[i] < minRatio)) {
            minRatio = constants[i] / coefficients[i];
            index = i;
        }
    }
    return index;
}

// Функция для поиска индекса переменной с наименьшим отрицательным значением
int findNegativeMinIndex(double coefficients[], int length)
{
    int index = -1, i;
    double min = 0;

    for (i = 0; i < length; i++) {
        if (coefficients[i] < min) {
            min = coefficients[i];
            index = i;
        }
    }
    return index;
}

// Вывод симплекс-таблицы
void printSimplexTable(int Cbasis[], int basis[], int cj[], int notBase[], double fStr[], double a0[], double matrix[][NUM_OF_CONSTRAINTS], int columns, double Q)
{
    int i;
    printf("|___Базис___|_x%-5d|_x%-5d|_x%-5d|_x%-5d|_x%-5d|_x%-5d|__Свободные_члены__|\n", notBase[0], notBase[1], notBase[2], notBase[3], notBase[4], notBase[5]);
    for (i = 0; i < NUM_OF_CONSTRAINTS; i++)
        printf("|___x%-4d___|%7.2lf|%7.2lf|%7.2lf|%7.2lf|%7.2lf|%7.2lf|______%5.2lf________|\n", basis[i], matrix[0][i], matrix[1][i], matrix[2][i], matrix[3][i], matrix[4][i], matrix[5][i], a0[i]);
    printf("|_____f_____|%7.2lf|%7.2lf|%7.2lf|%7.2lf|%7.2lf|%7.2lf|______%5.2lf______|\n", fStr[0], fStr[1], fStr[2], fStr[3], fStr[4], fStr[5], Q);
    
}

// Скалярное произведение
double calculateScalarProduct(int matrix1[], double matrix2[], int length)
{
    int i;
    double sum = 0;

    for (i = 0; i < length; i++)
        sum += matrix1[i] * matrix2[i];

    return sum;
}