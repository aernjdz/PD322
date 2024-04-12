using Microsoft.Win32;
using PropertyChanged;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace Exam_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                model.SourcePath = dialog.FileName;
                srcTextBox.Text = model.SourcePath;
            }

        }

        private async void Analysis_btn(object sender, RoutedEventArgs e)
        {
            model.SearchWord = srcWord.Text;

            if (string.IsNullOrEmpty(model.SourcePath) || string.IsNullOrEmpty(model.SearchWord))
            {
                MessageBox.Show("Please provide both source path and search word.");
                return;
            }

     ((Button)sender).IsEnabled = false;

            var files = Directory.GetFiles(model.SourcePath, "*.*", SearchOption.AllDirectories)
                                 .Where(s => s.EndsWith(".txt") || s.EndsWith(".doc") || s.EndsWith(".docx"));

            model.TotalFileCount = files.Count();

            double filesProcessed = 0;

            var progress = new Progress<double>(percentage =>
            {
                filesProcessed++;
                model.Percentage = (filesProcessed / model.TotalFileCount) * 100;
            });

            foreach (var file in files)
            {
                var fileName = System.IO.Path.GetFileName(file);
                FileAnalysisResult result = new FileAnalysisResult(fileName);
                model.AddProcess(result);
                await FileAnalysisAsync(file, result, progress);
            }

     ((Button)sender).IsEnabled = true;
        }


       private void SaveResult_btn(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON files (*json)|*.json";
            if (dialog.ShowDialog() == true) 
            {
                string filePath = dialog.FileName;
                string json = JsonConvert.SerializeObject(model.Processes, Formatting.Indented);

                try
                {
                    File.WriteAllText(filePath, json);
                    MessageBox.Show("Analysis results saved successfully to " + filePath, "Save Successful", MessageBoxButton.OK, MessageBoxImage.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving analysis results: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        
        private async Task FileAnalysisAsync(string filePath, FileAnalysisResult info, IProgress<double> progress)
        {
            var stopwatch = Stopwatch.StartNew();

            var content = await File.ReadAllTextAsync(filePath);

            int count = content.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                               .Count(word => word.Equals(model.SearchWord, StringComparison.OrdinalIgnoreCase));

            info.WordsFoundCount = count;
            info.FilePath = filePath;

            stopwatch.Stop();

            double fileSizeInBytes = new FileInfo(filePath).Length;
            double fileSizeInMegaBytes = fileSizeInBytes / (1024 * 1024);
            double processingTimeInSeconds = stopwatch.ElapsedMilliseconds / 1000.0;
            double megaBytesPerSecond = fileSizeInMegaBytes / processingTimeInSeconds;
            Console.WriteLine(megaBytesPerSecond);
            info.MegaBytesPerSeconds = Math.Round(megaBytesPerSecond,2);

            model.TotalTime += (int)stopwatch.ElapsedMilliseconds;
            progress.Report(100);
        }

    }
        [AddINotifyPropertyChangedInterface]
    public class ViewModel 
    {
       
        private ObservableCollection<FileAnalysisResult> processees;
        public string SourcePath { get; set; }
        public string SearchWord { get; set; }
        public int TotalTime {  get; set; }
        public int TotalFileCount {  get; set; }
        public double Percentage { get; set; }
        public int ProgressPercentageInt => (int)Percentage;
            public ViewModel()
        {
            processees = new ObservableCollection<FileAnalysisResult>();
        }
        public IEnumerable<FileAnalysisResult> Processes => processees;

        public void AddProcess(FileAnalysisResult info)
        {
            processees.Add(info);
        }
    }
    
[AddINotifyPropertyChangedInterface]
        public class FileAnalysisResult 
        {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int WordsFoundCount { get; set; }

        public double MegaBytesPerSeconds { get; set; }
       
      

        public FileAnalysisResult(string fileName)
        {
            this.FileName = fileName;
        }
        }

}