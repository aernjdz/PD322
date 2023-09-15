#include <iostream>
using namespace std;
// N1

//void findMinMax(int arr[], int size, int& minValue, int& minIndex, int& maxValue, int& maxIndex) {
//    if (size <= 0) {
//        cout<< "The array is empty or has a non-positive size." << endl;
//        return;
//    }
//
//    minValue = arr[0];
//    minIndex = 0;
//
//    maxValue = arr[0];
//    maxIndex = 0;
//
//    for (int i = 1; i < size; i++) {
//        if (arr[i] < minValue) {
//            minValue = arr[i];
//            minIndex = i;
//        }
//        else if (arr[i] > maxValue) {
//            maxValue = arr[i];
//            maxIndex = i;
//        }
//    }
//}

// N2
 
//void reverseArray(int arr[], int size) {
//    for (int i = 0; i < size / 2; i++) {
//        int temp = arr[i];
//        arr[i] = arr[size - 1 - i];
//        arr[size - 1 - i] = temp;
//    }
//}

// N3

bool isPrime(int num) {
    if (num <= 1) return false;
    if (num <= 3) return true;
    if (num % 2 == 0 || num % 3 == 0) return false;
    for (int i = 5; i * i <= num; i += 6) {
        if (num % i == 0 || num % (i + 2) == 0) return false;
    }
    return true;
}

int countPrimesInArray(const int arr[], int size) {
    int count = 0;
    for (int i = 0; i < size; i++) {
        if (isPrime(arr[i])) count++;
    }
    return count;
}



int main() {
    
    // N1
    /*int arr[] = { 12, 45, 8, 23, 67, 3, 99, 18 };
    int size = sizeof(arr) / sizeof(arr[0]);

    int minValue, minIndex, maxValue, maxIndex;

    findMinMax(arr, size, minValue, minIndex, maxValue, maxIndex);

    cout << "Minimum: Value :: " << minValue << " Index :: " << minIndex << endl;
    cout << "Maximum: Value :: " << maxValue << " Index :: " << maxIndex << endl;*/

    // N2
    /*int arr[] = { 1, 2, 3, 4, 5 };
    int size = sizeof(arr) / sizeof(arr[0]);

    cout << "Initial array: ";
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    reverseArray(arr, size);

    cout << "Reordered array: ";
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;*/
    
    //N3
    int arr[] = { 2, 3, 4, 5, 6, 7, 8, 9 };
    int size = sizeof(arr) / sizeof(arr[0]);

    int prime_Count = countPrimesInArray(arr, size);

    cout << "The number of prime numbers in the array: " << prime_Count << endl;
}
