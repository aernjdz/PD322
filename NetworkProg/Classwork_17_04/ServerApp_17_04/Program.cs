using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

namespace ServerApp_17_04
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            ChatServer server = new ChatServer();
            server.Start();

        }
    }
}