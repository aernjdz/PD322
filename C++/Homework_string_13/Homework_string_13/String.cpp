#include "String.h"


int String::str_count = 0;

String::String() : size(80), data(new char[size]) {
    str_count++;
}

String::String(size_t size) : size(size), data(new char[size]) {
    str_count++;
}

String::String(const char* str) : size(0), data(nullptr) {
    str_count++;
    if (str) {
        size = strlen(str);
        data = new char[size + 1];
        for (size_t i = 0; i < size; i++) {
            data[i] = str[i];
        }
        data[size] = '\0';
    }
}

String::~String() {
    delete[] data;
    str_count--;
}
void String::display() const {
    cout  << data << endl;
}

int String::getCount() {
    return str_count;
}
