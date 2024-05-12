using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TicTacToeLibrary;

namespace TicTacToeClient {
    class EnumToStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return null;
            if (!(value is Sign || value is GameStatus)) {
                if (!(value is Sign))
                    throw new ArgumentException($"The original value must be of type Sign");
                else
                    throw new ArgumentException($"The original value must be of type GameStatus");
            }
            if (targetType != typeof(string))
                throw new InvalidCastException();

            if (value is Sign) {
                Sign sign = (Sign)value;
                if (sign == Sign.Сross) return "Crosses";
                else if (sign == Sign.Zero) return "Zerro";
                else return "";
            }
            else {
                GameStatus gameStatus = (GameStatus)value;
                if (gameStatus == GameStatus.GameIsOn) return "The game is on";
                else if(gameStatus == GameStatus.CrossVictory) return "The game ended with the victory of the crosses";
                else if(gameStatus == GameStatus.ZeroVictory) return "The game ended with the zeroes winning";
                else if(gameStatus == GameStatus.Draw) return "The game ended in a draw";
                else return "The game hasn't started yet";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
