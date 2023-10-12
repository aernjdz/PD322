#include <iostream>
#include <string>
using namespace std;

// N1
/*struct dimensions {
double width;
double depth;
double height;
double volume;
};

struct washing_Mash {
string name_and_firm;
string color;
dimensions dime;
double power_W;
int speed_spin;
double temperature;

};
void show(washing_Mash x) {
cout << "Model :: " << x.name_and_firm << endl;
cout << "color :: " << x.color << endl;
cout << "Maximum download :: " << x.dime.volume << " liters" << endl;
cout << "Depth :: " << x.dime.depth << " cm" << endl;
cout << "Width :: " << x.dime.width <<  " cm" << endl;
cout << "Height :: " << x.dime.height << " cm" << endl;
cout << "Spin speed :: " << x.speed_spin << " rpm" << endl;
cout << "Temperature :: " << x.temperature << " degrees Celsius" << endl;
};*/

// N2

//struct temperature {
//	double min;
//	double max;
//};
//struct iron {
//	string name_and_firm;
//	string color;
//	temperature temp;
//	bool couple;
//	int power_W;
//};
//
//void show(iron x) {
//	cout << "Model :: " << x.name_and_firm << endl;
//	cout << "Color :: " << x.color << endl;
//	cout << "Max temparature :: " << x.temp.max << " degrees Celsius" << endl;
//	cout << "Min temparature :: " << x.temp.min << " degrees Celsius" << endl;
//	cout << "Couple :: " << ((x.couple) ? "Yes" : "No") << endl;
//	cout << "Power :: " << x.power_W << " kW" << endl;
//}
//iron create_iron() {
//	string model;
//	string color;
//	double temp[2] = { 0,0 };
//	bool couple;
//	int power;
//	cout << "Enter model :: ";
//	cin >> model;
//	cout << "Enter color :: ";
//	cin >> color;
//	cout << "Enter min temperature :: ";
//	cin >> temp[0];
//	cout << "Enter max temperature :: ";
//	cin >> temp[1];
//	cout << "Couple (0/1) :: ";
//	cin >> couple;
//	cout << "Enter Power :: ";
//	cin >> power;
//	iron tmp = { model,color,{temp[0], temp[1] }, couple, power };
//	return tmp;
//}
// 
//N3
//struct Boiler {
//	string brand;
//	string color;
//	int power;
//	int capacity;
//	int temperature;
//};
//void show(Boiler x) {
//		cout << "Model       :: " << x.brand << endl;
//		cout << "Color       :: " << x.color << endl;
//		cout << "Temparature :: " << x.temperature << " degrees Celsius" << endl;
//		cout << "Capasity    :: " << x.capacity <<" l." << endl;
//		cout << "Power       :: " << x.power << " kW" << endl;
//	}

int main()
{
    // N1
    /*washing_Mash a = {"Skyworth F70228SDW","white",{44,59.5,85,7},0.59,1200,95};
    show(a);*/

    // N2
    /*iron  models = { "Saturn ST-CC7118","blue and white",{50,329} ,true,2400 };
    show(models);

    iron new_0 = create_iron();
    show(new_0);*/
    // N3
    /*Boiler myBoiler{ "AquaHeat","White",2000,80,60 };
    show(myBoiler);*/
  
}