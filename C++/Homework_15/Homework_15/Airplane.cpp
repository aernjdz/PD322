#include "Airplane.h"

bool Airplane::operator==(const Airplane& other) const {
    return this->type == other.type;
}
bool Airplane::operator>(const Airplane& other) const {
    return this->MaxPassengers > other.MaxPassengers;
}
bool Airplane::operator<(const Airplane& other) const {
    return this->MaxPassengers < other.MaxPassengers;
}
Airplane& Airplane::operator++() {
    if (this->Passengers < this->MaxPassengers) {
        this->Passengers++;
    }
    return *this;
}
Airplane& Airplane::operator--() {
    if (this->Passengers >0) {
        this->Passengers--;
    }
    return *this;
}
void Airplane::print(string text) const {
    cout << text << endl;
    cout << "Type: " << type << endl;
    cout<< "Passengers: " << Passengers << " / " << MaxPassengers << endl;
}