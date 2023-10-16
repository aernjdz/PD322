#include "library.h"

void printBooks(Book* library, int size) {
	for (size_t i = 0; i < size; i++) 
	{	
		printBook(library[i], "Book " + to_string(i+1));
	}
}
void printBook(Book book, string text)
{
	cout << "\n\n\t=================== " << text <<" ===================" << endl;
	cout << "\t\t Name      :: " << book.name << endl;
	cout << "\t\t Author    :: " << book.author << endl;
	cout << "\t\t Publisher :: " << book.publisher << endl;
	cout << "\t\t Genre     :: " << book.genre << endl;
}

void editBook(Book& book)
{
		cout << "New title: ";  cin.getline(book.name,SIZE);
		cout << "New author: "; cin.getline(book.author,SIZE);
		cout << "New publisher: "; cin.getline(book.publisher,SIZE);
		cout << "New genre: "; cin.getline(book.genre,SIZE);
}

char* toLowerCase(char* line)
{
	char* newLine = new char[strlen(line) + 1];
	for (size_t i = 0; i < strlen(line); i++) {
		newLine[i] = tolower(line[i]);
	}
	newLine[strlen(line)] = '\0';
	return newLine;
};



int searchByAuthor(Book* library, int size, char* author) {
   
    for (int i = 0; i < size; i++) {
        if (strcmp(toLowerCase(library[i].author), toLowerCase(author)) == 0) {
            return i;
        }
    }
    return -1;
}
int searchByName(Book* library, int size, char* name) {
    
    for (int i = 0; i < size; i++) {
   
        if (strcmp(toLowerCase(library[i].name), toLowerCase(name)) == 0) {
            return i;
        }
    }
    return -1;
}
void sortByName(Book* library, int size) {
	for (size_t i = 0; i < size - 1; i++) {
		for (size_t j = 0; j < size - 1 - i; j++) {
			if (strcmp(toLowerCase(library[j].name), toLowerCase(library[j + 1].name)) > 0) {
				swap(library[j], library[j + 1]);
			}
		}
	}
}
void sortByAuthor(Book* library, int size) {
	for (size_t i = 0; i < size - 1; i++) {
		for (size_t j = 0; j < size - 1 - i; j++) {
			if (strcmp(toLowerCase(library[j].author), toLowerCase(library[j + 1].author)) > 0) {
				swap(library[j], library[j + 1]);
			}
		}
	}
}
void sortByPublisher(Book* library, int size) {
	for (size_t i = 0; i < size - 1; i++) {
		for (size_t j = 0; j < size - 1 - i; j++) {
			if (strcmp(toLowerCase(library[j].publisher), toLowerCase(library[j + 1].publisher)) > 0) {
				swap(library[j], library[j + 1]);
			}
		}
	}
}
void addBook(Book* library, int& size) {
	if (size < SIZE) {
		cout << "Enter book details:" << std::endl;
		cout << "Title: ";

		cin.getline(library[size].name, SIZE);

		cout << "Author: ";

		cin.getline(library[size].author, SIZE);
		cout << "Publisher: ";

		cin.getline(library[size].publisher, SIZE);
		cout << "Genre: ";

		cin.getline(library[size].genre, SIZE);

		size++;
	}
	else {
		cout << "Library is full. Cannot add more books." << endl;
	}
}

void removeBookByName(Book* library, int& size, char* name)
{
	for (int i = 0; i < size; i++) {
		if (strcmp(toLowerCase(library[i].name), toLowerCase(name)) == 0) {
			for (int j = i; j < size - 1; j++) {
				library[j] = library[j + 1];
			}
			size--;
			cout << "Book '" << name << "' has been deleted." << endl;
			return;

		}
		cout << "Book '" << name << "' not found in the library." << endl;

	}
}



