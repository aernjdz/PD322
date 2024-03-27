using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TaskManager
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Priorities.ItemsSource = Enum.GetValues(typeof(ProcessPriorityClass)).Cast<ProcessPriorityClass>();
            Priorities.SelectedIndex = 0;
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;

            if (listBox.SelectedItems.Count > 0)
            {
                var viewModel = (ViewModel)DataContext;
                viewModel.SelectedProcess = ((ProcessListItem)listBox.SelectedItems[0]).Process;
            }
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel)DataContext;
            viewModel.UpdateProcesses(sender, e);
        }

        private void ChangePriority_OnClick(object sender, RoutedEventArgs e)
        {
            var priority = (ProcessPriorityClass)Priorities.SelectionBoxItem;
            var viewModel = (ViewModel)DataContext;
            viewModel.ChangePriority(priority);
        }

        private void KillProcess_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel)DataContext;
            viewModel.KillSelectedProcess();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var processListItem = (ProcessListItem)checkBox.DataContext;
            processListItem.KeepAlive = true;
        }

        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var processListItem = (ProcessListItem)checkBox.DataContext;
            processListItem.KeepAlive = false;
        }

        private void IntervalComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (intervalComboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)intervalComboBox.SelectedItem;
                string intervalText = selectedItem.Content.ToString();
                int selectedInterval = int.Parse(intervalText.Split(' ')[0]);
                var viewModel = (ViewModel)DataContext;
                viewModel.StartTimer(selectedInterval);
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
    }
}
