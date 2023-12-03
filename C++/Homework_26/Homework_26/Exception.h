#pragma once
#include <iostream>
using namespace std;

class ExistLoginException :public exception
{
public:
	ExistLoginException(const string& message = "Invalid login") :
		exception(message.data())
	{}
};

class WrongPasswordLengthException :public exception
{
public:
	WrongPasswordLengthException(const string& message = "Invalid password") :
		exception(message.data())
	{}
};

class InvalidPasswordException : public exception
{
public:
	InvalidPasswordException(const string& message = "Invalid password") :
		exception(message.c_str())
	{}
};

class InvalidLoginException : public exception
{
public:
	InvalidLoginException(const string& message = "Invalid login") :
		exception(message.c_str())
	{}
};