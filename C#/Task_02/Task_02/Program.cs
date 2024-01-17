using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook<string, string> myPhoneBook = new PhoneBook<string, string>();

            myPhoneBook.AddEntry("John", "555-1234");
            myPhoneBook.AddEntry("Alice", "555-5678");
            myPhoneBook.PrintEntries();

            myPhoneBook.UpdateEntry("John", "555-4321");
            myPhoneBook.PrintEntries();

            string alicePhoneNumber = myPhoneBook.FindEntry("Alice");
            Console.WriteLine($"Phone number is Alice: {alicePhoneNumber}");

            myPhoneBook.RemoveEntry("Alice");
            myPhoneBook.PrintEntries();

          
        }
    }
}
