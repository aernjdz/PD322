#include <iostream>
#include "Array.h"
using namespace std;
int main()
{
	Array MyArray(5);
	MyArray.fillRandomValues(0, 10);
	cout << "Old Array :: ";
	MyArray.displayArray();
	MyArray.sortArray(true);
	cout << "Sort Array :: ";
	MyArray.displayArray();
	cout << "Old size :: " << MyArray.getSize() << endl;
	MyArray.resizeArray(8);
	cout << "New Array :: ";
	MyArray.displayArray();
	cout << "Size ::  " << MyArray.getSize() << endl;
	cout << "Min  ::  " << MyArray.findMin() << endl;
	cout << "Max  ::  " << MyArray.findMax() << endl;
}

