using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;

namespace Homework_06
{
    public partial class MainWindow : Window
    {
        ViewModel model;

        public MainWindow()
        {
            InitializeComponent();
            model = new ViewModel();
            this.DataContext = model;
        }

        private void OpenSource_btn(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                model.SourcePath = dialog.FileName;
                srcTextBox.Text = model.SourcePath;
            }
        }

        private async void Factorial_btn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(model.SourcePath))
            {
                MessageBox.Show("Please select a valid source folder.");
                return;

            }
            model.ResetProperties();

            try
            {
                string[] lines = await Task.Run(() => File.ReadAllLines(model.SourcePath));

             
                int totalNumbers = 0;
                foreach (string line in lines)
                {
                    totalNumbers += line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                }
                model.TotalNumbers = totalNumbers;

                await Task.Run(() =>
                {
                    foreach (string line in lines)
                    {
                        string[] numbers = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        Parallel.ForEach(numbers, num =>
                        {
                            if (int.TryParse(num, out int number))
                            {
                             
                                long factorial = CalculateFactorial(number);
                             

                                Factorials info = new Factorials(number);
                                info.Factorial = factorial;

                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    model.AddProcess(info);
                                    model.UpdatePercentage();
                                });
                            }
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private long CalculateFactorial(int number)
        {
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class ViewModel 
    {
        private ObservableCollection<Factorials> processes;
        private int totalNumbers = 0;

        public string SourcePath { get; set; }
      
        public double Percentage { get; set; }
        public int ProgressPercentageInt => (int)Percentage;
        public int TotalNumbers
        {
            get { return totalNumbers; }
            set
            {
                totalNumbers = value;

            }
        } 

        public ViewModel()
        {
            processes = new ObservableCollection<Factorials>();
        }

        public void ResetProperties()
        {
         
            Percentage = 0;
            TotalNumbers = 0;
            processes.Clear();
        }
        public IEnumerable<Factorials> Processes => processes;

        public void AddProcess(Factorials info)
        {
            processes.Add(info);
        }

        public void UpdatePercentage()
        {
            if (processes.Count == 0)
            {
                Percentage = 0;
            }
            else
            {     
                Percentage = (double)processes.Count / TotalNumbers * 100;
            }
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class Factorials
    {
        public int Num { get; set; }
        public long Factorial { get; set; }

        public Factorials(int num)
        {
            this.Num = num;
        }
    }
}
