﻿//Client

using System.Configuration;
using System.Net;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {

        // IPAddress address = Dns.GetHostEntry("localhost").AddressList[1];
        // string address = "127.0.0.1";
        string address = ConfigurationManager.AppSettings["serverAddress"]!;
        short port = short.Parse(ConfigurationManager.AppSettings["serverPort"]!);

        IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(address), port);
        TcpClient client = new TcpClient();

        try
        {
            client.Connect(serverPoint);

            string msg = "";

            while (msg != "end")
            {
                Console.WriteLine("Enter a message :: ");
                msg = Console.ReadLine();

                NetworkStream ns = client.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(msg);
                sw.Flush();

                StreamReader reader = new StreamReader(ns);

                string response = reader.ReadLine();
                Console.WriteLine($"Server  response :: {response}");

             /*   sw.Close();
                reader.Close();
                ns.Close();*/
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally { client.Close(); }
    }
}