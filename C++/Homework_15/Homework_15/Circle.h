#pragma once

#include<iostream>
#include<string>
using namespace std;


class Circle {
private:
	double radius;
public:
	Circle(double r) : radius(r) {};

	bool operator==(const Circle& other) const;
	bool operator>(const Circle& other) const;
	bool operator<(const Circle& other) const;
	Circle& operator+=(double value);
	Circle& operator-=(double value);
	double get() const;
	void print(string text = "") const;
};