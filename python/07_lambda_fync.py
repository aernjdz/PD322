from random import choice

matrix = [[" " for _ in range(3)] for _ in range(3)]

def print_matrix():
    for i in range(3):
        print(' ' + matrix[i][0] + ' | ' + matrix[i][1] + ' | ' + matrix[i][2])
        if i < 2:
            print('-----------')


def bot_move():
    available_moves = [(i, j) for i, row in enumerate(matrix) for j, cell in enumerate(row) if cell == ' ']
    if len(available_moves) > 0:
        position = choice(available_moves)
        row, col = position
        matrix[row][col] = 'O'
        print("Bot chooses position", (row * 3) + col + 1)
        print_matrix()


def check_win(player):
    for i in range(3):
        if matrix[i][0] == matrix[i][1] == matrix[i][2] == player:
            return True

    for i in range(3):
        if matrix[0][i] == matrix[1][i] == matrix[2][i] == player:
            return True

    if matrix[0][0] == matrix[1][1] == matrix[2][2] == player or matrix[0][2] == matrix[1][1] == matrix[2][0] == player:
        return True

    return False


def play_game():
    print("Welcome to Tic-Tac-Toe!")
    print_matrix()
    current_player = 'X'
    while True:
        if current_player == 'X':
            position = int(input("Player X, enter your move (1-9): ")) - 1
            if position < 0 or position >= 9 or matrix[position // 3][position % 3] != ' ':
                print("Invalid move! Try again.")
                continue
            matrix[position // 3][position % 3] = current_player
            print_matrix()
            if check_win(current_player):
                print("Player X wins!")
                break
        else:
            bot_move()
            if check_win(current_player):
                print("Player O wins!")
                break
        if all(cell != ' ' for row in matrix for cell in row):
            print("It's a tie!")
            break
        current_player = 'O' if current_player == 'X' else 'X'


play_game()
