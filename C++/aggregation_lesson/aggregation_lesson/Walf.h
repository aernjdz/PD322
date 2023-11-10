#pragma once
#include "Animal.h"
class Walf : protected Animal {
public:
	Walf() = default;
	Walf(const string& name, const int& age, const int& weight) : Animal(name, age), weight{ weight }
	{

	}
	void print() const {
		Animal::print();
		cout << "\t Weight :: " << weight << endl;
	}

protected:
	int weight;
};
class Dog : public Walf{
public:
	Dog() = default;
	Dog(const string& name, const int& age, const int& weight) : Walf(name, age, weight)
	{

	}
	void print() const {
		Walf::print();
	}
};



