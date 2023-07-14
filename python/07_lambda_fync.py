from random import choice

def create_matrix(size):
    return [[" " for _ in range(size)] for _ in range(size)]

def print_matrix(matrix):
    size = len(matrix)
    for i in range(size):
        print(' ' + ' | '.join(matrix[i]))
        if i < size - 1:
            print('-' * (size * 4 - 1))

def bot_move(matrix, player_symbol, bot_symbol):
    size = len(matrix)

   
    for i in range(size):
        for j in range(size):
            if matrix[i][j] == ' ':
                matrix[i][j] = bot_symbol
                if check_win(matrix, bot_symbol):
                    print("Bot chooses position", (i * size) + j + 1)
                    print_matrix(matrix)
                    return

                matrix[i][j] = ' ' 

    for i in range(size):
        for j in range(size):
            if matrix[i][j] == ' ':
                matrix[i][j] = player_symbol
                if check_win(matrix, player_symbol):
                    matrix[i][j] = bot_symbol
                    print("Bot chooses position", (i * size) + j + 1)
                    print_matrix(matrix)
                    return

                matrix[i][j] = ' '  

    available_moves = [(i, j) for i in range(size) for j in range(size) if matrix[i][j] == ' ']
    if available_moves:
        position = choice(available_moves)
        row, col = position
        matrix[row][col] = bot_symbol
        print("Bot chooses position", (row * size) + col + 1)
        print_matrix(matrix)


def check_win(matrix, player):
    size = len(matrix)
    for i in range(size):
        if all(cell == player for cell in matrix[i]):
            return True

    for i in range(size):
        if all(matrix[j][i] == player for j in range(size)):
            return True

    if all(matrix[i][i] == player for i in range(size)):
        return True

    if all(matrix[i][size - i - 1] == player for i in range(size)):
        return True

    return False

def play_game():
    player_symbol = input("Choose your symbol (X or O): ")
    while player_symbol.lower() not in ['x', 'o']:
        print("Invalid symbol! Please choose X or O.")
        player_symbol = input("Choose your symbol (X or O): ")

    player_symbol = player_symbol.upper()

    while True:
        print("Welcome to Tic-Tac-Toe!")
        size = int(input("Enter the board size: "))
        matrix = create_matrix(size)
        print_matrix(matrix)

        current_player = player_symbol if player_symbol =="X" else bot_symbol
        moves = 0
        total_cells = size * size

        bot_symbol = 'O' if player_symbol == 'X' else 'X'

        while True:
            if current_player == player_symbol:
                position = int(input("Player {}, enter your move (1-{}): ".format(player_symbol, total_cells))) - 1
                if position < 0 or position >= total_cells or matrix[position // size][position % size] != ' ':
                    print("Invalid move! Try again.")
                    continue
                matrix[position // size][position % size] = current_player
                print_matrix(matrix)
                moves += 1
                if check_win(matrix, current_player):
                    print("Player {} wins!".format(player_symbol))
                    break
            else:
                bot_move(matrix, player_symbol, bot_symbol)
                moves += 1
                if check_win(matrix, bot_symbol):
                    print("Player {} wins!".format(bot_symbol))
                    break

            if moves == total_cells:
                print("It's a tie!")
                break

            current_player = bot_symbol if current_player == player_symbol else player_symbol

        play_again = input("Do you want to play again? (yes/no): ")
        if play_again.lower() != 'yes':
            break

        player_symbol = 'O' if player_symbol == 'X' else 'X'
        bot_symbol = 'O' if player_symbol == 'X' else 'X'
        current_player = player_symbol if player_symbol =="X" else bot_symbol

play_game()
print("Good Bye!")