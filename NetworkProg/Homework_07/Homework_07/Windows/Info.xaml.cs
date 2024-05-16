using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;
using Org.BouncyCastle.Asn1.X509;
using System.Windows;


namespace Homework_07
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        MailWindow _mailWindow;
        public SmtpClient smtp {  get; set; } = new SmtpClient();
        public ImapClient imap { get; set; }  = new ImapClient();
        public string Address { get; set; } = string.Empty;
        public string Folder {  get; set; } = string.Empty;
        public MimeMessage MimeMessage { get; set; }
        public Info(MimeMessage message,SmtpClient s, ImapClient i, string add , string FolderName , MailWindow window) 
        {
            InitializeComponent();
            MimeMessage = message;
            _mailWindow = window;
            smtp = s;
            imap = i;
            Address = add;
            Folder = FolderName;
            senderBox.Text = message.From?.ToString() ?? " ";
            recieverBox.Text = message.To.ToString() ?? " ";
            dateBox.Text = message.Date.ToString() ?? " ";
            themeBox.Text = message.Subject ?? " ";
            bodyBox.Text = message.TextBody;
            filesBox.Text = message.Attachments?.ToString() ?? " ";

        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ReplyButton_Click(Object sender, RoutedEventArgs e)
        {
            Reply reply = new Reply(MimeMessage,smtp,imap,Address);
            reply.Show();
        }

       
    }
    
}
