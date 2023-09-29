#include <iostream>

using namespace std;

bool contains(int* arr, int size, int elem) {
    for (int i = 0; i < size; i++) {
        if (arr[i] == elem) {
            return true;
        }
    }
    return false;
}

int* commonElems(int* A, int n, int* B, int m, int& commonSize) {
    int* result = nullptr;
    commonSize = 0;

    for (int i = 0; i < n; i++) {
        if (contains(B, m, A[i])) {
            int* temp = new int[commonSize + 1];
            for (int j = 0; j < commonSize; j++) {
                temp[j] = result[j];
            }
            temp[commonSize] = A[i];
            delete[] result;
            result = temp;
            commonSize++;
        }
    }

    return result;
}

int* allElems(int* arr, int size, int& allSize) {
    int* result = new int[size];
    allSize = size;

    for (int i = 0; i < size; i++) {
        result[i] = arr[i];
    }

    return result;
}

void deleteArray(int* arr) {
    delete[] arr;
}

void printArray(int* arr, int size) {
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

void inputArray(int* arr, int size) {
   
    for (int i = 0; i < size; i++) {
        cout << "Enter "<< i+1 <<" element of the array: ";
        cin >> arr[i];
    }
}

int main() {
    int n, m;
    cout << "Enter the size of array A: ";
    cin >> n;
    int* A = new int[n];
    inputArray(A, n);

    cout << "Enter the size of array B: ";
    cin >> m;
    int* B = new int[m];
    inputArray(B, m);

    int commonSize;
    int* common = commonElems(A, n, B, m, commonSize);

    int allSize;
    int* combined = allElems(A, n, allSize);
    for (int i = 0; i < m; i++) {
        if (!contains(A, n, B[i])) {
            int* temp = new int[allSize + 1];
            for (int j = 0; j < allSize; j++) {
                temp[j] = combined[j];
            }
            temp[allSize] = B[i];
            delete[] combined;
            combined = temp;
            allSize++;
        }
    }

    cout << "Elements of both arrays: ";
    printArray(combined, allSize);

    cout << "Common elements: ";
    printArray(common, commonSize);

    deleteArray(A);
    deleteArray(B);
    deleteArray(combined);
    deleteArray(common);

   
}
