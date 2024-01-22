﻿using System;

namespace Homework_06
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your email: ");
                string userEmail = Console.ReadLine();

                Console.Write("Enter your password: ");
                string userPassword = Console.ReadLine();

                Account userAccount = new Account();
                userAccount.Email = userEmail;
                userAccount.Password = userPassword;

                Console.WriteLine("Account created successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            try
            {

                CreditCard creditCard = new CreditCard
                {
                    Name = "John Doe",
                    Number = "5111111111111118", //5111111111111118 -Mastercard 4111111111111111 - visa 370000200000000 - AmericanExpess  6011000990139424 - discover
                    ExpirationDate = "01/25",
                    CVV = "123"// AmericanExpess - 1234
                };
                creditCard.PrintCreditCard();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}