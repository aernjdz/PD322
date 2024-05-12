using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit;

namespace Homework_07.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MailViewModel
    {
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();
        public List<string> UserFolders { get; set; } = new List<string>();

        public MailViewModel()
        {
            // Connect to IMAP server and retrieve user folders
            ConnectAndRetrieveFolders();
        }

        private void ConnectAndRetrieveFolders()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            if (loginWindow.DataContext is LoginViewModel loginViewModel &&
    loginViewModel.SmtpClient.IsAuthenticated)
            {
                using (var client = new ImapClient())
                {

                    client.Connect("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);

                    client.Authenticate(loginViewModel.Address, loginViewModel.Password);


                  
                  
                    var folders = client.GetFolders(client.PersonalNamespaces[0]);
                    foreach (var folder in folders)
                    {
                        Console.WriteLine("Folder : " + folder.Name);
                        UserFolders.Add(folder.Name);
                    }

                    client.Disconnect(true);
                }
            }
        }
    }
}
