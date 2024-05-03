using System;
using System.IO;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        string serverAddress = "127.0.0.1";
        int serverPort = 8080;

        try
        {
            TcpClient client = new TcpClient(serverAddress, serverPort);
            Console.WriteLine("Connected to server...");

            // Sending a test message to the server
            string message = "<Code>=AA"; // Example license plate code
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(message);
            writer.Flush();
            Console.WriteLine($"Sent message to server: {message}");

            // Receiving response from the server
            StreamReader reader = new StreamReader(stream);
            string response = reader.ReadLine();
            Console.WriteLine($"Received response from server: {response}");


            string msg = "<Region>=Рівненська"; // Example license plate code
          
            writer.WriteLine(msg);
            writer.Flush();
            Console.WriteLine($"Sent message to server: {msg}");

            // Receiving response from the server
            
            string resp = reader.ReadLine();
            Console.WriteLine($"Received response from server: {resp}");
            // Closing connection
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
