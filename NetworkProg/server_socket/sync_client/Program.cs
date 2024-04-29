using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
	static string address = "127.0.0.1";
	static int port = 8080;
    private static void Main(string[] args)
    {
		try
		{
			IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address),port);
			Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
			string msg = "";
			while (msg != "end")
			{
				Console.Write("Enter a message :: ");
				msg = Console.ReadLine();
				byte[] buffer = Encoding.Unicode.GetBytes(msg);

				socket.SendTo(buffer,ipPoint);
			}
		}
		catch (Exception ex)
		{

			Console.WriteLine(ex.Message);
		}
    } 
}