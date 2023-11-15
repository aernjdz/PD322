#include <iostream>
#include "Matrix.h"
using namespace std;

int main() {
    Matrix<int, 2, 3> intMatrix1(1);
    Matrix<int, 2, 3> intMatrix2(2);

    Matrix<double, 2, 3> doubleMatrix1(1.5);
    Matrix<double, 2, 3> doubleMatrix2(2.5);

    Matrix<string, 2, 3> stringMatrix1("Hello");
    Matrix<string, 2, 3> stringMatrix2("World");

    cout << "Int Matrix 1:" << endl;
    intMatrix1.display();

    cout << "\nInt Matrix 2:" << endl;
    intMatrix2.display();
    intMatrix2(0,0) -= 1;
    cout << "\nSum of Int Matrices:" << endl;
    Matrix<int, 2, 3> intSum = intMatrix1 + intMatrix2;
    intSum.display();
    cout << "\nDif of Int Matrices:" << endl;
    Matrix<int, 2, 3> intdif = intMatrix2 - intMatrix1;
    intdif.display();

    cout << "\nDouble Matrix 1:" << endl;
    doubleMatrix1.display();

    std::cout << "\nDouble Matrix 2:" << endl;
    doubleMatrix2.display();

    cout << "\nSum of Double Matrices:" << endl;
    Matrix<double, 2, 3> doubleSum = doubleMatrix1 + doubleMatrix2;
    doubleSum.display();

    cout << "\ndif of Double Matrices:" << endl;
    Matrix<double, 2, 3> doubledif = doubleMatrix2 - doubleMatrix1;
    doubledif.display();

    cout << "\nString Matrix 1:" << endl;
    stringMatrix1.display();

    cout << "\nString Matrix 2:" << endl;
    stringMatrix2.display();

    cout << "\nSum of String Matrices:" << endl;
    Matrix<string, 2, 3> stringSum = stringMatrix1 + stringMatrix2;
    stringSum.display();

    cout << "\nComparison of Int Matrices: " << ((intMatrix1 == intMatrix2) ? "Int Matrices are equal." : "Int Matrices are not equal.") << endl;

    cout << "\nComparison of Double Matrices: " << ((doubleMatrix1 == doubleMatrix2) ? "Double Matrices are equal." : "Double Matrices are not equal.") << endl;
    cout << "\nComparison of String Matrices: " << ((stringMatrix1 == stringMatrix2) ? "String Matrices are equal." : "String Matrices are not equal.") << endl;
    
}