using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            int[] arr = CreateArr(size);

            Console.WriteLine("Original array:");
            PrintArray(arr);

            FillRandArr(arr, 0, 100);
            Console.WriteLine("\nArray after filling with random numbers:");
            PrintArray(arr);

            SwapPairs(arr);
            Console.WriteLine("\nArray after swapping pairs:");
            PrintArray(arr);

            int firstPositive = GetFirstPositive(arr);
            Console.WriteLine($"\nFirst positive element in the array: {firstPositive}");

            int evenCount = CountEvenElements(arr);
            Console.WriteLine($"\nNumber of even elements in the array: {evenCount}");

            int indexMultipleOf7 = FindIndexMultipleOf7(arr);
            if (indexMultipleOf7 != -1)
            {
                Console.WriteLine($"\nIndex of the first element multiple of 7: {indexMultipleOf7}");
            }
            else
            {
                Console.WriteLine("\nNo element multiple of 7 found in the array.");
            }

            int[] array = { 10, 2, -4, -50, -7, 8, -1, 3 };

            Console.WriteLine("Original array:");
            PrintArray(array);

            SepNegAndNonNeg(ref array);

            Console.WriteLine("\nArray after rearranging (negative elements, non-negative elements):");
            PrintArray(array);


            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int targetNumber))
            {
                int[] ar = new int[10];
                FillRandArr(ar, 0, 10); 

                Console.WriteLine("Generated array:");
                PrintArray(ar);

                int occurrences = CountOccurrences(ar,targetNumber);

                Console.WriteLine($"\nThe number {targetNumber} occurs {occurrences} times in the array.");
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
        static int[] CreateArr(int size)
            {
                return new int[size];
            }
            static void FillRandArr(int[] arr,int min = 0,int max = 100)
            {
                Random rand = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(min, max + 1);
                }
            }
            static void PrintArray(int[] arr)
            {
                foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
                Console.WriteLine();
            }
            static void SwapPairs(int[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i += 2)
                {
                    Swap(ref arr[i], ref arr[i + 1]);
                }
            }
            static void Swap(ref int a, ref int b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            static int GetFirstPositive(int[] arr)
            {
                int firstPositive = Array.Find(arr, element => element > 0);
                return (firstPositive > 0) ? firstPositive : 0;
            }

            static int CountEvenElements(int[] arr)
            {
                return arr.Count(element => element % 2 == 0);
            }

            static int FindIndexMultipleOf7(int[] arr)
            {
                int index = Array.FindIndex(arr, element => element % 7 == 0);
                return (index == -1) ? -1 : index;
            }
            static void SepNegAndNonNeg(ref int[] arr)
            {
            int[] negativeElements = Array.FindAll(arr, element => element < 0);
            int[] nonNegativeElements = Array.FindAll(arr, element => element >= 0);

            Array.Copy(negativeElements, arr, negativeElements.Length);
            Array.Copy(nonNegativeElements, 0, arr, negativeElements.Length, nonNegativeElements.Length);
            }

            static int CountOccurrences(int[] arr, int target)
            {
                return arr.Count(element => element == target);
            }
    }
}
