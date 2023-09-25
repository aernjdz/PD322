#include <iostream>
using namespace std;

// N1
//double power(double base, int exponent) {
//    if (exponent == 0) {
//        return 1.0; 
//   }
//
//    if (exponent > 0) {
//        return base * power(base, exponent - 1);
//    }
//    else {
//        return 1.0 / (base * power(base, -exponent - 1));
//   }
//}

// N2
//int sum_In_Range(int a, int b) {
//    if (a > b) {
//        return 0;
//    }
//    else {
//        return a + sumInRange(a + 1, b);
//    }
//}

// N3

//bool is_Perfect(int num) {
//    int sum = 0; 
//
//    for (int i = 1; i <= num / 2; i++) {
//        if (num % i == 0) {
//            sum += i;
//        }
//    }
//
//    return sum == num;
//}
//
//
//void find_Perfect_Numbers(int start, int end) {
//    for (int i = start; i <= end; i++) {
//        if (is_Perfect(i)) {
//            cout << i << " ";
//        }
//    }
//    cout << endl;
//}

// N4
void printCard(int rank, string suit) {
    cout << "Card: " << rank << " of " << suit << endl;
}
int main()
{
   // N1
   /*double base;
   int exponent;

   cout << "Enter the base: ";
   cin >> base;

   cout << "Enter the exponent: ";
   cin >> exponent;

   double result = power(base, exponent);
   cout << base << "^" << exponent << " = " << result << endl;*/

   // N2
    /*int a, b;
    
    cout << endl;
    cout << "Enter the value of a: ";
    cin >> a;

    cout << "Enter the value of b: ";
    cin >> b;

    if (a > b) {
        cout << "a should be less than or equal to b." << endl;
    }
    else {
        int result = sum_In_Range(a, b);
        cout << "The sum of numbers from " << a << " to " << b << " is " << result << endl;
    }*/
    // N3
    /*int start, end;

    cout << "Enter the beginning of the interval: ";
    cin >> start;

    cout << "Enter the end of the interval: ";
    cin >> end;

    cout << "Perfect numbers in the interval [" << start << ", " << end << "]: "; 
    find_Perfect_Numbers(start, end);*/

    // N4
    int rank;
    string suit;

  
    cout << "Enter the rank of the card: ";
    cin >> rank;

    cout << "Enter the suit of the card: ";
    cin >> suit;

   
    printCard(rank, suit);
}


