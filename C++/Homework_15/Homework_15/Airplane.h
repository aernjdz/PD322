#pragma once

#include<iostream>
using namespace std;

class Airplane {
private:
	string type;
	int Passengers;
	int MaxPassengers;
public:
	Airplane(string t, int maxP) : type(t), Passengers(0), MaxPassengers(maxP) {};
	bool operator==(const Airplane& other ) const;
	bool operator>(const Airplane& other) const;
	bool operator<(const Airplane& other) const;
	Airplane& operator++();
	Airplane& operator--();
	void print(string text="") const;
};