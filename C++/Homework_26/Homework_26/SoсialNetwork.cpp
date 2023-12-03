#include "SocialNetwork.h"
#include <cctype>
#include <algorithm>

bool containsCharacterType(const string& str, bool (*predicate)(char))
{
    return any_of(str.begin(), str.end(), predicate);
}

bool containsDigit(char c)
{
    return isdigit(c);
}

bool containsUpperAlpha(char c)
{
    return isupper(c);
}

bool containsLowerAlpha(char c)
{
    return islower(c);
}

bool containsPunctuation(char c)
{
    string symbols = "_&$#!?|@*^[]{}+-.";

    return find(symbols.begin(), symbols.end(), c) != symbols.end();
}

bool SocialNetwork::checkPassword(const string& password) const
{
    return containsCharacterType(password, containsDigit) &&
        containsCharacterType(password, containsLowerAlpha) &&
        containsCharacterType(password, containsUpperAlpha) &&
        containsCharacterType(password, containsPunctuation) &&
        password.size() > 7;
}

bool SocialNetwork::checkLogin(const string& login) const
{
    return find_if(accounts.begin(), accounts.end(),
        [&login](const User& user) { return user.getlogin() == login; }) == accounts.end();
}

void SocialNetwork::register_(const string& login, const string& password)
{
    if (!checkLogin(login))
    {
        throw ExistLoginException("Login already exists");
    }
    if (!checkPassword(password))
    {
        throw WrongPasswordLengthException("Invalid password");
    }
    User new_user(login, password);
    accounts.push_back(new_user);
}

void SocialNetwork::sign_in(const string& login, const string& password)
{
    auto it = find_if(accounts.begin(), accounts.end(),
        [&login](const User& user) { return user.getlogin() == login; });

    if (it == accounts.end())
    {
        throw InvalidLoginException("User not found");
    }

    const string& storedPassword = it->getpassword();
    if (storedPassword != password)
    {
        throw InvalidPasswordException("Invalid password");
    }

    cout << "Welcome, " << login << "!" << endl;
}
