#include <iostream>
#include <ctime>  


using std::cout;
using std::endl;
using std::string;

template<typename T>
void createArray(T**& arr, int row, int col);

template<typename T>
void fillArray(T** arr, const int& row, const int& col, int min = 1, int max = 10);

template<typename T>
void printArray(T** arr, const int& row, const int& col, string text = "");

template<typename T>
void insertRow(T**& arr, int& row,  int col, int index);

template<typename T>
void removeRow(T**& arr, int& row,  int col, int index);

template<typename T>
void insertCol(T** arr, int row, int& col, int index);

template<typename T>
void removeCol(T** arr, const int& row, int& col, int index);

template<typename T>
T findMax(T** arr, const int& row, const int& col);

template<typename T>
T findMin(T** arr, const int& row, const int& col);

template<typename T>
void deleteRowsWithZeros(T**& arr, int& row, const int& col);

template<typename T>
void addRowToEnd(T**& arr, int& row, const int& col);

template <typename T>
void removeRowFromEnd(T**& arr, int& row, const int& col);

template<typename T>
void addRowToBeginning(T**& arr, int& row, const int& col);

template<typename T>
void removeRowFromBeginning(T**& arr, int& row, const int& col);

template<typename T>
void addColumnToEnd(T** arr, const int& row, int& col);

template<typename T>
void removeColumnFromEnd(T** arr, const int& row, int& col);

template<typename T>
void addColumnToBeginning(T** arr, const int& row, int& col);

template<typename T>
void removeColumnFromBeginning(T** arr, const int& row, int& col);



template<typename T>
void createArray(T**& arr, int row, int col) {
    T** tmp = new T * [row];
    for (int i = 0; i < row; i++) {
        tmp[i] = new T[col]{};
    }
    arr = tmp;
}

template<typename T>
void fillArray(T** arr, const int& row, const int& col, int min, int max ) {
    srand(time(0));
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            arr[i][j] = min + rand() % (max - min + 1);
        }
    }
}

template<typename T>
void printArray(T** arr, const int& row, const int& col, string text) {
    cout << text << endl;
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            cout << arr[i][j] << "\t";
        }
        cout << endl;
    }
}

template<typename T>
void insertRow(T**& arr, int& row,  int col, int index) {
   
    if (index == row) {
        T** tmp = new T * [row + 1];
        for (int i = 0; i < row; i++) {
            tmp[i] = arr[i];
        }
        tmp[row] = new T[col]{};
        delete[] arr;
        arr = tmp;
        row++;
    }
    
    else if (index >= 0 && index < row) {
        T** tmp = new T * [row + 1];
        for (int i = 0; i < index; i++) {
            tmp[i] = arr[i];
        }
        tmp[index] = new T[col]{}; 
        for (int i = index; i < row; i++) {
            tmp[i + 1] = arr[i];
        }
        delete[] arr;
        arr = tmp;
        row++;
    }
}


template<typename T>
void removeRow(T**& arr, int& row,  int col, int index) {
    if (index >= 0 && index < row) {
        T** tmp = new T * [row - 1];
        for (int i = 0, j = 0; i < row; i++) {
            if (i != index) {
                tmp[j] = arr[i];
                j++;
            }
            else {
                delete[] arr[i];
            }
        }
        delete[] arr;
        arr = tmp;
        row--;
    }
}

template<typename T>
void insertCol(T** arr, int row, int& col, int index) {
    if (index < 0 || index > col) {
        return;
    }
    for (int i = 0; i < row; i++) {
        T* tmp = new T[col + 1];
        tmp[index] = 0;
        for (int j = 0; j < col; j++) {
            if (j < index) {
                tmp[j] = arr[i][j];
            }
            else {
                tmp[j + 1] = arr[i][j];
            }
        }
        delete[] arr[i];
        arr[i] = tmp;
    }
    col++;
}

template<typename T>
void removeCol(T** arr, const int& row, int& col, int index) {
    if (index < 0 || index >= col) {
        return;
    }
    col--;
    for (int i = 0; i < row; i++) {
        T* tmp = new T[col];
        for (int j = 0; j < col; j++) {
            if (j < index) {
                tmp[j] = arr[i][j];
            }
            else {
                tmp[j] = arr[i][j + 1];
            }
        }
        delete[] arr[i];
        arr[i] = tmp;
    }
}

