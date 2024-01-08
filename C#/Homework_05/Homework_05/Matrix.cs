using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_05
{
    class Matrix
    {

        private int[,] data;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Matrix (int rows,int colums)
        {
            Rows = rows;
            Columns = colums;
            data = new int[rows, colums];
        }

        public int this[int row, int column]
        {
            get { return data[row, column]; }
            set { data[row, column] = value; }
        }


        public void InputData()
        {
            Console.WriteLine($"Enter the elements for a {Rows}x{Columns} matrix:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"Element at position [{i},{j}]: ");
                    this[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Matrix ({Rows}x{Columns}):");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{this[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public int FindMax()
        {
            return Enumerable.Range(0, Rows).SelectMany(i => Enumerable.Range(0, Columns).Select(j => this[i, j])).Max();
        }
        public int FindMin()
        {
            return Enumerable.Range(0, Rows).SelectMany(i => Enumerable.Range(0, Columns).Select(j => this[i, j])).Min();
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new ArgumentException("Matrices must have the same dimensions for subtraction.");

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    result[i, j] = m1[i, j] - m2[i, j];
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");

            Matrix result = new Matrix(m1.Rows, m2.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m2.Columns; j++)
                    for (int k = 0; k < m1.Columns; k++)
                        result[i, j] += m1[i, k] * m2[k, j];
            return result;
        }

        public static Matrix operator *(Matrix m, int scalar)
        {
            Matrix result = new Matrix(m.Rows, m.Columns);
            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Columns; j++)
                    result[i, j] = m[i, j] * scalar;
            return result;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (ReferenceEquals(m1, m2))
                return true;

            if (m1 is null || m2 is null)
                return false;

            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                return false;

            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    if (m1[i, j] != m2[i, j])
                        return false;

            return true;
        }

        public static bool operator !=(Matrix m1, Matrix m2) => !(m1 == m2);

        public override bool Equals(object obj) => obj is Matrix matrix && this == matrix;

        public override int GetHashCode() => base.GetHashCode();
    }
}
