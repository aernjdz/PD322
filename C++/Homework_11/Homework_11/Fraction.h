#pragma once
#include <iostream>
#include <string>
using namespace std;

class Fraction {
private:
	int num;
	int dnum;
public:
	Fraction(const int& num, const int& dnum) {
		this->num = num;
		this->dnum = dnum;
	}
	string print();
	Fraction sum(const Fraction& other);
	Fraction subtract(const Fraction& other);
	Fraction multiply(const Fraction& other);
	Fraction divide(const Fraction& other);
};