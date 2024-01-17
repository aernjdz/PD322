using System;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            /* PhoneBook<string, string> myPhoneBook = new PhoneBook<string, string>();


             myPhoneBook.AddEntry("John", "555-1234");
             myPhoneBook.AddEntry("Alice", "555-5678");
             myPhoneBook.PrintEntries();


             myPhoneBook.UpdateName("John", "Johnny");
             myPhoneBook.UpdateNumber("Alice", "555-8765");
             myPhoneBook.PrintEntries();


             string johnnyPhoneNumber = myPhoneBook.FindEntry("Johnny");
             Console.WriteLine($"Johnny's phone number: {johnnyPhoneNumber}");


             myPhoneBook.RemoveEntry("Alice");
             myPhoneBook.PrintEntries();

             Console.ReadLine();
 */


                string text = "Here is the house that Jack built. And this is wheat, which is stored in a dark cell in the house that Jack built. And this is a cheerful tit bird, Which often steals wheat, Which is kept in a dark cell In the house that Jack built.";

               
                string[] words = Regex.Split(text.ToLower(), @"\W+");

             
                Dictionary<string, int> wordCount = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                        else
                        {
                            wordCount[word] = 1;
                        }
                    }
                }

           
                Console.WriteLine("Statistics by text:");
                Console.WriteLine("Word\t\tNumber of occurrences");
                Console.WriteLine("-----------------------------");

                foreach (var entry in wordCount)
                {
                    Console.WriteLine($"{entry.Key}\t\t\t\t{entry.Value}");
                }

          
                Console.WriteLine($"Total words: {words.Length} of which are unique: {wordCount.Count}");

                Console.ReadLine();
            }
        }


    }
