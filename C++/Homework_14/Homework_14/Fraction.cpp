#include "Fraction.h"

int Fraction::NSD(int a,int b)
{
	if (b == 0) return a;
	return NSD(b, a % b);
}

void Fraction::shorten()
{
	int common_divisor = NSD(num, dnum);
	this->num /= common_divisor;
	this->dnum /=  common_divisor;
}

Fraction Fraction::operator+(const Fraction& second) const
{
	return Fraction(this->num * second.dnum + second.num * this->dnum,this->dnum*second.dnum);
}

Fraction Fraction::operator-(const Fraction& second) const
{
	return Fraction(this->num * second.dnum - second.num * this->dnum, this->dnum * second.dnum);
}

Fraction Fraction::operator*(const Fraction& second) const
{
	return Fraction(this->num*second.num,this->dnum*second.dnum);
}

Fraction Fraction::operator/(const Fraction& second) const
{
	if (second.num == 0) { 
		cerr << "Division Zero error!" << endl; 
		return *this;
	}
	return Fraction(this->num*second.dnum,this->dnum*second.num);
}



const char* Fraction::show() const {
	
	int wholePart = this->num / this->dnum;
	int remainder = this->num % this->dnum;
   

    string fractionStr;
    if (wholePart != 0) {
        fractionStr = to_string(wholePart);
        if (remainder != 0) {
            fractionStr += " " + to_string(remainder) + "/" + to_string(this->dnum);
        }
    }
    else if (remainder != 0) {
        fractionStr = to_string(remainder) + "/" + to_string(this->dnum);
    }
    else {
        fractionStr = "0"; 
    }

  
    char* cstr = new char[fractionStr.length() + 1];
    strcpy_s(cstr, fractionStr.length() + 1, fractionStr.c_str());

    return cstr;

}

