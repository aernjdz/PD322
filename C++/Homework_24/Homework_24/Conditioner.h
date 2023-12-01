#pragma once
#include <iostream>
#include "IDDevices.h"
using namespace std;
enum class ACMode { Heating, Cooling, Turbo, Sleep };

class Conditioner : public IDDevices
{
    static const int MIN_TEMPERATURE = 10;
    static const int MAX_TEMPERATURE = 30;
    bool powerState;
    int temperature;
    ACMode mode;
public:
    Conditioner();
    void power() override;
    void plus() override;
    void minus() override;
    void next() override;
    void prev() override;
    void showInfo() override;
};
