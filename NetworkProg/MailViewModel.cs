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
using System.Windows;
using MailKit.Security;


namespace Homework_07.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MailViewModel
    {
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();

        public ImapClient ImapClient { get; set; } = new ImapClient();
        public List<string> Folders { get; set; } = new List<string>();

        public List<string> Mails { get; set; } = new List<string>();
        public string LoginStatus { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string Host_smtp {  get; set; } = string.Empty;   
        public int Port_smtp { get; set; } 
        public string Host_imap { get; set; } = string.Empty;
        public int Port_imap { get; set; }

        public  MailViewModel(SmtpClient smtpClient, ImapClient imapClient, string Adress )
        {

            SmtpClient = smtpClient;
            ImapClient = imapClient;
  
            Address = Adress;
          
            if (smtpClient.IsAuthenticated && imapClient.IsAuthenticated)
            {
                LoginStatus = $"You are logged in as {Adress}";
            }
            GetFolders();
        }

      
        void GetFolders()
        {
            try
            {
                var folders = ImapClient.GetFolders(ImapClient.PersonalNamespaces[0]);

                Folders.Clear();

                foreach (var folder in folders)
                {
                    Folders.Add(folder.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      public  void GetMails(string selectedFolderName)
        {
            
           
            var folder = ImapClient.GetFolder(selectedFolderName);

            folder.Open(FolderAccess.ReadOnly);

            // var messages = folder.Fetch(0, -1, MessageSummaryItems.Full);
            var msg = folder.Search(MailKit.Search.SearchQuery.All);
            
            foreach (var mess in msg)
            {
                var b = folder.GetMessage(mess);

                var t = b.From.Mailboxes.FirstOrDefault();

                if (t != null)
                {
                    var s = new MailboxAddress(t.Name,t.Address);

                    var g = new MimeMessage { From = { s } };

                    Mails.Add(g.Subject);
                }
                
               
            }

        }
    }

}

