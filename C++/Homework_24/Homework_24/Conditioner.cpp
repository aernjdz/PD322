#include "Conditioner.h"

Conditioner::Conditioner() : powerState(false), temperature(20), mode(ACMode::Cooling) {}

void  Conditioner::power()
{
    powerState = !powerState;
    showInfo();
}

void  Conditioner::plus()
{
    if (powerState && temperature < MAX_TEMPERATURE) {
        temperature++;
    }
    showInfo();
}

void Conditioner::minus()
{
    if (powerState && temperature > MIN_TEMPERATURE) {
        temperature--;
    }
    showInfo();
}

void Conditioner::next()
{
    if (powerState) {
        int nextMode = static_cast<int>(mode) + 1;
        if (nextMode > static_cast<int>(ACMode::Sleep)) {
            nextMode = static_cast<int>(ACMode::Heating);
        }
        mode = static_cast<ACMode>(nextMode);
    }
    showInfo();
}

void Conditioner::prev()
{
    if (powerState) {
        int prevMode = static_cast<int>(mode) - 1;
        if (prevMode < static_cast<int>(ACMode::Heating)) {
            prevMode = static_cast<int>(ACMode::Sleep);
        }
        mode = static_cast<ACMode>(prevMode);
    }
    showInfo();
}

void Conditioner::showInfo()
{
    cout << "\nAir Conditioner is " << (powerState ? "on" : "off") << endl;
    if (powerState) {
        cout << "Temperature: " << temperature << "C" << endl;
        cout << "Mode: ";
        switch (mode) {
        case ACMode::Heating: cout << "Heating"; break;
        case ACMode::Cooling: cout << "Cooling"; break;
        case ACMode::Turbo: cout << "Turbo"; break;
        case ACMode::Sleep: cout << "Sleep"; break;
        }
        cout << endl;
    }
}
