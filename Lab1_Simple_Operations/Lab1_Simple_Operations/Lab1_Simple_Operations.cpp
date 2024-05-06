#include <opencv2/core/core.hpp>
#include <opencv2/opencv.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <iostream>

using namespace std;
using namespace cv;

// Функция для выполнения гамма-коррекции изображения
void gammaCorrection(const Mat& src, Mat& dst, const float gamma)
{
    // Вычисление значения обратного гамма
    float invGamma = 1 / gamma;

    // Создание таблицы преобразования для коррекции гаммы
    Mat table(1, 256, CV_8U);
    uchar* p = table.ptr();
    for (int i = 0; i < 256; ++i) {
        p[i] = (uchar)(pow(i / 255.0, invGamma) * 255); // Применение гамма-коррекции к каждому значению яркости
    }

    // Применение LUT (Look Up Table) для выполнения гамма-коррекции
    LUT(src, table, dst);
}

int main(int argc, char* argv[])
{
    int s = 3, h = 30;
    float gamma = 2.4;
    string outputFileName = "";

    // Обработка переданных параметров
    if (argc > 1)
    {
        s = stoi(argv[1]);
    }
    if (argc > 2)
    {
        h = stoi(argv[2]);
    }
    if (argc > 3)
    {
        gamma = stof(argv[3]);
    }
    if (argc > 4)
    {
        outputFileName = string(argv[4]);
    }

    int height = h; //256 * h;
    int width = 256 * s;

    Mat image(2 * height, 2 * width, CV_8UC1, cv::Scalar(0));

    // Создание изображения 
    Mat gradient(height, width, CV_8UC1, cv::Scalar(0));

    // Генерация градиента
    for (int i = 0; i < gradient.cols; ++i)
    {
        uchar intensity = saturate_cast<uchar>((i * 256) / gradient.cols);
        gradient.col(i).setTo(intensity);
    }

    // Применение гамма-коррекции к изображению
    Mat gammaCorrected(height, width, CV_8UC1, cv::Scalar(0));
    gammaCorrection(gradient, gammaCorrected, gamma);

    vconcat(gradient, gammaCorrected, image);

    // Отображение гамма-скорректированного изображения
    namedWindow("Gamma Corrected Gradient Image");
    imshow("Gamma Corrected Gradient Image", image);
    waitKey(0);
               
    imwrite("grad.png", image);

    // Сохранение гамма-скорректированного изображения, если указано имя файла для сохранения
    if (!outputFileName.empty())
    {
        imwrite(outputFileName, image); // Сохранить скорректированное изображение
    }

    return 0;
}
