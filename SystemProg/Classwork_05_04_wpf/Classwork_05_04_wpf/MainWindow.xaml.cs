using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Data;
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


namespace Classwork_05_04_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        
        public float Progress { get; set; }
        public MainWindow()
        {
            InitializeComponent();
          /*  Source = "D:\\Downloads\\ua.m3u";
            Destination = "D:\\Downloads\\Telegram Desktop";*/
               
            srcTextBox.Text = Source;
            destTextBox.Text = Destination;
        }

        private void OpenSource_btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                Source = dialog.FileName;
                srcTextBox.Text = Source;   
            }
        }

        private void OpenDest_btn(object sender, RoutedEventArgs e)
        {
           CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Destination = dialog.FileName;
                destTextBox.Text = Destination;
            }
            
        }

        private async void Copy_btn(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(Source);
            /*FileStream srcStream = new FileStream(Source,FileMode.Open, FileAccess.Read);
            FileStream destStream = new FileStream(destPath,FileMode.Create, FileAccess.Write);

            byte[] bytes = new byte[1024*8];
            int bits = 0;
            do
            {
                srcStream.Read(bytes, 0, bits);
                destStream.Write(bytes, 0, bits);
            }
            while (bits > 0);

            srcStream.Close();
            destStream.Close();

            MessageBox.Show(destPath);

            File.Copy(Source,destPath,true);*/

            /* using (FileStream srcStream = new FileStream(Source, FileMode.Open, FileAccess.Read))
             {
                 using (FileStream destSteam = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                 {
                     byte[] bytes = new byte[1024 * 8];
                     int bits = 0;
                     do
                     {
                         bits = srcStream.Read(bytes, 0, bytes.Length);
                         destSteam.Write(bytes, 0, bits);
                         float res = srcStream.Length / destSteam.Length * 100;
                         percent.Value = res;
                     } while (bits > 0);
                 }
             }*/

            if (string.IsNullOrWhiteSpace(Source) || string.IsNullOrWhiteSpace(Destination))
            {
                MessageBox.Show("Please select source and destination paths.");
                return;
            }

            int copiesCount;

            if (!int.TryParse(copies_count.Text, out copiesCount) || copiesCount <= 0)
            {
                MessageBox.Show("Please enter a valid copies count.");
                return;
            }
            await CopyFilesAsync(Source, Destination ,fileName,copiesCount);
           MessageBox.Show("Copying completed.");
        }


        private async Task CopyFilesAsync(string src, string dest, string fileName, int copiesCount)
        {

       
            for (int i = 0; i < copiesCount; i++)
            {
               
                string destPath = System.IO.Path.Combine(dest, $"{fileName}_{i}{System.IO.Path.GetExtension(src)}");

                await CopyFileAsync(src, destPath);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    float progress = ((float)(i + 1) / copiesCount) * 100;
                    percent.Value = progress;
                });
            }
        }
        private async Task CopyFileAsync(string src, string dest)
        {
            await Task.Run(() =>
            {
                using (FileStream srcStream = new FileStream(src, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024 * 8];
                        int bytesRead;
                        while ((bytesRead = srcStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            });
          
     /*       return Task.Run(() =>
            {
                using (FileStream srcStream = new FileStream(src, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024 * 8];
                        int bits = 0;
                        do
                        {
                            bits = srcStream.Read(buffer, 0, buffer.Length);
                          
                            destStream.Write(buffer, 0, bits);
                            Application.Current.Dispatcher.Invoke(()=>{
                                float res = srcStream.Length / destStream.Length * 100;
                                percent.Value = res;
                            });
                        } while (bits > 0);
                    }
                }
            });*/
        }
    }
}