#pragma once
#include "IDDevices.h"

enum keys
{
    ENTER = 13, UP = 72, DOWN = 80, LEFT = 75, RIGHT = 77, ESC = 27
};

class SmartRemote
{
    IDDevices* device;
public:
    SmartRemote(IDDevices* device);
    void setDevice(IDDevices* device);
    void currentDevice() const;
    void testDevice();
};
