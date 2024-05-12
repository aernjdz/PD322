using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TicTacToeLibrary;

namespace TicTacToeClient {
    class SignToCharConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return null;
            if (!(value is Sign))
                throw new ArgumentException($"The original value must be of type {nameof(Sign)}");
            if (targetType != typeof(string))
                throw new InvalidCastException();

            Sign sign = (Sign)value;
            if (sign == Sign.Сross) 
                return "X";
            else if (sign == Sign.Zero) 
                return "0";
            else 
                return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
