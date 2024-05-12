using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary {
    public enum Sign { None, Сross, Zero }
    public enum GameStatus { DidNotStart, GameIsOn, CrossVictory, ZeroVictory, Draw }
    public static class Message {
        public const byte Сonnection = 1;
        public const byte GameStatus = 2;
        public const byte WhoseMove = 3;
        public const byte Move = 4;
        public const byte ChatNotice = 5;
        public const byte GameOver = 6;
        public const byte PlayerHasLeftGame = 7;
    }
}
