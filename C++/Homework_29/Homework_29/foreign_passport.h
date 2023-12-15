#pragma once
#include <iostream>
#include "passport.h"
using namespace std;

namespace ForeignPassport {
    struct ForeignPassportData : public Passport::PassportData {
       string issuingCountry;
        string expiryDate;

        ForeignPassportData(const string& fullName, const string& passportNumber, const string& dateOfBirth,
            const string& issuingCountry, const string& expiryDate);
    };

    class ForeignPassport : public Passport::Passport {
    public:
        ForeignPassport(const ForeignPassportData& data);
        void displayInfo() const;

    private:
        ForeignPassportData data;
    };
}