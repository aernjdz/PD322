using System;
using System.Windows;
using System.Windows.Input;
using Homework_07.paterns;
using MailKit.Net.Smtp;
using MailKit.Security;
using PropertyChanged;

namespace Homework_07.Models
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();

        public int MailTypeIndex { get; set; } = 0;

        public string Address { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsLoginEnabled { get; set; } = true;

        public string Status { get; set; } = string.Empty;

        private RelayCommand? loginCommand;

        public ICommand LoginCommand => loginCommand ??=
            new RelayCommand(o => Login(), o => CanLogin());

        public event EventHandler? RequestClose;

        public LoginViewModel()
        {
            SmtpClient.Authenticated += (s, e) => RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private async void AuthenticateAsync(string host, int port)
        {
            if (SmtpClient.IsConnected)
                SmtpClient.Disconnect(false);
            await SmtpClient.ConnectAsync(host, port, SecureSocketOptions.Auto);

            try
            {
                await SmtpClient.AuthenticateAsync(Address, Password);
                Status = string.Empty;
                IsLoginEnabled = true;
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
            catch (AuthenticationException)
            {
                Status = "Invalid login or password!";
                IsLoginEnabled = true;
            }
        }

        public bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Address) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        public void Login()
        {
            string host = string.Empty;
            int port = 587;
            switch (MailTypeIndex)
            {
                case 0: host = "smtp.gmail.com"; break;
                case 1: host = "smtp-mail.outlook.com"; break;
                case 2: host = "smtp.ukr.net"; port = 465; break;
            }

            IsLoginEnabled = false;
            AuthenticateAsync(host, port);
        }
    }
}