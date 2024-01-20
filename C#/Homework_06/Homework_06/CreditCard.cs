using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Homework_06
{
    public enum CardType
    {
        Visa,
        MasterCard,
        Discover,
        AmericanExpress,
       Unknown
    }

    public class CreditCard
    {
        private string _name;
        private string _number;
        private string _expirationDate;
        private string _cvv;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty or null");

                _name = value;
            }
        }

        public string Number
        {
            get { return _number; }
            set
            {
                if (!IsValidCreditCardNumber(value))
                    throw new ArgumentException("Invalid credit card number");

                _number = value;
            }
        }

        public string ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                if (!IsValidExpirationDate(value))
                    throw new ArgumentException("Invalid expiration date");

                _expirationDate = value;
            }
        }

        public string CVV
        {
            get { return _cvv; }
            set
            {
                if (!IsValidCVV(value))
                    throw new ArgumentException("Invalid CVV");

                _cvv = value;
            }
        }

        private bool IsValidCreditCardNumber(string number)
        {
            string cleanedNumber = new string(number.Where(char.IsDigit).ToArray());

            if (cleanedNumber.Length < 13 || cleanedNumber.Length > 19)
            {
                return false;
            }

            int sum = 0;
            bool doubleDigit = false;

            for (int i = cleanedNumber.Length - 1; i >= 0; i--)
            {
                int digit = cleanedNumber[i] - '0';

                if (doubleDigit)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            return sum % 10 == 0;
        }

        private bool IsValidExpirationDate(string expirationDate)
        {
            if (string.IsNullOrWhiteSpace(expirationDate))
            {
                return false;
            }

            if (DateTime.TryParseExact(expirationDate, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate > DateTime.Now;
            }

            return false;
        }

        private CardType GetCardTypeFromNumber(string cardNumber)
        {
            if (cardNumber.StartsWith("4"))
            {
                return CardType.Visa;
            }
            else if (cardNumber.StartsWith("5"))
            {
                return CardType.MasterCard;
            }
            else if (cardNumber.StartsWith("6"))
            {
                return CardType.Discover;
            }
            else if (cardNumber.StartsWith("34") || cardNumber.StartsWith("37"))
            {
                return CardType.AmericanExpress;
            }

            return CardType.Unknown; 
        }
        private bool IsValidCVV(string cvv)
        {
            if (string.IsNullOrWhiteSpace(cvv))
            {
                return false;
            }
            CardType cardType = GetCardTypeFromNumber(_number);
            if (cvv.All(char.IsDigit))
            {
                return (cvv.Length == 3 && (cardType == CardType.Visa || cardType == CardType.MasterCard || cardType == CardType.Discover))
                    || (cvv.Length == 4 && cardType == CardType.AmericanExpress);
            }

            return false;
        }
        public void PrintCreditCard()
        {
            Console.WriteLine("Credit Card Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Card Type: {(GetCardTypeFromNumber(Number) == CardType.Visa ? "Visa" : (GetCardTypeFromNumber(Number) == CardType.MasterCard ? "Mastercard" : (GetCardTypeFromNumber(Number) == CardType.Discover ? "Discover" : (GetCardTypeFromNumber(Number) == CardType.AmericanExpress ? "AmericanExpress" : "Unknown")))) }");
            Console.WriteLine($"Number: {Number}");
            Console.WriteLine($"Expiration Date: {ExpirationDate}");
            Console.WriteLine($"CVV: {CVV}");
        }
    }

}
