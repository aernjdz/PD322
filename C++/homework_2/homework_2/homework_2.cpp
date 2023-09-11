#include <iostream>
using namespace std;

int main()
{
    int num_1, num_2, num_3, num_4, num_5, num_6, num_7;
    //N1
    int number;

    cout << "Enter a six-digit number :: ";
    cin >> number;
    if (number >= 100000 && number <= 999999) {
   
        num_1 = number / 100000;
        num_2 = (number / 10000) % 10;
        num_3 = (number / 1000) % 10;
        num_4 = (number / 100) % 10;
        num_5 = (number / 10) % 10;
        num_6 = number % 10;

        cout << ((num_1 + num_2 + num_3 == num_4 + num_5 + num_6) ? "The number is lucky!" :  "The number is not lucky." ) << endl;  
    }
    else {
        cout << "Error: Please enter a six-digit number." << endl;
    }
    
    //N2
    int number;

   
    cout << "Enter a four-digit number :: ";
    cin >> number;

    if (number >= 1000 && number <= 9999) {
          
            num_1 = number / 1000;
            num_2 = (number / 100) % 10;
            num_3 = (number / 10) % 10;
            num_4 = number % 10;

           
            int new_Number = (num_2 * 1000) + (num_1 * 100) + (num_4 * 10) + num_3;

            cout << "Original number: " << number << endl;
            cout << "Modified number: " << new_Number << endl;
        }
    else {
            cout << "Error: Please enter a four-digit number." << endl;
        }

    //N3
    cout << "Enter seven integers :: ";
    cin >> num_1 >> num_2 >> num_3 >> num_4 >> num_5 >> num_6 >> num_7;
    int maxNumber = num_1;

    if (num_2 > maxNumber) {
            maxNumber = num_2;
    }
    if (num_3 > maxNumber) {
            maxNumber = num_3;
    }
    if (num_4 > maxNumber) {
            maxNumber = num_4;
    }
    if (num_5 > maxNumber) {
            maxNumber = num_5;
    }
    if (num_6 > maxNumber) {
            maxNumber = num_6;
    }
    if (num_7 > maxNumber) {
            maxNumber = num_7;
    }

    cout << "The maximum number is: " << maxNumber << endl;

    //N4
    
    double distanceAB, distanceBC, cargoWeight;

    
    cout << "Enter the distance from point A to point B (in kilometers) :: ";
    cin >> distanceAB;
    cout << "Enter the distance from point B to point C (in kilometers) :: ";
    cin >> distanceBC;
    cout << "Enter the weight of the cargo (in kilograms) :: ";
    cin >> cargoWeight;
    double fuelConsumptionPerKm;
    if (cargoWeight <= 500) {
        fuelConsumptionPerKm = 1.0;
    }
    else if (cargoWeight <= 1000) {
        fuelConsumptionPerKm = 4.0;
    }
    else if (cargoWeight <= 1500) {
        fuelConsumptionPerKm = 7.0;
    }
    else if (cargoWeight <= 2000) {
        fuelConsumptionPerKm = 9.0;
    }
    else {
        cout << "The aircraft cannot lift cargo exceeding 2000 kg. Flight is impossible." << endl;
        return 1;
    }
    double requiredFuel = (distanceAB + distanceBC) * fuelConsumptionPerKm;

    cout << "The minimum amount of fuel required for refueling at point B is: " << requiredFuel << " liters." << endl;

    
      

        
    
}

