#include <iostream>
#include "DList.h"
using namespace std;

int main()
{
    BTree<int> tree;

    tree.add(35);
    tree.add(12);
    tree.add(44);
    tree.add(10);
    tree.add(25);
    tree.add(35);
    tree.add(15);

    tree.print();

    cout << "Min :: " << tree.min() << endl;
    cout << "Max :: " << tree.max() << endl;


    tree.deleteElement(tree.min());
    tree.deleteElement(tree.max());

    cout << "After deleting min and max elements:" << endl;
    tree.print();

    cout << "Elements in the range [10, 25]:" << endl;
    tree.printRange(10, 25);

    cout << endl << "Clear:" << endl;
    tree.clear();
    cout <<"IsEmpty :: " << ((tree.isEmpty()) ? "Yes" : "No") << endl;

   
}