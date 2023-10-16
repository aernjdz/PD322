#pragma once
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;
using std::to_string;
using std::swap;
using std::strlen;
using std::size;
const int SIZE = 100;


struct Book 
{
	char name[SIZE];
	char author[SIZE];
	char publisher[SIZE];
	char genre[SIZE];
};

void printBooks(Book* library, int size);
void printBook(Book book,string text = "");
void editBook(Book& book);
char* toLowerCase(char* line);
int searchByAuthor(Book* library, int size, char* author);
int searchByName(Book* library, int size, char* name);
void sortByName(Book* library,int size);
void sortByAuthor(Book* library, int size);
void sortByPublisher(Book* library, int size);
void addBook(Book* library, int& size);
void removeBookByName(Book* library, int& size, char* name);