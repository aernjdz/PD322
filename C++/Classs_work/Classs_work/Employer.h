#pragma once
#include<iostream>
using namespace std;

class Employer {
protected:
    string name;

public:
    Employer(const string& n) : name(n) {}

    virtual void Print() const = 0; 
};

class President : public Employer {
public:
    President(const string& n) : Employer(n) {}

    void Print() const override {
        cout << "President " << name << ": Manages the entire organization." << endl;
    }
};

class Manager : public Employer {
public:
    Manager(const string& n) : Employer(n) {}

    void Print() const override {
       cout << "Manager " << name << ": Manages a specific department or team." << endl;
    }
};

class Worker : public Employer {
public:
    Worker(const string& n) : Employer(n) {}

    void Print() const override {
        cout << "Worker " << name << ": Performs specific tasks as part of the team." << endl;
    }
};

