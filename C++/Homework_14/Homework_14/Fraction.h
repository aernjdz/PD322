#pragma once
#include<iostream>
#include<string>
using namespace std;
class Fraction {
private:
	int num;
	int dnum;
public:
	Fraction(int num, int dnum) :num(num), dnum(dnum) {
		shorten();
	};

	int NSD(int a, int b);
	void shorten();

	Fraction operator+(const Fraction& second) const;
	Fraction operator-(const Fraction& second) const;
	Fraction operator*(const Fraction& second) const;
	Fraction operator/(const Fraction& second) const;
	const char* show() const;
};