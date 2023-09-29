#include <iostream>

using namespace std;

void fillSpiralMatrix(int** mat, int N) {
    int num = 1;
    int left = 0, right = N - 1, up = 0, down = N - 1;

    while (left <= right && up <= down) {
       
        for (int col = left; col <= right; col++) {
            mat[up][col] = num++;
        }
        up++;

     
        for (int row = up; row <= down; row++) {
            mat[row][right] = num++;
        }
        right--;

        for (int col = right; col >= left; col--) {
            mat[down][col] = num++;
        }
        down--;

        for (int row = down; row >= up; row--) {
            mat[row][left] = num++;
        }
        left++;
    }
}
void printMatrix(int** mat, int N, string text = "") {
    cout << text << endl;
    for (int row = 0; row < N; row++) {
        for (int col = 0; col < N; col++) {
            cout << mat[row][col] << "\t";
        }
        cout << endl;
    }
}

void deleteMatrix(int** mat, int N) {
    for (int i = 0; i < N; i++) {
        delete[] mat[i];
    }
    delete[] mat;
}
int main() {
    int N;
    cout << "Enter the size of the matrix (N): ";
    cin >> N;

    int** matrix = new int* [N];
    for (int i = 0; i < N; i++) {
        matrix[i] = new int[N];
    }

    fillSpiralMatrix(matrix, N);

    cout << "Matrix NxN with numbers from 1 to " << N * N << " in a spiral pattern:" << endl;
    printMatrix(matrix, N);

   
    deleteMatrix(matrix, N);

    
   
}
