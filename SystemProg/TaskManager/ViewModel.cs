using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using TaskManager.Annotations;

namespace TaskManager
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            StartTimer(2);
        }
        
        private Process _selectedProcess;
        public Process SelectedProcess
        {
            get => _selectedProcess;
            set
            {
                _selectedProcess = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProcessListItem> Processes { get; } = new ObservableCollection<ProcessListItem>();

        public void UpdateProcesses(object sender, EventArgs e)
        {
            var currentIds = Processes.Select(p => p.Id).ToList();

            foreach (var p in Process.GetProcesses())
            {
                if (!currentIds.Remove(p.Id))
                {
                    Processes.Add(new ProcessListItem(p));
                }
            }

            foreach (var id in currentIds) 
            {
                var process = Processes.First(p => p.Id == id);
                if (process.KeepAlive)
                {
                    Process.Start(process.ProcessName, process.Arguments);
                }
                Processes.Remove(process);
            }
        }

        public void ChangePriority(ProcessPriorityClass priority)
        {
            SelectedProcess.PriorityClass = priority;
        }

        public void KillSelectedProcess()
        {
            SelectedProcess.Kill();
        }

        public void StartTimer(int interval)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (sender, e) => UpdateProcesses(sender, e);
            timer.Interval = TimeSpan.FromSeconds(interval);
            timer.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
