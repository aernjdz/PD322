using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_03
{
    class Program
    {
        public static void FillRandom(int[][] matrix, int min = 0, int max = 10)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = rand.Next(min, max);
                }
            }
        }

        static void PrintArray(int[][] matrix, string prompt = "")
        {
            Console.WriteLine(prompt);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ShiftRowsUp(int[][] matrix, int ShiftUp)
        {
            for (int k = 0; k < ShiftUp; k++)
            {
                int[] tmp = matrix[0];
                for (int i = 0; i < matrix.Length - 1; i++)
                {
                    matrix[i] = matrix[i + 1];
                }
                matrix[matrix.Length - 1] = tmp;
            }
        }
        public static void ShiftRowsDown(int[][] matrix, int shiftDown)
        {
            for (int k = 0; k < shiftDown; k++)
            {
                int[] temp = matrix[matrix.Length - 1];
                for (int i = matrix.Length - 1; i > 0; i--)
                {
                    matrix[i] = matrix[i - 1];
                }
                matrix[0] = temp;
            }
        }
        public static void AddRow(ref int[][] matrix, int[] newRow)
        {
            Array.Resize(ref matrix, matrix.Length + 1);
            matrix[matrix.Length - 1] = newRow;
        }
        public static void RemoveRowAtIndex(ref int[][] matrix, int index)
        {
            if (index >= 0 && index < matrix.Length)
            {
                matrix = matrix.Where((row, i) => i != index).ToArray();
            }
        }

        public static void FindMinMax(int[][] matrix, out int min, out int max)
        {
            min = matrix.SelectMany(row => row).Min();
            max = matrix.SelectMany(row => row).Max();
        }


        public static int[][][] Create3DArray(int x, int y, int z, int min = 0, int max = 10)
        {
            return Enumerable.Range(0, x).Select(i => Enumerable.Range(0, y).Select(j => Enumerable.Range(0, z).Select(_ => new Random().Next(min, max)).ToArray()).ToArray()).ToArray();
        }

        public static int[] CalculateSumOfSubarrays(int[][][] array3D)
        {
            return array3D.Select(matrix => matrix.SelectMany(row => row).Sum()).ToArray();
        }
        public static void Print3D(int[][][] array3D)
        {
            for (int i = 0; i < array3D.Length; i++)
            {
                Console.WriteLine($"Matrix {i + 1}:");
                for (int j = 0; j < array3D[i].Length; j++)
                {
                    Console.WriteLine(string.Join(" ", array3D[i][j]));
                }
                Console.WriteLine();
            }
        }


        //-------------------------------------------------------------
        static void ProcessString(ref string input, char targetChar)
        {
            int index = input.LastIndexOf(targetChar);
            while (index != -1)
            {
                input = input.Remove(index, 1).Insert(index, char.ToUpper(targetChar).ToString());
                index = input.LastIndexOf(targetChar, index - 1);
            }

            if (index != -1)
            {
                input = input.Substring(0, index + 1);
            }
        }

        static void RemoveChars(ref string input, params char[] charsToRemove)
        {
            foreach (char charToRemove in charsToRemove)
            {
                input = input.Replace(charToRemove.ToString(), string.Empty);
            }
        }

        static void PrintLetterHistogram(string text)
        {
            var letters = text.Where(char.IsLetter).Select(char.ToLower);

            Console.WriteLine("Letter Histogram:");
            foreach (char letter in "abcdefghijklmnopqrstuvwxyz")
            {
                int count = letters.Count(l => l == letter);
                Console.WriteLine($"{letter} [{count}] {new string('*', count)}");
            }
        }

        static Dictionary<string, int> CountKeywords(string code, string[] keywords)
        {
            string[] words = code.Split(new char[] { ' ', '\n', '\r', '\t', '(', ')', '{', '}', ';', '.' }, StringSplitOptions.RemoveEmptyEntries);

            var keywordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (keywords.Contains(word))
                {
                    if (keywordCounts.ContainsKey(word))
                    {
                        keywordCounts[word]++;
                    }
                    else
                    {
                        keywordCounts[word] = 1;
                    }
                }
            }

            return keywordCounts;
        }

        static void PrintKeywordFrequencies(Dictionary<string, int> keywordCounts)
        {
            var sortedKeywords = keywordCounts.OrderByDescending(pair => pair.Value);

            foreach (var kvp in sortedKeywords)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        static void Main(string[] args)
        {
            int rows = 3;
            int cols = 4;

            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new int[cols];
            }

            FillRandom(jaggedArray);
            Console.WriteLine("Original Matrix:");
            PrintArray(jaggedArray);

            ShiftRowsUp(jaggedArray, 2);
            Console.WriteLine("\nMatrix after shifting rows up by 2:");
            PrintArray(jaggedArray);

            int[] newRow = { 11, 22, 33, 44 };
            AddRow(ref jaggedArray, newRow);
            Console.WriteLine("\nMatrix after adding a new row:");
            PrintArray(jaggedArray);

            RemoveRowAtIndex(ref jaggedArray, 1);
            Console.WriteLine("\nMatrix after removing row at index 1:");
            PrintArray(jaggedArray);

            int min, max;
            FindMinMax(jaggedArray, out min, out max);
            Console.WriteLine($"\nMin Value: {min}");
            Console.WriteLine($"Max Value: {max}");

          
            int x = 6, y = 3, z = 4;
            int[][][] array3D = Create3DArray(x, y, z);
            Console.WriteLine("\n3D Array:");
            Print3D(array3D);

          
            var sums = CalculateSumOfSubarrays(array3D);
            Console.WriteLine("\nSum of Elements in Each Subarray:");
            for (int i = 0; i < sums.Length; i++)
            {
                Console.WriteLine($"Matrix {i + 1}: {sums[i]}");
            }

            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.Write("Enter a character: ");
            char inputChar = Console.ReadKey().KeyChar;
            ProcessString(ref inputString, inputChar);
            Console.WriteLine("\nResult: " + inputString);

            Console.Write("Enter a string: ");
            string inputString_ = Console.ReadLine();

            Console.Write("Enter characters to remove (separated by spaces): ");
            char[] charsToRemove = Console.ReadLine().ToCharArray();

            RemoveChars(ref inputString_, charsToRemove);
            Console.WriteLine("Result: " + inputString_);

            string text = "I don’t know whether to delete this or rewrite it";
            Console.WriteLine(text);
            PrintLetterHistogram(text);

            string csharpCode = @"
            using System;
            
            class Program
            {
                static void Main()
                {
                    Console.WriteLine(""Hello, World!"");
                }
            }
        ";

            string[] keywords = { "using", "class", "static", "void", "Main", "Console", "WriteLine" };

            Dictionary<string, int> keywordCounts = CountKeywords(csharpCode, keywords);

            Console.WriteLine("Keyword Frequencies:");
            PrintKeywordFrequencies(keywordCounts);
        }
    }
}
