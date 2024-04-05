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
using System.Linq;

namespace Classwork_03_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ShowRandomNumber(object sender, RoutedEventArgs e)
        {
            /*  int value = GenerateValue();
              List.Items.Add(value);*/

            /*  Task<int> task = Task.Run(GenerateValue);
              int value = await task; 

              List.Items.Add(value);*/
            int value;
            if (int.TryParse(number.Text, out value))
            {
               // List.Items.Add(await GenerateValueAsync(value));
                List.Items.Add(await CalculateFactorialAsync(value));
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /* int GenerateValue() 
         { 
          Thread.Sleep(rnd.Next(10000));
             return rnd.Next(1000);
         }*/
        Task<int> GenerateValueAsync(int value)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(10000));
                return rnd.Next(value);
            });

        }
        async Task<long> CalculateFactorialAsync(int n)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(10000));
                return Enumerable.Range(2, n - 1).Aggregate(1L, (acc, x) => acc * x);

            });
        }
    }
}