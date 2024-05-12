using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibrary;

namespace TicTacToeServer {
    class SendMessageClient{

        public static async Task SendСonnectionMessage(TcpClient client, Sign sign) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.Сonnection);
            writer.Write((byte)sign);
            byte[] buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendGameStatusMessage(TcpClient client, GameStatus gameStatus) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.GameStatus);
            writer.Write((byte)gameStatus);
            byte[] buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendWhoseMoveMessage(TcpClient client, Sign currentMove) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.WhoseMove);
            writer.Write((byte)currentMove);
            byte[] buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendMoveMessage(TcpClient client, Cell cell) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.Move);
            writer.Write(cell.CellToByteArray());
            byte[] buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendChatNoticeMessage(TcpClient client, byte[] buffer) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.ChatNotice);
            writer.Write(buffer.Length);
            writer.Write(buffer);
            buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendGameOverMessage(TcpClient client, string textMessage) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.GameOver);
            byte[] buffer = Encoding.UTF8.GetBytes(textMessage);
            writer.Write(buffer.Length);
            writer.Write(buffer);
            buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendPlayerHasLeftGameMessage(TcpClient client) {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Message.PlayerHasLeftGame);
            byte[] buffer = Encoding.UTF8.GetBytes("Lost connection with another player!\n\rGame session will be interrupted.");
            writer.Write(buffer.Length);
            writer.Write(buffer);
            buffer = stream.ToArray();

            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
