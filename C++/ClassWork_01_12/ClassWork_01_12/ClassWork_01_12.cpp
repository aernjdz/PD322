#include <iostream>
#include <map>
#include <algorithm>

using namespace std;

using id = int;
using name = string;

using author = string;
using title = string;
template <typename T>
void print(const T& map, const string& prompt)
{
	cout << prompt << "::" << endl;
	for (auto& el : map) {
		cout << "\t Id :: " << el.first << "\t Name :: " << el.second << endl;
	}
}
int main()
{
	map <id, name> People
	{
		pair<id, name>{555, "Anan"},
		make_pair(777,"Denis"),
		{333,"Oleg"}
	};
	print(People, "Print map ::");
	People.insert({ 666,"Max" });
	print(People, "Print map ::");

	People[333] = "Olena";
	People[444] = "Maria";


	try {
		cout << "Test get key :: " << People.at(1000) << endl;
	}
	catch (const std::exception& ex) {
		cerr << "Error message :: " << ex.what() << endl;
	}
	print(People, "Print map ::");

	cout << "Test print iterator :: " << endl;
	for (auto i = People.begin(); i != People.end(); i++) {
		cout << "\t Id :: " << i->first << "\t Name :: " << i->second << endl;
	}
	cout << "Test print reverse iterator :: " << endl;
	for (auto i = People.rbegin(); i != People.rend(); i++) {
		cout << "\t Id :: " << i->first << "\t Name :: " << i->second << endl;
	}

	cout << "Test find key ::" << endl;
	id key = 333;
	auto it = People.find(key);

	if (it != People.end()) {
		cout << "\t Id :: " << it->first << "\t Name :: " << it->second << endl;
	}
	else {
		cerr << "Key not found" << endl;
	}

	print(People, "Print map ::");
	cout << "Test find_if key ::" << endl;
	it = find_if(People.begin(), People.end(), [](auto el) {return el.second == "Denis"; });
	if (it != People.end()) {
		cout << "\t Id :: " << it->first << "\t Name :: " << it->second << endl;
		People.erase(it);
	}
	else {
		cerr << "Denis not found" << endl;
	}

	print(People, "Print map ::");

	cout << "\n\nTest lower_bound :: " << endl;
	it = People.lower_bound(555);
	cout << "\t Id :: " << it->first << "\t Name :: " << it->second << endl;
	cout << "\n\nTest upper_bound :: " << endl;
	it = People.upper_bound(555);
	cout << "\t Id :: " << it->first << "\t Name :: " << it->second << endl;
	system("pause");
	system("cls");

	multimap <author, title> library
	{
		{"Tony Gaddis","C++ for beginning"},
		{"Tony Gaddis","Python for beginning"},
		{"Stiven Prata","Modern C++"},
		{"Tony Gaddis","Java for beginning"},
		{"Stiven Prata","Modern C"},
	};
	print(library, "Print exaple multimap");
	auto itt = find_if(library.begin(), library.end(), [](auto el) {return el.second == "Python for beginning"; });
	//library.erase("Tony Gaddis");
	//advance(itt,2);
	library.erase(itt);

	print(library, "Print exaple multimap");

	auto res = library.equal_range("Tony Gaddis");
	cout << "\n\nTest find equal_range :: " << endl;
	for (auto  i = res.first; i != res.second; i++)
	{
		cout << "\t Id :: " << i->first << "\t Name :: " << i->second << endl;
	}
}

