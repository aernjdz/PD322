#include "TV.h"

TV::TV(const int& max_channel) : max_channels(max_channel) {}

void TV::power()
{
    isOn = !isOn;
    showInfo();
}

void TV::plus()
{
    if (isOn && volume < MAX_VOLUME)
    {
        volume++;
    }
    showInfo();
}

void TV::minus()
{
    if (isOn && volume > 0)
    {
        volume--;
    }
    showInfo();
}

void TV::next() {
    channel = (channel % max_channels) + 1;
    showInfo();
}

void TV::prev() {
    channel = (channel - 2 + max_channels) % max_channels + 1;
    showInfo();
}
void TV::showInfo()
{
    if (!isOn)
    {
        cout << "TV is turned off" << endl;
        return;
    }
    cout << "\nTV is enabled" << endl;
    cout << "Volume  :: " << volume <<"%" << endl;
    cout << "Channel :: " << channel << endl;
}
