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

namespace TicTacToeClient {
   
    public partial class ConnectionWindow : Window {
        public string PlayerName { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public ConnectionWindow() {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        private void okButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(playerNameTextBox.Text)) {
                MessageBox.Show(
                    "Enter your name!",
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            if (string.IsNullOrEmpty(ipAddressTextBox.Text)) {
                MessageBox.Show(
                    "Enter the server IP address!",
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            if (string.IsNullOrEmpty(ipAddressTextBox.Text)) {
                MessageBox.Show(
                    "Enter server port!",
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            PlayerName = playerNameTextBox.Text;
            IpAddress = ipAddressTextBox.Text;
            try {
                Port = int.Parse(portTextBox.Text);
            }
            catch (FormatException) {

                MessageBox.Show(
                    "The port number can only consist of numbers!",
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            DialogResult = true;
        }
    
    }
}
