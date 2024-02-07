using System;
using System.IO;
using System.Text;
namespace Homework_15
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Enter the path to display the file structure:");
            string path = Console.ReadLine();

            try
            {
                if (Directory.Exists(path))
                {
                    DisplayDirectoryContents(path, "");
                }
                else
                {
                    Console.WriteLine("The specified path does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void DisplayDirectoryContents(string path, string indent)
        {
            Console.WriteLine($"{indent}+ {Path.GetFileName(path)}");
            indent += "  ";

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine($"{indent}- {Path.GetFileName(file)}");
            }

            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                DisplayDirectoryContents(directory, indent);
            }
        }
    }
}
