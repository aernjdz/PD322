using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary {
    

    public class Cell : INotifyPropertyChanged {
        private Sign _sign;
        private bool _isCanSelect = true;

        public event PropertyChangedEventHandler PropertyChanged;
        public int X { get; }
        public int Y { get; }
        public int Index { get; }

        public Cell(int pointX, int pointY, int index) {
            X = pointX;
            Y = pointY;
            Index = index;
        }
        
        public Sign Sign {
            get => _sign;
            set {
                if (_sign == value) return;
                _sign = value;
                _isCanSelect = false;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sign)));
            }
        }

        public bool IsCanSelected {
            get => _isCanSelect;
            set {
                if (_isCanSelect == value) return;
                _isCanSelect = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCanSelected)));
            }
        }

        public byte[] CellToByteArray() {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write((byte)_sign);
            writer.Write(_isCanSelect);

            writer.Write(X);
            writer.Write(Y);
            writer.Write(Index);
            return stream.ToArray();
        }
    }
}
