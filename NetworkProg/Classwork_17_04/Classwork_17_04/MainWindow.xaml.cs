using System.Collections.ObjectModel;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
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

namespace Classwork_17_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /* const string serverAddress = "127.0.0.1";
         const short serverPort = 4040;*/
        Configurator conf = new Configurator();

        public MainWindow()
        {
            InitializeComponent();
            conf.serverPoint = new IPEndPoint(IPAddress.Parse(conf.serverAddress), conf.serverPort);
            conf.client = new UdpClient();
            this.DataContext = conf.messages;
        }


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
         
            string msg = msgTextBox.Text;
            msgTextBox.Text = "";
            SendMessage(msg);
        }

        private void msgTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                SendButton_Click(null, null);
            }
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = "$<Join>";
            Listener();
            SendMessage(msg);
        }

        private async void SendMessage(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            await conf.client.SendAsync(data, data.Length, conf.serverPoint);
        }

        private async void Listener()
        {
            while (true)
            {
                var res = await conf.client.ReceiveAsync();
                string msg = Encoding.Unicode.GetString(res.Buffer);
                conf.messages.Add(new MessageInfo(msg));
            }
        }
    }
}