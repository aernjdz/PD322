#pragma once
#include <iostream>
using namespace std;

class Array
{
public:
	Array() : data(nullptr), size(0){}
	Array(int size) : size(size) {
		data = new int[size];
	}
	Array(const Array& other) : size(other.size) {
		data = new int[size];
		for (int i = 0; i < size; i++) {
			data[i] = other.data[i];
		}
	}
	~Array() {
		delete[] data;
	}
	void displayArray() const;
	void fillArray();
	void fillRandomValues(int minValue, int maxValue);
	void resizeArray(int newSize);
	void sortArray(bool ascending = true);
	int findMin();
	int findMax();
	const size_t& getSize() const;
private:
	int* data;
	int size;
};


