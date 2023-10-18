#include <iostream>
#include <fstream>
#include <string>

using namespace std;
void reverseLines(ifstream& input_file, ofstream& output_file) {
	string line;
	if (getline(input_file, line)) {
		reverseLines(input_file, output_file);
		output_file << line << endl;
	}
}

string* readFileLines(const string& fname, size_t& size) {
	string* lines = nullptr;
	ifstream file(fname);

	if (!file.is_open()) {
		cout << "Error: Could not open the file." << endl;
		return nullptr;
	}

	string line;
	while (getline(file, line)) {
		size++;
	}

	file.clear();
	file.seekg(0);

	lines = new string[size];
	int  index = 0;
	while (getline(file, line)) {
		lines[index] = line;
		index++;
	}

	file.close();
	return lines;
}

bool hasSpace(const string& line) {
	for (int i = 0; i < line.size(); i++) {
		if (isspace(line[i])) {
			return true;
		}
	}
	return false;
}

int findLastLineWithoutSpace(const string* lines, size_t size) {
	for (int i = size - 1; i >= 0; i--) {
		if (!hasSpace(lines[i])) {
			return i;
		}
	}
	return -1;
}

void writeFile_t4(const string& fname, const string* lines, size_t size) {
	string line = "------------";
	int index = findLastLineWithoutSpace(lines, size);

	ofstream file(fname, ios::app);
	if (!file.is_open()) {
		cout << "Error!" << endl;
		return;
	}

	if (index == -1 || index == size - 1) {
		file << line << endl;
		file.close();
		return;
	}

	for (size_t i = 0; i < size; i++) {
		file << lines[i] << "\n";
		if (i == index) {
			file << line << endl;
		}
	}
	file.close();
}

int main()
{
	// N1
	/*ifstream inputFile("input_01.txt");
	ofstream outputFile("output_01.txt");
	if (!inputFile.is_open() || !outputFile.is_open()) {
		cout << "Error!" << endl;
		return 1;
	}

	string word;

	while (inputFile >> word) {
		if (word.length() >= 7) {
			outputFile << word << " ";
		}
	}

	inputFile.close();
	outputFile.close();
	*/

	// N2
	/*ifstream inputFile("input_02.txt");
	ofstream outputFile("output_02.txt");

	if (!inputFile.is_open() || !outputFile.is_open()) {
		cout << "Error!" << endl;
		return 1;
	}

	string line;
	while (getline(inputFile, line)) {
		outputFile << line << endl;
	}

	inputFile.close();
	outputFile.close();
	*/

	// N3
	/*ifstream inputFile("input_03.txt");
	ofstream outputFile("output_03.txt");
	if (!inputFile.is_open() || !outputFile.is_open()) {
		cout << "Error!" << endl;
		return 1;
	}

	reverseLines(inputFile, outputFile);

	inputFile.close();
	outputFile.close();
	*/
	//N4

	size_t size = 0;
	string fname = "task4.txt";
	string* lines = readFileLines(fname, size);
	if (lines != nullptr) {
		for (size_t i = 0; i < size; i++) {
			cout << boolalpha << hasSpace(lines[i]) << "\t" << lines[i] << endl;
		}
		cout << "Last line without space: " << findLastLineWithoutSpace(lines, size) << endl;
		writeFile_t4(fname, lines, size);
		delete[] lines; 
	}

}


