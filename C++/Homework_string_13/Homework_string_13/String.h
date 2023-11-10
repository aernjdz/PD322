#pragma once
#include <iostream>
using namespace std;

class String {
public:
    String();
    String(size_t size);
    String(const char* str);
    ~String();

    void display() const;

    static int getCount();

private:
    char* data;
    size_t size;
    static int str_count;
};
