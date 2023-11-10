
//#include <iostream>
//#include"Car.h"
//class Person {
//public:
//    Person() = default;
//    Person(const string& name, const string& action) : name{ name }, brain{ action } {}
//
//    void print() const {
//        cout << "Name: " << name << ", Action: " << brain.getAction() << endl;
//    }
//
//private:
//    string name;
//
//    class Brain {
//    public:
//        Brain() = default;
//        Brain(const string& action) : act{ action } {}
//
//        string getAction() const {
//            return act;
//        }
//
//    private:
//        string act;
//    };
//
//    Brain brain;
//};
//int main()
//{
	/*Person person("John", "Thinking");
	  person.print();*/

	  //Engine engine("AB", 400, 2.5, 5, 1);
	  //engine.print();
	  //cout << endl;

	  //Car audi("Audi", engine);
	  //audi.print();
	  //cout << endl;
	  //Car ford("Ford", { "AA",500,3.5,7,1 });
	  //ford.print();
	  //cout << endl;
	  //Car bmw("Bmw", "AC", 450, 2.9, 6, 1);
	  //bmw.print();
//}

#include <iostream>
#include"Animal.h"
#include"Walf.h"
using namespace std;
int main()
{
	Animal animal("None", 5);
	animal.print();
	Walf walf("Walf",5, 6);
	walf.print();
	Dog dog("Dog", 5, 8);
	dog.print();

}

