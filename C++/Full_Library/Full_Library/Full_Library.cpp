#include <iostream>
#include "Library.h"
using namespace std;

int main() {
    int size = 10;
    InformationSource* library = new InformationSource[size]{
        {"Book", "The Great Gatsby", "F. Scott Fitzgerald", "Scribner", "Classic", 0},
        {"Book", "To Kill a Mockingbird", "Harper Lee", "HarperCollins", "Fiction", 0},
        {"Book", "1984", "George Orwell", "Penguin", "Dystopian", 0},
        {"Book", "Harry Potter and the Sorcerer's Stone", "J.K. Rowling", "Scholastic", "Fantasy", 0},
        {"Book", "The Lord of the Rings", "J.R.R. Tolkien", "Houghton Mifflin", "Fantasy", 0},
        {"Book", "Pride and Prejudice", "Jane Austen", "Penguin", "Romance", 0},
        {"Book", "Brave New World", "Aldous Huxley", "HarperCollins", "Sci-Fi", 0},
        {"Book", "The Catcher in the Rye", "J.D. Salinger", "Little, Brown", "Classic", 0},
        {"Book", "The Hobbit", "J.R.R. Tolkien", "Houghton Mifflin", "Fantasy", 0},
        {"Book", "Fahrenheit 451", "Ray Bradbury", "Simon & Schuster", "Dystopian", 0}
    };

    int choice;
    char title[SIZE];
    char author[SIZE];
    int index;

    while (true) {
        cout << "Library Management Menu:" << endl;
        cout << "1. Print Information Sources" << endl;
        cout << "2. Edit an Information Source" << endl;
        cout << "3. Delete an Information Source" << endl;
        cout << "4. Search by Author" << endl;
        cout << "5. Search by Title" << endl;
        cout << "6. Sort by Type and Title" << endl;
        cout << "7. Add an Information Source" << endl;
        cout << "8. Quit" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        cin.ignore();

        switch (choice) {
        case 1: {
            printInformationSources(library, size);
            break;
        }
        case 2: {
            cout << "Enter the index of the information source to edit (1-max_index): ";
            cin >> index;
            cin.ignore();
            if (index >= 1 && index <= size) {
                editInformationSource(library[index - 1]);
            }
            else {
                cout << "Invalid information source index. Please enter a valid index." << endl;
            }
            break;
        }
        case 3: {
            cout << "Enter the title of the information source to delete: ";
            cin.getline(title, SIZE);
            int deleteIndex = searchByTitle(library, size, title);
            if (deleteIndex != -1) {
                removeInformationSourceByTitle(library, size, title);
                cout << "Information source '" << title << "' has been deleted." << endl;
            }
            else {
                cout << "Information source not found in the library." << endl;
            }
            break;
        }
        case 4: {
            cout << "Enter the author's name: ";
            cin.getline(author, SIZE);
            int authorIndex = searchByAuthor(library, size, author);
            if (authorIndex != -1) {
                printInformationSource(library[authorIndex], "Information Source by Author: " + string(author));
            }
            else {
                cout << "Author not found in the library." << endl;
            }
            break;
        }
        case 5: {
            cout << "Enter the information source's title: ";
            cin.getline(title, SIZE);
            int titleIndex = searchByTitle(library, size, title);
            if (titleIndex != -1) {
                printInformationSource(library[titleIndex], "Information Source by Title: " + string(title));
            }
            else {
                cout << "Information source not found in the library." << endl;
            }
            break;
        }
        case 6: {
            sortByTypeAndTitle(library, size);
            cout << "Library sorted by type and title:" << endl;
            printInformationSources(library, size);
            break;
        }
        case 7: {
            addInformationSource(library, size);
            break;
        }
        case 8: {
            cout << "Goodbye!" << endl;
            delete[] library;
            return 0;
        }
        default:
            cout << "Invalid choice. Please enter a valid option." << endl;
            break;
        }
    }
}
