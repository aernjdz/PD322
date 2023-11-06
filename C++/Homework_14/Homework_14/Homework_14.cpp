
#include "Fraction.h"
#include <iostream>
using namespace std;
int main()
{
	Fraction first(1,2);
	Fraction second(1, 3);
	Fraction sum = first + second;
	Fraction odd = first - second;
	Fraction mult = first * second;
	Fraction div = first / second;
	
	cout <<first.show() << " + " << second.show() << " = " << sum.show() << endl;
	cout << first.show() << " - " << second.show() << " = " << odd.show() << endl;
	cout << first.show() << " * " << second.show() << " = " << mult.show() << endl;
	cout << first.show() << " / " << second.show() << " = " << div.show() << endl;

}

