#include <iostream>
using namespace std;
#include"Circle.h"
#include"Airplane.h"

int main()
{
    Circle first(5.0);
    Circle second(7.8);

    first.print("First ::");
    second.print("Second ::");
    cout << "====================" << endl;
    cout << first.get() << " == " << second.get() << " :: " << ((first == second) ? "True" : "False") << endl;
    cout << first.get() << " > " << second.get() << " :: " << ((first > second) ? "True" : "False") << endl;
    cout << first.get() << " < " << second.get() << " :: " << ((first < second) ? "True" : "False") << endl;
    cout << "====================" << endl;
    first += 1;
    second += 2;
    first.print("First ::");
    second.print("Second ::");
    cout << "================================================" << endl;
    Airplane plane1("Boeing 747", 500);
    Airplane plane2("Airbus A380", 600);

    plane1.print("Plane 1 :: ");
    plane2.print("Plane 2 :: ");
    cout << "====================" << endl;
    for (size_t i = 0; i < 10; i++) {
        ++plane1;
        ++plane2;
    }
    --plane2;
    plane1.print("Plane 1 :: ");
    plane2.print("Plane 2 :: ");
    cout << "====================" << endl;
    cout << ((plane1 == plane2) ? "The airplanes are of the same type." : "The airplanes are of different types.") << endl;
   
    cout << ((plane1 > plane2) ? "Plane 1 can carry more passengers than Plane 2." : "Plane 1 cannot carry more passengers than Plane 2.");
  
}

