using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_17_04
{
    internal class Configurator
    {
        public string serverAddress;
        public short serverPort;
        public IPEndPoint serverPoint;
        public UdpClient client;
        public ObservableCollection<MessageInfo> messages;

        public Configurator()
        {
            messages = new ObservableCollection<MessageInfo>();
            serverAddress = ConfigurationManager.AppSettings["serverAddress"];
            serverPort = short.Parse(ConfigurationManager.AppSettings["serverPort"]);
        }
    }
}
