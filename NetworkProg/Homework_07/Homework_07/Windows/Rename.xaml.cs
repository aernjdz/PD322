using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Controls.Primitives;

namespace Homework_07.Windows
{
    /// <summary>
    /// Interaction logic for Rename.xaml
    /// </summary>
    public partial class Rename : Window
    {
        private RenameViewModel viewModel;
        private string Selected { get; set; } = string.Empty;
        public Rename(SmtpClient smtp, ImapClient imap, MailWindow m)
        {
            viewModel = new RenameViewModel(smtp, imap, m, this);
            InitializeComponent();
            this.DataContext = viewModel;
            viewModel.GetFolders();
        }

        private void FolderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFolder = FolderComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedFolder)) {
                Selected = selectedFolder;
            }

        }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
            if(Selected != string.Empty && string.IsNullOrEmpty(InputBox.Text) != true)
            {

                viewModel.RenameFolder(Selected, InputBox.Text);

            }
            
        }
    }
}
