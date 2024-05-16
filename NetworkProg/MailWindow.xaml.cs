using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MailKit;

namespace Homework_07.Models
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window
    {
        MailViewModel viewModel;
        public MailWindow(SmtpClient smtpClient, ImapClient imapClient,string Adress)
        {
            InitializeComponent();
            viewModel = new MailViewModel(smtpClient,imapClient,Adress );

            this.DataContext = viewModel;
           

        }

        private  void FolderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFolderName = FolderListBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedFolderName))
            {
           

                try
                {
                    
                     viewModel.GetMails(selectedFolderName);
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
