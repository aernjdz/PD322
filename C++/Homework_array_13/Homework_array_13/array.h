#pragma once
#include <iostream>
#include <random>
#include <algorithm>
using namespace std;

class Array {
public:
    Array();
    Array(int size) : size(size), rng(random_device()()) {
        data = new int[size] {};
    }
    Array(const Array& other);
    ~Array();

    void fillRandom(int minValue, int maxValue);
    void display() const;
    void resize(int newSize);
    void sort();
    int getMin() const;
    int getMax() const;
    Array& operator=(const Array& other);

private:
    int* data;
    int size;
    mt19937 rng;
};
