#include <iostream>
#include "DList.h"
using namespace std;
int main()
{
    DList<int> myList;
    myList.addHead(2);
    myList.addHead(15);
    myList.addHead(3);
    myList.addHead(31);

    cout << "Original List:\n";
    myList.print();

    myList.addTail(111);
    myList.addTail(13);
    myList.addTail(55);

    cout << "\nList after adding elements to the tail:\n";
    myList.print();

    myList.removeHead();

    cout << "\nList after removing the head:\n";
    myList.print();

    myList.removeData(13);

    cout << "\nList after removing element with data 13:\n";
    myList.print();

    DList<int> clonedList(myList);

    cout << "\nOriginal List:\n";
    myList.print();

    cout << "\nCloned List:\n";
    clonedList.print();

    myList.removeHead();

    cout << "\nOriginal List after removing the head:\n";
    myList.print();

    cout << "\nCloned List:\n";
    clonedList.print();

    clonedList.removeHead();

    cout << "\nOriginal List:\n";
    myList.print();

    cout << "\nCloned List after removing the head:\n";
    clonedList.print();

    DList<int> anotherList;
    anotherList = clonedList;

    cout << "\nCloned List:\n";
    clonedList.print();

    cout << "\nAnother List:\n";
    anotherList.print();

    clonedList.removeHead();

    cout << "\nCloned List:\n";
    clonedList.print();

    cout << "\nAnother List:\n";
    anotherList.print();

    anotherList.reverse();

    cout << "\nReversed Another List:\n";
    anotherList.print();

    DList<int> secondList;
    secondList.addHead(25);
    secondList.addHead(12);
    secondList.addHead(45);
    secondList.addHead(33);

    cout << "\nSecond List:\n";
    secondList.print();

    DList<int> combinedList = myList + secondList;

    cout << "\nCombined List (myList + secondList):\n";
    combinedList.print();

    DList<int> thirdList = secondList;
    thirdList += myList;

    cout << "\nThird List (thirdList += myList):\n";
    thirdList.print();

    int replacements = thirdList.findAndReplace(25, 99);

    cout << "\nThird List after replacing 25 with 99:\n";
    thirdList.print();

    cout << "Number of replacements: " << replacements << "\n";

    DList<int> intersectionResult = secondList.intersection(myList);

    cout << "\nIntersection of Second List and Original List:\n";
    intersectionResult.print();

    
}
