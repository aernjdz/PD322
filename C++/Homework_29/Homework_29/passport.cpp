#include "passport.h"
#include <iostream>
using namespace std;

namespace Passport {
    PassportData::PassportData(const string& fullName, const string& passportNumber, const string& dateOfBirth)
        : fullName(fullName), passportNumber(passportNumber), dateOfBirth(dateOfBirth) {}

    Passport::Passport(const PassportData& data) : data(data) {}

    void Passport::displayInfo() const {
       cout << "Passport Information:\n";
       cout << "Full Name: " << data.fullName << "\n";
       cout << "Passport Number: " << data.passportNumber << "\n";
       cout << "Date of Birth: " << data.dateOfBirth << "\n";
       cout << "-----------------------------\n";
    }
}