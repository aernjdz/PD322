using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of rows for matrix A: ");
            int rowsA = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns for matrix A: ");
            int columnsA = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of rows for matrix B: ");
            int rowsB = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns for matrix B: ");
            int columnsB = int.Parse(Console.ReadLine());

            Matrix matrixA = new Matrix(rowsA, columnsA);
            Matrix matrixB = new Matrix(rowsB, columnsB);

            Console.WriteLine("Enter elements for matrix A:");
            matrixA.InputData();

            Console.WriteLine("\nEnter elements for matrix B:");
            matrixB.InputData();

            Console.WriteLine("\nMatrix A:");
            matrixA.DisplayData();

            Console.WriteLine("\nMatrix B:");
            matrixB.DisplayData();

            try
            {
                Matrix sumMatrix = matrixA + matrixB;
                Console.WriteLine("\nMatrix Sum (A + B):");
                sumMatrix.DisplayData();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            try
            {
                Matrix differenceMatrix = matrixA - matrixB;
                Console.WriteLine("\nMatrix Difference (A - B):");
                differenceMatrix.DisplayData();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            try
            {
                Matrix productMatrix = matrixA * matrixB;
                Console.WriteLine("\nMatrix Product (A * B):");
                productMatrix.DisplayData();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.Write("\nEnter a scalar value for multiplication with matrix A: ");
            int scalar = int.Parse(Console.ReadLine());

            Matrix scalarProductMatrix = matrixA * scalar;
            Console.WriteLine($"\nMatrix Scalar Product (A * {scalar}):");
            scalarProductMatrix.DisplayData();

            Console.WriteLine($"\nMaximum element in matrix A: {matrixA.FindMax()}");
            Console.WriteLine($"Minimum element in matrix A: {matrixA.FindMin()}");

            Console.WriteLine($"\nMaximum element in matrix B: {matrixB.FindMax()}");
            Console.WriteLine($"Minimum element in matrix B: {matrixB.FindMin()}");

            Console.WriteLine($"\nMatrix A == Matrix B: {matrixA == matrixB}");
            Console.WriteLine($"Matrix A != Matrix B: {matrixA != matrixB}");

            Console.WriteLine("\nMatrix A (copy):");
            Matrix matrixACopy = matrixA;
            matrixACopy.DisplayData();

            Console.WriteLine($"\nMatrix A.Equals(Matrix A copy): {matrixA.Equals(matrixACopy)}");
        }
    }
}
