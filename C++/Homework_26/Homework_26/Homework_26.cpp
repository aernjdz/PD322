#include <iostream>
#include <string>
#include "SocialNetwork.h"

using namespace std;

void handleRegistration(SocialNetwork& insta) {
    try {
        string login, password;
        cin.ignore();
        cout << "Enter login :: ";
        getline(cin, login);
        cout << "Enter password :: ";
        getline(cin, password);
        insta.register_(login, password);
        cout << "Registration successful!" << endl;
    }
    catch (const ExistLoginException& ex) {
        cout << "Error: " << ex.what() << endl;
    }
    catch (const WrongPasswordLengthException& ex) {
        cout << "Error: " << ex.what() << endl;
    }
}

void handleSignIn(SocialNetwork& insta) {
    try {
        string login, password;
        cin.ignore();
        cout << "Enter login :: ";
        getline(cin, login);
        cout << "Enter password :: ";
        getline(cin, password);
        insta.sign_in(login, password);
        cout << "Login successful!" << endl;
    }
    catch (const InvalidLoginException& ex) {
        cout << "Error: " << ex.what() << endl;
    }
    catch (const InvalidPasswordException& ex) {
        cout << "Error: " << ex.what() << endl;
    }
}

int main() {
    SocialNetwork inst;

    while (true) {
        int choice;
        cout << " 1 - Register; \n 2 - Sign in; \n Enter :: ";
        cin >> choice;

        switch (choice) {
        case 1:
            handleRegistration(inst);
            break;

        case 2:
            handleSignIn(inst);
            break;

        default:
            cout << "Invalid choice. Please enter 1 or 2." << endl;
            break;
        }
    }

    return 0;
}
