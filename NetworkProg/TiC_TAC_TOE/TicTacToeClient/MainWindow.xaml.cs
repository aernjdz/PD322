using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TicTacToeLibrary;

namespace TicTacToeClient {
    public partial class MainWindow : Window {

        private readonly MainWindowsViemModel _viemModel = new MainWindowsViemModel();

        public MainWindow() {
            InitializeComponent();
            DataContext = _viemModel;
            _viemModel.Chat.CollectionChanged += Chat_CollectionChanged;
        }

        private void Click(object sender, RoutedEventArgs e) {
            Cell cell = (sender as Button).DataContext as Cell;
            _viemModel.Move(cell);
        }

        private void Chat_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            Border border = (Border)VisualTreeHelper.GetChild(listBox, 0);
            ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
            scrollViewer.ScrollToBottom();
        }

       
    }
}
