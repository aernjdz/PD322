
#include <iostream>
#include "Passport.h"
int main()
{
    Passport ukrainianPassport("John", "Doe", "UA123456", { 1 ,1,2000 }, "Kyiv", "Kyiv", "1234567890", "MOI", "Male");
    ukrainianPassport.display();
    std::cout << "\n";

    ForeignPassport foreignPassport("John", "Doe", "UA123456", { 1 ,1,2000 }, "Kyiv", "Kyiv", "1234567890", "MOI", "Male", "FP789012");
    foreignPassport.setVisa({ "USA" ,1,1,2023 });
    foreignPassport.display();
}

