#include <iostream>
#include "array.h"

using namespace std;

int main() {
    Array arr(5);
    arr.fillRandom(0, 50);

    cout << "Randomly Array: ";
    arr.display();
    Array arr2 = arr;
    cout << "Copied Array: ";
    arr2.display();

    arr2.resize(8);
    cout << "Resized Array: ";
    arr2.display();

    arr2.sort();
    cout << "Sorted Array: ";
    arr2.display();

    cout << "Min Value: " << arr2.getMin() << endl;
    cout << "Max Value: " << arr2.getMax() << endl;
}
