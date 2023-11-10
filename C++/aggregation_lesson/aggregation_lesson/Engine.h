#pragma once
#include<iostream>
using namespace std;
class Engine {
private:
	string model;
	size_t power;
	double volume;
	double gasoline_con;
	size_t oil;
public:
	Engine() = default;
	Engine(const string& model, const size_t& power, const double& volume, const double& gasl, const size_t& oil) :model{ model }, power{ power }, volume{ volume },gasoline_con{ gasl }, oil{ oil }{}
	
	void print() const {
		cout << "Model :: " << this->model <<  " Power :: " << this->power << " Volume :: " << this->volume  << " Gasl :: " << this->gasoline_con  << " Oil :: " << this->oil << endl;
	}
};