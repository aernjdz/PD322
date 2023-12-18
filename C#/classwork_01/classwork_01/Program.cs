using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace classwork_01
{
    internal class Program
    {
        static void PrintArray(int[,] arr, string prompt = "")
        {
            Console.WriteLine(prompt);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],7}");
                }
                Console.WriteLine();
            }
        }

        static void ReverseRows(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                   
                    int temp = arr[i, j];
                    arr[i, j] = arr[rows - 1 - i, j];
                    arr[rows - 1 - i, j] = temp;
                }
            }
        }

        static void Main()
        {
            int[,] myArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            PrintArray(myArray, "Original Array:");

         
            ReverseRows(myArray);

            PrintArray(myArray, "Reversed Rows Array:");

            Console.ReadLine();
        }
    }
}