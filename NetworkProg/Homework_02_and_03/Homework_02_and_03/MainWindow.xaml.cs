using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageLiblary;
namespace Client_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }

    internal class ViewModel
    {
        private UdpClient client = new UdpClient();

        private bool isListening = false;

        public string Name { get; set; } = string.Empty;

        public string Ip { get; set; } = "127.0.0.1";

        public string Port { get; set; } = "8080";

        public string MessageText { get; set; } = "Lorem Ipsum!";

        private ObservableCollection<Message> messages { get; set; } =
            new ObservableCollection<Message>();

        public IEnumerable<Message> Messages => messages;

        public Message? SelectedMessage { get; set; }

        private RelayCommand? joinCommand;

        public ICommand JoinCommand => joinCommand ??=
            new RelayCommand(o => Join());

        private RelayCommand? sendMessageCommand;

        public ICommand SendMessageCommand => sendMessageCommand ??=
            new RelayCommand(o => SendMessage());

        private RelayCommand? sendReplyCommand;

        public ICommand SendReplyCommand => sendReplyCommand ??=
            new RelayCommand(o => SendReply());

        private RelayCommand? leaveCommand;

        public ICommand LeaveCommand => leaveCommand ??=
            new RelayCommand(o => Leave());

        private async void Listen()
        {
            while (isListening)
            {
                UdpReceiveResult res = await client.ReceiveAsync();
                string messageJson = Encoding.UTF8.GetString(res.Buffer);
                Message message = JsonSerializer.Deserialize<Message>(messageJson)!;
                messages.Add(message);
            }
        }

        private async void Send(Message message)
        {
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse(Ip), int.Parse(Port));
            string messageJson = JsonSerializer.Serialize(message);
            byte[] data = Encoding.UTF8.GetBytes(messageJson);

            await client.SendAsync(data, serverIp);

            if (!isListening)
            {
                UdpReceiveResult result = await client.ReceiveAsync();
                string responseJson = Encoding.UTF8.GetString(result.Buffer);
                Message response = JsonSerializer.Deserialize<Message>(responseJson)!;
                messages.Add(response);
            }
        }

        private void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(MessageText))
                MessageBox.Show("You cannot send an empty message");
            else
            {
                Message message = new Message
                {
                    SenderName = Name,
                    Text = MessageText
                };
                Send(message);
            }
        }

        private void SendReply()
        {
            if (SelectedMessage == null)
                MessageBox.Show("Select a message to reply");
            else if (SelectedMessage.SenderName == "<server>")
                MessageBox.Show("Cannot reply to a server message");
            else if (string.IsNullOrWhiteSpace(MessageText))
                MessageBox.Show("You cannot send an empty message");
            else
            {
                Message message = new Message
                {
                    SenderName = Name,
                    Text = MessageText,
                    ToAddress = SelectedMessage.FromAddress,
                    ToPort = SelectedMessage.FromPort,
                    ReplyToMessage = SelectedMessage
                };
                Send(message);
            }
        }

        private void Join()
        {
            if (isListening)
                MessageBox.Show("You have already joined");
            else if (string.IsNullOrWhiteSpace(Name))
                MessageBox.Show("Enter a valid name to join");
            else if (Name == "<server>")
                MessageBox.Show("Cannot name a user as server");
            else
            {
                isListening = true;
                Message message = new Message
                {
                    SenderName = Name,
                    Command = Message.JOIN_CMD
                };
                Send(message);
                Listen();
            }
        }

        private void Leave()
        {
            if (!isListening)
            {
                MessageBox.Show("You cannot leave unless you have joined");
                return;
            }

            Message message = new Message
            {
                SenderName = Name,
                Command = Message.LEAVE_CMD
            };
            Send(message);
            isListening = false;
        }
    }
}