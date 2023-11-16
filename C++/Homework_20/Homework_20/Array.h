#pragma once
#include<iostream>
using namespace std;

template <typename T>
class Array {
private:
    template <typename U>
    class Node {
    public:
        U data;
        Node* next;
        Node* prev;

        Node(const U& value, Node* prev = nullptr, Node* next = nullptr)
            : data(value), prev(prev), next(next) {}
    };

    Node<T>* head;
    Node<T>* tail;
    size_t size;
    size_t capacity;
    size_t grow;

public:
    Array() : head(nullptr), tail(nullptr), size(0), capacity(0), grow(1) {}

    Array(const Array& other) : head(nullptr), tail(nullptr), size(0), capacity(0), grow(other.grow) {
        Node<T>* current = other.head;
        while (current != nullptr) {
            Add(current->data);
            current = current->next;
        }
    }

    ~Array() {
        RemoveAll();
    }

    size_t GetSize() const {
        return size;
    }

    void SetSize(int newSize, int newGrow = 1) {
        if (newSize < 0 || newGrow < 0) {
            cout << "Invalid size or growth value." << endl;
            return;
        }

        grow = newGrow;
        if (newSize > capacity) {
            Reserve(newSize);
        }
        size = newSize;
    }

    size_t GetUpperBound() const {
        return size > 0 ? size - 1 : 0;
    }

    bool IsEmpty() const {
        return size == 0;
    }

    void FreeExtra() {
        if (size < capacity) {
            Node<T>* current = tail;
            while (size < capacity) {
                Node<T>* prev = current->prev;
                delete current;
                current = prev;
                --capacity;
            }
            if (size == 0) {
                head = tail = nullptr;
            }
            else {
                tail->next = nullptr;
            }
        }
    }

    void RemoveAll() {
        Node<T>* current = head;
        while (current != nullptr) {
            Node<T>* next = current->next;
            delete current;
            current = next;
        }
        head = tail = nullptr;
        size = 0;
        capacity = 0;
    }

    T GetAt(size_t index) const {
        if (index >= size) {
            cout << "Index out of bounds." << endl;
            return T();
        }

        Node<T>* current = head;
        for (size_t i = 0; i < index; ++i) {
            current = current->next;
        }
        return current->data;
    }

    void SetAt(size_t index, const T& value) {
        if (index >= size) {
            cout << "Index out of bounds." << endl;
            return;
        }

        Node<T>* current = head;
        for (size_t i = 0; i < index; ++i) {
            current = current->next;
        }
        current->data = value;
    }

    T operator[](size_t index) const {
        return GetAt(index);
    }

    T& operator[](size_t index) {
        if (index >= size) {
            cout << "Index out of bounds." << endl;
            static T dummy;  
            return dummy;
        }

        Node<T>* current = head;
        for (size_t i = 0; i < index; ++i) {
            current = current->next;
        }
        return current->data;
    }

    void Add(const T& value) {
        if (size == capacity) {
            Reserve(size + grow);
        }

        Node<T>* newNode = new Node<T>(value, tail, nullptr);
        if (tail == nullptr) {
            head = tail = newNode;
        }
        else {
            tail->next = newNode;
            tail = newNode;
        }
        ++size;
    }

    void Append(const Array& other) {
        Node<T>* current = other.head;
        while (current != nullptr) {
            Add(current->data);
            current = current->next;
        }
    }

    Array& operator=(const Array& other) {
        if (this != &other) {
            RemoveAll();
            grow = other.grow;
            Node<T>* current = other.head;
            while (current != nullptr) {
                Add(current->data);
                current = current->next;
            }
        }
        return *this;
    }

    T* GetData() const {
        T* data = new T[size];
        Node<T>* current = head;
        for (size_t i = 0; i < size; ++i) {
            data[i] = current->data;
            current = current->next;
        }
        return data;
    }

    void InsertAt(size_t index, const T& value) {
        if (index > size) {
            cout << "Invalid index for insertion." << endl;
            return;
        }

        if (index == size) {
            Add(value);
            return;
        }

        Node<T>* current = head;
        for (size_t i = 0; i < index; ++i) {
            current = current->next;
        }

        Node<T>* newNode = new Node<T>(value, current->prev, current);
        if (current->prev != nullptr) {
            current->prev->next = newNode;
        }
        else {
            head = newNode;
        }
        current->prev = newNode;
        ++size;
    }

    void RemoveAt(size_t index) {
        if (index >= size) {
            cout << "Index out of bounds for removal." << endl;
            return;
        }

        Node<T>* current = head;
        for (size_t i = 0; i < index; ++i) {
            current = current->next;
        }

        if (current->prev != nullptr) {
            current->prev->next = current->next;
        }
        else {
            head = current->next;
        }

        if (current->next != nullptr) {
            current->next->prev = current->prev;
        }
        else {
            tail = current->prev;
        }

        delete current;
        --size;
    }

    void Print() const {
        Node<T>* current = head;
        while (current != nullptr) {
            cout << current->data << " ";
            current = current->next;
        }
        cout << endl;
    }

private:
    void Reserve(size_t newCapacity) {
        if (newCapacity <= capacity) {
            return;
        }

        Node<T>* current = tail;
        while (capacity < newCapacity) {
            Node<T>* newNode = new Node<T>(T(), nullptr, current);
            if (current != nullptr) {
                current->prev = newNode;
            }
            else {
                head = newNode;
            }
            current = newNode;
            ++capacity;
        }
    }
};
