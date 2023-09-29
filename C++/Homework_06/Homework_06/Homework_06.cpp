#include <iostream>
#include <ctime> 
using namespace std;
//  N1

//void printMatrix(int** matrix, int numRows, int numCols) {
//    for (int i = 0; i < numRows; i++) {
//        for (int j = 0; j < numCols; j++) {
//            cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//}
//
//void deleteMatrix(int**& matrix, int numRows) {
//    for (int i = 0; i < numRows; i++) {
//        delete[] matrix[i];
//    }
//    delete[] matrix;
//    matrix = nullptr;
//}
//
//void addColumn(int**& matrix, int& numRows, int& numCols, int* newColumn, int position) {
//    if (position < 0 || position > numCols) {
//        cout << "Invalid position for adding a column." << endl;
//        return;
//    }
//
//    int** newMatrix = new int* [numRows];
//    for (int i = 0; i < numRows; i++) {
//        newMatrix[i] = new int[numCols + 1];
//        for (int j = 0, col = 0; col <= numCols; j++, col++) {
//            if (col == position) {
//                newMatrix[i][col] = newColumn[i];
//                col++;
//            }
//            newMatrix[i][col] = matrix[i][j];
//        }
//    }
//
//    deleteMatrix(matrix, numRows);
//
//    matrix = newMatrix;
//    numCols++;
//}
//
//void generateRandomMatrix(int**& matrix, int& numRows, int& numCols) {
//    cout << "Enter the number of rows: ";
//    cin >> numRows;
//    cout << "Enter the number of columns: ";
//    cin >> numCols;
//
//    matrix = new int* [numRows];
//    for (int i = 0; i < numRows; i++) {
//        matrix[i] = new int[numCols];
//        for (int j = 0; j < numCols; j++) {
//            matrix[i][j] = rand() % 100; 
//        }
//    }
//}

// N2
//void printMatrix(int** matrix, int numRows, int numCols) {
//    for (int i = 0; i < numRows; i++) {
//        for (int j = 0; j < numCols; j++) {
//            cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//}
//
//void deleteMatrix(int**& matrix, int numRows) {
//    for (int i = 0; i < numRows; i++) {
//        delete[] matrix[i];
//    }
//    delete[] matrix;
//    matrix = nullptr;
//}
//
//void deleteColumn(int**& matrix, int& numRows, int& numCols, int position) {
//    if (position < 0 || position >= numCols) {
//        cout << "Invalid position for deleting a column." << endl;
//        return;
//    }
//
//    int** newMatrix = new int* [numRows];
//    for (int i = 0; i < numRows; i++) {
//        newMatrix[i] = new int[numCols - 1];
//        for (int j = 0, col = 0; j < numCols; j++) {
//            if (j != position) {
//                newMatrix[i][col] = matrix[i][j];
//                col++;
//            }
//        }
//    }
//
//    deleteMatrix(matrix, numRows);
//
//    matrix = newMatrix;
//    numCols--;
//}
//
//void generateRandomMatrix(int**& matrix, int& numRows, int& numCols) {
//    cout << "Enter the number of rows: ";
//    cin >> numRows;
//    cout << "Enter the number of columns: ";
//    cin >> numCols;
//
//    matrix = new int* [numRows];
//    for (int i = 0; i < numRows; i++) {
//        matrix[i] = new int[numCols];
//        for (int j = 0; j < numCols; j++) {
//            matrix[i][j] = rand() % 100; 
//        }
//    }
//}

// N3

void printMatrix(int** matrix, int numRows, int numCols) {
    for (int i = 0; i < numRows; i++) {
        for (int j = 0; j < numCols; j++) {
            cout << matrix[i][j] << " ";
        }
        cout << endl;
    }
}

void deleteMatrix(int**& matrix, int numRows) {
    for (int i = 0; i < numRows; i++) {
        delete[] matrix[i];
    }
    delete[] matrix;
    matrix = nullptr;
}

void generateRandomMatrix(int**& matrix, int& numRows, int& numCols) {
    cout << "Enter the number of rows: ";
    cin >> numRows;
    cout << "Enter the number of columns: ";
    cin >> numCols;

    matrix = new int* [numRows];
    for (int i = 0; i < numRows; i++) {
        matrix[i] = new int[numCols];
        for (int j = 0; j < numCols; j++) {
            matrix[i][j] = rand() % 100; 
        }
    }
}

