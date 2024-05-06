#define _USE_MATH_DEFINES

#include <opencv2/core/core.hpp>
#include "opencv2/imgcodecs.hpp"
#include "opencv2/imgproc.hpp"
#include <opencv2/opencv.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/features2d.hpp>
#include <iostream>
#include <random>

using namespace std;
using namespace cv;



void addRandomNoise(const cv::Mat& image) {
    cv::Mat noise = cv::Mat(image.rows, image.cols, CV_8U);

    // Генерируем случайный шум
    cv::randn(noise, cv::Scalar(0), cv::Scalar(25)); // Гауссовский шум со средним 0 и стандартным отклонением 25

    // Добавляем шум к изображению
    cv::add(image, noise, image);
}

cv::Mat createRandomShapeImage(int width, int height, bool hasSignal) {    
    cv::Mat image(height, width, CV_8U, cv::Scalar(50));
    if (hasSignal) {
        int shapeType = 0; //rand() % 3; // Случайно выбираем тип фигуры (1 - круг, 2 - прямоугольник, 3 - эллипс)
        cv::Scalar color = cv::Scalar(255); // Белый цвет для фигур
        int x = width / 2; //rand() % width; // Случайная координата x
        int y = height / 2; //rand() % height; // Случайная координата y

        if (shapeType == 0) {
            cv::circle(image, cv::Point(x, y), 20, color, -1); // Рисуем случайный круг
        }
        else if (shapeType == 1) {
            cv::rectangle(image, cv::Point(x, y), cv::Point(x + 30, y + 20), color, -1); // Рисуем случайный прямоугольник
        }
        else {
            cv::ellipse(image, cv::Point(x, y), cv::Size(30, 20), 0, 0, 360, color, -1); // Рисуем случайный эллипс
        }
    }

    return image;
}

// Функция для генерации изображений с сигналом
std::vector<cv::Mat> generateImagesWithSignal(int numImages) {
    std::vector<cv::Mat> imagesWithSignal; // Пустой вектор для хранения изображений с сигналом

    for (int i = 0; i < numImages; ++i) {
        // Создание изображения с сигналом
        cv::Mat imageWithSignal = createRandomShapeImage(300, 300, true); // Создаем изображение с формами
        addRandomNoise(imageWithSignal); // Добавляем случайный шум к изображению с формами
        imagesWithSignal.push_back(imageWithSignal); // Добавление изображения в вектор
        imwrite("with_signal_" + to_string(i) + ".png", imageWithSignal);
    }

    return imagesWithSignal;
}

// Функция для генерации изображений без сигнала
std::vector<cv::Mat> generateImagesWithoutSignal(int numImages) {
    std::vector<cv::Mat> imagesWithoutSignal; // Пустой вектор для хранения изображений без сигнала

    for (int i = 0; i < numImages; ++i) {
        // Создание изображения без сигнала
        cv::Mat imageWithoutSignal = createRandomShapeImage(300, 300, false); // Создаем изображение с формами
        addRandomNoise(imageWithoutSignal); // Добавляем случайный шум к изображению с формами
        imagesWithoutSignal.push_back(imageWithoutSignal); // Добавление изображения в вектор
        imwrite("no_signal_" + to_string(i) + ".png", imageWithoutSignal);
    }

    return imagesWithoutSignal;
}

void getMeanStdDev(const vector<cv::Mat>& images, cv::Mat& meanMatrix, cv::Mat& stdDevMatrix)
{
    // Calculate mean matrix
    for (const auto& image : images) {
        meanMatrix += image; // Accumulate sum of matrix elements
    }
    meanMatrix /= images.size(); // Divide by number of images to obtain mean

    // Calculate standard deviation matrix
    //for (const auto& matrix : images) {
    //    cv::Mat diff;
    //    cv::absdiff(matrix, meanMatrix, diff); // Compute absolute differences between matrix and mean matrix
    //    diff = diff.mul(diff); // Element-wise multiplication to obtain squared differences
    //    stdDevMatrix += diff; // Accumulate squared differences
    //}
    //stdDevMatrix /= images.size(); // Divide accumulated squared differences by the number of matrices
    //stdDevMatrix.convertTo(stdDevMatrix, CV_64FC1);
    //cv::sqrt(stdDevMatrix, stdDevMatrix); // Take the square root to obtain standard deviation matrix
}

cv::Mat calculateHotellingTemplate(const cv::Mat& Ky, const cv::Mat& delta_y) {
    // Создание матрицы с конвертированным типом данных для delta_y
    cv::Mat delta_y_converted;
    delta_y.convertTo(delta_y_converted, Ky.type());
    
    // Решение линейного уравнения Kyw = delta_y
    cv::Mat w;
    cv::solve(Ky, delta_y_converted, w);

    return w;
}

