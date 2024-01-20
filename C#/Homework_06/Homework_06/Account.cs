using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Homework_06
{
    class Account
    {
        private string _email;
        private string _password;
        public string Email
        {
            get { return _email; }
            set
            {
                if (IsValidEmail(value))
                    _email = value;
                else
                    throw new ArgumentException("Email format is incorrect");
            }
        }
        private bool IsValidEmail(string email)
        {

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            return atIndex > 0 &&
                   dotIndex > atIndex && 
                   email.ToCharArray().All(c => Char.IsLetterOrDigit(c) || c == '_' || c == '.' || c == '@')
                   && email.Length >= 4 && email.Length <= 50;
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (IsValidPassword(value))
                    _password = value;
                else
                    throw new ArgumentException("Incorrect password format");
            }
        }
        private bool IsValidPassword(string password)
        {
            return password.Length >= 6 &&
                   password.Any(c => Char.IsDigit(c)) &&
                   password.Any(c => Char.IsLetter(c));
        }
    }
}
