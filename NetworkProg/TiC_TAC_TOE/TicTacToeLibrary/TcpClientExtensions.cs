using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary {
    public static class TcpClientExtensions {
        
        public static async Task<byte[]> ReadFromStream(this TcpClient client, int length) {
            byte[] buffer = new byte[length];
            int current = 0;
            while (current < length) {
                int read = await client.GetStream().ReadAsync(buffer, current, length - current);
                current += read;
            }
            return buffer;
        }
    }
}
