using System;

namespace Homework_11
{
    //Task 1
    public delegate void DrawDelegate(uint height, ConsoleColor color, char symbol);
    //Task 2
    public enum Operation { Plus, Minus, Mult, Div }
   
 
    class Program
    {
        static void Sort<T>(T[] arr, Comparison<T> comp)
        {
            if (arr == null || comp == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (comp(arr[j], arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //Task 1
             DrawDelegate drawDelegate = FigureDrawer.DrawSquare;
             drawDelegate += FigureDrawer.DrawTriangle;


             drawDelegate(5, ConsoleColor.Red, '*');
         


            //Task 2
              Calculator calc = new Calculator();

              calc.SetOperation(Operation.Plus);
              Console.WriteLine("5 + 3 = " + calc.Calculate(5, 3));

              calc.SetOperation(Operation.Minus);
              Console.WriteLine("5 - 3 = " + calc.Calculate(5, 3));

              calc.SetOperation(Operation.Mult);
              Console.WriteLine("5 * 3 = " + calc.Calculate(5, 3));

              calc.SetOperation(Operation.Div);
              Console.WriteLine("5 / 3 = " + calc.Calculate(5, 3));

            //Task3
            string[] stringArray = { "banana", "apple", "orange", "grape", "kiwi" };
            Sort(stringArray, (x, y) => x.Length.CompareTo(y.Length));
            Console.WriteLine("Sorted strings by length:");
            foreach (var str in stringArray)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();

         
            Product[] products = {
            new Product("Laptop", 1200),
            new Product("Smartphone", 800),
            new Product("Tablet", 600),
            new Product("Camera", 500)
        };
            Sort(products, (x, y) => x.Price.CompareTo(y.Price));
            Console.WriteLine("Sorted products by price:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}


