#include <stdio.h>
#define N 4

int perm()
{
    char s[N + 1], t; int i, j, r, k;

    for (i = 0; i < N; i++) s[i] = '1' + i;
    s[N] = '\0';

    while (1) {
        printf("%s\n", s);
        // Находим самое правое место, где s[i] < s[i+1]
        for (i = N - 1; i >= 0 && s[i] > s[i + 1]; i--);
        if (i < 0) break; // Уже получили "654321" - самую старшую перестановку
            // Находим s[j] - наименьший элемент справа от s[i] и больший его
        for (j = N - 1; s[i] > s[j]; j--);
        // Меняем s[i] <-> s[j]
        t = s[j];
        s[j] = s[i];
        s[i] = t;
        // То, что за "i" - переворачиваем
        for (k = i + 1, r = N - 1; r > k; k++, r--) {
            t = s[r];
            s[r] = s[k];
            s[k] = t;
        }
    }
    return 0;
}