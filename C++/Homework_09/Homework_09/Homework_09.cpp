#include <iostream>
#include <string>
#include <cstring>

using namespace std;

struct Car {
    string model;
    string color;
    union {
        int number_int;
        char number_string[9];
    };
    bool is_number;
    Car() : model(""), color(""), is_number(true), number_int(0) { }
    Car(string model, string color, int number) : model(model), color(color), is_number(true) {number_int = number;}
    Car(string model, string color, const char* number) : model(model), color(color), is_number(false) {
        strncpy_s(number_string, number, 8);
        number_string[8] = '\0';
    }

    void printCar() {
        cout << "Model: " << model << endl;
        cout << "Color: " << color << endl;
        if (is_number) {
            cout << "Number: " << number_int << endl;
        }
        else {
            cout << "Number: " << number_string << endl;
        }
    }
};

void fillCar(Car& car, string model, string color, int number) {
    car.model = model;
    car.color = color;
    car.is_number = true;
    car.number_int = number;
}

void fillCar(Car& car, string model, string color, const char* number) {
    car.model = model;
    car.color = color;
    car.is_number = false;
    strncpy_s(car.number_string, number, 8);
    car.number_string[8] = '\0';
}

void editCar(Car& car, string model, string color, int number) {
    car.model = model;
    car.color = color;
    car.is_number = true;
    car.number_int = number;
}

void editCar(Car& car, string model, string color, const char* number) {
    car.model = model;
    car.color = color;
    car.is_number = false;
    strncpy_s(car.number_string, number, 8);
    car.number_string[8] = '\0';
}

void printAllCars(Car cars[], int count) {
    for (int i = 0; i < count; i++) {
        cout << "Car " << i + 1 << ":" << endl;
        cars[i].printCar();
        cout << endl;
    }
}
char* toLowerCase(char* line)
{
    char* newLine = new char[strlen(line) + 1];
    for (size_t i = 0; i < strlen(line); i++) {
        newLine[i] = tolower(line[i]);
    }
    newLine[strlen(line)] = '\0';
    return newLine;
};
int findCarByNumber(Car cars[], int count, char* number) {
    char* loweredNumber = toLowerCase(number);

    for (int i = 0; i < count; i++) {
        if (!cars[i].is_number) {
            char* carNumberLowered = toLowerCase(cars[i].number_string);

            if (strcmp(carNumberLowered, loweredNumber) == 0) {
                delete[] loweredNumber; 
                delete[] carNumberLowered;
                return i;
            }

            delete[] carNumberLowered;
        }
        else {
            
            char carNumberString[9];
            sprintf_s(carNumberString, "%d", cars[i].number_int);

            if (strcmp(carNumberString, loweredNumber) == 0) {
                delete[] loweredNumber; 
                return i;
            }
        }
    }

    delete[] loweredNumber;
    return -1; 
}

int main() {
    const int numCars = 10;
    Car cars[numCars];

   
    fillCar(cars[0], "Sedan", "black", 1000);
    fillCar(cars[1], "SUV", "blue", "ABC123");
    fillCar(cars[2], "Convertible", "red", "XYZ789");
    fillCar(cars[3], "Truck", "white", 2000);
    fillCar(cars[4], "SUV", "green", "DEF456");
    fillCar(cars[5], "Sedan", "gray", "JKL321");
    fillCar(cars[6], "Convertible", "yellow", 3000);
    fillCar(cars[7], "Truck", "silver", "MNO987");
    fillCar(cars[8], "SUV", "black", 4000);
    fillCar(cars[9], "Sedan", "white", "PQR654");
    int foundCarIndex;
    while (true) {
        cout << "Menu:" << endl;
        cout << "1. Print all cars" << endl;
        cout << "2. Edit a car" << endl;
        cout << "3. Find a car by number" << endl;
        cout << "4. Exit" << endl;
        cout << "Enter your choice: ";
        char searchNumber[9];
        int choice;
        cin >> choice;

        switch (choice) {
        case 1:
            printAllCars(cars, numCars);
            break;
        case 2:
            int carIndex;
            cout << "Enter the index of the car to edit: ";
            cin >> carIndex;
            if (carIndex >= 0 && carIndex < numCars) {
                string model, color;
                cout << "Enter the new model: ";
                cin >> model;
                cout << "Enter the new color: ";
                cin >> color;
                if (cars[carIndex].is_number) {
                    int number;
                    cout << "Enter the new number (integer): ";
                    cin >> number;
                    editCar(cars[carIndex], model, color, number);
                }
                else {
                    char number[9];
                    cout << "Enter the new number (text): ";
                    cin >> number;
                    editCar(cars[carIndex], model, color, number);
                }
            }
            else {
                cout << "Invalid car index." << endl;
            }
            break;
        case 3:
           
            cout << "Enter the number to search for: ";
            cin >> searchNumber;
             foundCarIndex = findCarByNumber(cars, numCars, searchNumber);
            if (foundCarIndex != -1) {
                cout << "Found car with number " << searchNumber << " at index " << foundCarIndex << endl;
                cars[foundCarIndex].printCar();
            }
            else {
                cout << "Car with number " << searchNumber << " not found." << endl;
            }
            break;
        case 4:
            return 0;
        default:
            cout << "Invalid choice. Please select a valid option." << endl;
            break;
        }
    }

    return 0;
}