double calculateHotellingSNR(const cv::Mat& w, const cv::Mat& delta_y) {
    cv::Mat delta_y_converted;

    // Ensure compatibility by converting w to the same type as delta_y if needed
    delta_y.convertTo(delta_y_converted, w.type());
    cout << delta_y_converted.type() << endl;
    cout << delta_y.type() << endl;

    // Perform the dot product after ensuring type compatibility
    Mat SNR = cv::Mat(w.t() * delta_y_converted); // Calculate dot product
    cout << SNR << endl;
    double SNR_Hot = SNR.at<double>(0, 0);
    return SNR_Hot;
}



int main(int argc, char** argv)
{
    // Вызов функций для генерации изображений для каждого класса
    int numImages = 3; // Количество изображений для каждого класса
    std::vector<cv::Mat> imagesWithSignal = generateImagesWithSignal(numImages);
    std::vector<cv::Mat> imagesWithoutSignal = generateImagesWithoutSignal(numImages);

    // Вычисление статистик для каждого класса
    cv::Mat mean_H0 = cv::Mat::zeros(imagesWithSignal[0].size(), imagesWithSignal[0].type());
    Mat mean_H1 = cv::Mat::zeros(imagesWithSignal[0].size(), imagesWithSignal[0].type()); // Векторы средних
    cv::Mat stdDev_H1 = cv::Mat::zeros(imagesWithSignal[0].size(), imagesWithSignal[0].type());
    Mat stdDev_H0 = cv::Mat::zeros(imagesWithSignal[0].size(), imagesWithSignal[0].type()); // Среднеквадратичные отклонения
    cv::Mat covMatrix_H1, covMatrix_H0; // Ковариационные матрицы

    // Вычисление статистик для изображений с сигналом
    getMeanStdDev(imagesWithSignal, mean_H1, stdDev_H1);

    // Вычисление статистик для изображений без сигнала
    getMeanStdDev(imagesWithoutSignal, mean_H0, stdDev_H0);

    cv::Mat image(300, 300, CV_8U, cv::Scalar(50));

    // Рисуем серый круг в центре
    cv::circle(image, cv::Point(200, 200), 50, cv::Scalar(65), -1);

    // Создаем маски для круга и фона
    cv::Mat circle_mask = cv::Mat::zeros(image.size(), CV_8U);
    
    cv::circle(circle_mask, cv::Point(image.cols / 2, image.rows / 2), 50, cv::Scalar(255), -1);

    cv::Mat background_mask = 255 - circle_mask;

    cv::Mat noise = cv::Mat(image.size(), image.type());
    cv::randn(noise, cv::Scalar(0), cv::Scalar(25)); // Генерация гауссовского шума с средним 0 и стандартным отклонением 25

    cv::Mat noisy_image = image.clone(); // Создание копии исходного изображения
    noisy_image += noise; // Добавление шума к изображению
       

    cv::Mat blurred_image;
    cv::GaussianBlur(noisy_image, blurred_image, cv::Size(5, 5), 1.5); // Применение гауссовского размытия с ядром 5x5 и стандартным отклонением 1.5

    cv::imshow("mean_H0", mean_H0);
    cv::imshow("mean_H1", mean_H1);
    cv::Mat delta_mean = mean_H1 - mean_H0;

    cv::calcCovarMatrix(blurred_image, covMatrix_H0, mean_H0, cv::COVAR_NORMAL | cv::COVAR_ROWS);
    cv::calcCovarMatrix(blurred_image, covMatrix_H1, mean_H1, cv::COVAR_NORMAL | cv::COVAR_ROWS);

    cv::Mat inv_cov_matrix;

    cv::invert((covMatrix_H0 + covMatrix_H1)/2, inv_cov_matrix, cv::DECOMP_SVD);
    imshow("covMatrix_H1", covMatrix_H1);

    cv::Mat w_HO = calculateHotellingTemplate(inv_cov_matrix, delta_mean); //calculateHotellingObserverTemplate(mean_H0, mean_H1, inv_cov_matrix, delta_mean);

    blurred_image.convertTo(blurred_image, w_HO.type());
  
    Mat t = blurred_image * w_HO;

    double snr = calculateHotellingSNR(w_HO, delta_mean);

    //std::cout << "Template: " << w_HO << std::endl;
    std::cout << "SNR: " << snr << std::endl;
    cv::imshow("t", t);
    cv::imshow("w_HO", w_HO);
    cv::imshow("delta_y", delta_mean);
    cv::imshow("inv_cov_matrix", inv_cov_matrix);

    waitKey(0);


    return 0;
}
