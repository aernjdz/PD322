using System;
using System.Windows;
using System.Windows.Input;
using Homework_07.paterns;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using PropertyChanged;

namespace Homework_07.Models
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();

        public ImapClient ImapClient { get; set; } = new ImapClient();
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

        private async void AuthenticateAsync(string host_smtp, int port_smtp, string host_imap, int port_imap)
        {
            if (SmtpClient.IsConnected)
                SmtpClient.Disconnect(false);
            if(ImapClient.IsConnected)
                ImapClient.Disconnect(false);

            await SmtpClient.ConnectAsync(host_smtp, port_smtp, SecureSocketOptions.Auto);
            await ImapClient.ConnectAsync(host_imap,port_imap,SecureSocketOptions.Auto);
            try
            {
                await SmtpClient.AuthenticateAsync(Address, Password);
                await ImapClient.AuthenticateAsync(Address, Password);


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
            string host_smtp = string.Empty;
            string host_imap = string.Empty;
            int port_smtp = 587;
            int port_imap = 993;
            switch (MailTypeIndex)
            {
                case 0: host_smtp = "smtp.gmail.com"; host_imap = "imap.gmail.com"; break;
                case 1: host_smtp = "smtp-mail.outlook.com"; host_imap = "outlook.office365.com"; break;
                case 2: host_smtp = "smtp.ukr.net"; host_imap = "imap.ukr.net"; port_smtp = 465; break;
            }

            IsLoginEnabled = false;
            AuthenticateAsync(host_smtp, port_smtp,host_imap,port_imap);
        }
    }
}