void rotateRows(int**& matrix, int numRows, int numCols, int numRotations, bool clockwise) {
    int** newMatrix = new int* [numRows];
    for (int i = 0; i < numRows; i++) {
        newMatrix[i] = new int[numCols];
    }

    for (int k = 0; k < numRotations; k++) {
        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                if (clockwise) {
                    newMatrix[(i + 1) % numRows][j] = matrix[i][j];
                }
                else {
                    newMatrix[i][j] = matrix[(i + 1) % numRows][j];
                }
            }
        }

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                matrix[i][j] = newMatrix[i][j];
            }
        }
    }

    for (int i = 0; i < numRows; i++) {
        delete[] newMatrix[i];
    }
    delete[] newMatrix;
}

void rotateColumns(int**& matrix, int numRows, int numCols, int numRotations, bool clockwise) {
    int** newMatrix = new int* [numRows];
    for (int i = 0; i < numRows; i++) {
        newMatrix[i] = new int[numCols];
    }

    for (int k = 0; k < numRotations; k++) {
        for (int j = 0; j < numCols; j++) {
            for (int i = 0; i < numRows; i++) {
                if (clockwise) {
                    newMatrix[i][(j + 1) % numCols] = matrix[i][j];
                }
                else {
                    newMatrix[i][j] = matrix[i][(j + 1) % numCols];
                }
            }
        }

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                matrix[i][j] = newMatrix[i][j];
            }
        }
    }

    for (int i = 0; i < numRows; i++) {
        delete[] newMatrix[i];
    }
    delete[] newMatrix;
}



int main() {

    srand(static_cast<unsigned>(time(0)));

    //N1

    /*int numRows, numCols;
    int** matrix = nullptr;


    

    generateRandomMatrix(matrix, numRows, numCols);

    int* newColumn = new int[numRows];
    cout << "Enter the new column elements:" << endl;
    for (int i = 0; i < numRows; i++) {
        cin >> newColumn[i];
    }

    int position;
    cout << "Enter the position to add the new column: ";
    cin >> position;

    addColumn(matrix, numRows, numCols, newColumn, position);

    cout << "Updated matrix:" << endl;
    printMatrix(matrix, numRows, numCols);

    deleteMatrix(matrix, numRows);
    delete[] newColumn;*/

    // N2
    /*int numRows, numCols;
    int** matrix = nullptr;
    generateRandomMatrix(matrix, numRows, numCols);

    cout << "Generated matrix:" << endl;
    printMatrix(matrix, numRows, numCols);

    int position;
    cout << "Enter the position of the column to delete: ";
    cin >> position;

    deleteColumn(matrix, numRows, numCols, position);

    cout << "Updated matrix:" << endl;
    printMatrix(matrix, numRows, numCols);

    deleteMatrix(matrix, numRows);*/

    //N3
    int numRows, numCols;
    int** matrix = nullptr;


    generateRandomMatrix(matrix, numRows, numCols);

    cout << "Generated matrix:" << endl;
    printMatrix(matrix, numRows, numCols);

    int numRotations;
    cout << "Enter the number of rotations: ";
    cin >> numRotations;

    bool clockwise;
    cout << "Rotate clockwise? (1 for yes, 0 for no): ";
    cin >> clockwise;

    char choice;
    cout << "Rotate rows (R) or columns (C) all matrix (A) ? ";
    cin >> choice;

    if (choice == 'R' || choice == 'r') {
        rotateRows(matrix, numRows, numCols, numRotations, clockwise);
    }
    else if (choice == 'C' || choice == 'c' ) {
        rotateColumns(matrix, numRows, numCols, numRotations, clockwise);
    }
    else if (choice == 'A' || choice == 'a') { 
        rotateRows(matrix, numRows, numCols, numRotations, clockwise);
        rotateColumns(matrix, numRows, numCols, numRotations, clockwise);
    }
    else {
        cout << "Invalid choice." << endl;
    }


    cout << "Rotated matrix:" << endl;
    printMatrix(matrix, numRows, numCols);

    deleteMatrix(matrix, numRows);
  
}
