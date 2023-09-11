#include <iostream>

using namespace std;

int main() {
    char n;
    int size;

    while (true) {
        cout << "Enter a letter from 'a' to 'k': ";
        cin >> n;

        cout << "Enter the size of the figure: ";
        cin >> size;

        switch (n) {
        case 'a':
            for (int i = size; i >= 0; i--) {
                for (int l = 0; l < 2 * (size - i); l++) {
                    cout << " ";
                }
                for (int j = 0; j <= i; j++) {
                    cout << "* ";
                }
                cout << endl;
            }
            break;

        case 'b':
            for (int i = 1; i <= size; i++) {
                for (int j = 0; j < i; j++) {
                    cout << "* ";
                }
                cout << endl;
            }
            break;

        case 'c':
            for (int i = size - 1; i >= 0; i--) {
                for (int k = 0; k <= size - 1 - i; k++) {
                    cout << " ";
                }
                for (int j = 0; j <= i; j++) {
                    cout << "* ";
                }
                cout << endl;
            }
            break;

        case 'd':
            for (int i = size - 1; i >= 0; i--) {
                for (int k = 0; k <= size - 1 - i; k++) {
                    cout << " ";
                }
                for (int j = 0; j <= i; j++) {
                    cout << "* ";
                }
                cout << endl;
            }
            for (int i = size - 1; i >= 0; i--) {
                for (int j = 0; j <= i; j++) {
                    cout << " ";
                }
                for (int k = 0; k <= size - 1 - i; k++) {
                    cout << "* ";
                }
                cout << endl;
            }
            break;

        case 'e':
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if ((i > j && i < size- 1 - j) || (i < j && i >size - 1 - j)) {
                        cout << "* ";
                    }
                    else {
                        cout << "  ";
                    }
                }
                cout << endl;
            }
            break;
        case 'f':
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i > j && i < size - 1 - j) {
                        cout << " ";
                    }
                    else {
                        cout << "*";
                    }
                }
                cout << endl;
            }
            break;

        case 'g':
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i < j && i > size - 1 - j) {
                        cout << " ";
                    }
                    else {
                        cout << "*";
                    }
                }
                cout << endl;
            }
            break;

        case 'h':
            for (int i = size; i > 0; i--) {
                for (int j = 1; j <= i; j++) {
                    cout << "* ";
                }
                cout << endl;
            }
            break;

        case 'k':
            for (int i = 1; i <= size; i++) {
                for (int k = 0; k < 2 * (size - i); k++) {
                    cout << " ";
                }
                for (int j = 1; j < i; j++) {
                    cout << "* ";
                }
                cout << endl;
            }
            break;

        default:
            cout << "Invalid choice!" << endl;
            break;
        }
    }

   
}
