import msvcrt
import os
import random

def clear_screen():
    os.system("cls" if os.name == "nt" else "clear")

def print_board(board):
    clear_screen()
    print("==== Spots ====")
    for row in board:
        print(" | ".join(f"{val:2}" if val != 0 else "  " for val in row))
        print("-" * 21)

def find_empty_cell(board):
    for i in range(len(board)):
        for j in range(len(board[i])):
            if board[i][j] == 0:
                return i, j

def is_valid_move(x, y):
    return 0 <= x < 4 and 0 <= y < 4

def is_game_over(board):
    current_num = 0
    for row in board:
        for val in row:
            if val != current_num:
                return False
            current_num += 1
    return True

def shuffle_board(board):
    flat_board = [val for row in board for val in row]
    random.shuffle(flat_board)
    shuffled_board = [flat_board[i:i+4] for i in range(0, 16, 4)]
    return shuffled_board

def main():
    initial_board = [[0, 1, 2, 3], [4, 5, 6, 7], [8, 9, 10, 11], [12, 13, 14, 15]]
    shuffled_board = shuffle_board(initial_board)
    empty_x, empty_y = find_empty_cell(shuffled_board)

    while True:
        print_board(shuffled_board)

        if is_game_over(shuffled_board):
            print("Congratulations! You won!")
            break

        print("Use the arrows to move the cookie. Press \"Q\" to exit.")

        key = msvcrt.getch()
        if key == b'\xe0':
            arrow_key = msvcrt.getch()

            if arrow_key == b'H':  # Up arrow
                new_x, new_y = empty_x + 1, empty_y
            elif arrow_key == b'P':  # Down arrow
                new_x, new_y = empty_x - 1, empty_y
            elif arrow_key == b'K':  # Left arrow
                new_x, new_y = empty_x, empty_y + 1
            elif arrow_key == b'M':  # Right arrow
                new_x, new_y = empty_x, empty_y - 1
            else:
                continue

            if is_valid_move(new_x, new_y):
                shuffled_board[empty_x][empty_y], shuffled_board[new_x][new_y] = shuffled_board[new_x][new_y], shuffled_board[empty_x][empty_y]
                empty_x, empty_y = new_x, new_y
        
        elif key.lower() == b'q':
            print("Game Over.")
            break


main()