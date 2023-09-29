#include <iostream>
using namespace std;

// N1
//void printMatrix(int** matrix, int rows, int cols,string text = "") {
//    cout << text << endl;
//    for (int i = 0; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//            cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//}
//
//void addRowToEnd(int**& matrix, int& rows, int cols, int* newRow) {
//    int** oldMatrix = matrix;
//    rows++;
//    matrix = new int* [rows];
//    for (int i = 0; i < rows; i++) {
//        matrix[i] = new int[cols];
//    }
//
//    for (int i = 0; i < rows - 1; i++) {
//        for (int j = 0; j < cols; j++) {
//            matrix[i][j] = oldMatrix[i][j];
//        }
//    }
//
//
//    for (int j = 0; j < cols; j++) {
//        matrix[rows - 1][j] = newRow[j];
//    }
//
//
//    for (int i = 0; i < rows - 1; i++) {
//        delete[] oldMatrix[i];
//    }
//    delete[] oldMatrix;
//}

// N2
//void printMatrix(int** matrix, int rows, int cols,string text = "") {
//    cout << text << endl;
//    for (int i = 0; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//           cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//}
//void addRowToBeginning(int**& matrix, int& rows, int cols, int* newRow) {
//    int** newMatrix = new int* [rows + 1];
//    for (int i = 0; i < rows + 1; i++) {
//        newMatrix[i] = new int[cols];
//    }
//
//
//    for (int i = 0; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//            newMatrix[i + 1][j] = matrix[i][j];
//        }
//    }
//
//
//    for (int j = 0; j < cols; j++) {
//        newMatrix[0][j] = newRow[j];
//    }
//
//    for (int i = 0; i < rows; i++) {
//        delete[] matrix[i];
//    }
//
//    delete[] matrix;
//    matrix = newMatrix;
//    rows++;
//}

// N3
//void printMatrix(int** matrix, int rows, int cols,string text = "") {
//    cout << text << endl;
//    for (int i = 0; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//           cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//}
//void addRowAtIndex(int**& matrix, int& rows, int cols, int* newRow, int index) {
//    if (index < 0 || index > rows) {
//        cout << "error index" << endl;
//        return;
//    }
//
//    int** newMatrix = new int* [rows + 1];
//    for (int i = 0; i < rows + 1; i++) {
//        newMatrix[i] = new int[cols];
//    }
//
//    for (int i = 0; i < index; i++) {
//        for (int j = 0; j < cols; j++) {
//            newMatrix[i][j] = matrix[i][j];
//        }
//    }
//
//    for (int j = 0; j < cols; j++) {
//        newMatrix[index][j] = newRow[j];
//    }
//
//
//    for (int i = index; i < rows; i++) {
//        for (int j = 0; j < cols; j++) {
//            newMatrix[i + 1][j] = matrix[i][j];
//        }
//    }
//
//    for (int i = 0; i < rows; i++) {
//        delete[] matrix[i];
//    }
//    delete[] matrix;
//
//    matrix = newMatrix;
//    rows++;
//}

//N4
void printMatrix(int** matrix, int rows, int cols,string text = "") {
   cout << text << endl;
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
           cout << matrix[i][j] << " ";
        }
        cout << endl;
    }
}
void deleteRowAtIndex(int**& matrix, int& rows, int cols, int index) {
    if (index < 0 || index >= rows) {
        cout << "erorr index" << endl;
        return;
    }

    int** newMatrix = new int* [rows - 1];
    for (int i = 0, newRow = 0; i < rows; i++) {
        if (i != index) {
            newMatrix[newRow] = new int[cols];
            for (int j = 0; j < cols; j++) {
                newMatrix[newRow][j] = matrix[i][j];
            }
            newRow++;
        }
    }
    for (int i = 0; i < rows; i++) {
        delete[] matrix[i];
    }
    delete[] matrix;
    matrix = newMatrix;
    rows--;
}
int main() {
    int rows = 2;
    int cols = 3;

    int** matrix = new int* [rows];
    for (int i = 0; i < rows; i++) {
        matrix[i] = new int[cols];
    }

    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            matrix[i][j] = i * cols + j;
        }
    }

    int newRow[3] = { 9, 10, 11 };
    printMatrix(matrix, rows, cols,"Before :: ");
    deleteRowAtIndex(matrix, rows, cols, 1);

    printMatrix(matrix, rows, cols,"After :: ");

    for (int i = 0; i < rows; i++) {
        delete[] matrix[i];
    }
    delete[] matrix;

}
