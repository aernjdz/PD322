#include <iostream>
#include <ctime>

using namespace std;
//
//const int MAX_SIZE = 100;
//
//void inputArray(int arr[], int& size) {
//    cout << "Enter the size of the array: ";
//    cin >> size;
//
//    cout << "Enter the elements of the array:" << endl;
//    for (int i = 0; i < size; i++) {
//        cin >> arr[i];
//    }
//}
//
//void displayArray(const int arr[], int size) {
//    cout << "Array elements:" << endl;
//    for (int i = 0; i < size; i++) {
//        cout << arr[i] << " ";
//    }
//    cout << endl;
//}
//
//void shuffleArray(int arr[], int size) {
//    srand(static_cast<unsigned int>(time(nullptr)));
//    for (int i = size - 1; i > 0; i--) {
//        int randomIndex = rand() % (i + 1);
//        int temp = arr[i];
//        arr[i] = arr[randomIndex];
//        arr[randomIndex] = temp;
//    }
//}
//
//int findFirstIndex(const int arr[], int size, int target) {
//    for (int i = 0; i < size; i++) {
//        if (arr[i] == target) {
//            return i;
//        }
//    }
//    return -1;
//}
//
//int findLastIndex(const int arr[], int size, int target) {
//    for (int i = size - 1; i >= 0; i--) {
//        if (arr[i] == target) {
//            return i;
//        }
//    }
//    return -1;
//}
//
//void sortAscending(int arr[], int size) {
//    for (int i = 1; i < size; i++) {
//        int key = arr[i];
//        int j = i - 1;
//        while (j >= 0 && arr[j] > key) {
//            arr[j + 1] = arr[j];
//            j--;
//        }
//        arr[j + 1] = key;
//    }
//}
//
//void sortDescending(int arr[], int size) {
//    for (int i = 1; i < size; i++) {
//        int key = arr[i];
//        int j = i - 1;
//        while (j >= 0 && arr[j] < key) {
//            arr[j + 1] = arr[j];
//            j--;
//        }
//        arr[j + 1] = key;
//    }
//}
//
//string repeatCharacter(char character, int length) {
//    string result;
//    result.reserve(length);
//
//    for (int i = 0; i < length; i++) {
//        result += character;
//    }
//
//    return result;
//}

// N2
template <typename T, int COL>
void populateArray(T matrix[][COL], int row, int col, int min = 1, int max = 20) {
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            matrix[i][j] = min + rand() % (max - min + 1);
        }
    }
}

template <typename T, int COL>
void displayArray(T matrix[][COL], int row, int col, string text = "") {
    cout << text << ":: " << endl;
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            cout << matrix[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

template <typename T, int COL>
auto findMaxElement(T matrix[][COL], int row, int col) {
    auto max = matrix[0][0];

    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            if (max < matrix[i][j]) {
                max = matrix[i][j];
            }
        }
    }

    return max;
}

template <typename T, int COL>
bool isRowSorted(T matrix[][COL], int row, int col, int number_row) {
    if (number_row < 0 || number_row >= row)
        return false;

    for (int j = 0; j < col - 1; j++) {
        if (matrix[number_row][j] > matrix[number_row][j + 1]) {
            return false;
        }
    }

    return true;
}

template <typename T, int COL>
bool areAllRowsSorted(T matrix[][COL], int row, int col) {
    for (int j = 0; j < row; j++) {
        if (!isRowSorted(matrix, row, col, j)) {
            return false;
        }
    }
    return true;
}
int main() {

    // N1
    /*int arr[MAX_SIZE];
    int size;

    inputArray(arr, size);
    displayArray(arr, size);

    shuffleArray(arr, size);

    cout << "Shuffled array:" << endl;
    displayArray(arr, size);

    int target;
    cout << "Enter the target element to search for: ";
    cin >> target;

    int firstIndex = findFirstIndex(arr, size, target);
    if (firstIndex != -1) {
        cout << "The first occurrence of " << target << " is at index " << firstIndex << endl;
    }
    else {
        cout << target << " not found in the array." << endl;
    }

    int lastIndex = findLastIndex(arr, size, target);
    if (lastIndex != -1) {
        cout << "The last occurrence of " << target << " is at index " << lastIndex << endl;
    }
    else {
        cout << target << " not found in the array." << endl;
    }
    sortAscending(arr, size);
    cout << "Sorted in ascending order:" << endl;
    displayArray(arr, size);

    sortDescending(arr, size);
    cout << "Sorted in descending order:" << endl;
    displayArray(arr, size);

    char character = 'A';
    int length = 5;
    string newArray = repeatCharacter(character, length);
    cout << newArray << endl;*/

    // N2
    const int row = 4, col = 3;
    int matrix[row][col]{ {1, 2, 3}, {4, 5, 6}, {7, 8, 9}, {10, 11, 12} };

    displayArray(matrix, row, col, "Example Matrix");
    cout << "Max element: " << findMaxElement(matrix, row, col) << endl;
    cout << "IsRowSorted: " << boolalpha << isRowSorted(matrix, row, col, 3) << endl;
    cout << "AreAllRowsSorted: " << boolalpha << areAllRowsSorted(matrix, row, col) << endl;

        
    

}
