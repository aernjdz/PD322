using Homework_07;
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

namespace Homework_07_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShopDb context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ShopDb();
            
        }

        private void ShowShops(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Shops.ToList();
        }
        private void ShowProducts(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Products.ToList();
        }
        private void ShowPositions(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Positions.ToList();
        }
        private void ShowWorkers(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Workers.ToList();
        }
        private void ShowCountries(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Countries.ToList();
        }
        private void ShowCities(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Cities.ToList();
        }
        private void ShowCategories(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Categories.ToList();
        }
    }
}