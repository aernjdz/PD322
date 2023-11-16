#pragma once
#include <iostream>

template <typename T>
struct Node
{
    T data;
    Node* next;
    Node(const T& data, Node* next = nullptr)
        : data(data), next(next) {}
};

template <typename T>
class FList
{
public:
    FList() = default;
    FList(const FList& other);
    FList& operator=(const FList& other);
    ~FList();

    void addHead(const T& data);
    void print() const;
    bool isEmpty() const;
    void removeHead();
    size_t getSize() const;
    void clear();
    void addTail(const T& data);
    FList<T>& operator+=(const FList<T>& other);
    FList<T> operator-(const FList<T>& other) const;

private:
    Node<T>* head = nullptr;
    Node<T>* tail = nullptr;
    size_t size = 0;
};

template<typename T>
FList<T>::FList(const FList<T>& other)
{
    Node<T>* current = other.head;
    while (current != nullptr)
    {
        addTail(current->data);
        current = current->next;
    }
}

template<typename T>
FList<T>& FList<T>::operator=(const FList<T>& other)
{
    if (this == &other)
    {
        return *this;
    }

    clear();
    Node<T>* current = other.head;
    while (current != nullptr)
    {
        addTail(current->data);
        current = current->next;
    }
    return *this;
}

template<typename T>
FList<T>::~FList()
{
    clear();
}

template<typename T>
void FList<T>::addHead(const T& data)
{
    Node<T>* tmp = new Node<T>(data, head);
    if (isEmpty()) {
        tail = tmp;
    }
    head = tmp;
    ++size;
}

template<typename T>
void FList<T>::print() const
{
    auto tmp = head;
    while (tmp != nullptr)
    {
        std::cout << tmp->data << "\t";
        tmp = tmp->next;
    }
    std::cout << std::endl;
}

template<typename T>
bool FList<T>::isEmpty() const
{
    return head == nullptr;
}

template<typename T>
void FList<T>::removeHead()
{
    if (isEmpty()) {
        std::cout << "Forward List is empty" << std::endl;
        return;
    }
    auto* tmp = head;
    head = head->next;
    if (isEmpty()) {
        tail = nullptr;
    }
    delete tmp;
    --size;
}

template<typename T>
size_t FList<T>::getSize() const
{
    return size;
}

template<typename T>
void FList<T>::clear()
{
    while (!isEmpty()) {
        removeHead();
    }
}

template<typename T>
void FList<T>::addTail(const T& data)
{
    Node<T>* newNode = new Node<T>(data);
    if (isEmpty()) {
        head = tail = newNode;
    }
    else {
        tail->next = newNode;
        tail = newNode;
    }
    ++size;
}

template<typename T>
FList<T>& FList<T>::operator+=(const FList<T>& other)
{
    Node<T>* current = other.head;

    while (current != nullptr) {
        addTail(current->data);
        current = current->next;
    }

    return *this;
}

template<typename T>
FList<T> FList<T>::operator-(const FList<T>& other) const
{
    FList<T> result;
    Node<T>* current1 = head;

    while (current1 != nullptr) {
        bool isCommon = false;
        Node<T>* current2 = other.head;

        while (current2 != nullptr) {
            if (current1->data == current2->data) {
                isCommon = true;
                break;
            }
            current2 = current2->next;
        }

        if (!isCommon) {
            result.addTail(current1->data);
        }

        current1 = current1->next;
    }

    return result;
}
