#pragma once
#include "IDDevices.h"
#include <iostream>
using namespace std;
class TV : public IDDevices
{
    static const int MAX_VOLUME = 100;
    int max_channels;
    bool isOn = false;
    int volume = 15;
    int channel = 1;

public:
    TV(const int& max_channel = 20);

    void power() override;
    void plus() override;
    void minus() override;
    void next() override;
    void prev() override;
    void showInfo() override;
};
