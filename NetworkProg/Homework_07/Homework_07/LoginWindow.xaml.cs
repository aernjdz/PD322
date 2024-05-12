
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
using Homework_07.paterns;
using Homework_07.Models;
namespace Homework_07
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginViewModel LoginViewModel = new LoginViewModel();

        public LoginWindow()
        {
            InitializeComponent();

            DataContext = LoginViewModel;
            LoginViewModel.RequestClose += (s, e) =>
                Application.Current.Dispatcher.Invoke(Close);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel.Password = (sender as PasswordBox)?.Password ?? string.Empty;
        }
    }
}

