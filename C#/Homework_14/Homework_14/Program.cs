using System;
using System.IO;

namespace Homework_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to display the file structure:");
            string path = Console.ReadLine();

            try
            {
                if (Directory.Exists(path))
                {
                    DisplayDirectoryContents(path);
                }
                else
                {
                    Console.WriteLine("Folder does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void DisplayDirectoryContents(string path)
        {
            Console.WriteLine($"Contents of the folder {path}:");
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                Console.WriteLine($"File: {Path.GetFileName(file)}");
            }

            foreach (string directory in directories)
            {
                Console.WriteLine($"Folder: {Path.GetFileName(directory)}");
            }

            foreach (string directory in directories)
            {
                DisplayDirectoryContents(directory);
            }
        }
    }
}
