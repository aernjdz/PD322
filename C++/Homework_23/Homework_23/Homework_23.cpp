

#include <iostream>
#include "Animal.h"
using namespace std;

int main() {
    HomeZoo myZoo;

    myZoo.addAnimal();
    myZoo.addAnimal();
    myZoo.displayAnimals();
    cout << "=======================" << endl;
    myZoo.sellAnimal();
    myZoo.displayAnimals();
    cout << "=======================" << endl;
    myZoo.sellAllAnimals();
    myZoo.displayAnimals();

    return 0;
}
