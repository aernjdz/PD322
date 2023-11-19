#pragma once
#include<iostream>
using namespace std;


enum AnimalType {
    DOG,
    CAT,
    PARROT,
    HAMSTER
};

class Animal {
protected:
    string name;
    size_t age;

public:
    Animal(const string& n, size_t a) : name{ n }, age{ a } {}

    virtual void sound() const = 0;
    virtual void type() const = 0;
    virtual void show() const = 0;

    const string& getName() const { return name; }
    size_t getAge() const { return age; }
};

class Dog : public Animal {
public:
    Dog(const string& n, size_t a) : Animal(n, a) {}

    void sound() const override { cout << "Woof" << endl; }
    void type() const override { cout << "Dog" << endl; }
    void show() const override {
        cout << "Name: " << name << ", Age: " << age << ", Type: Dog, Sound: Woof" << endl;
    }
};

class Cat : public Animal {
public:
    Cat(const string& n, size_t a) : Animal(n, a) {}

    void sound() const override { cout << "Meow" << endl; }
    void type() const override { cout << "Cat" << endl; }
    void show() const override {
        cout << "Name: " << name << ", Age: " << age << ", Type: Cat, Sound: Meow" << endl;
    }
};

class Parrot : public Animal {
public:
    Parrot(const string& n, size_t a) : Animal(n, a) {}

    void sound() const override { cout << "Squawk" << endl; }
    void type() const override { cout << "Parrot" << endl; }
    void show() const override {
        cout << "Name: " << name << ", Age: " << age << ", Type: Parrot, Sound: Squawk" << endl;
    }
};

class Hamster : public Animal {
public:
    Hamster(const string& n, size_t a) : Animal(n, a) {}

    void sound() const override { cout << "Squeak" << endl; }
    void type() const override { cout << "Hamster" << endl; }
    void show() const override {
        cout << "Name: " << name << ", Age: " << age << ", Type: Hamster, Sound: Squeak" << endl;
    }
};

class HomeZoo {
private:
    Animal** zoo;
    size_t size;

public:
    HomeZoo() : zoo{ nullptr }, size{ 0 } {}

    ~HomeZoo() {
        for (size_t i = 0; i < size; ++i) {
            delete zoo[i];
        }
        delete[] zoo;
    }

    void addAnimal() {
        string name;
        size_t age;
        int type;

        cout << "Enter the type of animal (0 - Dog, 1 - Cat, 2 - Parrot, 3 - Hamster): ";
        cin >> type;

        cout << "Enter the name of the animal: ";
        cin >> name;
        cout << "Enter the age of the animal: ";
        cin >> age;

        Animal* newAnimal = nullptr;

        switch (type) {
        case DOG:
            newAnimal = new Dog(name, age);
            break;
        case CAT:
            newAnimal = new Cat(name, age);
            break;
        case PARROT:
            newAnimal = new Parrot(name, age);
            break;
        case HAMSTER:
            newAnimal = new Hamster(name, age);
            break;
        default:
            cout << "Invalid animal type." << endl;
            return;
        }

        Animal** newZoo = new Animal * [size + 1];
        for (size_t i = 0; i < size; ++i) {
            newZoo[i] = zoo[i];
        }
        newZoo[size] = newAnimal;

        delete[] zoo;
        zoo = newZoo;
        ++size;
    }

    void displayAnimals() const {
        for (size_t i = 0; i < size; ++i) {
            zoo[i]->show();
        }
    }

    void sellAnimal() {
        string name;
        cout << "Enter the name of the animal to sell: ";
        cin >> name;

        for (size_t i = 0; i < size; ++i) {
            if (zoo[i]->getName() == name) {
                delete zoo[i];

                for (size_t j = i; j < size - 1; ++j) {
                    zoo[j] = zoo[j + 1];
                }

                --size;
                return;
            }
        }

        cout << "Animal with name " << name << " not found." << endl;
    }

    void sellAllAnimals() {
        for (size_t i = 0; i < size; ++i) {
            delete zoo[i];
        }
        delete[] zoo;

        zoo = nullptr;
        size = 0;
    }
};