template<typename T>
T findMax(T** arr, const int& row, const int& col) {
    T max = arr[0][0];
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            if (arr[i][j] > max) {
                max = arr[i][j];
            }
        }
    }
    return max;
}

template<typename T>
T findMin(T** arr, const int& row, const int& col) {
    T min = arr[0][0];
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            if (arr[i][j] < min) {
                min = arr[i][j];
            }
        }
    }
    return min;
}

template<typename T>
void deleteRowsWithZeros(T**& arr, int& row, const int& col) {
    int numRowsWithZeros = 0;

    // Count the rows with zeros
    for (int i = 0; i < row; i++) {
        bool hasZero = false;
        for (int j = 0; j < col; j++) {
            if (arr[i][j] == 0) {
                hasZero = true;
                break;
            }
        }
        if (hasZero) {
            numRowsWithZeros++;
        }
    }

    if (numRowsWithZeros > 0) {
        T** tmp = new T * [row - numRowsWithZeros];
        int tmpRowIndex = 0;

        for (int i = 0; i < row; i++) {
            bool hasZero = false;
            for (int j = 0; j < col; j++) {
                if (arr[i][j] == 0) {
                    hasZero = true;
                    break;
                }
            }
            if (!hasZero) {
                tmp[tmpRowIndex] = arr[i];
                tmpRowIndex++;
            }
            else {
                delete[] arr[i];
            }
        }
        delete[] arr;
        arr = tmp;
        row -= numRowsWithZeros;
    }
}

template<typename T>
void addRowToEnd(T**& arr, int& row, const int& col) {
    T** tmp = new T * [row + 1];
    for (int i = 0; i < row; i++) {
        tmp[i] = arr[i];
    }
    tmp[row] = new T[col]{}; 
    delete[] arr;
    arr = tmp;
    row++;
}

template<typename T>
void removeRowFromEnd(T**& arr, int& row, const int& col) {
    if (row > 0) {
        delete[] arr[row - 1];
        row--;
    }
}

template<typename T>
void addRowToBeginning(T**& arr, int& row, const int& col) {
    T** tmp = new T * [row + 1];
    tmp[0] = new T[col]{}; 
    for (int i = 0; i < row; i++) {
        tmp[i + 1] = arr[i];
    }
    delete[] arr;
    arr = tmp;
    row++;
}

template<typename T>
void removeRowFromBeginning(T**& arr, int& row, const int& col) {
    if (row > 0) {
        delete[] arr[0];
        for (int i = 1; i < row; i++) {
            arr[i - 1] = arr[i];
        }
        row--;
    }
}

template<typename T>
void addColumnToEnd(T** arr, const int& row, int& col) {
    for (int i = 0; i < row; i++) {
        T* tmp = new T[col + 1];
        tmp[col] = 0; 
        for (int j = 0; j < col; j++) {
            tmp[j] = arr[i][j];
        }
        delete[] arr[i];
        arr[i] = tmp;
    }
    col++;
}

template<typename T>
void removeColumnFromEnd(T** arr, const int& row, int& col) {
    if (col > 0) {
        for (int i = 0; i < row; i++) {
            T* tmp = new T[col - 1];
            for (int j = 0; j < col - 1; j++) {
                tmp[j] = arr[i][j];
            }
            delete[] arr[i];
            arr[i] = tmp;
        }
        col--;
    }
}

template<typename T>
void addColumnToBeginning(T** arr, const int& row, int& col) {
    for (int i = 0; i < row; i++) {
        T* tmp = new T[col + 1];
        tmp[0] = 0; 
        for (int j = 0; j < col; j++) {
            tmp[j + 1] = arr[i][j];
        }
        delete[] arr[i];
        arr[i] = tmp;
    }
    col++;
}

template<typename T>
void removeColumnFromBeginning(T** arr, const int& row, int& col) {
    if (col > 0) {
        for (int i = 0; i < row; i++) {
            T* tmp = new T[col - 1];
            for (int j = 0; j < col - 1; j++) {
                tmp[j] = arr[i][j + 1];
            }
            delete[] arr[i];
            arr[i] = tmp;
        }
        col--;
    }
}
