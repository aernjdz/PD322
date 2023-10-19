#pragma once
#include <iostream>
#include <string>
using namespace std;

const int SIZE = 100;

struct InformationSource {
    char type[SIZE];
    char title[SIZE];
    char author[SIZE];
    char publisher[SIZE]; // Added "publisher" field
    char category[SIZE];
    int year;
};

void printInformationSources(InformationSource* library, int size);
void printInformationSource(InformationSource source, string text);
int searchByTitle(InformationSource* library, int size, char* title);
void editInformationSource(InformationSource& source);
int searchByAuthor(InformationSource* library, int size, char* author);
int searchByName(InformationSource* library, int size, char* name);
void sortByTypeAndTitle(InformationSource* library, int size);
void addInformationSource(InformationSource* library, int& size);
void removeInformationSourceByTitle(InformationSource* library, int& size, char* title);
int countByCategory(InformationSource* library, int size, char* category);
void removeNewspapersByYear(InformationSource* library, int& size, int year);
