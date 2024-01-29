using System;
using System.IO;

namespace class_task_05
{
    class CmdLine
    {
        private string currentDirectory;

        public CmdLine()
        {
            currentDirectory = Directory.GetCurrentDirectory();
        }

        public void ExecuteCommand(string command)
        {
            string[] commandParts = command.Split(' ');
            string action = commandParts[0].ToLower();

            try
            {
                switch (action)
                {
                    case "md":
                        CreateDirectory(commandParts[1]);
                        break;
                    case "rd":
                        DeleteDirectory(commandParts[1]);
                        break;
                    case "cd":
                        ChangeDirectory(commandParts[1]);
                        break;
                    case "dir":
                    case "ls":
                        ListDirectory();
                        break;
                    case "create":
                        CreateFile(commandParts[1]);
                        break;
                    case "type":
                        ViewFileContent(commandParts[1]);
                        break;
                    case "copy":
                        CopyFile(commandParts[1], commandParts[2]);
                        break;
                    case "del":
                        DeleteFile(commandParts[1]);
                        break;
                    case "append":
                        AppendToFile(commandParts[1]);
                        break;
                    case "help":
                        ShowHelp();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void CreateDirectory(string directoryName)
        {
            Directory.CreateDirectory(Path.Combine(currentDirectory, directoryName));
        }

        private void DeleteDirectory(string directoryName)
        {
            Directory.Delete(Path.Combine(currentDirectory, directoryName), true);
        }

        private void ChangeDirectory(string directoryName)
        {
            currentDirectory = Path.Combine(currentDirectory, directoryName);
            Directory.SetCurrentDirectory(currentDirectory);
        }

        private void ListDirectory()
        {
            string[] directories = Directory.GetDirectories(currentDirectory);
            string[] files = Directory.GetFiles(currentDirectory);

         

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Directories:");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var dir in directories)
            {
               
                Console.WriteLine(Path.GetFileName(dir));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Files:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }

            Console.ResetColor(); 
        }

        private void CreateFile(string fileName)
        {
            using (StreamWriter writer = File.CreateText(Path.Combine(currentDirectory, fileName)))
            {
                Console.WriteLine("Enter text to write to the file (press Ctrl+Z to finish):");
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private void ViewFileContent(string fileName)
        {
            string filePath = Path.Combine(currentDirectory, fileName);
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
        }

        private void CopyFile(string sourceFileName, string destFileName)
        {
            string sourceFilePath = Path.Combine(currentDirectory, sourceFileName);
            string destFilePath = Path.Combine(currentDirectory, destFileName);
            File.Copy(sourceFilePath, destFilePath, true);
        }

        private void DeleteFile(string fileName)
        {
            File.Delete(Path.Combine(currentDirectory, fileName));
        }

        private void AppendToFile(string fileName)
        {
            string filePath = Path.Combine(currentDirectory, fileName);
            if (File.Exists(filePath))
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    Console.WriteLine("Enter text to append to the file (press Ctrl+Z to finish):");
                    string line;
                    while ((line = Console.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("md <directory_name>   - Create a directory");
            Console.WriteLine("rd <directory_name>   - Delete a directory");
            Console.WriteLine("cd <directory_name>   - Change current directory");
            Console.WriteLine("dir                   - List files and directories in current directory");
            Console.WriteLine("ls                    - Alias for 'dir'");
            Console.WriteLine("create <file_name>    - Create a text file and write text to it");
            Console.WriteLine("type <file_name>      - View content of a text file");
            Console.WriteLine("copy <source> <dest>  - Copy a file");
            Console.WriteLine("del <file_name>       - Delete a file");
            Console.WriteLine("append <file_name>    - Append text to a file");
            Console.WriteLine("help                  - Show this help message");
        }
    }
}
