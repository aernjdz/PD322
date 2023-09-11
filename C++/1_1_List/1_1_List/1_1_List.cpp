#include <iostream>
#include <ctime>
using namespace std;

int main() {
   //N1
	/*const int num_Months = 6;
	double profits[num_Months];
	double total_Profit = 0.0;

	for (size_t i = 0; i < num_Months; i++) {
		cout << "Enter profit for month " << i + 1 << " :: ";
		cin >> profits[i];

		total_Profit += profits[i];
	}
	cout << "Profit for each month :: " << endl;
	for (size_t i = 0; i < num_Months; ++i) {
		cout << "Month " << i + 1 << " :: " << profits[i] << endl;
	}

	cout << "Total profit for 6 months :: " << total_Profit << endl;*/

	//N2
	/*const int array_Size = 10;
	int Array[array_Size];

	cout << "Array :: ";
	srand(static_cast<unsigned>(time(0)));
	for (size_t i = 0; i < array_Size; ++i) {
		Array[i] = rand() % 100;
		cout << Array[i] << " ";
	}
	cout << endl;
	cout << "Array in reverse order :: ";
	for (int i = array_Size - 1; i >= 0; --i) {
		cout << Array[i] << " ";
	}
	cout << endl;*/

	//N3
	/*const int num_Sides = 5;
	double sides[num_Sides];
	double P = 0.0;
	for (size_t i = 0; i < num_Sides; ++i) {
		cout << "Enter the length of side " << i + 1 << " :: ";
		cin >> sides[i];
		P += sides[i];
	}
	cout << "The perimeter of the pentagon is :: " << P << endl;*/

	//N4
	const int num_Months = 12;
	double profits[num_Months];

	
	for (int i = 0; i < num_Months; ++i) {
		cout << "Enter profit for month " << i + 1 << " :: ";
		cin >> profits[i];
	}

	double maxProfit = profits[0];
	double minProfit = profits[0];
	int maxMonth = 1;
	int minMonth = 1;

	for (int i = 1; i < num_Months; ++i) {
		if (profits[i] > maxProfit) {
			maxProfit = profits[i];
			maxMonth = i + 1;
		}
		if (profits[i] < minProfit) {
			minProfit = profits[i];
			minMonth = i + 1;
		}
	}
	cout << "Month with the maximum profit: Month " << maxMonth << " (" << maxProfit << ")" << endl;
	cout << "Month with the minimum profit: Month " << minMonth << " (" << minProfit << ")" << endl;

}
