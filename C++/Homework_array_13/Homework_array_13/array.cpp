#include"array.h"

Array::Array() : data(nullptr), size(0), rng(random_device()()) {}



Array::Array(const Array& other) : size(other.size), rng(random_device()()) {
    data = new int[size];
    copy(other.data, other.data + size, data);
}

Array::~Array() {
    delete[] data;
}

void Array::fillRandom(int minValue, int maxValue) {
    std::uniform_int_distribution<int> distribution(minValue, maxValue);
    for (int i = 0; i < size; i++) {
        data[i] = distribution(rng);
    }
}

void Array::display() const {
    for (int i = 0; i < size; i++) {
        cout << data[i] << ' ';
    }
    cout << endl;
}

void Array::resize(int newSize) {
    if (newSize == size) {
        return;
    }

    int* newData = new int[newSize] {};

    if (newSize < size) {
        copy(data, data + newSize, newData);
    }
    else {
        uniform_int_distribution<int> distribution(10, 100);
        copy(data, data + size, newData);
        for (int i = size; i < newSize; i++) {
            newData[i] = distribution(rng);
        }
    }

    delete[] data;
    data = newData;
    size = newSize;
}

void Array::sort() {
    std::sort(data, data + size);
}

int Array::getMin() const {
    if (size == 0) {
        return 0;
    }
    return *min_element(data, data + size);
}

int Array::getMax() const {
    if (size == 0) {
        return 0;
    }
    return *max_element(data, data + size);
}

Array& Array::operator=(const Array& other) {
    if (this == &other) {
        return *this;
    }

    int* newData = new int[other.size];
    copy(other.data, other.data + other.size, newData);

    delete[] data;
    size = other.size;
    data = newData;

    return *this;
}
