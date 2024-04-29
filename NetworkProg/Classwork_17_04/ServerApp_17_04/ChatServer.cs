using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp_17_04
{
    internal class ChatServer
    {
        private const short port = 4040;
        private const string JOIN = "$<Join>";
        public UdpClient server {  get; set; }
        public IPEndPoint clientEndPoint = null;
        public List<IPEndPoint> members;

        public ChatServer()
        {
            server = new UdpClient(port);
            members = new List<IPEndPoint>();
        }

        public void Start()
        {
            while (true)
            {
                byte[] data = server.Receive(ref clientEndPoint);
                string msg = Encoding.Unicode.GetString(data);


                switch (msg)
                {
                    case JOIN:
                        AddMembers(clientEndPoint);
                        break;
                    default:
                        Console.WriteLine($"Got message  {msg,-20} from : {clientEndPoint} at {DateTime.Now.ToShortTimeString()}");
                        SendToAll(data);
                        break;
                }

            }
        }
        public void AddMembers(IPEndPoint clientEndPoint)
        {
            members.Add(clientEndPoint);
            Console.WriteLine("Member was added!");
        }
        public async void SendToAll(byte[] data)
        {
            foreach (var member in members)
            {
                await server.SendAsync(data, data.Length, member);
            }
        }
    }
}
