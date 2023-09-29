//#include "arrayFunc.h"
//
//
//int** createArray(int row, int col)
//{
//	int** tmp = new int * [row];
//	for (size_t i = 0; i < row; i++)
//	{
//		tmp[i] = new int[col]{};
//	}
//	return tmp;
//}
//
////template<typename T>
//void fillArray(int** arr, const int& row, const int& col, int min, int max)
//{
//	for (size_t i = 0; i < row; i++)
//	{
//		for (size_t j = 0; j < col; j++)
//		{
//			arr[i][j] = min + rand() % (max - min + 1);
//		}
//	}
//}
//
//void printArray(int** arr, const int& row, const int& col, string text)
//{
//	cout << text << endl;
//	for (size_t i = 0; i < row; i++)
//	{
//		for (size_t j = 0; j < col; j++)
//		{
//			cout << arr[i][j] << "\t";
//		}
//		cout << endl;
//	}
//}