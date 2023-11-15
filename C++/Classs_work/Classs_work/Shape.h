#pragma once
#include <iostream>
#define _USE_MATH_DEFINES
#include <math.h>

using namespace std;

class Shape {
public:
	virtual double calculateArea() const  = 0;
};
class Rectangle : public Shape {
private:
	double lenght;
	double width;
public:
	Rectangle() = default;
	Rectangle(const double& l, const double& w) : lenght{ l }, width{ w }{

	}

	double calculateArea() const override {
		return this->lenght * width;
	}
};
class Triangle : public Shape {
private:
	double base;
	double height;
public:
	Triangle() = default;
	Triangle(const double& base, const double& height) : base{ base }, height{ height }{

	}
	double calculateArea() const override {
		return 0.5 * this->base * this->height;
	}
};
class Circle : public Shape {
private:
	double radius;
public:
	Circle() = default;
	Circle(const double& radius) : radius{ radius } {}

	double calculateArea() const override {
		return M_PI * radius * radius;
	}

};
class Trapezoid : public Shape {
private:
	double upperBase;
	double lowerBase;
	double height;

public:
	Trapezoid(double ub, double lb, double h) : upperBase(ub), lowerBase(lb), height(h) {}

	double calculateArea() const override {
		return 0.5 * (upperBase + lowerBase) * height;
	}
};