using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

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

namespace Homework_07
{
    /// <summary>
    /// Interaction logic for Reply.xaml
    /// </summary>
    public partial class Reply : Window
    {

        ReplyViewModel viewModel;
        public Reply(MimeMessage mimeMessage,SmtpClient smtpClient, ImapClient imapClient,string Address)
        {
            InitializeComponent();
            viewModel = new ReplyViewModel(this, smtpClient,imapClient,Address,mimeMessage);
           this.DataContext = viewModel;

        }

    }
}
