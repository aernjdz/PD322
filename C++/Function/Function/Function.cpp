
#include <iostream>
using namespace std;
// N1
//void drawRectangle(int N, int K) {
//    for (int i = 0; i < N; i++) {
//        for (int j = 0; j < K; j++) {
//            cout << "*" << " ";
//        }
//        cout << endl;
//    }
 
// N2
//unsigned long long factorial(int n) {
//    unsigned long long factorial = 1;
//    for (int i = 2; i <= n; i++) {
//        factorial *= i;
//    }
//
//    return factorial;
//}

// N3
//bool isPrime(int n) {
//    if (n <= 1) return false;
//    if (n <= 3) return true;
//    if (n % 2 == 0 || n % 3 == 0) return false;
//    for (int i = 5; i * i <= n; i += 6) {
//        if (n % i == 0 || n % (i + 2) == 0) return false;
//    }
//    return true;
//}

// N4
//double cube(double x) {
//    return x * x * x;
//}

// N5
//int findMax(int a, int b) {
//    if (a > b) {
//        return a;
//    }
//    else {
//        return b;
//    }
//}

// N5 
bool isPositive(double num) {
   
    return (num > 0);
    }

int main()
{
    // N1
    /*int n, k;
    cout << "Enter the height of the rectangle (N): ";
    cin >> n;
    cout << "Enter the width of the rectangle (K): ";
    cin >> k;
    drawRectangle(n, k);*/

    // N2
    /*int num;
    cout << "Enter a non-negative integer: ";
    cin >> num;

    if (num < 0) {
        cout << "Factorial is undefined for negative numbers." << endl;
    }
    else {
        cout << "Factorial of " << num << " is " << factorial(num) << endl;
    }*/

    // N3
    /*int num;
    cout << "Enter is number :: ";
    cin >> num;
    cout << num<< (isPrime(num) ? " is a prime number." : " is not a prime number.") << endl;*/

    // N4
    /*double num;
    cout << "Enter is number :: ";
    cin >> num;
    cout << "The cube of a number :: " << cube(num) << endl;*/

    // N5
    /*int num_1, num_2;
    cout << "Enter is first number :: ";
    cin >> num_1;
    cout << "Enter is second number :: ";
    cin >> num_2;
    cout << "The greatest of the numbers " << num_1 << " and " << num_2 << " is " << findMax(num_1, num_2) << endl;*/

    double num;
    cout << "Enter is number :: ";
    cin >> num;

    cout << num << (isPositive(num) ? " is positive." : " is negative or equal to zero.") << endl;

}
    

