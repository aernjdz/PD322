#include <iostream>
using namespace std;
#include"IDrive.h"
int main() {
   
    Car car("Toyota", 200);
    Horse horse("Spirit", "Arabian");
    Driver driver("John");

 
    driver.setVehicle(&car);
    driver.testDrive();

    cout << "\n";

   
    driver.setVehicle(&horse);
    driver.testDrive();

    return 0;
}
