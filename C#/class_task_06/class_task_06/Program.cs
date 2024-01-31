using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace class_task_06
{
    class Program
    {
        static bool ValidateEmail(string email) => Regex.IsMatch(email, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$");
        static bool ValidatePassword(string password) => password.Length >= 6 && Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]") && Regex.IsMatch(password, "[-_]");
        static string FormatPhoneNumber(string number) => $"+38 (0{number.Substring(0, 2)}) {number.Substring(2, 3)}-{number.Substring(5, 2)}-{number.Substring(7, 2)}";

        static void Main(string[] args)
        {
            try
            {
               
                string filePath1 = "input.txt";
                Console.WriteLine("Task 1: ");

                using (StreamReader sr = new StreamReader(filePath1))
                {
                    string content = sr.ReadToEnd();
                    MatchCollection matches = Regex.Matches(content, @"[\d]+[.,][\d]+");

                    Console.WriteLine("Found fractional numbers:");
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match.Value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            try
            {
                
                string inputFilePath = "input_text.txt";
                string outputFilePath = "res.txt";
                string[] badWords = File.ReadAllLines("bad-words.txt");

                Console.WriteLine("\nTask 2: ");

                string content;
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    content = sr.ReadToEnd();
                }

                foreach (string word in badWords)
                {
                    content = Regex.Replace(content, @"\b" + Regex.Escape(word) + @"\b", new string('*', word.Length), RegexOptions.IgnoreCase);
                }

                using (StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    sw.Write(content);
                }

                Console.WriteLine("Profanity has been replaced in the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            try
            {
                
                string filePath2 = "input2.txt";
                Console.WriteLine("\nTask 3: ");

                List<int> numbers = new List<int>();

                using (StreamReader sr = new StreamReader(filePath2))
                {
                    string content = sr.ReadToEnd();
                    MatchCollection matches = Regex.Matches(content, @"\d+");

                    Console.WriteLine("Found numbers:");
                    foreach (Match match in matches)
                    {
                        numbers.Add(int.Parse(match.Value));
                        Console.WriteLine(match.Value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

       
            Console.WriteLine("\nTask 4: ");

            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            if (ValidateEmail(email) && ValidatePassword(password))
            {
                Console.WriteLine("Email and password are valid.");
            }
            else
            {
                Console.WriteLine("Email or password do not meet the requirements.");
            }

            try
            {
                
                string filePath3 = "input3.txt";
                Console.WriteLine("\nTask 5: ");

                using (StreamReader sr = new StreamReader(filePath3))
                {
                    string content = sr.ReadToEnd();
                    MatchCollection matches = Regex.Matches(content, @"\b\d{4}/\d{2}/\d{2} \d{2}:\d{2}(:\d{2})?\b");

                    Console.WriteLine("Found dates:");
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match.Value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            try
            {
            
                string filePath4 = "input4.txt";
                Console.WriteLine("\nTask 6: ");

                string content = File.ReadAllText(filePath4);
                MatchCollection matches = Regex.Matches(content, @"\b\d{10}\b");

                foreach (Match match in matches)
                {
                    string phoneNumber = FormatPhoneNumber(match.Value);
                    content = content.Replace(match.Value, phoneNumber);
                }

                Console.WriteLine("Modified content:");
                Console.WriteLine(content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
