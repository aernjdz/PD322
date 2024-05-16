using Homework_07.Windows;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework_07
{
    internal class RenameViewModel
    {
        MailWindow _mailWindow_s;
        Rename _window_r;
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();
        public ImapClient ImapClient { get; set; } = new ImapClient();
        public List<string> Folders { get; set; } = new List<string>();


        public RenameViewModel(SmtpClient smtp,ImapClient imap, MailWindow window_s,Rename window_r) { 
        SmtpClient = smtp;
        ImapClient = imap;
        _mailWindow_s = window_s;
        _window_r = window_r;
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
        public async void RenameFolder(string name,string newname )
        {
            var folder_perent = ImapClient.GetFolder(ImapClient.PersonalNamespaces[0]);
            var folder = ImapClient.GetFolder(name);
            await folder.RenameAsync(folder_perent, newname);
            MessageBox.Show($"Folder {name} renamed Successfully!");
            _window_r.Close();
        }
    }
}
