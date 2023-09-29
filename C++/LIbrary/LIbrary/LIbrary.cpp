#include <iostream>
#include "arrayFunc.h"
using namespace std;

/*
    Створити бібліотеку для роботи з багатовимірними масивами
    1) Створення масиву
    2) Заповнення масиву
    3) Вивід масиву
    4) функція додавання / видалення рядка в кінець
    5) функція додавання / видалення рядка на початок
    6) функція додавання / видалення рядка за індексом
    7) функція додавання / видалення стовпця в кінець
    8) функція додавання / видалення стовпця на початок
    9) функція додавання / видалення стовпця за індексом
    10) функція знаходження максимального значення
    11) функція знаходження мінімального значення
    12) Написати програму, яка видаляє з двовимірного масиву, заповненого випадковими числами, рядки, що містять нульові елементи.

*/


int main()
{
    int row = 4, col = 5, ** ptr;
    createArray(ptr, row, col);
    fillArray(ptr, row, col);
    printArray(ptr, row, col, "Print Array");
    insertRow(ptr, row, col, 0);
    cout << endl;
    printArray(ptr, row, col, "Print Insert Row");
    removeRow(ptr, row, col, 3);
    cout << endl;
    printArray(ptr, row, col, "Print Remove Row");
    deleteRowsWithZeros(ptr, row, col);
    cout << endl;
    printArray(ptr, row, col, "Print delete Rows With Zeros");
    insertCol(ptr, row, col, 0);
    cout << endl;
    printArray(ptr, row, col, "Print Insert Col");
    removeCol(ptr, row, col, 3);
    cout << endl;
    printArray(ptr, row, col, "Print Remove Col");
   
    cout << endl;
    cout << "Max :: " << findMax(ptr, row, col) << endl;
    cout << "Min :: " << findMin(ptr, row, col) << endl;
    addRowToBeginning(ptr,row,col);
    cout << endl;
    printArray(ptr, row, col, "Print Insert Row To Beginning");
    removeRowFromBeginning(ptr, row, col);
    cout << endl;
    printArray(ptr, row, col, "Print Remove Row from Beginning");
    addRowToEnd(ptr,row,col);
    cout << endl;
    printArray(ptr, row, col, "Print Insert Row to end");
    removeRowFromEnd(ptr,row,col);
    cout << endl;
    printArray(ptr, row, col, "Print Remove Row from end");
    addColumnToBeginning(ptr, row, col);
    cout << endl;
    printArray(ptr, row, col, "Print Insert Col To Beginning");
    removeColumnFromBeginning(ptr, row, col);
    cout << endl;
    printArray(ptr, row, col, "Print Remove Col from Beginning");
    addColumnToEnd(ptr, row, col);
    cout << endl;
    printArray(ptr, row, col, "Print Insert Col to end");
    removeColumnFromEnd(ptr, row, col);
    cout << endl;
    printArray(ptr, row, col, "Print Remove Col from end");
}