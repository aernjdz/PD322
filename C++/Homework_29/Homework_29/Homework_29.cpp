#include "passport.h"
#include "foreign_passport.h"
#include "passport_manager.h"

int main() {
    Passport::PassportData passportData("John Doe", "123456789", "01-01-1990");
    Passport::Passport passport(passportData);
    passport.displayInfo();

    ForeignPassport::ForeignPassportData foreignPassportData("John Doe", "123456789", "01-01-1990", "USA", "10-01-2023");
    ForeignPassport::ForeignPassport foreignPassport(foreignPassportData);
    foreignPassport.displayInfo();

    PassportManager::PassportManager passportManager;
    passportManager.printPassportDetails(passport);
    passportManager.printForeignPassportDetails(foreignPassport);

   
}