using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    static string address = "127.0.0.1";
    static int port = 8080; // 1000 .... 600000
    private static void Main(string[] args)
    {
       IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
        EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);

        try
        {
            ListenSocket.Bind(ipPoint);
            while (true)
            {
                int bytes = 0;
                byte[] buffer = new byte[1024];
                bytes = ListenSocket.ReceiveFrom(buffer, ref remoteEndPoint);
                string msg = Encoding.Unicode.GetString(buffer);
                Console.WriteLine($"{DateTime.Now.ToString()} : {msg} from {remoteEndPoint}");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        ListenSocket.Shutdown(SocketShutdown.Both);
        ListenSocket.Close();
    }
}