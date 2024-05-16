using Homework_07.Windows;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System.Windows;
using System.Windows.Controls;


namespace Homework_07
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window
    {
        public MailViewModel viewModel;
        public MailWindow(SmtpClient smtpClient, ImapClient imapClient,string Adress)
        {
            InitializeComponent();
            viewModel = new MailViewModel(smtpClient,imapClient,Adress );

            this.DataContext = viewModel;
           

        }

        private async void FolderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFolderName = FolderListBox.SelectedItem as string;
            int i = 0;
            if (!string.IsNullOrEmpty(selectedFolderName) && int.TryParse(Max_Messages.Text,out i))
            {
                

                try
                {
                    
                    var folder =  await viewModel.ImapClient.GetFolderAsync(selectedFolderName);

                    
                    if (i > 0) {
                       await viewModel.GetMails(folder, i);
                    }
                    else
                    {
                        await viewModel.GetMails(folder, 50);
                    }
                   
                  
                       
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
          
        }


        private void MailsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var t = e.AddedItems[0] as string;
                
                var msg = viewModel.Inbox.FirstOrDefault(k => k.Keys.FirstOrDefault() == t);
                if (msg != null)
                {
                    var win = new Info(msg[t], viewModel.SmtpClient, viewModel.ImapClient, viewModel.Address, FolderName: FolderListBox?.SelectedItem as string,this);
                    win.Show();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Create_Folder window = new Create_Folder(viewModel.ImapClient);
            window.ShowDialog();
            viewModel.GetFolders();
     
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Rename window = new Rename(viewModel.SmtpClient,viewModel.ImapClient,this);
            window.ShowDialog();
            viewModel.GetFolders();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = DataContext as MailViewModel;
           var a = viewModel?.FilterMails(SearchBox.Text);
            if ( a == -1)
            {
                FolderListBox_SelectionChanged(sender, null);
            }
        }
    }
}
