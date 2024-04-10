using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;

namespace Homework_03
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private FileAnalysisResult _analysisResult;
        public FileAnalysisResult AnalysisResult
        {
            get
            {
                lock (syncObject)
                {
                    return _analysisResult;
                }
            }
            set
            {
                lock (syncObject)
                {
                    _analysisResult = value;
                }
                OnPropertyChanged("AnalysisResult");
            }
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                lock (syncObject)
                {
                    _progress = value;
                }
                OnPropertyChanged("Progress");
            }
        }

        private readonly object syncObject = new object();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OpenSource_btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                srcTextBox.Text = openFileDialog.FileName;
            }
        }

        private void Analisis_btn(object sender, RoutedEventArgs e)
        {
            string filePath = srcTextBox.Text;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist.");
                return;
            }

            Thread thread = new Thread(() =>
            {
                FileAnalysisResult result = AnalyzeFile(filePath);
                Application.Current.Dispatcher.Invoke(() => { AnalysisResult = result; });
            });
            thread.Start();
        }

        private FileAnalysisResult AnalyzeFile(string filePath)
        {
            FileAnalysisResult result = new FileAnalysisResult();
            string text = File.ReadAllText(filePath);
            int totalChars = text.Length;
            int processedChars = 0;

            result.FileName = Path.GetFileName(filePath);
            result.FileSize = new FileInfo(filePath).Length;
            result.WordsCount = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            result.LinesCount = text.Split('\n').Length;
            result.PunctuationsCount = CountPunctuation(text);

            foreach (char c in text)
            {
                processedChars++;
                Progress = (int)((double)processedChars / totalChars * 100);
                Thread.Sleep(5);
            }

            return result;
        }

        private int CountPunctuation(string text)
        {
            int count = 0;
            char[] punctuation = { '.', ',', ';', ':', '-', '—', '–', '…', '!', '?', '"', '\'', '«', '»', '(', ')', '{', '}', '[', ']', '<', '>', '/' };

            foreach (char c in text)
            {
                if (Array.IndexOf(punctuation, c) != -1)
                {
                    count++;
                }
            }

            return count;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class FileAnalysisResult
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public int WordsCount { get; set; }
        public int LinesCount { get; set; }
        public int PunctuationsCount { get; set; }
    }
}
