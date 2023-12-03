//#include <iostream>
//#include <map>
//#include <algorithm>
//#include <fstream>
//using namespace std;
//N1
//using pl = string;
//using eng = string;
//
//using Dictionary = map<pl, eng>;
//
//template <typename T>
//void print(const T& map, const string& prompt)
//{
//    cout << prompt << "::" << endl;
//    for (auto& el : map) {
//        cout << "\t\t\t Poland :: " << el.first << "\t\t English :: " << el.second << endl;
//    }
//}
//
//
//void addWord(Dictionary& map ,const string& word, const string& definition) {
//    map.insert({ word,definition });
//    cout << "Successful!" << endl;
//}
//
//void removeWord(Dictionary& map, const string& word) {
//    auto it = map.find(word);
//    if (it != map.end()) {
//        map.erase(it);
//        cout << "Successful removal of the word!" << endl;
//    }
//    else {
//        cerr << "Error find world!"<<endl;
//    }
//}
//void editWord(Dictionary& map,const string& word ,const string& newDefinition ) {
//    auto it = map.find(word);
//    if (it != map.end()) {
//        it->second = newDefinition;
//        cout << "Successful!" << endl;
//    }
//    else {
//        cerr << "Error find world!" << endl;
//    }
//}
//
//void saveToFile(const Dictionary& map, const string& filename) {
//    ofstream file(filename);
//    if (file.is_open()) {
//        for (const auto& entry : map) {
//            file << entry.first << " " << entry.second << "\n";
//        }
//        cout << "Dictionary saved to file successfully." << endl;
//    }
//    else {
//        cerr << "Error opening the file for saving." << endl;
//    }
//}
//
//void loadFromFile(Dictionary& map, const string& filename) {
//    ifstream file(filename);
//    if (file.is_open()) {
//        map.clear();
//
//        pl word;
//        eng definition;
//        while (file >> word >> definition) {
//            map[word] = definition;
//        }
//        cout << "Dictionary loaded from file successfully." << endl;
//    }
//    else {
//        cerr << "Error opening the file for loading." << endl;
//    }
//}
//int main()
//{
//    Dictionary dict
//    {
//        {"Szacunek","Respect"},
//        {"Tak","Yes"},
//        {"Ja","I"},
//        {"Witam","Hello"},
//    };
//
//
//    print(dict, "Dict Pl to ENG ");
//    addWord(dict, "text","test");
//    print(dict, "Dict Pl to ENG ");
//    removeWord(dict,"Tak");
//    print(dict, "Dict Pl to ENG ");
//    editWord(dict,"Witam","Hi");
//    print(dict, "Dict Pl to ENG ");
//    saveToFile(dict, "dictionary.txt");
//    dict.clear();
//    loadFromFile(dict, "dictionary.txt");
//    print(dict, "Dict Pl to ENG (After Loading)");
//}


 
#include <iostream>
#include <fstream>
#include <map>
#include <vector>
#include <string>
#include <algorithm>
#include <locale>
using namespace std;

using WordFrequencyMap = map<string, int>;
using TranslationDictionary = map<string, vector<string>>;

string readTextFromFile(const string& filename) {
    ifstream file(filename);
    if (!file.is_open()) {
        cerr << "Error opening file: " << filename << endl;
        return "";
    }

    string content;
    string line;
    while (getline(file, line)) {
        content += line + " ";
    }

    file.close();
    return content;
}

WordFrequencyMap buildWordFrequencyMap(const string& text) {
    WordFrequencyMap frequencyMap;
    string word;
    for (char c : text) {
        if (isalpha(c) || c == '\'') {
            word += tolower(c);
        }
        else if (!word.empty()) {
            frequencyMap[word]++;
            word.clear();
        }
    }
    if (!word.empty()) {
        frequencyMap[word]++;
    }
    return frequencyMap;
}


TranslationDictionary buildTranslationDictionary() {
    return {
        {"sample", {"przykład", "wzorzec"}},
        {"text", {"tekst"}},
        {"frequent", {"częsty", "często"}},
        {"word", {"słowo"}},
        {"program", {"program"}},
        {"file", {"plik"}},
        {"most", {"najbardziej"}},
        {"test", {"testowanie"}},
        {"words", {"słowa"}},
        {"translations", {"tłumaczenia"}},
    };
}

void printWordFrequencies(const WordFrequencyMap& frequencyMap) {
    cout << "Częstotliwość Słów (Word Frequencies):" << endl;
    for (const auto& entry : frequencyMap) {
        cout << entry.first << ": " << entry.second << " razy" << endl;
    }
}


string findMostFrequentWord(const WordFrequencyMap& frequencyMap) {
    auto maxEntry = max_element(frequencyMap.begin(), frequencyMap.end(),
        [](const auto& entry1, const auto& entry2) {
            return entry1.second < entry2.second;
        });
    return maxEntry->first;
}

void writeResultsToFile(const WordFrequencyMap& frequencyMap, const TranslationDictionary& translationDict, const string& filename) {
    ofstream file(filename);
    if (!file.is_open()) {
        cerr << "Error opening file for writing: " << filename << endl;
        return;
    }

    file << "Częstotliwość Słów (Word Frequencies):" << endl;
    for (const auto& entry : frequencyMap) {
        file << entry.first << ": " << entry.second << " razy" << endl;


        auto translationIt = translationDict.find(entry.first);
        if (translationIt != translationDict.end()) {
            file << "  Tłumaczenia: ";
            for (const auto& translation : translationIt->second) {
                file << translation << ", ";
            }
            file << endl;
        }
    }

    cout << "Wyniki zapisane do pliku: " << filename << endl;

    file.close();
}

int main() {

    string filename = "sample.txt"; 
    string text = readTextFromFile(filename);

    if (text.empty()) {
        return 1; 
    }
    WordFrequencyMap frequencyMap = buildWordFrequencyMap(text);

  
    printWordFrequencies(frequencyMap);

  
    string mostFrequentWord = findMostFrequentWord(frequencyMap);
    cout << "Najczęściej występujące słowo: " << mostFrequentWord << endl;

  
    TranslationDictionary translationDict = buildTranslationDictionary();

    
    string outputFilename = "word_frequencies_with_translations.txt"; 
    writeResultsToFile(frequencyMap, translationDict, outputFilename);

}
