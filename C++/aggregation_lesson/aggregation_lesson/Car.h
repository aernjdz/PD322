#pragma once
#include "Engine.h"

class Car {
public: 
	Car() = default;
	Car(const string& brand, const Engine& engine) : brand{ brand }, engine{ engine } {};
	Car(const string& brand, const string& model, const size_t& power, const double& volume, const double& gasl, const size_t& oil) : brand{ brand }, engine{ model, power, volume, gasl, oil }{};
	void print() const {
		cout << "Brand :: " << this->brand << endl;
		cout << "Engene :: " << endl;
		engine.print();
	}
private:
	string brand;
	Engine engine;
};