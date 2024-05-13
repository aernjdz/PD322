using System;
using System.ComponentModel;
using System.Net;
using System.Security.Policy;
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
using System.IO;
using System.Collections.ObjectModel;
using PropertyChanged;
using System.Net.NetworkInformation;

namespace Homework_08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WebClient> webClients;
        ViewModel model;

        public MainWindow()
        {

            InitializeComponent();
            model = new ViewModel();
            this.DataContext = model;
            webClients = new List<WebClient>();
          
        }
        private void OpenSource_btn(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                Title = "Select Source Folder",
                IsFolderPicker = true,
                Multiselect = false
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                string selectedPath = dialog.FileName;

                srcPath.Text = selectedPath;
            }
        }

        private async void Download_btn(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(srcURL.Text) && !string.IsNullOrWhiteSpace(srcPath.Text))
            {
                try
                {
                    string url = srcURL.Text;
                    Uri downloadUri = new Uri(url);


                    string fileName = System.IO.Path.GetFileName(url);
                    model.Url = url;
                    DownloaderResult res = new DownloaderResult(fileName);
                    model.AddProcess(res);






                    using (WebClient webClient = new WebClient())
                    {
                       
                               
                                webClient.DownloadProgressChanged += (sender, e) => WebClient_DownloadProgressChanged(sender, e, ref res);
                                webClient.DownloadFileCompleted += (sender, e) => WebClient_DownloadFileCompleted(sender, e, ref res);
                                webClients.Add(webClient);

                                await webClient.DownloadFileTaskAsync(downloadUri, System.IO.Path.Combine(srcPath.Text, fileName));
                            
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid URL and select a download path.", "Download Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


       


        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e, ref DownloaderResult r)
        {



            model.FileSize = (float)Math.Round((float)e.TotalBytesToReceive / 1024 / 1024, 2);

            double bytesIn = e.BytesReceived;
            double totalBytes = e.TotalBytesToReceive;
            double speed = (bytesIn / 1024 / 1024) / (DateTime.Now - r.StartTime).TotalSeconds;
            speed = Math.Round(speed, 2);

            r.Speed = speed;
            r.Status = $"Downloading .... {Math.Round((float)e.BytesReceived / 1024 / 1024, 2)} MB of {Math.Round((float)e.TotalBytesToReceive / 1024 / 1024, 2)} MB";
            r.FileSize = (float)Math.Round((float)e.TotalBytesToReceive / 1024 / 1024, 2);
            r.ProgressInt = e.ProgressPercentage;

        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e, ref DownloaderResult r)


        {
            if (e.Cancelled)
            {
                r.Status = "Cancelled";
            }

            else if (e.Error != null)
            {
                r.Status = "Download Error";
                MessageBox.Show($"Download failed: {e.Error.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            else
            {
                r.Status = "Download Complete";
                MessageBox.Show("Download completed successfully.", "Download Complete", MessageBoxButton.OK, MessageBoxImage.Information);



            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            foreach (var client in webClients)
            {
                client.Dispose();
            }
        }

      

    }
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ObservableCollection<DownloaderResult> processees;
        public string FileName { get; set; }
        public string Url { get; set; }
        public int ProgressInt { get; set; }
        public float FileSize { get; set; }
        public double Progress { get; set; }
        public bool IsWaiting => Progress == 0;
        public  ViewModel()
        {
           
        processees = new ObservableCollection<DownloaderResult>();
         
        }

        public IEnumerable<DownloaderResult> Processes => processees;

        public void AddProcess(DownloaderResult info)
        {
            processees.Add(info);
        }
       
    }
    [AddINotifyPropertyChangedInterface]
    public class DownloaderResult
    {
        public string FileName { get; set; }
        public string Status { get; set; } = "Wait...";
        public float FileSize { get; set; }
        public int ProgressInt { get; set; }
        public double Speed { get; set; }
        public DateTime StartTime { get; set; }
    
        public DownloaderResult(string name)
        {
            this.FileName = name;
            StartTime = DateTime.Now;
        }


    }
}