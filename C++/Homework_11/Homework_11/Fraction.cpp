#include "Fraction.h"


string Fraction::print()
{

	return to_string(this->num) + "/" + to_string(dnum);
}
Fraction Fraction::sum(const Fraction &other) {
	return Fraction(this->num * other.dnum + other.num * this->dnum, this->dnum * other.dnum);
	
}
Fraction Fraction::subtract(const Fraction& other) {
	return 	Fraction(this->num * other.dnum - other.num * this->dnum, this->dnum * other.dnum);
}
Fraction Fraction::multiply(const Fraction& other) {
	return Fraction(this->num * other.num,this->dnum * other.dnum);
}
Fraction Fraction::divide(const Fraction& other) {
	return Fraction(this->num * other.dnum, this->dnum * other.num);
}