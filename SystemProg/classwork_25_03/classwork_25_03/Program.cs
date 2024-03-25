
using System.Diagnostics;
using System.Net.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        /*  Process current = Process.GetCurrentProcess();
          current.PriorityClass = ProcessPriorityClass.High;
          Console.WriteLine("-------Current Process info------");
          Console.WriteLine($"PriorityClass :: {current.BasePriority}");
          Console.WriteLine($"ProcessName :: {current.ProcessName}");
          Console.WriteLine($"Id :: {current.Id}");
          Console.WriteLine($"MachineName :: {current.MachineName}");
          Console.WriteLine($"StartTime :: {current.StartTime}");
          Console.WriteLine($"TotalProcessorTime :: {current.TotalProcessorTime}");
          Console.WriteLine($"--------------------------------");
          Console.ReadKey();*/

        /*  Process[] processes = Process.GetProcesses();
          foreach (Process p in processes)
          {
              try
              {
                  Console.WriteLine($"{p.ProcessName,-40} {p.Id,-10} {p.PriorityClass , -20} {p.StartTime}");
              }catch (Exception ex)
              {
                 Console.ForegroundColor = ConsoleColor.Red;
                  Console.WriteLine($"Error with {p.ProcessName,-30} : {ex.Message}");

                  Console.ResetColor();

              }
          }
          Console.ReadKey();*/

        /* Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe", "google.com");*/

       

    }
}