#include "passport_manager.h"

namespace PassportManager {
    void PassportManager::printPassportDetails(const Passport::Passport& passport) const {
        cout << "Passport Manager - Passport Details:\n";
        passport.displayInfo();
    }

    void PassportManager::printForeignPassportDetails(const ForeignPassport::ForeignPassport& foreignPassport) const {
        cout << "Passport Manager - Foreign Passport Details:\n";
        foreignPassport.displayInfo();
    }
}