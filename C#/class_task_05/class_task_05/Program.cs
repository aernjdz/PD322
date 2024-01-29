using System;

namespace class_task_05
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CmdLine cmdLine = new CmdLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (true)
            {
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
