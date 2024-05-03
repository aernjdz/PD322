using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_UI
{
    public partial class MainWindow : Window
    {
        private string serverAddress = "127.0.0.1"; // Server IP address
        private int serverPort = 8080; // Server port
        private TcpClient client;

        public MainWindow()
        {
            InitializeComponent();
            InitializeClient();
        }

        private async void InitializeClient()
        {
            try
            {
                var ipPoint = new IPEndPoint(IPAddress.Parse(serverAddress), serverPort);
                client = new TcpClient();
                await client.ConnectAsync(ipPoint.Address, ipPoint.Port);
           //     MessageBox.Show("Connected to server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] codes = { "<Code>", "<Region>" };
            string data = TextBox.Text.Trim();
            string msg;

            if (data.Length > 2)
            {
                msg = $"{codes[1].Trim()}={data}";
            }
            else
            {
                msg = $"{codes[0].Trim()}={data}";
            }

            try
            {
                NetworkStream ns = client.GetStream();

                using (StreamWriter sw = new StreamWriter(ns, Encoding.UTF8, leaveOpen: true))
                {
                    await sw.WriteLineAsync(msg);
                    await sw.FlushAsync();
                }

                using (StreamReader reader = new StreamReader(ns, Encoding.UTF8, leaveOpen: true))
                {
                    string response = await reader.ReadLineAsync();
                    resultListBox.Items.Add(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error communicating with server: " + ex.Message);
            }
        }
        protected override void OnClosed(EventArgs e)
        {

            client.Close();
            base.OnClosed(e);
        }
    }
}
