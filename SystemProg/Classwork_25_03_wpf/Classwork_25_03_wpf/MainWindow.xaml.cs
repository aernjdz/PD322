using System.Diagnostics;
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

namespace Classwork_25_03_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      private void LaunchProgram(object sender, RoutedEventArgs e)
        {
            Button btn =sender as Button;
            if (btn != null )
            {
                string cmd = btn.Tag.ToString();
                Launch(cmd);
            }
        }

        private void Launch(string programName)
        {
            try
            {
                Process.Start(programName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching {programName}: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LaunchCustomProgram(object sender, RoutedEventArgs e)
        {
            string customProgramPath = CustomProgramPathTextBox.Text;
            if (!string.IsNullOrWhiteSpace(customProgramPath))
            {
                Launch(customProgramPath);
            }
            else
            {
                MessageBox.Show("Please specify the path of the custom program.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /*        private void Refresh(object sender, RoutedEventArgs e)
                {
                    grid.ItemsSource = Process.GetProcesses();

                }*/
    }
}