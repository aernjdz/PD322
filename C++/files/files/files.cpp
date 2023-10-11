
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// N1
/*bool compareFiles(string file1_path, string file2_path) {
	ifstream file_1(file1_path);
	ifstream file_2(file2_path);
	string line_1, line_2;
	int line_Num = 1;
	while (getline(file_1, line_1) && getline(file_2, line_2)) {
		if (line_1 != line_2) {
			cout << "Files differ at line " << line_Num << ":\n";
			cout << "File 1: " << line_1 << endl;
			cout << "File 2: " << line_2 << endl;
			return false;
		}
		line_Num++;
	}
	if (getline(file_1, line_1) || getline(file_2, line_2)) {
		cout << "Files have different line counts."<<endl;
		return false;
	}
	return true;
}
**/
// N2

/*struct CharacterStats {
	int chars;
	int lines;
	int vowel;
	int consonant;
	int digit;
};
CharacterStats count(ifstream& file) {
	CharacterStats stats = { 0, 0, 0, 0,0 };
	char ch;
	while (file.get(ch)) {
		stats.chars++;
		if (isalpha(ch)) {
			ch = tolower(ch);
			switch (ch) {
			case 'a':
			case 'e':
			case 'i':
			case 'o':
			case 'u':
			case 'y':
				stats.vowel++;
			default:
				stats.consonant++;
			}
		}else if (isdigit(ch)){
			stats.digit++;
		}
		if (ch == '\n') {
			stats.lines++;
		}
	}
	return stats;
}*/
//N3
string readFile(string& name) {
	string tmp = "";
	string result = "";
	ifstream file(name);
	if (!file.is_open()) {

		cout << "Error" << endl;
		return "";
	}

	while (getline(file, tmp)) {
		result += tmp;
		result += "\n";
	}
	return result;
	
}
void writeFile(string& name,string& text) {
	ofstream file(name);
	if (!file.is_open()) {
		cout << "Error" << endl;
		return;
	}
	file << text << endl;

}
string caesarEncrypt(string& text,int key) {
	string result = "";
	for (char character : text) {
		if (isalpha(character)) {
			char shift = isupper(character)? 'A' : 'a';
			char encryptedChar = (character - shift + key) % 26 + shift;
			result += encryptedChar;
		}
		else {
			result += character;
		}
	}
	return result;
}
int main()
{
	// N1
		/*string file1Path = "file1.txt";
		string file2Path = "file2.txt";*/
		/*if (compareFiles(file1Path, file2Path)) {
			cout << "The files are identical.";
		}*/

	// N2
	/*ifstream input_File("input.txt");
	ofstream output_File("output.txt");
	if (!input_File.is_open() && !output_File.is_open()) {
		cout << "An error occurred while opening the file" << endl;
		return 1;
	}
	CharacterStats stats = count(input_File);
	output_File << "Char`s count :: " << stats.chars << endl;
	output_File << "Line`s count :: " << stats.lines << endl;
	output_File << "Vowel char`s count :: " << stats.vowel << endl;
	output_File << "Consonant char`s count :: " << stats.consonant << endl;
	output_File << "Number`s count :: " << stats.digit << endl;

	input_File.close();
	output_File.close();
	cout << "Statistics successfully written to file 'output.txt'." << endl;*/

	// N3
	string input_File = "input.txt";
	string output_File = "output.txt";

	string text = readFile(input_File);
	cout << "Input :: " << endl;
	cout << text << endl;
	string result = caesarEncrypt(text, 3);
	cout << "Output :: " << endl;
	cout << result << endl;
	writeFile(output_File, result);
	}

