#include <iostream>
#include "String.h"

using namespace std;

int main() {
    String str1;
    String str2(60);

    const char* inputStr = "Hello, C++!";
    String str3(inputStr);

    str3.display();

    cout << "Number of String objects: " << String::getCount() << endl;

    return 0;
}
