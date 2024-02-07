using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Homework_16
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Task 1*/
             List<int> num = new List<int>();


             for (int i = 0; i <= 100000; i++)
             {
                 string numberString = i.ToString();

                 if (Regex.IsMatch(numberString, @"\b[1-9]\d{3}\b"))
                 {
                     num.Add(i);
                 }
             }
             Console.WriteLine("Four-digit numbers in the range from 0 to 100000:");
             foreach (int number in num)
             {
                 Console.WriteLine(number);
             }

            /*Task 2*/
             string[] wordsToCheck = { "asd123zxc456", "bnm567hjk890", "abc123def456ghi789" };
             foreach (string word in wordsToCheck)
             {
                 if (Regex.IsMatch(word, @"\b(?=\D*\d{3}\D*\d{3}\D*\b)\w+\b"))
                 {
                     Console.WriteLine($"Word '{word}' matches the pattern.");
                 }
                 else
                 {
                     Console.WriteLine($"Word '{word}' does not match the pattern.");
                 }
             }

            /*Task 3*/
            string text = "The WWW protocol is used to access the World Wide Web. PDF documents can be viewed with Adobe Acrobat. RTF files can be opened with most word processors. RTC is the abbreviation for Real-Time Clock. BMP is a common image format.";


            MatchCollection matches = Regex.Matches(text, @"\b[A-Z]{3}\b");

            Console.WriteLine("Found abbreviations:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

            /*Task 4*/
            string[] years = { "1800", "1905", "2000", "2100", "2201" };

            Console.WriteLine("Filtered years:");

            foreach (string year in years)
            {
                if (Regex.IsMatch(year, @"^(19\d{2}|20\d{2})$"))
                {
                    Console.WriteLine(year);
                }
            }

            /*Task 5*/
            List<string> phoneNumbers = new List<string>
            {
            "+38-012-3456789",
            "+38-032-1234567",
            "+38-067-1112233",
            "+38-044-9988776",
            "+38-045-2244668",
            "+38-067-7770023",
            "+38-095-0000123",
            "+38-050-0000234"
            };
          
            Console.WriteLine("Phone numbers matching the specified pattern:");

            foreach (string phoneNumber in phoneNumbers)
            {
                if (Regex.IsMatch(phoneNumber, @"\+38-0\d{2}-\d{7,8}"))
                {
                    Console.WriteLine(phoneNumber);
                }
            }
        }
    }
}
