
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace Classwork_22_04_task
{
    internal class Server
    {

        TcpListener listener;
        IPEndPoint iPEndPoint;
        private string connectionString;
        public Server()
        {
           iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
           listener = new TcpListener(iPEndPoint);

        }

        public void Start()
        {
            try
            {
               
                listener.Start();
                Console.WriteLine("Server started!\nWaiting for connections...");
                TcpClient client = listener.AcceptTcpClient();

                while (client.Connected)
                {
                    HandleClient(client);
                }

                    Console.WriteLine("Client connected!");
                  
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void HandleClient( TcpClient client)
        {
            try
            {
                using (NetworkStream ns = client.GetStream())
                using (StreamReader reader = new StreamReader(ns))
                using (StreamWriter writer = new StreamWriter(ns))
                {
                    string requestData = reader.ReadLine();

                    Console.WriteLine($"Received request: {requestData}");

                    string response = ProcessRequest(requestData);
                    Console.WriteLine($"Response sent: {response}");
                    writer.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private string ProcessRequest(string requestData)
        {

            connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            string response = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT region FROM CarRegions WHERE code = '{requestData}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    object result = command.ExecuteScalar();
                    response = result != null ? result.ToString() : "Region not found.";
                }
            }
            catch (Exception ex)
            {
                response = $"Error processing request: {ex.Message}";
            }

            return response;
        }
    }
}
