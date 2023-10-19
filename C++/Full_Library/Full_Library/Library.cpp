#include "Library.h"
void printInformationSources(InformationSource* library, int size) {
    for (int i = 0; i < size; i++) {
        printInformationSource(library[i],"");
    }
}

void printInformationSource(InformationSource source, string text = "") {
    cout << text << "Type: " << source.type << endl;
    cout << "Title: " << source.title << endl;
    cout << "Author: " << source.author << endl;
    cout << "Publisher: " << source.publisher << endl;
    if (strcmp(source.type, "Journal") == 0 || strcmp(source.type, "Newspaper") == 0) {
        cout << "Year: " << source.year << endl;
    }
    if (strcmp(source.type, "Book") == 0 || strcmp(source.type, "Journal") == 0 || strcmp(source.type, "Newspaper") == 0) {
        cout << "Category: " << source.category << endl;
    }
    cout << endl;
}
int searchByTitle(InformationSource* library, int size, char* title) {
    int count = 0;
    for (int i = 0; i < size; i++) {
        if (strcmp(library[i].title, title) == 0) {
            count++;
            printInformationSource(library[i], "Found source: ");
        }
    }
    return count;
}
void editInformationSource(InformationSource& source) {
    cout << "Editing information source:" << endl;
    cout << "Type: ";
    cin.getline(source.type, SIZE);
    cout << "Title: ";
    cin.getline(source.title, SIZE);
    cout << "Author: ";
    cin.getline(source.author, SIZE);
    cout << "Publisher: ";
    cin.getline(source.publisher, SIZE);
    if (strcmp(source.type, "Journal") == 0 || strcmp(source.type, "Newspaper") == 0) {
        cout << "Year: ";
        cin >> source.year;
        cin.ignore();
    }
    if (strcmp(source.type, "Book") == 0 || strcmp(source.type, "Journal") == 0 || strcmp(source.type, "Newspaper") == 0) {
        cout << "Category: ";
        cin.getline(source.category, SIZE);
    }
}

int searchByAuthor(InformationSource* library, int size, char* author) {
    int count = 0;
    for (int i = 0; i < size; i++) {
        if (strcmp(library[i].author, author) == 0) {
            count++;
            printInformationSource(library[i], "Found source: ");
        }
    }
    return count;
}

int searchByName(InformationSource* library, int size, char* name) {
    int count = 0;
    for (int i = 0; i < size; i++) {
        if (strcmp(library[i].title, name) == 0) {
            count++;
            printInformationSource(library[i], "Found source: ");
        }
    }
    return count;
}

void sortByTypeAndTitle(InformationSource* library, int size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = i + 1; j < size; j++) {
            if (strcmp(library[i].type, library[j].type) > 0 || (strcmp(library[i].type, library[j].type) == 0 && strcmp(library[i].title, library[j].title) > 0)) {
                swap(library[i], library[j]);
            }
        }
    }
}

void addInformationSource(InformationSource* library, int& size) {
    if (size < SIZE) {
        cout << "Adding a new information source:" << endl;
        editInformationSource(library[size]);
        size++;
    }
    else {
        cout << "The library is already full. Unable to add a new source." << endl;
    }
}

void removeInformationSourceByTitle(InformationSource* library, int& size, char* title) {
    int index = -1;
    for (int i = 0; i < size; i++) {
        if (strcmp(library[i].title, title) == 0) {
            index = i;
            break;
        }
    }
    if (index != -1) {
        for (int i = index; i < size - 1; i++) {
            library[i] = library[i + 1];
        }
        size--;
        cout << "Information source with the title '" << title << "' has been removed." << endl;
    }
    else {
        cout << "Information source with the title '" << title << "' not found." << endl;
    }
}

int countByCategory(InformationSource* library, int size, char* category) {
    int count = 0;
    for (int i = 0; i < size; i++) {
        if (strcmp(library[i].category, category) == 0) {
            count++;
        }
    }
    return count;
}

void removeNewspapersByYear(InformationSource* library, int& size, int year) {
    int index = 0;
    while (index < size) {
        if (strcmp(library[index].type, "Newspaper") == 0 && library[index].year == year) {
            removeInformationSourceByTitle(library, size, library[index].title);
        }
        else {
            index++;
        }
    }
}
