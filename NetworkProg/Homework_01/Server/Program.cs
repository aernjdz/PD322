using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Server
{
    internal class Program
    {
        static string address = "127.0.0.1";
        static short port = 8080;
        static string conn = ConfigurationManager.ConnectionStrings["zipDB"].ConnectionString;

        static IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
        static EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        static void Main(string[] args)
        {
            SqlConnection connect = new SqlConnection(conn);



            Socket Listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                Listener.Bind(ipPoint);
                while (true)
                {
                    int bytes = 0;
                    byte[] buffer = new byte[1024];
                    bytes = Listener.ReceiveFrom(buffer, ref remoteEndPoint);

                    string msg = Encoding.Unicode.GetString(buffer, 0, bytes);
                    List<string> info = GetInfo(msg, connect);

                    byte[] response = Encoding.Unicode.GetBytes(string.Join(Environment.NewLine, info));



                    WriteColor($"[{DateTime.Now.ToLongTimeString()}] : {msg} from [{remoteEndPoint}]", ConsoleColor.Green);
                    if (info.Count != 0)
                    {
                        WriteColor($"[{DateTime.Now.ToLongTimeString()}] : Result send to [{remoteEndPoint}]", ConsoleColor.Yellow);
                        Listener.SendTo(response, remoteEndPoint);
                    }
                    else
                    {
                        byte[] error = Encoding.Unicode.GetBytes("Result not found!");
                        Listener.SendTo(error, remoteEndPoint);
                        WriteColor($"[{DateTime.Now.ToLongTimeString()}] : Result not found! [{msg}]", ConsoleColor.DarkRed);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Listener.Shutdown(SocketShutdown.Both);
            Listener.Close();


        }
            static List<string> GetInfo(string zipcode, SqlConnection connection)
            {
                List<string> infoList = new List<string>();
                string query = "SELECT * FROM houses WHERE zip = @ZipCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ZipCode", zipcode);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string region = reader["region"].ToString();
                            string district = reader["district"].ToString();
                            string street = reader["street"].ToString();
                            infoList.Add($"Region: {region}, District: {district}, Street: {street}");
                        }
                    }
                    connection.Close();
                }


                return infoList;
            }
        
        static void WriteColor(string message, ConsoleColor color)
        {
            var pieces = Regex.Split(message, @"(\[[^\]]*\])");

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                if (piece.StartsWith("[") && piece.EndsWith("]"))
                {
                    Console.ForegroundColor = color;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);
                Console.ResetColor();
            }

            Console.WriteLine();
        }

    }
}
