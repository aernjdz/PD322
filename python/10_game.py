import msvcrt
import random

def print_board(board):
    for row in board:
        print(' '.join(map(str, row)))

def find_empty_cell(board):
    for i in range(4):
        for j in range(4):
            if board[i][j] == 0:
                return i, j
    return None

def is_solvable(board):
    inversions = 0
    flattened_board = [val for row in board for val in row if val != 0]
    
    for i in range(len(flattened_board)):
        for j in range(i + 1, len(flattened_board)):
            if flattened_board[j] < flattened_board[i]:
                inversions += 1
    
    blank_row, _ = find_empty_cell(board)
    
    if (blank_row % 2 == 0 and inversions % 2 == 0) or (blank_row % 2 != 0 and inversions % 2 != 0):
        return True
    return False

def main():
    solved_board = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 0]]
    board = [[15, 10, 11, 12], [5, 9, 6, 8], [1, 13, 2, 7], [3, 4, 14, 0]]
    
    if not is_solvable(board):
        print("The initial board configuration is not solvable.")
        return
    
    while True:
        print_board(board)
        print("Use arrow keys to move the empty cell (0). Press 'q' to quit.")
        
        key = msvcrt.getch()
        
        if key == b'q':
            break
        elif key == b'\xe0':
            key = msvcrt.getch()
            print(key)
            if key == b'H':  # Up arrow key
                empty_row, empty_col = find_empty_cell(board)
                if empty_row < 3:
                    board[empty_row][empty_col], board[empty_row + 1][empty_col] = board[empty_row + 1][empty_col], board[empty_row][empty_col]
            elif key == b'M':  # Right arrow key
                empty_row, empty_col = find_empty_cell(board)
                if empty_col > 0:
                    board[empty_row][empty_col], board[empty_row][empty_col - 1] = board[empty_row][empty_col - 1], board[empty_row][empty_col]
            elif key == b'P':  # Down arrow key
                empty_row, empty_col = find_empty_cell(board)
                if empty_row > 0:
                    board[empty_row][empty_col], board[empty_row - 1][empty_col] = board[empty_row - 1][empty_col], board[empty_row][empty_col]
            elif key == b'K':  # Left arrow key
                empty_row, empty_col = find_empty_cell(board)
                if empty_col < 3:
                    board[empty_row][empty_col], board[empty_row][empty_col + 1] = board[empty_row][empty_col + 1], board[empty_row][empty_col]
        
        if board == solved_board:
            print("Congratulations, you solved the puzzle!")
            break

if __name__ == "__main__":
    main()
