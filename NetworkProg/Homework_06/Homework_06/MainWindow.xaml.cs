using Microsoft.WindowsAPICodePack.Dialogs;

using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> filePaths = new List<string>();

        public string SmtpServer { get; set; } = "smtp.gmail.com";



        public int Port { get; set; } = 587;


        public string Username { get; set; } = "andriuzarichn5@gmail.com";




        public string Password { get; set; } = "vhsp wipp rexn uneg";
        public MainWindow()
        {
            InitializeComponent();
            SmtpBox.Text = SmtpServer;
            PortBox.Text = $"{Port}";
            UsernameBox.Text = Username;
            PasswordBox.Text = Password;    
        }



         private void Send_Click(object sender, RoutedEventArgs e)
         {

             MailMessage msg = new MailMessage(FromBox.Text, ToBox.Text, ThemeBox.Text, MsgBox.Text);

             SmtpClient client = new SmtpClient(SmtpServer, Port);
             client.Credentials = new NetworkCredential(Username, Password);
             msg.Priority = MailPriority.High;
             if (filePaths.Count > 0)
             {
                 foreach (var item in filePaths)
                 {
                     msg.Attachments.Add(new Attachment(item));
                 }
             }
             client.EnableSsl = true;
             client.SendCompleted += Client_SendCompleted;
             client.SendAsync(msg,msg);
         }

   

        private void AttachFile_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                foreach (string filePath in dialog.FileNames)
                {
                    


                    string fileName = System.IO.Path.GetFileName(filePath);

                    filePaths.Add(filePath);
                    Files.Items.Add(fileName);
                }
            }
        }
        private void FilesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Files.SelectedItem != null)
            {
                int selectedIndex = Files.SelectedIndex;
                filePaths.RemoveAt(selectedIndex);
                Files.Items.Remove(Files.SelectedItem);
              
            }
        }
        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState!;
            MessageBox.Show($"Message was send! Subject: {state.Subject}");
        }

       

        private void SmtpServer_Load(object sender, RoutedEventArgs e)
        {
           SmtpServer = SmtpBox.Text;
        }

        private void Port_Load(object sender, RoutedEventArgs e)
        {
            Port = int.Parse(PortBox.Text);
        }

        private void Username_Load(object sender, RoutedEventArgs e)
        {
            Username = UsernameBox.Text;
        }

        private void Password_Load(object sender, RoutedEventArgs e)
        {
            Password = PasswordBox.Text;
        }
    }
}