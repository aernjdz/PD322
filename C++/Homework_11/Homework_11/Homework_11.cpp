#include <iostream>
#include "Fraction.h"
using namespace std;
int main()
{
    Fraction f_1(1, 3);
    Fraction f_2(4, 7);
    Fraction sum = f_1.sum(f_2);
    cout << "Sum      :: " << f_1.print() << " + " << f_2.print() << " = " << sum.print() << endl;
    Fraction substract = f_1.subtract(f_2);
    cout << "Subtract :: " << f_1.print() << " - " << f_2.print() << " = " <<  substract.print() << endl;
    Fraction  multiply = f_1.multiply(f_2);
    cout << "Multiply :: " << f_1.print() << " * " << f_2.print() << " = " << multiply.print() << endl;
    Fraction  divide = f_1.divide(f_2);
    cout << "Divide   :: " << f_1.print() << " / " << f_2.print() << " = " << divide.print() << endl;
}

