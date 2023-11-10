#include "Circle.h"

bool Circle::operator==(const Circle& other) const
{
	return this->radius == other.radius;
}
bool Circle::operator>(const Circle& other) const
{
	return this->radius > other.radius;
}
bool Circle::operator<(const Circle& other) const
{
	return this->radius < other.radius;
}
Circle& Circle::operator+=(double value) {
	radius += value;
	return *this;
}
Circle& Circle::operator-=(double value) {
	radius -= value;
	return *this;
}


double Circle::get() const {
	return this->radius;
}
void Circle::print(string text) const {
	cout << text << " " << this->radius << endl;
	
}