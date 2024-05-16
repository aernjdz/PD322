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
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using MailKit.Search;


namespace Homework_07
{
    [AddINotifyPropertyChangedInterface]
    public class MailViewModel
    {
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();

        public ImapClient ImapClient { get; set; } = new ImapClient();
        public ObservableCollection<string> Folders { get; set; } = new ObservableCollection<string>();
        
        
        public ObservableCollection<string> Inbox_Text { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Dictionary<string, MimeMessage>> Inbox { get; set; } = new ObservableCollection<Dictionary<string, MimeMessage>>();

        public string LoginStatus { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host_smtp { get; set; } = string.Empty;
        public int Port_smtp { get; set; }
        public string Host_imap { get; set; } = string.Empty;
        public int Port_imap { get; set; }

        public MailViewModel(SmtpClient smtpClient, ImapClient imapClient, string Adress)
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


        public void GetFolders()
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

        public async Task GetMails(IMailFolder folder, int Max_FolderCount)
        {



            Inbox.Clear();
            Inbox_Text.Clear();
            await folder.OpenAsync(FolderAccess.ReadOnly);

            // var messages = folder.Fetch(0, -1, MessageSummaryItems.Full);
            var fold = await folder.SearchAsync(MailKit.Search.SearchQuery.All);

            if (fold.Count <= Max_FolderCount)
            {
                foreach (var item in fold)
                {
                    await Load(item, folder);
                }
            }
            else
            {
                for (var i = 0; i <= Max_FolderCount; i++)
                {
                    await Load(fold[i], folder);

                }
                return;
            }




        }
        public async Task Load(UniqueId id, IMailFolder folders)
        {
            var mime = await folders.GetMessageAsync(id);

            var msgFrom = mime.From.Mailboxes.FirstOrDefault();

            var mailbox = new MailboxAddress(msgFrom?.Name, msgFrom?.Address);
            if (msgFrom != null)
            {
                string key = $"[{mime.Date.ToLocalTime()}] : [{msgFrom}] | {mime.Subject}";

                var messageDictionary = new Dictionary<string, MimeMessage>();

             
                messageDictionary.Add(key, mime);
                Inbox_Text.Add(key);

                Inbox.Add(messageDictionary);
            }


        }

        public int FilterMails(string SearchText)
        {
            if (!string.IsNullOrEmpty(SearchText))

            {
                var filteredText = Inbox_Text.Where(item => item.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
                var filtered = Inbox.Where(mailDict => mailDict.Keys.Any(key => key.Contains(SearchText, StringComparison.OrdinalIgnoreCase))).ToList();
                    Inbox_Text = new ObservableCollection<string>(filteredText);
                    Inbox = new ObservableCollection<Dictionary<string, MimeMessage>>(filtered);
                    return 1;
                
              
            }
            return -1;
        }
    }
}



