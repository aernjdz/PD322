using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using TicTacToeLibrary;

namespace TicTacToeServer {

    public partial class MainWindow : Window {

        private string _ipAddress;
        private int _port;
        private IList<TcpClient> _clients;
        private readonly Field _field;
        public ObservableCollection<string> Logs { get; }


        private Sign _currentMove;
        private GameStatus _gameStatus;
        public MainWindow() {
            InitializeComponent();
            DataContext = this;
             _field = new Field(10, 10);
            Logs = new ObservableCollection<string>();
            _clients = new List<TcpClient>();
            _currentMove = Sign.Сross;
            _gameStatus = GameStatus.DidNotStart;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ConfigWindow dialog = new ConfigWindow();
            if (dialog.ShowDialog() == true) {
                _ipAddress = dialog.IpAddress;
                _port = dialog.Port;
            }
            else {
                Close();
                return;
            }

            TcpListener listener = new TcpListener(IPAddress.Parse(_ipAddress), _port);
            Title = $"IP = {_ipAddress} Port = {_port}";
            listener.Start();
            ServeClients(listener);

        }
        private async void ServeClients(TcpListener listener) {
            while (true) {
                if (_clients.Count == 2)
                    return;
                TcpClient client = await listener.AcceptTcpClientAsync();
                ServeClient(client);
            }
        }

        private async void ServeClient(TcpClient client) {
            try {
                while (true) {
                    byte[] buffer = await client.ReadFromStream(1);
                    byte message = buffer[0];

                    if (message == Message.Сonnection) {
                        await AddNewClient(client);
                    }
                    else if (message == Message.Move) {

                        buffer = await client.ReadFromStream(1);
                        Sign sign = (Sign)buffer[0];

                        buffer = await client.ReadFromStream(1);
                        bool isCanSelect = BitConverter.ToBoolean(buffer, 0);

                        buffer = await client.ReadFromStream(4);
                        int pointX = BitConverter.ToInt32(buffer, 0);

                        buffer = await client.ReadFromStream(4);
                        int pointY = BitConverter.ToInt32(buffer, 0);

                        buffer = await client.ReadFromStream(4);
                        int index = BitConverter.ToInt32(buffer, 0);

                        Cell cell = new Cell(pointX, pointY, index) { Sign = _currentMove };

                        _field.Cells[pointY, pointX] = cell;
                        _field.CellsBinding[index] = cell;

                     
                        if (IsWasBuiltRow(pointX, pointY)) {
                            if (_currentMove == Sign.Сross)
                                _gameStatus = GameStatus.CrossVictory;
                            else
                                _gameStatus = GameStatus.ZeroVictory;
                        }
                        
                     
                        if (!_field.CellsBinding.Any(item => item.Sign == Sign.None))
                            _gameStatus = GameStatus.Draw;

                       
                        foreach (TcpClient other in _clients)
                            await SendMessageClient.SendMoveMessage(other, cell);

                        if (_currentMove == Sign.Сross)
                            _currentMove = Sign.Zero;
                        else
                            _currentMove = Sign.Сross;
                        Dispatcher.Invoke(() => Logs.Add($"Сделал ход {client.Client.RemoteEndPoint} {DateTime.Now}"));
                    }

                    else if (message == Message.ChatNotice) {
                        buffer = await client.ReadFromStream(4);
                        buffer = await client.ReadFromStream(BitConverter.ToInt32(buffer, 0));
                        foreach (TcpClient other in _clients)
                            if (other.Client.RemoteEndPoint != client.Client.RemoteEndPoint)
                                await SendMessageClient.SendChatNoticeMessage(other, buffer);
                        Dispatcher.Invoke(() => Logs.Add($"Sent a message to chat {client.Client.RemoteEndPoint} {DateTime.Now}"));
                    }

                   
                    foreach (TcpClient other in _clients)
                        await SendMessageClient.SendGameStatusMessage(other, _gameStatus);

                    if (_gameStatus != GameStatus.DidNotStart && message != Message.ChatNotice) {
                   
                        if (IsGameOver()) {
                            await ReportGameOver();
                            foreach (TcpClient other in _clients) {
                                if (client.Client.Connected)
                                    client.Client.Shutdown(SocketShutdown.Both);
                                client.Client.Close();
                            }
                            Close();
                            return;
                        }
                     
                        foreach (TcpClient other in _clients)
                            await SendMessageClient.SendWhoseMoveMessage(other, _currentMove);
                    }
                }
            }
            catch (Exception) {
                Dispatcher.Invoke(() => Logs.Add($"Left the game {client.Client.RemoteEndPoint} {DateTime.Now}"));
                foreach (TcpClient other in _clients)
                    if (other.Client.RemoteEndPoint != client.Client.RemoteEndPoint)
                        await SendMessageClient.SendPlayerHasLeftGameMessage(other);
                Close();
                return;
            }
        }

