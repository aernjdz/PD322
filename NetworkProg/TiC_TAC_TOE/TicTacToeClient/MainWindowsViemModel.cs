using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToeLibrary;

namespace TicTacToeClient {
    class MainWindowsViemModel : INotifyPropertyChanged {
        private TcpClient _server;
        private string _ipAddress;
        private int _port;
        private string _name;
        private Sign _sign;
        private Sign _currentMove;
        private GameStatus _gameStatus;
        private string _chatMessage;

        public Field Field { get; }
        public ObservableCollection<string> Chat { get; }


        public event PropertyChangedEventHandler PropertyChanged;
        public string Name {
            get => _name;
            set {
                if (_name == value) return;
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public Sign Sign {
            get => _sign;
            set {
                if (_sign == value) return;
                _sign = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sign)));
            }
        }
        public Sign CurrentMove {
            get => _currentMove;
            set {
                if (_currentMove == value) return;
                _currentMove = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentMove)));
            }
        }
        public GameStatus GameStatus {
            get => _gameStatus;
            set {
                if (_gameStatus == value) return;
                _gameStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GameStatus)));
            }
        }
        public string ChatMessage {
            get => _chatMessage;
            set {
                if (_chatMessage == value) return;
                _chatMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChatMessage)));
            }
        }
        

        public DelegateCommand WindowLoadedCommand { get; }
        public DelegateCommand SendToChatCommand { get; }

        public MainWindowsViemModel() {

            _currentMove = Sign.None;
            _gameStatus = GameStatus.DidNotStart;
            Field = new Field(5,5);
            Chat = new ObservableCollection<string>();
            WindowLoadedCommand = new DelegateCommand(WindowLoaded);
            SendToChatCommand = new DelegateCommand(async () => await SendToChat());
        }

        public async void WindowLoaded() {
            while (true) {
                ConnectionWindow dialog = new ConnectionWindow();
                if (dialog.ShowDialog() == true) {
                    Name = dialog.PlayerName;
                    _ipAddress = dialog.IpAddress;
                    _port = dialog.Port;
                }
                else {
                    Application.Current.MainWindow.Close();
                    return;
                }

                try {
                    _server = new TcpClient(_ipAddress, _port);
                    break;
                }
                catch (SocketException ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            await SendMessageServer.SendСonnectionMessage(_server);
            ListenToServer();
        }

        private async void ListenToServer() {
            try {
                while (true) {
                    byte[] buffer = await _server.ReadFromStream(1);
                    byte message = buffer[0];

                    if (message == Message.Сonnection) {
                        buffer = await _server.ReadFromStream(1);
                        Sign = (Sign)buffer[0];
                    }
                    else if (message == Message.GameStatus) {
                        buffer = await _server.ReadFromStream(1);
                        GameStatus = (GameStatus)buffer[0];
                    }
                    else if (message == Message.WhoseMove) {
                        buffer = await _server.ReadFromStream(1);
                        CurrentMove = (Sign)buffer[0];
                    }
                    else if (message == Message.Move) {
                        buffer = await _server.ReadFromStream(1);
                        Sign sign = (Sign)buffer[0];

                        buffer = await _server.ReadFromStream(1);
                        bool isCanSelect = BitConverter.ToBoolean(buffer, 0);

                        buffer = await _server.ReadFromStream(4);
                        int pointX = BitConverter.ToInt32(buffer, 0);

                        buffer = await _server.ReadFromStream(4);
                        int pointY = BitConverter.ToInt32(buffer, 0);

                        buffer = await _server.ReadFromStream(4);
                        int index = BitConverter.ToInt32(buffer, 0);

                        Cell cell = new Cell(pointX, pointY, index) { Sign = sign, IsCanSelected = isCanSelect };

                        Field.Cells[pointY, pointX] = cell;
                        Field.CellsBinding[index] = cell;
                    }
                    else if (message == Message.ChatNotice) {
                        buffer = await _server.ReadFromStream(4);
                        buffer = await _server.ReadFromStream(BitConverter.ToInt32(buffer, 0));
                        Chat.Add(Encoding.UTF8.GetString(buffer));
                    }
                    else if (message == Message.GameOver || message == Message.PlayerHasLeftGame) {
                        buffer = await _server.ReadFromStream(4);
                        buffer = await _server.ReadFromStream(BitConverter.ToInt32(buffer, 0));
                        MessageBox.Show(Encoding.UTF8.GetString(buffer));
                        BreakConnection();
                        return;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                BreakConnection();
                Application.Current.MainWindow.Close();
                return;
            }
        }

        public async void Move(Cell cell) {
            if (!_server.Connected)
                return;
            if (GameStatus == GameStatus.DidNotStart) {
                MessageBox.Show("The game hasn't started yet");
                return;
            }
            if (CurrentMove != Sign) {
                MessageBox.Show("It's not your turn now!");
                return;
            }
            await SendMessageServer.SendMoveMessage(_server, cell);
        }

        private async Task SendToChat() {
            if (!_server.Connected)
                return;
            if (string.IsNullOrEmpty(ChatMessage))
                return;

            string textMessage = $"{_name}: {ChatMessage}";
            Chat.Add(textMessage);
            ChatMessage = "";

            await SendMessageServer.SendChatNoticeMessage(_server, textMessage);
        }

        private void BreakConnection() {
            if (_server.Client.Connected)
                _server.Client.Shutdown(SocketShutdown.Both);
            _server.Client.Close();
        }
    }
}
