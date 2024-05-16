using MailKit.Net.Imap;
using System.Windows;


namespace Homework_07
{
    /// <summary>
    /// Interaction logic for Create_Folder.xaml
    /// </summary>
    public partial class Create_Folder : Window
    {
        public ImapClient Client { get; set; } = new ImapClient();

        public Create_Folder(ImapClient imap)
        {
            Client = imap;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var folders = Client.GetFolder(Client.PersonalNamespaces[0]);
            folders.Create($"{InputBox.Text}", true);
            Close();
          
        }


        
        
    }
}
