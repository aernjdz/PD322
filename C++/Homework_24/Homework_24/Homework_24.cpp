#include <iostream>
#include "SmartRemote.h"
#include "TV.h"
#include "Conditioner.h"

int main()
{
    TV tv;
    Conditioner ac;

    SmartRemote remote(&tv);
    remote.currentDevice();
    remote.testDevice();

    remote.setDevice(&ac);
    remote.currentDevice();
    remote.testDevice();

    return 0;
}
