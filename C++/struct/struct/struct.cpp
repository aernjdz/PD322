
#include <iostream>
#include "library.h"
using namespace std;
int main()
{
    int size = 10;
    Book* library = new Book[size]{
        {"The Great Gatsby","F.Scott Fitzgerald","Scribner","Classic",},
        {"To Kill a Mockingbird", "Harper Lee", "HarperCollins", "Fiction"},
        { "1984", "George Orwell", "Penguin", "Dystopian"},
        { "Harry Potter and the Sorcerer's Stone", "J.K.Rowling", "Scholastic" ,"Fantasy"},
        { "The Lord of the Rings", "J.R.R.Tolkien", "Houghton Mifflin","Fantasy"},
        { "Pride and Prejudice",  "Jane Austen",  "Penguin",  "Romance"},
        { "Brave New World",  "Aldous Huxley",  "HarperCollins", "Sci-Fi"},
        { "The Catcher in the Rye", "'J.D. Salinger",  "Little, Brown",  "Classic"},
        { "The Hobbit",  "J.R.R. Tolkien", "Houghton Mifflin",  "Fantasy"},
        { "Fahrenheit 451", "Ray Bradbury",  "Simon & Schuster", "Dystopian"}
    };
    printBooks(library, size);
   // editBook(library[0]);
    //printBooks(library, size);
    //char author[SIZE];
    //cin.getline(author,SIZE);
    //cout << searchByAuthor(library, size, author);
    //char name[SIZE];
    //cin.getline(name, SIZE);
    //cout << searchByName(library, size, name);
    sortByPublisher(library, size);
    printBooks(library, size);
    addBook(library,size);
}

