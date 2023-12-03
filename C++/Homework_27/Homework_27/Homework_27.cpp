#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

const size_t MAX_NAME_SIZE = 20;

enum Category {
    ACTION,
    RPG,
    STRATEGY,
    SPORTS
};


const char* categoryToString(Category category) {
    switch (category) {
    case ACTION: return "ACTION";
    case RPG: return "RPG";
    case STRATEGY: return "STRATEGY";
    case SPORTS: return "SPORTS";
    default: return "UNKNOWN";
    }
}


Category stringToCategory(const string& str) {
    if (str == "ACTION") return ACTION;
    if (str == "RPG") return RPG;
    if (str == "STRATEGY") return STRATEGY;
    if (str == "SPORTS") return SPORTS;
    return ACTION;
}


class Game {
public:
    char name[MAX_NAME_SIZE];
    Category category;
    int popularity;

    Game() = default;


    Game(const char* name, Category category, int popularity)
        : category(category), popularity(popularity)
    {
        strncpy_s(this->name, name, _TRUNCATE);
    }


    void print() const
    {
        cout << "\t Name        :: " << name << endl;
        cout << "\t Category    :: " << categoryToString(category) << endl;
        cout << "\t Popularity  :: " << popularity << endl;
    }
};


class GameManager {
private:
    const char* filename;

public:

    GameManager(const char* filename) : filename(filename) {}


    void addGame(const Game& game)
    {
        ofstream file(filename, ios_base::out | ios_base::app | ios_base::binary);
        file.write((char*)&game, sizeof(Game));
        file.close();
        cout << "Game added successfully." << endl;
    }


    void viewAllGames()
    {
        ifstream file(filename, ios_base::binary);
        Game game;
        while (file.read(reinterpret_cast<char*>(&game), sizeof(Game)))
        {
            cout << "\n ----------------------- \n";
            game.print();
        }
        file.close();
    }


    void searchGameByName(const char* name)
    {
        ifstream file(filename, ios_base::binary);
        Game game;
        bool found = false;
        while (file.read(reinterpret_cast<char*>(&game), sizeof(Game)))
        {
            if (strcmp(game.name, name) == 0)
            {
                found = true;
                cout << "\n ----------------------- \n";
                game.print();
            }
        }
        file.close();

        if (!found)
            cout << "Game with name '" << name << "' not found." << endl;
    }


    void searchGamesByCategory(const string& categoryStr)
    {
        ifstream file(filename, ios_base::binary);
        Game game;
        Category categoryToSearch = stringToCategory(categoryStr);
        while (file.read(reinterpret_cast<char*>(&game), sizeof(Game)))
        {
            if (game.category == categoryToSearch)
            {
                cout << "\n ----------------------- \n";
                game.print();
            }
        }
        file.close();
    }


    void editGameByIndex(int index, const Game& newGame)
    {
        fstream file(filename, ios_base::in | ios_base::out | ios_base::binary);

        file.seekp(sizeof(Game) * index);
        file.write(reinterpret_cast<const char*>(&newGame), sizeof(Game));

        file.close();
        cout << "Game edited successfully." << endl;
    }


    void removeGameByName(const char* name)
    {
        ifstream infile(filename, ios_base::binary);
        ofstream outfile("temp.dat", ios_base::out | ios_base::binary);

        Game game;
        bool removed = false;

        while (infile.read(reinterpret_cast<char*>(&game), sizeof(Game)))
        {
            if (strcmp(game.name, name) != 0)
                outfile.write(reinterpret_cast<const char*>(&game), sizeof(Game));
            else
                removed = true;
        }

        infile.close();
        outfile.close();

        remove(filename);
        rename("temp.dat", filename);

        if (!removed)
            cout << "Game with name '" << name << "' not found." << endl;
        else
            cout << "Game with name '" << name << "' removed successfully." << endl;
    }


    void clearDatabase()
    {
        ofstream file(filename, ios_base::trunc);
        file.close();
        cout << "Database cleared." << endl;
    }
};


void printMenu()
{
    cout << "\nMenu:\n";
    cout << "1. View all games\n";
    cout << "2. Add a new game\n";
    cout << "3. Search game by name\n";
    cout << "4. Search games by category\n";
    cout << "5. Edit game by index\n";
    cout << "6. Remove game\n";
    cout << "7. Clear database\n";
    cout << "8. Exit\n";
    cout << "Enter your choice: ";
}

int main()
{
    GameManager gameManager("games.dat");
    int choice;

    do {
        printMenu();
        cin >> choice;

        switch (choice)
        {
        case 1:
            gameManager.viewAllGames();
            break;
        case 2:
        {
            char name[MAX_NAME_SIZE];
            string categoryStr;
            int popularity;

            cout << "Enter game name: ";
            cin.ignore();
            cin.getline(name, MAX_NAME_SIZE);

            cout << "Enter game category (ACTION, RPG, STRATEGY, SPORTS): ";
            cin >> categoryStr;

            cout << "Enter game popularity: ";
            cin >> popularity;

            Game newGame(name, stringToCategory(categoryStr), popularity);
            gameManager.addGame(newGame);
        }
        break;
        case 3:
        {
            char searchName[MAX_NAME_SIZE];
            cout << "Enter the name to search: ";
            cin.ignore();
            cin.getline(searchName, MAX_NAME_SIZE);
            gameManager.searchGameByName(searchName);
        }
        break;
        case 4:
        {
            string searchCategory;
            cout << "Enter the category to search (ACTION, RPG, STRATEGY, SPORTS): ";
            cin >> searchCategory;
            gameManager.searchGamesByCategory(searchCategory);
        }
        break;
        case 5:
        {
            int index;
            cout << "Enter the index to edit: ";
            cin >> index;

            char newName[MAX_NAME_SIZE];
            string newCategoryStr;
            int newPopularity;

            cout << "Enter new game name: ";
            cin.ignore();
            cin.getline(newName, MAX_NAME_SIZE);

            cout << "Enter new game category (ACTION, RPG, STRATEGY, SPORTS): ";
            cin >> newCategoryStr;

            cout << "Enter new game popularity: ";
            cin >> newPopularity;

            Game editedGame(newName, stringToCategory(newCategoryStr), newPopularity);
            gameManager.editGameByIndex(index, editedGame);
        }
        break;
        case 6:
        {
            char removeName[MAX_NAME_SIZE];
            cout << "Enter the name to remove: ";
            cin.ignore();
            cin.getline(removeName, MAX_NAME_SIZE);
            gameManager.removeGameByName(removeName);
        }
        break;
        case 7:
            gameManager.clearDatabase();
            break;
        case 8:
            cout << "Exiting the program.\n";
            break;
        default:
            cout << "Invalid choice. Please enter a number between 1 and 8.\n";
            break;
        }
    } while (choice != 8);

    return 0;
}
