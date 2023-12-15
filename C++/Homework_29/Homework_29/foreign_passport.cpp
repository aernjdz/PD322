#include "foreign_passport.h"
#include <iostream>
using namespace std;


namespace ForeignPassport {
    ForeignPassportData::ForeignPassportData(const string& fullName, const string& passportNumber,
        const string& dateOfBirth, const string& issuingCountry, const string& expiryDate)
        : Passport::PassportData(fullName, passportNumber, dateOfBirth), issuingCountry(issuingCountry), expiryDate(expiryDate) {}

    ForeignPassport::ForeignPassport(const ForeignPassportData& data) : Passport::Passport(data), data(data) {}

    void ForeignPassport::displayInfo() const {
        Passport::displayInfo();
        cout << "Foreign Passport Information:\n";
        cout << "Issuing Country: " << data.issuingCountry << "\n";
        cout << "Expiry Date: " << data.expiryDate << "\n";
        cout << "-----------------------------\n";
    }
}