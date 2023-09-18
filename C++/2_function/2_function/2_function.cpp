#include <iostream>
#include<ctime>
using namespace std;
// N1
//double power(double base, int exponent) {
//    if (exponent == 0) {
//        return 1.0;
//    }
//
//    if (exponent > 0) {
//        return base * power(base, exponent - 1);
//    }
//    else {
//        return 1.0 / (base * power(base, -exponent - 1));
//    }
//}

// N2
//void printStars(int N) {
//    if (N <= 0) {
//        return;
//    }
//
//    cout << "*";
//    printStars(N - 1);
//}

// N3
//int sumInRange(int a, int b) {
//    if (a > b) {
//        return 0;
//    }
//    else {
//        return a + sumInRange(a + 1, b);
//    }
//}

// N4
//int randomInt(int min, int max) {
//    return min + rand() % (max - min + 1);
//}
//
//int findMinSumPosition(int arr[], int currentPos, int minPos, int currentSum, int minSum) {
//    if (currentPos >= 100) {
//        return minPos;
//    }
//
//   
//    for (int i = currentPos; i < currentPos + 10; ++i) {
//        currentSum += arr[i];
//    }
//
//    if (currentSum < minSum) {
//        minSum = currentSum;
//        minPos = currentPos;
//    }
//
//    return findMinSumPosition(arr, currentPos + 1, minPos, currentSum - arr[currentPos], minSum);
//}

template <typename T>
T findMax(T arr[], int size) {
    T maxVal = arr[0];
    for (int i = 1; i < size; ++i) {
        if (arr[i] > maxVal) {
            maxVal = arr[i];
        }
    }
    return maxVal;
}

template <typename T>
T findMax(T arr[][3], int rows, int cols) {
    T maxVal = arr[0][0];
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            if (arr[i][j] > maxVal) {
                maxVal = arr[i][j];
            }
        }
    }
    return maxVal;
}

template <typename T>
T findMax(T arr[][2][3], int depth, int rows, int cols) {
    T maxVal = arr[0][0][0];
    for (int i = 0; i < depth; ++i) {
        for (int j = 0; j < rows; ++j) {
            for (int k = 0; k < cols; ++k) {
                if (arr[i][j][k] > maxVal) {
                    maxVal = arr[i][j][k];
                }
            }
        }
    }
    return maxVal;
}

template <typename T>
T findMax(T a, T b) {
    return (a > b) ? a : b;
}

template <typename T>
T findMax(T a, T b, T c) {
    T maxVal = a;
    if (b > maxVal) {
        maxVal = b;
    }
    if (c > maxVal) {
        maxVal = c;
    }
    return maxVal;
}

int main() {

    // N1
    /*double base;
    int exponent;

    cout << "Enter the base: ";
    cin >> base;

    cout << "Enter the exponent: ";
    cin >> exponent;

    double result = power(base, exponent);
    cout << base << "^" << exponent << " = " << result << endl;*/

    // N2
    /*int N;
    cout <<Enter the number of stars (N): 5 << endl << Result: ***** <<endl;
    cout << "Enter the number of stars (N): ";
    cin >> N;

    if (N <= 0) {
        cout << "The number of stars must be greater than 0." << endl;
    }
    else {
        cout << "Result: ";
        printStars(N);
        cout << endl;
    }*/

    // N3
    //int a, b;
    //cout << "Enter the value of a : " << 5 << endl << "Enter the value of b : " << 10 << endl << "The sum of numbers from " << 5 << " to " << 10 << " is " << sumInRange(5, 10) << endl;
    //cout << endl;
    //cout << "Enter the value of a: ";
    //cin >> a;

    //cout << "Enter the value of b: ";
    //cin >> b;

    //if (a > b) {
    //    cout << "a should be less than or equal to b." << endl;
    //}
    //else {
    //    int result = sumInRange(a, b);
    //    cout << "The sum of numbers from " << a << " to " << b << " is " << result << endl;
    //}

    // N4

    /*srand(time(0));

    int arr[100];

   
    for (int i = 0; i < 100; ++i) {
        arr[i] = randomInt(-100, 100); 
    }

    int minPos = findMinSumPosition(arr, 0, 0, 0, INT_MAX);

    cout << "Start of the sequence with the minimum sum: position " << minPos << endl;*/

    //N4

    int arr1D[] = { 3, 5, 1, 7, 2, 9 };
    double arr2D[][3] = { {3.2, 5.4, 1.1}, {7.5, 2.3, 9.8}, {4.7, 6.2, 8.9} };
    float arr3D[][2][3] = { {{3.1, 5.0, 1.9}, {7.4, 2.6, 9.2}}, {{4.3, 6.8, 8.7}, {10.5, 12.1, 11.3}} };
    int num1 = 5;
    int num2 = 10;
    int num3 = 8;

    cout << "Maximum value in the one-dimensional array: " << findMax(arr1D, sizeof(arr1D) / sizeof(arr1D[0])) << endl;
    cout << "Maximum value in the two-dimensional array: " << findMax(arr2D, sizeof(arr2D) / sizeof(arr2D[0]), sizeof(arr2D[0]) / sizeof(arr2D[0][0])) << endl;
    cout << "Maximum value in the three-dimensional array: " << findMax(arr3D, sizeof(arr3D) / sizeof(arr3D[0]), sizeof(arr3D[0]) / sizeof(arr3D[0][0]), sizeof(arr3D[0][0]) / sizeof(arr3D[0][0][0])) << endl;
    cout << "Maximum value between two integers: " << findMax(num1, num2) << endl;
    cout << "Maximum value among three integers: " << findMax(num1, num2, num3) << endl;
    

}

