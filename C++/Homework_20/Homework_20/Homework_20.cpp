#include <iostream>
#include "Array.h"
using namespace std;

int main() {
    Array<int> _array;
    Array<int> array_;

    _array.SetSize(5, 5);
    array_.SetSize(5, 5);
    cout << "Array size: " << _array.GetSize() << ", Upper bound: " << _array.GetUpperBound() << endl;

   
    _array.Add(1);
    _array.Add(31);
    _array.Add(61);
    _array.Add(72);
    _array.Add(45);
    _array.Add(12);
    cout << "First array :: " << endl;
    _array.Print();
    cout << "Second array :: " << endl;
    
    array_.Add(238);
    array_.Add(238);
    array_.Print();

    cout << "Append array :: " << endl;
    array_.Append(_array);
    array_.Print();
    cout << "Add value in index (1) ::" << endl;
    array_.InsertAt(1,5);
    array_.Print();
    cout << "Remove value in index (4) ::" << endl;
    array_.RemoveAt(4);
    array_.Print();
    cout << "Replase value in index (0) ::" << endl;
    array_.Print();
    array_.SetAt(0, 2);
    array_.Print();

    cout << "Elem is index (2) :: " << array_.GetAt(2) << endl;
    cout << "Array size: " << array_.GetSize() << ", Upper bound: " << array_.GetUpperBound() << endl;
    cout << "Remove all data ::" << endl;
    array_.RemoveAll();
    cout << "Is Empty :: " << ((array_.IsEmpty()) ? "Yes" : "No") << endl;
    return 0;
}


