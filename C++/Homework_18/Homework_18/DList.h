#pragma once
#include <iostream>

template<typename T>
struct Node
{
    T data;
    Node* next, * prev;
    Node(const T& data = T(), Node* prev = nullptr, Node* next = nullptr)
        : data(data), next(next), prev(prev) {}
};

template<typename T>
class DList
{
public:
   
    DList() : head(nullptr), tail(nullptr), size(0) {}

    DList(const DList<T>& other)
    {
        clone(this, other);
    }

    DList<T>& operator =(const DList<T>& other)
    {
        if (this != &other)
        {
            clear();
            clone(this, other);
        }
        return *this;
    }

    void addHead(const T& data);
    void addTail(const T& data);
    void removeHead();
    void removeTail();
    void print() const;
    void printR() const;
    bool isEmpty() const;
    void removeData(const T& data);
    void clear();
    void reverse();

    void insertAfter(const T& data, const T& newData);
    int findAndReplace(const T& data, const T& newData);
    DList<T> concatenate(const DList<T>& other) const;
    DList<T> operator+(const DList<T>& other) const;
    DList<T>& operator+=(const DList<T>& other);
    DList<T> intersection(const DList<T>& other) const;

private:
    Node<T>* findData(const T& data) const;
    void clone(DList<T>* dest, const DList<T>& source);

    Node<T>* head;
    Node<T>* tail;
    size_t size;
};

template<typename T>
void DList<T>::addHead(const T& data)
{
    Node<T>* tmp = new Node<T>(data, nullptr, head);
    if (isEmpty()) {
        tail = tmp;
    }
    else {
        head->prev = tmp;
    }
    head = tmp;
    ++size;
}

template<typename T>
void DList<T>::addTail(const T& data)
{
    Node<T>* tmp = new Node<T>(data, tail, nullptr);
    if (isEmpty()) {
        head = tmp;
    }
    else {
        tail->next = tmp;
    }
    tail = tmp;
    ++size;
}

template<typename T>
void DList<T>::removeHead()
{
    if (isEmpty()) {
        return;
    }
    auto tmp = head;
    head = tmp->next;
    if (isEmpty()) {
        tail = nullptr;
    }
    else {
        head->prev = nullptr;
    }
    delete tmp;
    --size;
}

template<typename T>
void DList<T>::removeTail()
{
    if (isEmpty()) {
        return;
    }
    auto tmp = tail;
    tail = tmp->prev;
    if (isEmpty()) {
        head = nullptr;
    }
    else {
        tail->next = nullptr;
    }
    delete tmp;
    --size;
}

template<typename T>
void DList<T>::print() const
{
    auto tmp = head;
    while (tmp != nullptr) {
        std::cout << tmp->data << "\t";
        tmp = tmp->next;
    }
    std::cout << std::endl;
}

template<typename T>
void DList<T>::printR() const
{
    auto tmp = tail;
    while (tmp != nullptr) {
        std::cout << tmp->data << "\t";
        tmp = tmp->prev;
    }
    std::cout << std::endl;
}

template<typename T>
bool DList<T>::isEmpty() const
{
    return head == nullptr;
}

template<typename T>
void DList<T>::removeData(const T& data)
{
    auto find = findData(data);
    if (find == nullptr) {
        return;
    }
    if (find == head) {
        removeHead();
        return;
    }
    if (find == tail) {
        removeTail();
        return;
    }
    find->prev->next = find->next;
    find->next->prev = find->prev;
    delete find;
    --size;
}

template<typename T>
void DList<T>::clear()
{
    while (!isEmpty()) {
        removeHead();
    }
}

template<typename T>
void DList<T>::reverse()
{
    Node<T>* tmp = nullptr;
    tmp = head;
    head = tail;
    tail = tmp;
    Node<T>* current = tail;
    while (current != nullptr) {
        tmp = current->prev;
        current->prev = current->next;
        current->next = tmp;
        current = current->prev;
    }
}

template<typename T>
Node<T>* DList<T>::findData(const T& data) const
{
    auto tmp = head;
    while (tmp != nullptr && tmp->data != data) {
        tmp = tmp->next;
    }
    return tmp;
}

template <typename T>
void DList<T>::clone(DList<T>* dest, const DList<T>& source)
{
    Node<T>* tmp_ = source.head;
    while (tmp_ != nullptr) {
        dest->addTail(tmp_->data);
        tmp_ = tmp_->next;
    }
}

template<typename T>
void DList<T>::insertAfter(const T& data, const T& newData)
{
    Node<T>* find = findData(data);
    if (find != nullptr) {
        Node<T>* newNode = new Node<T>(newData, find, find->next);
        if (find->next != nullptr) {
            find->next->prev = newNode;
        }
        find->next = newNode;
        ++size;
    }
}

template<typename T>
int DList<T>::findAndReplace(const T& data, const T& newData)
{
    int count = 0;
    Node<T>* current = head;
    while (current != nullptr) {
        if (current->data == data) {
            current->data = newData;
            ++count;
        }
        current = current->next;
    }
    return count;
}

template<typename T>
DList<T> DList<T>::concatenate(const DList<T>& other) const
{
    DList<T> result = *this;
    Node<T>* otherCurrent = other.head;
    while (otherCurrent != nullptr) {
        result.addTail(otherCurrent->data);
        otherCurrent = otherCurrent->next;
    }
    return result;
}

template<typename T>
DList<T> DList<T>::operator+(const DList<T>& other) const
{
    DList<T> result = *this;
    Node<T>* otherCurrent = other.head;
    while (otherCurrent != nullptr) {
        result.addTail(otherCurrent->data);
        otherCurrent = otherCurrent->next;
    }
    return result;
}

template<typename T>
DList<T>& DList<T>::operator+=(const DList<T>& other)
{
    Node<T>* otherCurrent = other.head;
    while (otherCurrent != nullptr) {
        addTail(otherCurrent->data);
        otherCurrent = otherCurrent->next;
    }
    return *this;
}

template<typename T>
DList<T> DList<T>::intersection(const DList<T>& other) const
{
    DList<T> result;
    Node<T>* current = head;
    while (current != nullptr) {
        if (other.findData(current->data) != nullptr && result.findData(current->data) == nullptr) {
            result.addTail(current->data);
        }
        current = current->next;
    }
    return result;
}
