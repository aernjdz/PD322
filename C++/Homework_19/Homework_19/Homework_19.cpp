#include <iostream>
#include "FList.h"
using namespace std;

int main()
{
    FList<int> list;

    list.addHead(2);
    list.print();
    list.addHead(13);
    list.addHead(25);
    list.addHead(2);
    list.print();

    FList<int> copiedList = list;

    cout << "Copied List: ";
    copiedList.print();


    cout << "List size :: " << list.getSize() << endl;
    list.removeHead();
    list.print();
    cout << "List size :: " << list.getSize() << endl;
    list.removeHead();
    list.print();
    cout << "List size :: " << list.getSize() << endl;
    list.removeHead();
    list.print();
    cout << "List size :: " << list.getSize() << endl;
    list.removeHead();
    list.print();
    cout << "List size :: " << list.getSize() << endl;
    list.removeHead();
    list.print();
    cout << "List size :: " << list.getSize() << endl;

    FList<int> list2;
    list2.addHead(25);
    list2.addHead(43);
    list2.addHead(25);

    FList<int> mergedList = list;
    mergedList += list2;
    cout << "Merged List: ";
    mergedList.print();

    FList<int> commonElements = list - list2;
    cout << "Common Elements: ";
    commonElements.print();

    list.clear();
    cout << "List after clearing: ";
    list.print();

    cout << "Copied List: ";
    copiedList.print();

}
