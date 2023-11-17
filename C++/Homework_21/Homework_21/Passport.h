#pragma once
#include<iostream>
using namespace std;
struct Date {

string type;
size_t day;
size_t month;
size_t year;

Date() = default;
Date(const string& t,const size_t& d, const size_t& m, const size_t& y) : type(t),day(d), month(m), year(y) {}
Date(const size_t& d, const size_t& m, const size_t& y):day(d),month(m),year(y){}

void displayDate() const {
    if (type == "") {
        if (month < 10 || day < 10) {
            cout << 0 << day << "/" << 0 << month << "/" << year << endl;
        }
        else if (day < 10) {
            cout << 0 << day << "/" << month << "/" << year << endl;
        }
        else if (month < 10) {
            cout << day << "/" << 0 << month << "/" << year << endl;
        }
        else {
            cout << day << "/" << month << "/" << year << endl;
        }
    }
    else {
        if (month < 10 || day < 10) {
            cout << type << "-" << 0 << day << "/" << 0 << month << "/" << year << endl;
        }
        else if (day < 10) {
            cout << type << "-" << 0 << day << "/" << month << "/" << year << endl;
        }
        else if (month < 10) {
            cout << type << "-"<<  day << "/" << 0 << month << "/" << year << endl;
        }
        else {
            cout << type << "-" << day << "/" << month << "/" << year << endl;
        }
    }
}
};

class Passport {
private:
    string FirstName;
    string LastName;
    string PassportNumber;
    Date DateOfBirth;
    string Residence;
    string Registration;
    string IdentificationNumber;
    string IssuingAuthority;
    string Gender;
public:
    Passport() = default;
    Passport(const string& firstName, const string& lastName, const string& passportNumber, const Date& dateOfBirth, const string& residence, const string& registration, const string& identificationNumber, const string& issuingAuthority, const string& gender) : FirstName{ firstName }, LastName{ lastName }, PassportNumber{ passportNumber }, DateOfBirth{ dateOfBirth},Residence{ residence }, Registration{ registration }, IdentificationNumber{ identificationNumber },IssuingAuthority{issuingAuthority}, Gender{ gender } {}

    void setFirstName(const string& fName) {
        FirstName = fName;
    }

    void setLastName(const std::string& lName) {
        LastName = lName;
    }

    void setPassportNumber(const string& passportNum) {
        PassportNumber = passportNum;
    }

    void setDateOfBirth(const Date& dob) {
        DateOfBirth = dob;
    }

    void setResidence(const string& place) {
        Residence = place;
    }

    void setRegistration(const string& reg) {
        Registration = reg;
    }

    void setIdentificationNumber(const string& idNum) {
        IdentificationNumber = idNum;
    }

    void setIssuingAuthority(const string& authority) {
        IssuingAuthority = authority;
    }

    void setGender(const string& gen) {
        Gender = gen;
    }

    void display() const {
        cout << "Passport Information:\n";
        cout << "First Name: " << FirstName << "\n";
        cout << "Last Name: " << LastName << "\n";
        cout << "Passport Number: " << PassportNumber << "\n";
        cout << "Date of Birth :: ";
        DateOfBirth.displayDate();
        cout << "Residence: " << Residence << "\n";
        cout << "Registration: " << Registration << "\n";
        cout << "Identification Number: " << IdentificationNumber << "\n";
        cout << "Issuing Authority: " << IssuingAuthority << "\n";
        cout << "Gender: " << Gender << "\n";
    }
};
class ForeignPassport : public Passport {
private:
    string foreignPassportNumber;
    Date visa;

public:
    ForeignPassport(const string& firstName, const string& lastName, const string& passportNumber,
        const Date& dateOfBirth, const string& residence, const string& registration,
        const string& identificationNumber, const string& issuingAuthority, const string& gender,
        const string& foreignPassportNumber)
        : Passport(firstName, lastName, passportNumber, dateOfBirth, residence, registration, identificationNumber, issuingAuthority, gender),
        foreignPassportNumber(foreignPassportNumber) {}

    void setForeignPassportNumber(const string& fpNumber) {
        foreignPassportNumber = fpNumber;
    }

    void setVisa(const Date& visaInfo) {
        visa = visaInfo;
    }

    void display() const {
        Passport::display();
        cout << "Foreign Passport Information:" << endl;
        cout << "Foreign Passport Number: " << foreignPassportNumber <<endl;
        cout << "Visa: ";
        visa.displayDate();
    }
};
