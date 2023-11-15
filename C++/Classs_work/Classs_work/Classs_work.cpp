
#include <iostream>
#include "Shape.h"
#include "Employer.h"
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

    cout << endl;
    President president("John Doe");
    Manager manager("Alice Smith");
    Worker worker("Bob Johnson");

    std::cout << "Information about each type of employer:" << std::endl;
    std::cout << "-------------------------------------" << std::endl;

    president.Print();
    manager.Print();
    worker.Print();

}

