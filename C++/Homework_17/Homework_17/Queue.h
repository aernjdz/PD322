#pragma once
#include<iostream>
using namespace std;
template<typename T>
struct Node
{
    int pr;
    T data;
    Node(const T& data = T(), const int& pr = 0) :
        data{ data }, pr{ pr }
    {

    }
};

template <typename T = int>
class PrQueue
{
public:
    PrQueue(const size_t& size, const size_t& step) :
        capacity{ size }, step{ step }, back_{ -1 }
    {
        queue = new Node<T>[capacity];
    }
    void empty(); // очищення стеку
    void push(const Node<T>& data); // додати нове значення в стек
    void pop(); // видалити значення
    size_t getCapacity() const;
    size_t size() const;
    const T& top();
    void print() const;
    bool IsEmpty() const;  // Додавання IsEmpty
    bool IsFull() const;   // Додавання IsFull
    void InsertWithPriority(const Node<T>& data);  // Додавання InsertWithPriority
    void PullHighestPriorityElement();  // Додавання PullHighestPriorityElement
    Node<T> Peek() const;  // Додавання Peek
    void Show() const;  // Додавання Show
    ~PrQueue()
    {
        delete[] queue;
    }
private:
    Node<T>* queue = nullptr;
    bool full() const;
    void resize();
    bool isEmpty() const;
    int getPos(const Node<T> data) const;
    size_t capacity;
    size_t step;
    int back_;
};

template<typename T>
inline void PrQueue<T>::empty()
{
    back_ = -1;
}

template<typename T>
inline void PrQueue<T>::push(const Node<T>& data)
{
    back_++;
    int index = getPos(data);
    if (full()) {
        resize();
    }
    if (isEmpty() || index == -1) {
        queue[back_] = data;
        return;
    }
    for (int i = back_; i > index; i--)
    {
        queue[i] = queue[i - 1];
    }
    queue[index] = data;
}

template<typename T>
inline void PrQueue<T>::pop()
{
    if (!isEmpty()) {
        for (int i = 0; i < back_; i++) {
            queue[i] = queue[i + 1];
        }
        back_--;
    }
}

template<typename T>
inline size_t PrQueue<T>::getCapacity() const
{
    return this->capacity;
}

template<typename T>
inline size_t PrQueue<T>::size() const
{
    return back_ + 1;
}

template<typename T>
inline const T& PrQueue<T>::top()
{
    if (back_ == -1) {
        return T();
    }
    return queue[0].data;
}

template<typename T>
inline void PrQueue<T>::print() const
{
    if (isEmpty()) {
        cout << "Queue is empty" << endl;
        return;
    }
    for (size_t i = 0; i <= back_; i++)
    {
        cout << queue[i].data << "(" << queue[i].pr << ")" << "\t";
    }
    cout << endl;
}

template<typename T>
inline bool PrQueue<T>::full() const
{   
    
    return capacity == back_ + 1;
}

template<typename T>
inline void PrQueue<T>::resize()
{
    capacity += step;
    step *= 2;
    Node<T>* tmp = new Node<T>[capacity];
    for (size_t i = 0; i <= back_; i++)
    {
        tmp[i] = queue[i];
    }
    delete[] queue;
    queue = tmp;
}

template<typename T>
inline bool PrQueue<T>::isEmpty() const
{
    return back_ == -1;
}

template<typename T>
inline int PrQueue<T>::getPos(const Node<T> data) const
{
    for (size_t i = 0; i <= back_; i++)
    {
        if (data.pr > queue[i].pr) {
            return i;
        }
    }
    return -1;
}



template<typename T>
inline bool PrQueue<T>::IsFull() const
{
    return full();
}

template<typename T>
inline bool PrQueue<T>::IsEmpty() const
{
    return isEmpty();
}

template<typename T>
inline void PrQueue<T>::InsertWithPriority(const Node<T>& data)
{
    push(data);
}

template<typename T>
inline void PrQueue<T>::PullHighestPriorityElement()
{
    pop();
}

template<typename T>
inline Node<T> PrQueue<T>::Peek() const
{
    if (!isEmpty()) {
        return queue[0];
    }
    else {
        return Node<T>();
    }
}

template<typename T>
inline void PrQueue<T>::Show() const
{
    print();
}
