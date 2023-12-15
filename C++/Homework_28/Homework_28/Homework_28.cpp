#include <iostream>
#include <list>
#include <algorithm>
#include <fstream>
#include <string>
using namespace std;

class Book {
public:
    Book() : year(0), available(false) {}

    Book(const string& author, const string& name, int year)
        : author(author), name(name), year(year), available(true) {}

    void setAvailable(bool isAvailable) {
        available = isAvailable;
    }

    bool getAvailable() const {
        return available;
    }

    friend ostream& operator<<(ostream& os, const Book& book) {
        os << "Author: " << book.author << "\tName: " << book.name << "\tYear: " << book.year;
        if (book.available)
            os << "\tAvailable";
        else
            os << "\tNot Available";
        return os;
    }

    const string& getAuthor() const {
        return author;
    }

    const string& getName() const {
        return name;
    }

    int getYear() const {
        return year;
    }

    void setAuthor(const string& newAuthor) {
        author = newAuthor;
    }

    void setName(const string& newName) {
        name = newName;
    }

    void setYear(int newYear) {
        year = newYear;
    }

private:
    string author;
    string name;
    int year;
    bool available;
};

template <typename ContType>
void print(const ContType& cont, const string& prompt = "") {
    cout << prompt << endl;


    for (const auto& el : cont) {
        cout << el << endl;
    }
    cout << endl;
}

class Library {
private:
    list<Book> lib;

public:
    void addBook(const Book& book) {
        lib.push_back(book);
    }

    void printAllBooks() const {
        if (lib.empty()) {
            cout << "Library is empty." << endl;
        }
        else {
            print(lib, "Library Books:");
        }
    }

    bool searchBook(const string& author, const string& name) const {
        auto it = find_if(lib.begin(), lib.end(),
            [author, name](const Book& b) { return b.getAuthor() == author && b.getName() == name; });

        return it != lib.end();
    }

    void searchBooksByAuthor(const string& author) const {
        auto it = find_if(lib.begin(), lib.end(),
            [author](const Book& b) { return b.getAuthor() == author; });

        if (it != lib.end()) {
            cout << "Books by Author " << author << ":" << endl;
            while (it != lib.end() && it->getAuthor() == author) {
                cout << *it << endl;
                ++it;
            }
        }
        else {
            cout << "No books found by Author " << author << endl;
        }
    }

    void lendBook(const string& author, const string& name) {
        auto it = find_if(lib.begin(), lib.end(),
            [author, name](const Book& b) { return b.getAuthor() == author && b.getName() == name && b.getAvailable(); });

        if (it != lib.end()) {
            it->setAvailable(false);
            cout << "Book lent: " << *it << endl;
        }
        else {
            cout << "Book not available for lending or not found." << endl;
        }
    }

    void returnBook(const string& author, const string& name) {
        auto it = find_if(lib.begin(), lib.end(),
            [author, name](const Book& b) { return b.getAuthor() == author && b.getName() == name && !b.getAvailable(); });

        if (it != lib.end()) {
            it->setAvailable(true);
            cout << "Book returned: " << *it << endl;
        }
        else {
            cout << "Book not available for return or not found." << endl;
        }
    }

    void sortBooks() {
        lib.sort([](const Book& a, const Book& b) {
            return (a.getAuthor() < b.getAuthor()) || (a.getAuthor() == b.getAuthor() && a.getName() < b.getName());
            });
    }

    void removeBook(const string& author, const string& name, int year) {
        lib.remove_if([author, name, year](const Book& b) {
            return b.getAuthor() == author && b.getName() == name && b.getYear() == year;
            });
    }

    void removeBookByIndex(size_t index) {
        if (index < lib.size()) {
            auto it = std::next(lib.begin(), index);
            lib.erase(it);
        }
        else {
            cout << "Invalid index." << endl;
        }
    }

    void editBook(size_t index, const string& newAuthor, const string& newName, int newYear) {
        if (index < lib.size()) {
            auto it = std::next(lib.begin(), index);
            it->setAuthor(newAuthor);
            it->setName(newName);
            it->setYear(newYear);
        }
        else {
            cout << "Invalid index." << endl;
        }
    }

    const list<Book>& getLibrary() const {
        return lib;
    }

