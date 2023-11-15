
#include <iostream>
#include "Shape.h"
using namespace std;
int main()
{
    Rectangle rectangle(5, 3);
    Circle circle(4);
    Triangle triangle(6, 2);
    Trapezoid trapezoid(3, 7, 4);
    cout << "Reactangle Area :: " << rectangle.calculateArea() << "cm2" << endl;
    cout << "Circle Area :: " << circle.calculateArea() << "cm2" << endl;
    cout << "Triangle Area :: " << triangle.calculateArea() << "cm2" << endl;
    cout << "Trapezoid Area :: " << trapezoid.calculateArea() << "cm2" << endl;

}

