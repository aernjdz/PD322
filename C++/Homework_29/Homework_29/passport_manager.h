#pragma once

#include "passport.h"
#include "foreign_passport.h"

namespace PassportManager {
    class PassportManager {
    public:
        void printPassportDetails(const Passport::Passport& passport) const;
        void printForeignPassportDetails(const ForeignPassport::ForeignPassport& foreignPassport) const;
    };
}