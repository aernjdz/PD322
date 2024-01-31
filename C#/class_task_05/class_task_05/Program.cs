using System;

namespace class_task_05
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CmdLine cmdLine = new CmdLine();
           
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("> ");
                string command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    break; 
                }

                cmdLine.ExecuteCommand(command);
            }
        }
    }
}
