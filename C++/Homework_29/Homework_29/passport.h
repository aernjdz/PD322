#pragma once

#include <iostream>
#include <string>
using namespace std;
namespace Passport {
    struct PassportData {
        std::string fullName;
        std::string passportNumber;
        std::string dateOfBirth;

        PassportData(const std::string& fullName, const std::string& passportNumber, const std::string& dateOfBirth);
    };

    class Passport {
    public:
        Passport(const PassportData& data);
        void displayInfo() const;

    private:
        PassportData data;
    };
}