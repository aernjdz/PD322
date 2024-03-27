using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace Homework_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public ObservableCollection<ProcessInfo> Processes { get; set; }
        public ProcessInfo SelectedProcess { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Processes = new ObservableCollection<ProcessInfo>();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            Processes.Clear();
            foreach (Process process in Process.GetProcesses())
            {
                Processes.Add(new ProcessInfo(process));
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadProcesses();
        }

        private void TaskList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedProcess = ProcessesListBox.SelectedItem as ProcessInfo;
        }

        private void ChangePriority_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedProcess != null && Priorities.SelectedItem != null)
            {
               var priority = (ProcessPriorityClass)Priorities.SelectionBoxItem;
                SelectedProcess.ChangePriority(priority);
            }
        }

        private void KillProcess_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedProcess != null)
            {
                SelectedProcess.Kill();
                LoadProcesses();
            }
        }

        private void IntervalComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (intervalComboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)intervalComboBox.SelectedItem;
                string intervalText = selectedItem.Content.ToString();
                int selectedInterval = int.Parse(intervalText.Split(' ')[0]);
                StartTimer(selectedInterval);
            }
        }

        private void StartTimer(int interval)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (sender, e) => LoadProcesses();
            timer.Interval = TimeSpan.FromSeconds(interval);
            timer.Start();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            // Обработка события Checked чекбокса
        }
        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            // Обработка события Unchecked чекбокса
        }

    }
}
