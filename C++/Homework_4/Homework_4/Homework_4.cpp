
#include <iostream>
#include <ctime>

using namespace std;

int main()
{
	//N1
	/*const int size = 10;
	int Array[size];

	srand((unsigned)time(0));
	for (size_t i = 0; i < size; i++) {
		Array[i] = rand() % 100;
	}

	int min = Array[0];
	int max = Array[0];

	for (size_t i = 0; i < size; i++) {

		if (Array[i] < min) {
			min = Array[i];
		}
		if (Array[i] > max) {
			max = Array[i];
		}
	}
	cout << "Array elements :: ";
	for (size_t i = 0; i < size; i++) {
		cout << Array[i] << " ";
	}
	cout << endl;

	cout << "Min value :: " << min << endl;
	cout << "Max value :: " << max << endl;*/

	//N2
	/*const int num_Month = 12;
	double Profits[num_Month];

	for (size_t i = 0; i < num_Month; i++) {
		cout << "Enter profit for month " << i + 1 << " :: ";
		cin >> Profits[i];

	}
	int start_Month, end_Month;
	cout << "Enter the starting month of the range (from 1 to 12) :: ";
	cin >> start_Month;
	cout << "Enter the ending month of the range (from 1 to 12) :: ";
	cin >> end_Month;

	if (start_Month < 1 || start_Month > num_Month || end_Month < 1 || end_Month > num_Month || start_Month > end_Month) {
		cout << "Invalid month entry. Please enter the range again." << endl;
		return 1;
	}

	double min = Profits[start_Month - 1];
	double max = Profits[start_Month - 1];
	int min_Month, max_Month;
	for (size_t i = start_Month - 1; i < end_Month; i++) {
		if (Profits[i] < min) {
			min = Profits[i];
			min_Month = i + 1;
		}
		if (Profits[i] > max) {
			max = Profits[i];
			max_Month = i + 1;
		}
	}
	cout << "Month with the maximum profit in the selected range :: " << max_Month << endl;
	cout << "Month with the minimum profit in the selected range :: " << min_Month << endl;*/

	//N3


	const int size = 10;

    int arr[size];

    srand((unsigned)time(0)); 

	cout << "Array of elements :: ";
    for (int i = 0; i < size; i++) {
        arr[i] = rand() % 20 - 10;
        cout << arr[i] << " ";
    }
    cout << endl;

    
	int sum_Negative = 0;

	int start_negative_index = -1;
	int end_negative_index = -1;
	int sum_Between_Negatives = 0;
	int product_Even_Indices = 1;
	int min_index = -1;
	int max_index = -1;
	int max = arr[0];
	int min = arr[0];
	int product_Between_Min_Max = 1;

	for (size_t i = 0; i < size; i++){
		if (arr[i] < min) {
			
			min_index = i;
			min = arr[i];
			//cout << i << endl;
			//cout << "---min----" << endl;
		}

		if (max < arr[i]) {
			
			max_index = i;
			max = arr[i];
			//cout << i << endl;
			//cout << "---max----" << endl;
		}

		if (start_negative_index == -1 && arr[i] < 0) {
			start_negative_index = i;
		}
		if (arr[i] < 0) {
			end_negative_index = i;
			sum_Negative += arr[i];
		}
		if (i % 2 == 0) {
			//cout << arr[i];
			product_Even_Indices *= arr[i];
		}
	}

	for (size_t i = start_negative_index + 1 ; i < end_negative_index; i++) {
		sum_Between_Negatives += arr[i];
	}
	if (min_index < max_index) {
		for (size_t i = min_index + 1; i < max_index; i++) {
			//cout << arr[i];
			product_Between_Min_Max *= arr[i];
		}
	}
	else {
		for (size_t i = max_index + 1; i < min_index; i++) {
			//cout << arr[i];
			product_Between_Min_Max *= arr[i];
		}
	}

	cout << "Sum of negative elements :: " << sum_Negative << endl;
	cout << "Product of elements between minimum and maximum :: " << product_Between_Min_Max << endl;
	cout << "Product of elements with even indices :: " << product_Even_Indices << endl;
	cout << "Sum of elements between the first and last negatives :: " << sum_Between_Negatives << endl;

    return 0;
	

}
