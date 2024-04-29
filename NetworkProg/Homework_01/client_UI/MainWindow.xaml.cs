using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace client_UI
{
    public partial class MainWindow : Window
    {
        private string serverAddress = "127.0.0.1"; // Server IP address
        private int serverPort = 8080; // Server port

        private UdpClient client; // UDP client instance

        public MainWindow()
        {
            InitializeComponent();
            client = new UdpClient();
        }

        private async void Factorial_btn(object sender, RoutedEventArgs e)
        {
            string zipcode = srcTextBox.Text;

            if (string.IsNullOrWhiteSpace(zipcode) || !int.TryParse(zipcode, out _)) return;

            List<string> infoList = await GetInfoAsync(zipcode);

            resultListBox.Items.Clear();

            foreach (string info in infoList)
            {
                resultListBox.Items.Add(info);
            }
        }

   
        private async Task<List<string>> GetInfoAsync(string zipcode)
        {
            List<string> infoList = new List<string>();

            try
            {
             
                byte[] sendData = Encoding.Unicode.GetBytes(zipcode);

                await client.SendAsync(sendData, sendData.Length, serverAddress, serverPort);

            
                UdpReceiveResult receiveResult = await client.ReceiveAsync();
                string response = Encoding.Unicode.GetString(receiveResult.Buffer);

                string[] lines = response.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

           
                infoList.AddRange(lines);
            }
            catch (Exception ex)
            {
        
                MessageBox.Show($"Error: {ex.Message}");
            }

            return infoList;
        }

        protected override void OnClosed(EventArgs e)
        {

            client.Close();
            base.OnClosed(e);
        }
    }
}
