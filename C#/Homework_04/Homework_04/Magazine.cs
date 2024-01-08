using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_04
{
    class Magazine
    {
        private string name;
        private int foundationYear;
        private string description;
        private string contactPhone;
        private string email;

        public void SetName(string newName)
        {
            name = newName;
        }

        public string GetName()
        {
            return name;
        }

        public void SetFoundationYear(int newFoundationYear)
        {
            foundationYear = newFoundationYear;
        }

        public int GetFoundationYear()
        {
            return foundationYear;
        }

        public void SetDescription(string newDescription)
        {
            description = newDescription;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetContactPhone(string newContactPhone)
        {
            contactPhone = newContactPhone;
        }

        public string GetContactPhone()
        {
            return contactPhone;
        }

        public void SetEmail(string newEmail)
        {
            email = newEmail;
        }

        public string GetEmail()
        {
            return email;
        }

        public void InputData()
        {
            Console.Write("Enter the magazine name: ");
            SetName(Console.ReadLine());

            Console.Write("Enter the foundation year: ");
            SetFoundationYear(int.Parse(Console.ReadLine()));

            Console.Write("Enter the magazine description: ");
            SetDescription(Console.ReadLine());

            Console.Write("Enter the contact phone: ");
            SetContactPhone(Console.ReadLine());

            Console.Write("Enter the email: ");
            SetEmail(Console.ReadLine());
        }

        public void DisplayData()
        {
            Console.WriteLine($"Magazine Name: {GetName()}");
            Console.WriteLine($"Foundation Year: {GetFoundationYear()}");
            Console.WriteLine($"Magazine Description: {GetDescription()}");
            Console.WriteLine($"Contact Phone: {GetContactPhone()}");
            Console.WriteLine($"Email: {GetEmail()}");
        }
    }
}
