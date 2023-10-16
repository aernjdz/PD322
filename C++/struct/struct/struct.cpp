#include <iostream>
#include "library.h"
using namespace std;

int main() {
   
    int size = 10;
    Book* library = new Book[size]{
        {"The Great Gatsby","F.Scott Fitzgerald","Scribner","Classic",},
        {"To Kill a Mockingbird", "Harper Lee", "HarperCollins", "Fiction"},
        { "1984", "George Orwell", "Penguin", "Dystopian"},
        { "Harry Potter and the Sorcerer's Stone", "J.K.Rowling", "Scholastic" ,"Fantasy"},
        { "The Lord of the Rings", "J.R.R.Tolkien", "Houghton Mifflin","Fantasy"},
        { "Pride and Prejudice",  "Jane Austen",  "Penguin",  "Romance"},
        { "Brave New World",  "Aldous Huxley",  "HarperCollins", "Sci-Fi"},
        { "The Catcher in the Rye", "J.D. Salinger",  "Little, Brown",  "Classic"},
        { "The Hobbit",  "J.R.R. Tolkien", "Houghton Mifflin",  "Fantasy"},
        { "Fahrenheit 451", "Ray Bradbury",  "Simon & Schuster", "Dystopian"}
    };

    int choice;
    char name[SIZE];
    char author[SIZE];
    int index;

    while (true) {
        cout << "Library Management Menu:" << endl;
        cout << "1. Print Books" << endl;
        cout << "2. Edit a Book" << endl;
        cout << "3. Delete a Book" << endl;
        cout << "4. Search by Author" << endl;
        cout << "5. Search by Name" << endl;
        cout << "6. Sort by Publisher" << endl;
        cout << "7. Add a Book" << endl;
        cout << "8. Quit" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        cin.ignore();

        switch (choice) {
        case 1:
        {
            printBooks(library, size);
            break;
        }
        case 2: {
            cout << "Enter the index of the book to edit (1-max_index): ";
            cin >> index;
            cin.ignore();
            if (index >= 0 && index < size) {
                editBook(library[--index]);
            }
            else {
                cout << "Invalid book index. Please enter a valid index." << endl;
            }
            break;
        }
        case 3: {
            cout << "Enter the name of the book to delete: ";
            cin.getline(name, SIZE);
            int deleteIndex = searchByName(library, size, name);
            if (deleteIndex != -1) {
                for (int i = deleteIndex; i < size - 1; i++) {
                    library[i] = library[i + 1];
                }
                size--;
                cout << "Book '" << name << "' has been deleted." << endl;

                library[size].name[0] = '\0';
                library[size].author[0] = '\0';
                library[size].publisher[0] = '\0';
                library[size].genre[0] = '\0';
            }
            else {
                cout << "Book not found in the library." << endl;
            }
            break;
        }
        case 4: {
            cout << "Enter the author's name: ";
            cin.getline(author, SIZE);
            int authorIndex = searchByAuthor(library, size, author);
            if (authorIndex != -1) {
                printBook(library[authorIndex], "Book by Author: " + string(author));
            }
            else {
                cout << "Author not found in the library." << endl;
            }
            break;
        }
        case 5: {
            cout << "Enter the book's name: ";
            cin.getline(name, SIZE);
            int nameIndex = searchByName(library, size, name);
            if (nameIndex != -1) {
                printBook(library[nameIndex], "Book by Name: " + string(name));
            }
            else {
                cout << "Book not found in the library." << endl;
            }
            break;
        }
        case 6: {
            sortByPublisher(library, size);
            cout << "Library sorted by publisher:" << endl;
            printBooks(library, size);
            break;
        }
        case 7: {
            addBook(library, size);
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
