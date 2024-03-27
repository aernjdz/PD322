using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01
{
    public class ProcessInfo
    {
        public int Id { get; private set; }
        public string ProcessName { get; private set; }
        public Process Process { get; private set; }

        public ProcessInfo(Process process)
        {
            Id = process.Id;
            ProcessName = process.ProcessName;
            Process = process;
        }

        public void ChangePriority(ProcessPriorityClass priority)
        {
            Process.PriorityClass = priority;
        }

        public void Kill()
        {
            Process.Kill();
        }
    }
}
