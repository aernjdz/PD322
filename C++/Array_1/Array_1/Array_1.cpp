

#include <iostream>
#include <ctime>
using namespace std;

int main()
{
	//N1
	/*const int row = 5,col = 5;
	double sum = 0;
	int Array[row][col]; 


	srand((unsigned)time(0));

	for (size_t i = 0; i < row; i++) {
		for (size_t j = 0; j < col; j++) {
			Array[i][j] = rand() % 20 +1;
		}
	}

	int min = Array[0][0];
	int max = Array[0][0];

	for (size_t i = 0; i < row; i++) {
		for (size_t j = 0; j < col; j++) {
			sum += Array[i][j];
			if (Array[i][j] < min) {
				min = Array[i][j];
			}
			if (Array[i][j] > max) {
				max = Array[i][j];
			}
			cout << Array[i][j] << " ";
		}
		cout << endl;
	}
	
	cout << "Sum :: " << sum << endl;
	cout << "Arithmetic mean :: " << (sum / (row * col)) << endl;
	cout << "Min :: " << min << endl;
	cout << "Max :: " << max << endl;*/

	//N2
	/*const int row = 5,col = 5;
	int Array[row][col];
	

	srand((unsigned)time(0));

	for (size_t i = 0; i < row; i++) {
		for (size_t j = 0; j < col; j++) {
			if (i != 4 and j != 4) {
				Array[i][j] = rand() % 20 + 1;
			}
			else {
				Array[i][j] = 0;
			}
		}
	}

	

	for (size_t i = 0; i < 4 ; i++) {
		for (size_t j = 0; j < 4; j++) {
			Array[row-1][col-1] += Array[i][j];
			Array[i][col - 1] += Array[i][j];
			Array[row - 1][j] += Array[i][j];
		}
		
	}
	

	for (size_t i = 0; i < row; i++) {
		for (size_t j = 0; j < col; j++) {
			
			if ( j != col-1) {
				cout << Array[i][j] << "\t";
			}
			else{
				cout << "| " << Array[i][j];
			}		
		}
		cout << endl;
		if (i == row - 2) {
			
		cout << "------------------------------------" << endl;
			
		}
	}*/
	//N3
	const int row_1 = 5,col_1 = 10,row_2 = 5, col_2 = 5;
	int Array_1[row_1][col_1];
	int Array_2[row_2][col_2];


	srand((unsigned)time(0));

	cout << "The first array (5x10) :: " << endl;
	for (size_t i = 0; i < row_1; i++) {
		for (size_t j = 0; j < col_1; j++) {
			Array_1[i][j] = rand() % 51;
			cout << Array_1[i][j] << "\t";
		}
		cout << endl;
	}

	cout << "The second array (5x5) :: " << endl;
	for (size_t i = 0; i < row_2; i++) {
		for (size_t j = 0; j < col_2; j++) {
			Array_2[i][j] = Array_1[i][2 * j] + Array_1[i][2 * j + 1];

			cout << Array_2[i][j] << "\t";
		}
		cout << endl;
	}

}
