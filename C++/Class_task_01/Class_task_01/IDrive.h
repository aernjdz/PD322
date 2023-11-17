#pragma once
#include<iostream>
using namespace std;
class IDrivable {
public:
    virtual void start() = 0;
    virtual void stop() = 0;
    virtual void upSpeed() = 0;
    virtual void downSpeed() = 0;
    virtual ~IDrivable() {}
};


class Car : public IDrivable {
private:
    const string brand;
    const int maxSpeed;
    int currentSpeed;

public:
    Car(const string& brand, int maxSpeed) : brand{ brand }, maxSpeed{ maxSpeed }, currentSpeed{ 0 } {}

    void start() override {
       cout << "Car started.\n";
    }

    void stop() override {
        cout << "Car stopped.\n";
    }

    void upSpeed() override {
        if (currentSpeed < maxSpeed) {
            currentSpeed += 10;
            cout << "Car speed increased to " << currentSpeed << " km/h.\n";
        }
        else {
            cout << "Car is already at max speed.\n";
        }
    }

    void downSpeed() override {
        if (currentSpeed > 0) {
            currentSpeed -= 10;
            cout << "Car speed decreased to " << currentSpeed << " km/h.\n";
        }
        else {
            cout << "Car is already stationary.\n";
        }
    }
};

class Horse : public IDrivable {
private:
    const string name;
    const string breed;
    int currentSpeed;

public:
    Horse(const string& name, const string& breed) : name{ name }, breed{ breed }, currentSpeed{ 0 } {}

    void start() override {
        cout << "Horse started.\n";
    }

    void stop() override {
        cout << "Horse stopped.\n";
    }

    void upSpeed() override {
        currentSpeed += 5;
        cout << "Horse speed increased to " << currentSpeed << " km/h.\n";
    }

    void downSpeed() override {
        if (currentSpeed > 0) {
            currentSpeed -= 5;
            cout << "Horse speed decreased to " << currentSpeed << " km/h.\n";
        }
        else {
            cout << "Horse is already stationary.\n";
        }
    }
};

class Driver {
private:
    string name;
    IDrivable* vehicle;

public:
    Driver(const string& name) : name{ name }, vehicle{ nullptr } {}

    void setVehicle(IDrivable* newVehicle) {
        vehicle = newVehicle;
    }

    void testDrive() {
        if (vehicle) {
            vehicle->start();
            vehicle->upSpeed();
            vehicle->downSpeed();
            vehicle->stop();
        }
        else {
            cout << "No vehicle assigned for test drive.\n";
        }
    }
};