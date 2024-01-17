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

         
            myPhoneBook.UpdateName("John", "Johnny");
            myPhoneBook.UpdateNumber("Alice", "555-8765");
            myPhoneBook.PrintEntries();

       
            string johnnyPhoneNumber = myPhoneBook.FindEntry("Johnny");
            Console.WriteLine($"Johnny's phone number: {johnnyPhoneNumber}");

    
            myPhoneBook.RemoveEntry("Alice");
            myPhoneBook.PrintEntries();

            Console.ReadLine();


        }
    }
}
