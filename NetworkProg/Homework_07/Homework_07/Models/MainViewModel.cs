using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using MailKit.Net.Smtp;
using Microsoft.Win32;
using MimeKit;
using System.IO;
using System.Windows;
using Homework_07.paterns;
using MailKit.Net.Imap;


namespace Homework_07
{
    [AddINotifyPropertyChangedInterface]
    internal class MainViewModel
    {
        public SmtpClient SmtpClient { get; set; } = new SmtpClient();
        public ImapClient ImapClient { get; set; } = new ImapClient();

        public string FromAddress { get; set; } = string.Empty;

        public string LoginStatus { get; set; } = string.Empty;

        public bool IsLoggedIn { get; set; } = false;

        public string ToAddress { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public bool IsImportant { get; set; } = false;

        public string Body { get; set; } = string.Empty;

        private ObservableCollection<string> fileNames =
            new ObservableCollection<string>();

        public IEnumerable<string> FileNames => fileNames;

        public string SelectedFileName { get; set; } = string.Empty;

        private RelayCommand? loginCommand;


        public ICommand LoginCommand => loginCommand ??=
            new RelayCommand(o => Login(), o => !IsLoggedIn);

        private RelayCommand? getCommand;

        public ICommand GETCommand => getCommand ??=
            new RelayCommand(o => ImapMail(), o => IsLoggedIn);
        private RelayCommand? attachFileCommand;

        public ICommand AttachFileCommand => attachFileCommand ??=
            new RelayCommand(o => AttachFile(), o => IsLoggedIn);

        private RelayCommand? removeFileCommand;

        public ICommand RemoveFileCommand => removeFileCommand ??=
            new RelayCommand(o => fileNames.Remove(SelectedFileName),
                o => fileNames.Count > 0);

        private RelayCommand? sendCommand;

        public ICommand SendCommand => sendCommand ??=
            new RelayCommand(o => SendAsync(), o => CanSend());

        public void Login()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.DataContext is LoginViewModel loginViewModel &&
                loginViewModel.SmtpClient.IsAuthenticated)
            {
                SmtpClient = loginViewModel.SmtpClient;
                ImapClient = loginViewModel.ImapClient;
                FromAddress = loginViewModel.Address;
                LoginStatus = $"You are logged in as {loginViewModel.Address}";
                IsLoggedIn = true;
            }
            else
            {
                SmtpClient = new SmtpClient();
                ImapClient = new ImapClient();
                FromAddress = string.Empty;
                LoginStatus = string.Empty;
                IsLoggedIn = false;
            }
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

        public void ImapMail()
        {
            MailWindow mailWindow = new MailWindow(SmtpClient, ImapClient, FromAddress);
            mailWindow.Show();
        }
        public bool CanSend()
        {
            return !string.IsNullOrWhiteSpace(FromAddress) &&
                   !string.IsNullOrWhiteSpace(ToAddress) &&
                   !string.IsNullOrWhiteSpace(Body);
        }

        public async void SendAsync()
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress($"{FromAddress}", FromAddress));
            message.To.Add(new MailboxAddress("Test user", ToAddress));
            message.Subject = Subject;
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
        }
    }
}
