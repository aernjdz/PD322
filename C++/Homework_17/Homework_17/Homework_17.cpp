#include <iostream>
#include "Queue.h"
using namespace std;

int main() {
   
    PrQueue<int> priorityQueue(5, 5);

    priorityQueue.InsertWithPriority(Node<int>(10, 3));
    priorityQueue.InsertWithPriority(Node<int>(5, 1));
    priorityQueue.InsertWithPriority(Node<int>(7, 2));
    priorityQueue.InsertWithPriority(Node<int>(8, 2));
    priorityQueue.InsertWithPriority(Node<int>(2, 2));

    cout << "Peek: Value = " << priorityQueue.Peek().data
        << ", Priority = " << priorityQueue.Peek().pr << endl;

   
    cout << "Queue elements:" << endl;
    priorityQueue.Show(); 
    cout << "IsEmpty :: " << (priorityQueue.IsEmpty() ? "Yes" : "No") << endl;
    cout << "IsFull :: " << (priorityQueue.IsFull() ? "Yes" : "No") << endl;
    priorityQueue.PullHighestPriorityElement();

    cout << "Queue elements after pulling highest priority element:" << endl;
    priorityQueue.Show();

    return 0;
}
