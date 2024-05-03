
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using MessageLiblary;
using System.Text.RegularExpressions;
internal class Program
{
    private const int maximumClients = 10;

    private const int port = 8080;

    private static UdpClient server = new UdpClient(port);

    private static Dictionary<IPEndPoint, string> members = new Dictionary<IPEndPoint, string>();

    private static async void SendFromUser(Message message)
    {
        string messageJson = JsonSerializer.Serialize(message);
        byte[] data = Encoding.UTF8.GetBytes(messageJson);

        foreach (IPEndPoint ip in members.Keys)
            if (ip.Port != message.FromPort && ip.Address != IPAddress.Parse(message.FromAddress!))
                await server.SendAsync(data, ip);
    }

    private static async void SendToUser(Message message)
    {
        string messageJson = JsonSerializer.Serialize(message);
        byte[] data = Encoding.UTF8.GetBytes(messageJson);

        IPEndPoint to = new IPEndPoint(IPAddress.Parse(message.ToAddress!), message.ToPort
            ?? throw new ArgumentNullException());
        await server.SendAsync(data, to);
    }

    static void Main(string[] args)
    {
        while (true)
        {
            IPEndPoint? clientIp = null;

            byte[] data = server.Receive(ref clientIp);
            string messageJson = Encoding.UTF8.GetString(data);
            Message message = JsonSerializer.Deserialize<Message>(messageJson)!;

            if (!string.IsNullOrWhiteSpace(message.Text))
                WriteColor($"[{DateTime.Now.ToShortTimeString()}] - [{message.Text}] | from [{clientIp}]",ConsoleColor.Cyan);
            else
                WriteColor($"[{DateTime.Now.ToShortTimeString()}] - [{message.Command}] | from [{clientIp}]",ConsoleColor.Cyan);

            if (message.Command == Message.JOIN_CMD && !members.ContainsKey(clientIp))
            {
                if (members.Count < maximumClients)
                {
                    Message response = new Message
                    {
                        SenderName = "<server>",
                        Text = $"{message.SenderName} joined",
                        FromAddress = clientIp.Address.ToString(),
                        FromPort = message.FromPort
                    };
                    SendFromUser(response);

                    members.Add(clientIp, message.SenderName);
                    WriteColor($"[{DateTime.Now.ToShortTimeString()}] - [{message.SenderName}] joined",ConsoleColor.Green);
                }
                else
                {
                    Message response = new Message
                    {
                        SenderName = "<server>",
                        Text = "Server is full, you cannot join",
                        ToAddress = clientIp.Address.ToString(),
                        ToPort = message.ToPort
                    };
                    SendToUser(response);

                    WriteColor($"[{DateTime.Now.ToShortTimeString()}] - [{message.SenderName}] cannot join, server is full", ConsoleColor.Yellow);
                }
            }
            else if (message.Command == Message.LEAVE_CMD && members.ContainsKey(clientIp))
            {
                Message response = new Message
                {
                    SenderName = "<server>",
                    Text = $"{message.SenderName} left",
                    FromAddress = clientIp.Address.ToString(),
                    FromPort = clientIp.Port
                };
                SendFromUser(response);

                members.Remove(clientIp);
                WriteColor($"[{DateTime.Now.ToShortTimeString()}] - [{message.SenderName}] left",ConsoleColor.Red);
            }
            else if (!members.ContainsKey(clientIp))
            {
                Message response = new Message
                {
                    SenderName = "<server>",
                    Text = "You cannot send messages unless you are registered",
                    ToAddress = clientIp.Address.ToString(),
                    ToPort = clientIp.Port
                };
                SendToUser(response);
            }
            else if (message.ReplyToMessage == null)
            {
                Message response = new Message
                {
                    SenderName = message.SenderName,
                    Text = message.Text,
                    FromAddress = clientIp.Address.ToString(),
                    FromPort = clientIp.Port
                };
                SendFromUser(response);
            }
            else
            {
                Message response = new Message
                {
                    SenderName = message.SenderName,
                    Text = message.Text,
                    FromAddress = clientIp.Address.ToString(),
                    FromPort = clientIp.Port,
                    ToAddress = message.ToAddress?.ToString(),
                    ToPort = message.ToPort,
                    ReplyToMessage = message.ReplyToMessage
                };
                SendToUser(response);
            }
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
