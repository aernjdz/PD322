#include <iostream>
using namespace std;



void printArray2D(int arr[], int size, string  text = "") {
    cout << text << endl;
    for (int i = 0; i < size; i++) {
        cout << arr[i] << "\t";
    }
    cout << endl;
}


// N1
//void fillArray(int array[], int size, int start) {
//    array[0] = start;
//
//    for (int i = 1; i < size; i++) {
//        array[i] = array[i - 1] * 2;
//    }
//}

// N2
//void fillArray(int array[], int size, int start) {
//    array[0] = start;
//
//    for (int i = 1; i < size; i++) {
//        array[i] = array[i - 1] + 1;
//    }
//}

// N3
//const int rows = 2, cols = 5;
//void fillArray(int arr[rows][cols]) {
//    for (int i = 0; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//            arr[i][j] = rand() % 100;
//        }
//    }
//}
//void printArray3D(int arr[rows][cols], string text = "") {
//
//    cout << text << endl;
//    for (int i = 0; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//            cout << arr[i][j] << "\t";
//        }
//        cout << endl;
//    }
//}
//void cyclicShift(int array[rows][cols], int shifts, char direction) {
//
//    int tempArray[rows][cols];
//
//    for (int k = 0; k < shifts; k++) {
//        for (int i = 0; i < rows; i++) {
//            for (int j = 0; j < cols; j++) {
//                if (direction == 'L') {
//                    tempArray[i][j] = array[i][(j + 1) % cols];
//                }
//                else if (direction == 'R') {
//                    tempArray[i][j] = array[i][(j + cols - 1) % cols];
//                }
//                else if (direction == 'U') {
//                    tempArray[i][j] = array[(i + 1) % rows][j];
//                }
//                else if (direction == 'D') {
//                    tempArray[i][j] = array[(i + rows - 1) % rows][j];
//                }
//            }
//        }
//
//        for (int i = 0; i < rows; i++) {
//            for (int j = 0; j < cols; j++) {
//                array[i][j] = tempArray[i][j];
//            }
//        }
//    }
//}
//
//char toggleCase(char letter) {
//    return ((letter >= 'a' && letter <= 'z') ? letter - 32 : letter);
//}


int main()
{
    // N1
    /*int number;
    const int size = 10;
    int arr[size]{};
    cout << "Enter is first element in array :: ";
    cin >> number;
    if (number == 0) { 
        cout << "Please enter a number greater than 0" << endl;
        return 1; 
    }
    fillArray(arr, size, number);
    printArray2D(arr, size, "Result Array :: ");*/

    // N2
    /*int number;
    const int size = 10;
    int arr[size]{};
    cout << "Enter is first element in array :: ";
    cin >> number;
    fillArray(arr, size, number);
    printArra2D(arr, size, "Result Array :: ");*/

    // N3
    /*srand(time(0));
 
    int arr[rows][cols]{};
    int shifts;
    char direction;

    fillArray(arr);
    printArray3D(arr, "Before :: ");


    cout << "Enter number of shifts :: ";
    cin >> shifts;
    cout << "Choose a direction (L - left, R - right, U - up, D - down): ";
    cin >> direction;
    cyclicShift(arr,shifts, toggleCase(direction));
    printArray3D(arr, "After :: ");*/
}

