#include <iostream>
using namespace std;

class Contact {
private:
    char* name;
    char* mobilePhone;
    char* city;
    char* country;

public:
    Contact() : name(nullptr), mobilePhone(nullptr), city(nullptr), country(nullptr) {}

    Contact(const char* p, const char* num_pho, const char* c, const char* cr)
        : name(nullptr), mobilePhone(nullptr), city(nullptr), country(nullptr) {
        setName(p);
        setMobilePhone(num_pho);
        setCity(c);
        setCountry(cr);
    }

    ~Contact() {
        delete[] name;
        delete[] mobilePhone;
        delete[] city;
        delete[] country;
    }

    const char* getName() const { return name; }
    const char* getMobilePhone() const { return mobilePhone; }
    const char* getCity() const { return city; }
    const char* getCountry() const { return country; }

    void setName(const char* p) {
        if (name != nullptr) {
            delete[] name;
        }
        if (p != nullptr) {
            name = new char[strlen(p) + 1];
            strcpy_s(name, strlen(p) + 1, p);
        }
        else {
            name = nullptr;
        }
    }

    void setMobilePhone(const char* num_pho) {
        if (mobilePhone != nullptr) {
            delete[] mobilePhone;
        }
        if (num_pho != nullptr) {
            mobilePhone = new char[strlen(num_pho) + 1];
            strcpy_s(mobilePhone, strlen(num_pho) + 1, num_pho);
        }
        else {
            mobilePhone = nullptr;
        }
    }

    void setCity(const char* c) {
        if (city != nullptr) {
            delete[] city;
        }
        if (c != nullptr) {
            city = new char[strlen(c) + 1];
            strcpy_s(city, strlen(c) + 1, c);
        }
        else {
            city = nullptr;
        }
    }

    void setCountry(const char* cr) {
        if (country != nullptr) {
            delete[] country;
        }
        if (cr != nullptr) {
            country = new char[strlen(cr) + 1];
            strcpy_s(country, strlen(cr) + 1, cr);
        }
        else {
            country = nullptr;
        }
    }
};

int main() {
    Contact contact("Aernjdz", "123-456-7890", "Warsaw", "Poland");

    cout << "Name: " << contact.getName() << endl;
    cout << "Mobile Phone: " << contact.getMobilePhone() << endl;
    cout << "City: " << contact.getCity() << endl;
    cout << "Country: " << contact.getCountry() << endl;

    return 0;
}
