
#include <iostream>
using namespace std;
int main() {
    //N1
    int seconds;
    cout << "Enter the number of seconds :: ";
    cin >> seconds;

    int hours = seconds / 3600;
    int minutes = (seconds % 3600) / 60;
    int remainingSeconds = seconds % 60;

    cout << "Hours: " << hours << endl;
    cout << "Minutes: " << (hours == 0 && minutes == 0 ? 0 : minutes) << endl;
    cout << "Seconds: " << remainingSeconds << endl;
    
    //N2
    double amount;
    cout << "enter a decimal number :: ";
    cin >> amount;
    int grn = static_cast<int>(amount);
    double fractionalpart = amount - grn;
    int cop = static_cast<int>(fractionalpart * 100);

    cout << grn << " uah " << cop << " cop. " << endl;

    //N3
    double distance_Meters;
    double time_Input;

    cout << "Calculating running speed." << endl;
    cout << "Enter the distance (meters) :: ";
    cin >> distance_Meters;
    cout << "Enter the time (min.sec) :: ";
    cin >> time_Input;

    int time_Minutes = static_cast<int>(time_Input);
    double time_Seconds = (time_Input - time_Minutes) * 100.0;
    double time_In_Seconds = (time_Minutes * 60.0) + time_Seconds;
    double speed_Kmph = (distance_Meters / 1000.0) / (time_In_Seconds / 3600.0);


    cout.setf(ios::fixed);
    cout.precision(1);

    cout << "Distance: " << distance_Meters << " m." << endl;
    cout << "Time: " << time_Minutes << " min " << time_Seconds << " sec = " << time_In_Seconds << " sec." << endl;
    cout << "You ran at a speed of " << speed_Kmph << " km/h." << endl;

    //N4
    int days;

    cout << "Enter the number of days: ";
    cin >> days;

    int weeks = days / 7;
    int remainingDays = days % 7;

    cout << days << " days = " << weeks << " weeks and " << remainingDays << " days." << endl;

}


