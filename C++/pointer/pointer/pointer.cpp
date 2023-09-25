#include <iostream>
using namespace std;

// N1
//template <typename T>
//T findMax(T* num_1, T* num_2) {
//	return (*num_1 > *num_2) ? *num_1 : *num_2;
//}

// N2
//string determineSign(double* ptr) {
//	if (*ptr == 0) return "is equal to zero";
//	if (*ptr > 0) { return "more than 0"; } else { return "less than 0"; }
//}

// N3
//void swap(double* num_1, double* num_2) {
//	double temp = *num_1;
//	*num_1 = *num_2;
//	*num_2 = temp;
//}

// N4
//void add(double* result, double* num1, double* num2) {
//	*result = *num1 + *num2;
//}
//
//void subtract(double* result, double* num1, double* num2) {
//	*result = *num1 - *num2;
//}
//
//void multiply(double* result, double* num1, double* num2) {
//	*result = *num1 * *num2;
//}
//
//bool divide(double* result, double* num1, double* num2) {
//	if (*num2 != 0) {
//		*result = *num1 / *num2;
//		return true; 
//	}
//	else {
//		return false; 
//	}
//}

// N5
void fillArrayWithRandomValues(int* arr, int size) {
    for (int i = 0; i < size; i++) {
        arr[i] = rand() % 100; 
    }
}
int calculateSum(int* arr, int size) {
    int sum = 0;
    for (int i = 0; i < size; i++) {
        sum += *(arr + i);
    }
    return sum;
}
void printArray(int* arr, int size, string text = "") {
    cout << text;
    for (int i = 0; i < size; i++) {
       cout << arr[i] << " ";
    }
    cout << endl;
}
int main()
{
    srand(unsigned(time(0)));
	// N1
	/*int num1 = 8, num2= -10;
	double num3= -6.7, num4 = 0.8;
	

	
	cout << "Max int :: " << findMax(&num1, &num2) << endl;
	cout << "Max double :: " << findMax(&num3, &num4) << endl;*/

	// N2
	/*double num;
	cout << "Enter is number :: ";
	cin >> num;

	cout << "" << determineSign(&num) << endl;*/

	// N3

	/*double num1 = 5, num2 = 8;
	swap(&num1, &num2);
	cout << "After the exchange: the first number = " << num1 << ", second number = " << num2 << endl;*/


	// N4
 /* double num1, num2;
    char operation;

    cout << "Enter the first number: ";
    cin >> num1;

    cout << "Enter the operation (+, -, *, /): ";
    cin >> operation;

    cout << "Enter the second number: ";
    cin >> num2;

    double result = 0.0;

    switch (operation) {
    case '+':
        add(&result, &num1, &num2);
        break;
    case '-':
        subtract(&result, &num1, &num2);
        break;
    case '*':
        multiply(&result, &num1, &num2);
        break;
    case '/':
        if (divide(&result, &num1, &num2)) {
            break;
        }
        else {
            cout << "Error: Division by zero" << endl;
            return 1; 
        }
    default:
        cout << "Error: Invalid operation" << endl;
        return 1; 
    }

    cout << "Result: " << num1 << " " << operation << " " << num2 << " = " << result << endl;*/

    // N5
    const int arraySize = 5;
    int myArray[arraySize];

    fillArrayWithRandomValues(myArray, arraySize);
    printArray(myArray, arraySize, "Array :: ");
    int sum = calculateSum(myArray, arraySize);

    cout << "The sum of array elements :: " << sum << endl;

        
}