    void saveLibraryToFile(const string& filename) const {
        ofstream file(filename);
        if (file.is_open()) {
            for (const auto& book : lib) {
                file << book.getAuthor() << '\t' << book.getName() << '\t' << book.getYear() << '\t' << book.getAvailable() << '\n';
            }
            file.close();
            cout << "Library saved to file: " << filename << endl;
        }
        else {
            cout << "Unable to open file for saving: " << filename << endl;
        }
    }

    void loadLibraryFromFile(const string& filename) {
        ifstream file(filename);
        if (file.is_open()) {
            lib.clear(); 
            string author, name;
            int year;
            bool available;
            while (file >> author >> name >> year >> available) {
                lib.emplace_back(author, name, year);
                lib.back().setAvailable(available);
            }
            file.close();
            cout << "Library loaded from file: " << filename << endl;
        }
        else {
            cout << "Unable to open file for loading: " << filename << endl;
        }
    }

};

int main() {
    Library library;

    while (true) {
        cout << "\nMenu:\n";
        cout << "1. Add Book\n";
        cout << "2. Print All Books\n";
        cout << "3. Search Book\n";
        cout << "4. Search Books by Author\n";
        cout << "5. Lend Book\n";
        cout << "6. Return Book\n";
        cout << "7. Sort Books\n";
        cout << "8. Remove Book\n";
        cout << "9. Remove Book by Index\n";
        cout << "10. Edit Book\n";
        cout << "11. Save Library to File\n";
        cout << "12. Load Library from File\n";
        cout << "0. Exit\n";
        cout << "Enter your choice: ";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1: {
            cin.ignore(); 
            string author, name;
            int year;

            cout << "Enter author: ";
            getline(cin, author);

            cout << "Enter name: ";
            getline(cin, name);

            cout << "Enter year: ";
            while (!(cin >> year)) {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                cout << "Invalid input. Enter a number: ";
            }

            library.addBook(Book(author, name, year));
            break;
        }
        case 2:
            library.printAllBooks();
            break;
        case 3: {
            cin.ignore(); 
            string author, name;
            cout << "Enter author: ";
            getline(cin, author);
            cout << "Enter name: ";
            getline(cin, name);
            if (library.searchBook(author, name)) {
                cout << "Book found." << endl;
            }
            else {
                cout << "Book not found." << endl;
            }
            break;
        }
        case 4: {
            cin.ignore(); 
            string author;
            cout << "Enter author: ";
            getline(cin, author);
            library.searchBooksByAuthor(author);
            break;
        }
        case 5: {
            cin.ignore(); 
            string author, name;
            cout << "Enter author: ";
            getline(cin, author);
            cout << "Enter name: ";
            getline(cin, name);
            library.lendBook(author, name);
            break;
        }
        case 6: {
            cin.ignore(); 
            string author, name;
            cout << "Enter author: ";
            getline(cin, author);
            cout << "Enter name: ";
            getline(cin, name);
            library.returnBook(author, name);
            break;
        }
        case 7:
            library.sortBooks();
            break;
        case 8: {
            cin.ignore(); 
            string author, name;
            int year;
            cout << "Enter author: ";
            getline(cin, author);
            cout << "Enter name: ";
            getline(cin, name);
            cout << "Enter year: ";
            while (!(cin >> year)) {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                cout << "Invalid input. Enter a number: ";
            }
            library.removeBook(author, name, year);
            break;
        }
        case 9: {
            size_t index;
            cout << "Enter index: ";
            cin >> index;
            library.removeBookByIndex(index);
            break;
        }
        case 10: {
            size_t index;
            cin.ignore();
            string newAuthor, newName;
            int newYear;
            cout << "Enter index: ";
            cin >> index;
            cout << "Enter new author: ";
            getline(cin, newAuthor);
            cout << "Enter new name: ";
            getline(cin, newName);
            cout << "Enter new year: ";
            while (!(cin >> newYear)) {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                cout << "Invalid input. Enter a number: ";
            }
            library.editBook(index, newAuthor, newName, newYear);
            break;
        }
        case 11: {
            cin.ignore(); 
            string filename;
            cout << "Enter filename to save: ";
            getline(cin, filename);
            library.saveLibraryToFile(filename);
            break;
        }
        case 12: {
            string filename;
            cout << "Enter filename to load: ";
            cin >> filename;
            library.loadLibraryFromFile(filename);
            break;
        }
        case 0:
            return 0;
        default:
            cout << "Invalid choice. Try again.\n";
        }
    }

    return 0;
}
