using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Classwork_22_04_task
{
    class Client
    {
        static void Main(string[] args)
        {

            string serverAddress = ConfigurationManager.AppSettings["serverAddress"]!;

            short port = short.Parse(ConfigurationManager.AppSettings["serverPort"]!);

          
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(serverAddress), port);
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(serverPoint);

                Console.WriteLine("Connected to server.");

                string msg = "";

                while (msg != "end")
                {
                    Console.Write("Enter car code: ");
                    msg = Console.ReadLine();
                    NetworkStream ns = client.GetStream();
                    StreamWriter writer = new StreamWriter(ns);
                    writer.Write(msg);

                    StreamReader reader = new StreamReader(ns);

                    string responseData = reader.ReadLine();
                    Console.WriteLine($"Server response: {responseData}");

                }
          
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
