#include <iostream>
#include <vector>
#include <algorithm>
#include <ctime>
#include <fstream>

using namespace std;

int main() {
    vector<int> v1;
    int input;
    cout << "Enter elements for v1 (separated by spaces, enter a non-integer to finish): ";
    while (cin >> input) {
        v1.push_back(input);
    }

    if (cin.fail()) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }

    vector<int> v2(10, 0);

    int n;
    cout << "Enter the number of elements for v3: ";
    cin >> n;
    srand(static_cast<unsigned int>(time(0)));
    vector<int> v3;
    for (int i = 0; i < n; ++i) {
        v3.push_back(rand() % 100);
    }

    vector<int> v4 = v1;

    vector<int> v5(v3.begin() + 1, v3.end() - 1);

    cout << "Elements of v3: ";
    for (int elem : v3) {
        cout << elem << " ";
    }
    cout << endl;

    cout << "Elements of v1 in reverse order written to 'Numbers.txt'\n";
    reverse(v1.begin(), v1.end());
    ofstream outputFile("Numbers.txt");
    if (!outputFile.is_open()) {
        cerr << "Failed to open file 'Numbers.txt' for writing" << endl;
        return 1;
    }
    for (int elem : v1) {
        outputFile << elem << " ";
    }
    outputFile.close();

    vector<int> v2_clear;
    for (int i = 1; i <= 10; ++i) {
        v2_clear.push_back(i);
    }
    random_shuffle(v2_clear.begin(), v2_clear.end());
    v2_clear.erase(v2_clear.begin() + 1);
    v2_clear.pop_back();
    cout << "Shuffled v2: ";
    for (int elem : v2_clear) {
        cout << elem << " ";
    }
    cout << endl;

    vector<int> v4_double = v4;
    for (int& elem : v4_double) {
        v4_double.insert(v4_double.begin(), elem);
        ++elem;
    }

    vector<int> v5_clear;
    for (int elem : v4_double) {
        if (elem % 2 == 0) {
            v5_clear.push_back(elem);
        }
    }
    transform(v5_clear.begin(), v5_clear.end(), v5_clear.begin(), [](int x) { return x / 2; });
    cout << "Resulting v5: ";
    for (int elem : v5_clear) {
        cout << elem << " ";
    }
    cout << endl;

    int value = 5;
    auto it = find(v5_clear.begin(), v5_clear.end(), value);
    while (it != v5_clear.end()) {
        cout << "value :: " << *it << "\t index :: " << it - v5_clear.begin() << endl;
        it = find(it + 1, v5_clear.end(), value);
    }
    cout << "Count value {" << value << "} :: " << count(v5_clear.begin(), v5_clear.end(), value) << endl;

    swap(v4_double, v5_clear);

    vector<vector<int>> multiplication_table(10, vector<int>(10));
    for (int i = 1; i <= 10; ++i) {
        for (int j = 1; j <= 10; ++j) {
            multiplication_table[i - 1][j - 1] = i * j;
        }
    }

    cout << "Multiplication Table:\n";
    for (const auto& row : multiplication_table) {
        for (int elem : row) {
            cout << elem << "\t";
        }
        cout << endl;
    }

    return 0;
}
