#include <iostream>
#include <ctime>
using namespace std;

/*void transposeMatrix(int* matrix, int* transposed, int rows, int cols) {
    for (size_t i = 0; i < rows; i++) {
        for (size_t j = 0; j < cols; j++) {
            transposed[j * rows + i] = matrix[i * cols + j];
        }
    }
}

void generate(int* matrix, int rows, int cols) {
    for (size_t i = 0; i < rows; i++) {
        for (size_t j = 0; j < cols; j++) {
            matrix[i * cols + j] = rand() % 10;
        }
    }
}

void print(int* matrix, int rows, int cols) {
    for (size_t i = 0; i < rows; i++) {
        for (size_t j = 0; j < cols; j++) {
            cout << matrix[i * cols + j] << " ";
        }
        cout << endl;
    }
}

void remove(int* matrix) {
    delete[] matrix;
}*/
// N2
void initializeContacts(string** contacts, int maxContacts) {
    for (int i = 0; i < maxContacts; i++) {
        contacts[i] = new string[2];
    }
}

void releaseContacts(string** contacts, int maxContacts) {
    for (int i = 0; i < maxContacts; i++) {
        delete[] contacts[i];
    }
    delete[] contacts;
}

int searchByName(string** contacts, string& name, int maxContacts, int contact_count) {
    for (char& c : name) {
        c = tolower(c);
    }

    for (int i = 0; i < contact_count; i++) {
        string lowercaseName = contacts[i][0];
        for (char& c : lowercaseName) {
            c = tolower(c);
        }
        if (lowercaseName == name) {
            return i;
        }
    }
    return -1;
}

int searchByPhone(string** contacts, string& phone, int maxContacts, int contact_count) {
    for (int i = 0; i < contact_count; i++) {
        if (contacts[i][1] == phone) {
            return i;
        }
    }
    return -1;
}

void printContact(string** contacts, int index) {
    if (index != -1) {
        cout << "Contact " << (index + 1) << ":" << endl;
        cout << "Name: " << contacts[index][0] << endl;
        cout << "Number: " << contacts[index][1] << endl;
        cout << endl;
    }
    else {
        cout << "Not Found" << endl;
    }
}

void printContacts(string** contacts, int contact_count) {
    for (int i = 0; i < contact_count; i++) {
        printContact(contacts, i);
    }
}

void replaceContact(string** contacts, int index, string& name, string& phone) {
    if (index != -1) {
        contacts[index][0] = name;
        contacts[index][1] = phone;
    }
    else {
        cout << "Not Found!" << endl;
    }
}

void addContact(string** contacts, string& name, string& phone, int maxContacts, int& contact_count) {
    if (contact_count < maxContacts) {
        for (int i = 0; i < maxContacts; i++) {
            if (contacts[i][0].empty()) {
                contacts[i][0] = name;
                contacts[i][1] = phone;
                contact_count++;
                break;
            }
        }
    }
    else {
        cout << "Contacts list is full." << endl;
    }
}

void removeContact(string** contacts, int index, int& contact_count) {
    if (index != -1) {
        for (int i = index; i < contact_count - 1; i++) {
            contacts[i][0] = contacts[i + 1][0];
            contacts[i][1] = contacts[i + 1][1];
        }
        contacts[contact_count - 1][0].clear();
        contacts[contact_count - 1][1].clear();
        contact_count--;
    }
    else {
        cout << "Not Found!" << endl;
    }
}

void generateRandomContacts(string** contacts, int maxContacts) {
    const string randomNames[] = { "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Helen", "Ivy", "Jack" };
    const string randomPhones[] = { "111-111-1111", "222-222-2222", "333-333-3333", "444-444-4444", "555-555-5555",
                                   "666-666-6666", "777-777-7777", "888-888-8888", "999-999-9999", "000-000-0000" };

   

    for (int i = 0; i < maxContacts; i++) {
        int randomIndex = rand() % 10;
        contacts[i][0] = randomNames[randomIndex];
        contacts[i][1] = randomPhones[randomIndex];
    }
}

int main() {
    //N1
   // srand(time(0));
    /*const int rows = 3;
    const int cols = 3;
    int* matrix = new int[rows * cols];
    int* transposed = new int[rows * cols];

    generate(matrix, rows, cols);
    cout << "Original Matrix:" << endl;
    print(matrix, rows, cols);

    transposeMatrix(matrix, transposed, rows, cols);
    cout << "Transposed Matrix:" << endl;
    print(transposed, cols, rows);

    remove(matrix);
    remove(transposed);*/
    //N2
    srand(static_cast<unsigned int>(time(0)));

    const int max_contacts = 11;
    string** contacts = new string * [max_contacts];
    int contact_count = 5;
    initializeContacts(contacts, max_contacts);
    generateRandomContacts(contacts, contact_count);
    string name;
    string phone;
    int index;

    while (true) {
        cout << "Menu ::" << endl;
        cout << "1. Search by name" << endl;
        cout << "2. Search by phone number" << endl;
        cout << "3. Print contacts" << endl;
        cout << "4. Add a contact" << endl;
        cout << "5. Remove a contact" << endl;
        cout << "6. Replace a contact" << endl;
        cout << "7. Exit" << endl;

        int choice;
        cin >> choice;

        switch (choice) {
        case 1: 
            cout << "Enter name to search :: ";
            cin >> name;
            printContact(contacts, searchByName(contacts, name, max_contacts, contact_count));
            break;
        
        case 2: 
            cout << "Enter phone number to search :: ";
            cin >> phone;
            printContact(contacts,searchByPhone(contacts, phone,max_contacts,contact_count));
            break;
        
        case 3:
            printContacts(contacts, contact_count);
            break;
        case 4: 
            cout << "Enter Name :: ";
            cin >> name;
            cout << "Enter phone number :: ";
            cin >> phone;
            addContact(contacts, name, phone, max_contacts,contact_count);
          
            break;
        case 5: 
            cout << "Enter the index of the contact to remove: ";
            cin >> index;
            removeContact(contacts, index - 1,contact_count);
            
            break;
        case 6:
    
            cout << "Enter the index of the contact to replace: ";
            cin >> index;
            
            cout << "Enter new name: ";
            cin >> name;
            cout << "Enter new phone number: ";
            cin >> phone;
            replaceContact(contacts, index - 1, name, phone);
            break;
        case 7:
            releaseContacts(contacts, max_contacts);
            return 0;
        default:
            cout << "Invalid choice. Please try again." << endl;
        }
    }
}
