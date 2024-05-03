using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    static string address = "127.0.0.1";
    static short port = 8080;
    const string path = "D:\\ШАГ\\PD322\\NetworkProg\\Homework_04\\Homework_04\\data.json";
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(address), port);
        TcpListener listener = new TcpListener(EndPoint);

        try
        {
            listener.Start();
            WriteColor("[Server started!! Wait connection]", ConsoleColor.Yellow);
            TcpClient client = listener.AcceptTcpClient();
            while (client.Connected)
            {
                
                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter wr = new StreamWriter(ns);

                string response = sr.ReadLine()!;
                if (response != null)
                {
                    string[] parts = response.Split("=");


                    if (parts.Length > 1)
                    {
                        string opr = parts[0].Trim();
                        string msg = parts[1].Trim();
                        if (opr == "<Code>")
                        {
                            WriteColor($"[{client.Client.RemoteEndPoint}] - {response} at [{DateTime.Now.ToShortTimeString()}]", ConsoleColor.Green);

                            string region = GetRegionByCode(msg);


                            wr.WriteLine(region);
                            wr.Flush();
                            WriteColor($"Sent region to client: [{region}]", ConsoleColor.Cyan);
                        }
                        else if (opr == "<Region>")
                        {
                            WriteColor($"[{client.Client.RemoteEndPoint}] - {response} at [{DateTime.Now.ToShortTimeString()}]", ConsoleColor.Green);

                            string code = GetCodeByRegion(msg);
                            wr.WriteLine(code);
                            wr.Flush();
                            WriteColor($"Sent code to client: [{code}]", ConsoleColor.Cyan);
                        }
                        else
                        {
                            WriteColor($"[{client.Client.RemoteEndPoint}] - {response} at [{DateTime.Now.ToShortTimeString()}]", ConsoleColor.Green);
                        }
                    }
                }
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


        static string GetRegionByCode(string code)
        {
            try
            {
                string json = File.ReadAllText(path);
                JObject jsonObject = JObject.Parse(json);
                JObject codes = (JObject)jsonObject["codes"]!;

                foreach (var region in codes)
                {
                    if (((JArray)region.Value!).Any(c => c.ToString() == code))
                    {
                        return region.Key;
                    }
                }

                return "Невідома область";
            }
            catch (Exception ex)
            {
                WriteColor($"Error: {ex.Message}", ConsoleColor.Red);
                return "Помилка при зчитуванні даних";
            }
        }

        static string GetCodeByRegion(string region)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                string json = File.ReadAllText(path);
                JObject jsonObject = JObject.Parse(json);
                JObject codes = (JObject)jsonObject["codes"]!;

                foreach (var regionPair in codes)
                {
                    if (regionPair.Key == region)
                    {
                        result.Append(string.Join(",", ((JArray)regionPair.Value!).Select(x => x.ToString())));
                    }
                }

                return result.ToString();

            }
            catch (Exception ex)
            {
                WriteColor($"Error: {ex.Message}", ConsoleColor.Red);
                return "Помилка при зчитуванні даних";
            }
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