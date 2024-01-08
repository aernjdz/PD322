using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_04
{
    class Store
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileDescription { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }

        public void InputData()
        {
            Console.Write("Enter the store name: ");
            Name = Console.ReadLine();

            Console.Write("Enter the store address: ");
            Address = Console.ReadLine();

            Console.Write("Enter the profile description: ");
            ProfileDescription = Console.ReadLine();

            Console.Write("Enter the contact phone: ");
            ContactPhone = Console.ReadLine();

            Console.Write("Enter the email: ");
            Email = Console.ReadLine();
        }

        public void DisplayData()
        {
            Console.WriteLine($"Store Name: {Name}");
            Console.WriteLine($"Store Address: {Address}");
            Console.WriteLine($"Profile Description: {ProfileDescription}");
            Console.WriteLine($"Contact Phone: {ContactPhone}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
