#include "TV.h"
#include <iostream>
#include "SmartRemote.h"
#include <conio.h>
#include "Conditioner.h"

SmartRemote::SmartRemote(IDDevices* device) : device(device) {}

void SmartRemote::setDevice(IDDevices* device)
{
    this->device = device;
}

void SmartRemote::currentDevice() const
{
    auto tv = dynamic_cast<TV*>(device);
    auto ac = dynamic_cast<Conditioner*>(device);

    if (tv != nullptr) {
        cout << "Current Device: TV" << endl;
    }
    else if (ac != nullptr) {
        cout << "Current Device: Conditioner" << endl;
    }
}

void SmartRemote::testDevice()
{
    while (true)
    {
        int s = _getch();
        if (s == keys::ESC) {
            break;
        }
        switch (s)
        {
        case ENTER:
            device->power(); break;
        case UP:
            device->next(); break;
        case DOWN:
            device->prev(); break;
        case LEFT:
            device->minus(); break;
        case RIGHT:
            device->plus(); break;
        }
    }
}
