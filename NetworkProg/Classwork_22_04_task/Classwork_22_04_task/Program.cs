

namespace Classwork_22_04_task
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();
        }
    }
}