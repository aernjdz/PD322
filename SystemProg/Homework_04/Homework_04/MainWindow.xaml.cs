using System.IO;
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
using Microsoft.Win32;
namespace Homework_04
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

        private async void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string text = inputTextBox.Text;

            Task<string> analysisTask = Task.Run(() => AnalyzeText(text));

            string report = await analysisTask;

            if (showOnScreenRadioButton.IsChecked == true)
            {
                resultTextBox.Text = report;
            }
            else if (saveToFileRadioButton.IsChecked == true)
            {
                SaveReportToFile(report);
                MessageBox.Show("Report saved to file.", "Report Saved");
            }
        }

        private string AnalyzeText(string text)
        {
            int interrogativeSentencesCount = text.Split('?').Length - 1;
            int exclamatorySentencesCount = text.Split('!').Length - 1;

            
            string[] separators = new string[] { ".", "!", "?" };
            string[] sentences = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int sentencesCount = sentences.Length;

            string[] words = text.Split(new char[] { ' ', ',', ':', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsCount = words.Length;
            int charactersCount = text.Count(c => !char.IsWhiteSpace(c));

            string report = $"Number of sentences: {sentencesCount}\n";
            report += $"Number of words: {wordsCount}\n";
            report += $"Number of characters: {charactersCount}\n";
            report += $"Number of interrogative sentences: {interrogativeSentencesCount}\n";
            report += $"Number of exclamatory sentences: {exclamatorySentencesCount}";

            return report;
        }


        private void SaveReportToFile(string report)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, report);
                }
           
        }
    }
}