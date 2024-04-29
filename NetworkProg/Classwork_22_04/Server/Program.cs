using System.Net;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

        TcpListener listener = new TcpListener(ipPoint);

		try
		{
			listener.Start();

			Console.WriteLine("Server started!\nWait Connection");

			TcpClient client = listener.AcceptTcpClient();
           

            while (client.Connected)
			{
                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);
                string msg = sr.ReadLine();
				Console.WriteLine($"{client.Client.RemoteEndPoint} - {msg} at {DateTime.Now.ToShortTimeString()}");

				StreamWriter writer = new StreamWriter(ns);
				string msg_ = "Message was send!";

				writer.WriteLine(msg_);
				writer.Flush();
				
			}
			

		}
		catch (Exception ex)
		{

			Console.WriteLine(ex.Message);
		}
		finally
		{
           
            listener.Stop();
		}
    }
}