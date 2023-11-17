#pragma once
#include<iostream>
using namespace std;

template<typename T>
struct Node
{
    T data;
    Node* parent, * left, * right;
    Node(const T& data = T(), Node* parent = nullptr, Node* left = nullptr, Node* right = nullptr) :
        data{ data }, left{ left }, parent{ parent }, right{ right }
    {

    }
};

template<typename T>
class BTree
{
public:
    BTree() = default;
    void add(const T& data);
    void print() const;
    bool isEmpty() const;
    T min() const;
    T max() const;
    bool find(const T& data) const;
    void printRange(const T& left, const T& right);

    void clear();
    ~BTree();
    void deleteElement(const T& data);
    Node<T>* getRoot() const;

private:
    Node<T>* root = nullptr;
    size_t size = 0;
    void helperPrint(Node<T>* node) const;
    void clearHelper(Node<T>* node);
    Node<T>* findMax(Node<T>* node) const;
    Node<T>* findMin(Node<T>* node) const;
    Node<T>* deleteSubtree(Node<T>* root, const T& data);
    void printRangeHelper(Node<T>* node, const T& left, const T& right);
};

template<typename T>
void BTree<T>::add(const T& data)
{
    Node<T>* newNode = new Node<T>(data);
    size++;
    if (isEmpty()) {
        root = newNode;
        return;
    }
    auto tmp = root;
    while (true)
    {
        if (newNode->data < tmp->data) {
            if (tmp->left == nullptr) {
                tmp->left = newNode;
                newNode->parent = tmp;
                break;
            }
            tmp = tmp->left;
        }
        else {
            if (tmp->right == nullptr) {
                tmp->right = newNode;
                newNode->parent = tmp;
                break;
            }
            tmp = tmp->right;
        }
    }
}

template<typename T>
void BTree<T>::print() const
{
    cout << "Binary Tree :: ";
    helperPrint(root);
    cout << endl;
}

template<typename T>
bool BTree<T>::isEmpty() const
{
    return root == nullptr;
}

template<typename T>
T BTree<T>::min() const
{
    auto tmp = root;
    while (tmp->left != nullptr)
    {
        tmp = tmp->left;
    }
    return tmp->data;
}

template<typename T>
T BTree<T>::max() const
{
    auto tmp = root;
    while (tmp->right != nullptr)
    {
        tmp = tmp->right;
    }
    return tmp->data;
}

template<typename T>
bool BTree<T>::find(const T& data) const
{
    auto tmp = root;
    while (tmp != nullptr)
    {
        if (tmp->data == data) {
            return true;
        }
        if (data < tmp->data) {
            tmp = tmp->left;
        }
        else {
            tmp = tmp->right;
        }
    }
    return false;
}

template<typename T>
void BTree<T>::helperPrint(Node<T>* node) const
{
    if (node != nullptr) {
        helperPrint(node->left);
        cout << node->data << "\t";
        helperPrint(node->right);
    }
}

template<typename T>
void BTree<T>::clearHelper(Node<T>* node)
{
    if (node != nullptr)
    {
        clearHelper(node->left);
        clearHelper(node->right);
        delete node;
    }
}

template<typename T>
void BTree<T>::clear()
{
    clearHelper(root);
    root = nullptr;
    size = 0;
}

template<typename T>
BTree<T>::~BTree()
{
    clear();
}

template<typename T>
void BTree<T>::printRange(const T& left, const T& right)
{
    printRangeHelper(root, left, right);
}

template<typename T>
void BTree<T>::printRangeHelper(Node<T>* node, const T& left, const T& right)
{
    if (node != nullptr)
    {
        if (node->data > left)
        {
            printRangeHelper(node->left, left, right);
        }

        if (node->data >= left && node->data <= right)
        {
            cout << node->data << "\t";
        }

        if (node->data < right)
        {
            printRangeHelper(node->right, left, right);
        }
    }
}

template<typename T>
void BTree<T>::deleteElement(const T& data)
{
    root = deleteSubtree(root, data);
    size--;
}

template<typename T>
Node<T>* BTree<T>::deleteSubtree(Node<T>* root, const T& data)
{
    if (root == nullptr)
        return root;

    if (data < root->data)
        root->left = deleteSubtree(root->left, data);
    else if (data > root->data)
        root->right = deleteSubtree(root->right, data);
    else {
        if (root->left == nullptr) {
            Node<T>* temp = root->right;
            delete root;
            return temp;
        }
        else if (root->right == nullptr) {
            Node<T>* temp = root->left;
            delete root;
            return temp;
        }

        Node<T>* temp = findMin(root->right);
        root->data = temp->data;
        root->right = deleteSubtree(root->right, temp->data);
    }
    return root;
}

template<typename T>
Node<T>* BTree<T>::getRoot() const
{
    return root;
}

template<typename T>
Node<T>* BTree<T>::findMax(Node<T>* node) const
{
    while (node->right != nullptr)
    {
        node = node->right;
    }
    return node;
}

template<typename T>
Node<T>* BTree<T>::findMin(Node<T>* node) const
{
    while (node->left != nullptr)
    {
        node = node->left;
    }
    return node;
}