        private bool IsWasBuiltRow(int pointX, int pointY) {
            int count = 0;
        
            for (int i = -4; i <= 4; i++) {
                if (pointY + i >= 0 && pointY + i < _field.Rows) {
                    if (_field.Cells[pointY + i, pointX].Sign == _currentMove) {
                        ++count;
                        if (count == 5)
                            return true;
                    }
                    else
                        count = 0;
                }
            }
            count = 0;
          
            for (int i = -4; i <= 4; i++) {
                if (pointX + i >= 0 && pointX + i < _field.Rows) {
                    if (_field.Cells[pointY, pointX + i].Sign == _currentMove) {
                        ++count;
                        if (count == 5)
                            return true;
                    }
                    else
                        count = 0;
                }
            }
            count = 0;
           
            for (int i = -4; i <= 4; i++) {
                if (pointY + i >= 0 && pointX + i >= 0 && pointY + i < _field.Rows && pointX + i < _field.Rows) {
                    if (_field.Cells[pointY + i, pointX + i].Sign == _currentMove) {
                        ++count;
                        if (count == 5)
                            return true;
                    }
                    else
                        count = 0;
                }
            }
            count = 0;
        
            for (int i = -4; i <= 4; i++) {
                if (pointY - i >= 0 && pointX + i >= 0 && pointY - i < _field.Rows && pointX + i < _field.Rows) {
                    if (_field.Cells[pointY - i, pointX + i].Sign == _currentMove) {
                        ++count;
                        if (count == 5)
                            return true;
                    }
                    else
                        count = 0;
                }
            }
            return false;
        }

        private async Task AddNewClient(TcpClient client) {
            Sign sign;
            lock (_clients) {
                if (_clients.Count == 0) {
                    sign = Sign.Сross;
                    Dispatcher.Invoke(() => Logs.Add($"First player {client.Client.RemoteEndPoint} {DateTime.Now}"));
                }
                else {
                    sign = Sign.Zero;
                    Dispatcher.Invoke(() => Logs.Add($"Second player {client.Client.RemoteEndPoint} {DateTime.Now}"));
                    _gameStatus = GameStatus.GameIsOn;
                }
                _clients.Add(client);
            }
            await SendMessageClient.SendСonnectionMessage(client, sign);
        }

        private async Task ReportGameOver() {
            string textMessage;
            if (_gameStatus == GameStatus.CrossVictory) {
                textMessage = "The X`s won!";
                foreach (TcpClient client in _clients)
                    await SendMessageClient.SendGameOverMessage(client, textMessage);
            }
            else if (_gameStatus == GameStatus.ZeroVictory) {
                textMessage = "The O`s won!";
                foreach (TcpClient client in _clients)
                    await SendMessageClient.SendGameOverMessage(client, textMessage);
            }
            else {
                textMessage = "Draw!";
                foreach (TcpClient client in _clients)
                    await SendMessageClient.SendGameOverMessage(client, textMessage);
            }
        }

        private bool IsGameOver() =>
            _gameStatus == GameStatus.CrossVictory ||
            _gameStatus == GameStatus.ZeroVictory ||
            _gameStatus == GameStatus.Draw;

    }
}
