#include "Array.h"


const size_t& Array::getSize() const {
    return this->size;
}
void Array::displayArray() const {
    for (int i = 0; i < size; i++) {
        cout << data[i] << " ";
    }
    cout << endl;
}
void Array::fillArray() {
    for (int i = 0; i < size; i++) {
        cout << "Enter value for element " << i << ": ";
        cin >> data[i];
    }
}

void Array::fillRandomValues(int minValue, int maxValue) {
    srand(static_cast<unsigned>(time(0)));

    for (int i = 0; i < size; i++) {
        data[i] = rand() % (maxValue - minValue + 1) + minValue;
    }
}

void Array::resizeArray(int newSize) {
    int* newData = new int[newSize];
    for (int i = 0; i < std::min(size, newSize); i++) {
        newData[i] = data[i];
    }
    for (int i = size; i < newSize; i++) {
        newData[i] = 0;  
    }
    delete[] data;
    data = newData;
    size = newSize;
}


int Array::findMin() {
    int minVal = data[0];
    for (int i = 1; i < size; i++) {
        if (data[i] < minVal) {
            minVal = data[i];
        }
    }
    return minVal;
}

int Array::findMax() {
    int maxVal = data[0];
    for (int i = 1; i < size; i++) {
        if (data[i] > maxVal) {
            maxVal = data[i];
        }
    }
    return maxVal;
}
void Array::sortArray(bool ascending) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (ascending) {
                if (data[j] > data[j + 1]) {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
            else {
                if (data[j] < data[j + 1]) {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }
    }
}
