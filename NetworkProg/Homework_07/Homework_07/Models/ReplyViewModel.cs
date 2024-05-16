using Homework_07.paterns;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using Microsoft.Win32;
using MimeKit;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;


namespace Homework_07
{
    [AddINotifyPropertyChangedInterface]
    internal class ReplyViewModel
    {
        private Reply Window { get; set; }
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();
        public ImapClient ImapClient { get; set; } = new ImapClient();
        public string Address { get; set; } = string.Empty;
        public string LoginStatus { get; set; } = string.Empty;
        public string FromAddress { get; set; } = string.Empty;

        public MimeMessage Origin { get; set; }
        public string ToAddress { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;
        public bool IsImportant { get; set; } = false;

        public string Body { get; set; } = string.Empty;

        private ObservableCollection<string> fileNames =
            new ObservableCollection<string>();

        public IEnumerable<string> FileNames => fileNames;

        public string SelectedFileName { get; set; } = string.Empty;



        private RelayCommand? attachFileCommand;
        public ICommand AttachFileCommand => attachFileCommand ??=
            new RelayCommand(o => AttachFile());

        private RelayCommand? removeFileCommand;

        public ICommand RemoveFileCommand => removeFileCommand ??=
            new RelayCommand(o => fileNames.Remove(SelectedFileName),
                o => fileNames.Count > 0);

        private RelayCommand? sendCommand;

        public ICommand SendCommand => sendCommand ??=
            new RelayCommand(o => SendAsync());

        public ReplyViewModel(Reply window, SmtpClient smtp, ImapClient imap, string Adress, MimeMessage msg)
        {
            Window = window;
            Origin = msg;
            SmtpClient = smtp;
            ImapClient = imap;
            Address = Adress;
            if (smtp.IsAuthenticated && imap.IsAuthenticated)
            {
                LoginStatus = $"You are logged in as {Adress}";
            }
            Subject = Origin.Subject;
        }


        public void AttachFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == true)
                foreach (string fileName in dialog.FileNames)
                {
                    fileNames.Add(fileName);
                }

        }



        public async void SendAsync()
        {

            MimeMessage reply = Origin;
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress($"{Address}", Address));
            foreach (var mailboxAddress in reply.From.Mailboxes)
            {
                message.To.Add(mailboxAddress);
            }
            foreach (var mailboxAddress in reply.Cc.Mailboxes)
            {
                message.Cc.Add(mailboxAddress);
            }

            if (!reply.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase))
            {
                message.Subject = "Re: " + reply.Subject;
                Subject = "Re: " + reply.Subject;

            }
            else
            {
                message.Subject = reply.Subject;
                Subject = reply.Subject;
            }

            message.Importance = IsImportant ? MessageImportance.High : MessageImportance.Normal;

            Multipart multipart = new Multipart
            {
                new TextPart("plain") { Text = Body }
            };

            foreach (string fileName in fileNames)
            {
                multipart.Add(new MimePart()
                {
                    Content = new MimeContent(File.OpenRead(fileName)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    FileName = Path.GetFileName(fileName)
                });
            }

            message.Body = multipart;
            message.InReplyTo = reply.MessageId;
            message.References.Add(reply.MessageId);
            try
            {
                await SmtpClient.SendAsync(message);
            }
            catch (SmtpCommandException)
            {
                MessageBox.Show("Invalid recipient", "Error", MessageBoxButton.OK);
                return;
            }



            MessageBox.Show("Message sent successfully!");
            ToAddress = string.Empty;
            Subject = string.Empty;
            IsImportant = false;
            Body = string.Empty;
            fileNames.Clear();
            Window.Close();
        }
    }
}

