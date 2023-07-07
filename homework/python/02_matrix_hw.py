from random import randint

# №1

size = int(input("Enter list size :: "))
list = [randint(0,20) for i in range(size)]

print(f"Before :: {' '.join(map(str,list))}")

max_index = list.index(max(list))
min_index = list.index(min(list))

start_index = min(min_index,max_index) + 1
end_index = max(min_index,max_index)

for i in range(start_index,end_index):
    list[i] *= 2

print(f"After  :: {' '.join(map(str,list))}")

# №2

size = int(input("Enter list size :: "))
list = [randint(0,20) for i in range(size)]

print(f"Before :: {' '.join(map(str,list))}")
for i in range(0,len(list)-1,2):
    list[i],list[i+1] = list[i+1],list[i] 
print(f"After  :: {' '.join(map(str,list))}")

# №3

size = int(input("Enter list size :: "))
list = [randint(0,20) for i in range(size)]
print(f"List :: {' '.join(map(str,list))}")
repeat = []
count = {} 
for i in list:
    if list.count(i) > 1 and not i in repeat:
        repeat.append(i)
print(f"Result :: {' '.join(map(str,repeat))}")

# №4

width,height = map(int,input("Enter matrix size  in format 1x1 (wxh):: ").split('x'))
matrix = [[randint(0,20) for _ in range(width)] for i in range(height)]
pading = len(str(sum(_ for rows in matrix for _ in rows)))
row = ""
for _ in matrix:
    for num in _:
         row += f"{num:<{pading}d}"
    row += f" |{sum(_):<{pading}d}"
    print(row)
    row = ""
column = ''
for i in range(width):
   column += f"{sum(rows[i] for rows in matrix):<{pading}d}"
column += f" |{sum(_ for rows in matrix for _ in rows):<{pading}d}"
print("-"*len(column))
print(column)

# №5

tour_position = input("Enter the position of the Tour :: ")
column = ord(tour_position[0]) - ord('a')
row = int(tour_position[1]) - 1

board = [['.' for _ in range(8)] for _ in range(8)]

for i in range(8):
        board[row][i] = '*'

for i in range(8):
        board[i][column] = '*'\
        
board[row][column] = 'T'

  
print("a b c d e f g h")
for i, row in enumerate(board):
    print(f"{' '.join(row)} {i+1}")

# №6

officer_position = input("Enter the position of the Officer :: ")
column = ord(officer_position[0]) - ord('a')
row = int(officer_position[1]) - 1

board = [['.' for _ in range(8)] for _ in range(8)]
for i in range(8):
    diagonal_row = row + i
    diagonal_column = column + i
    if 0 <= diagonal_column < 8 and 0 <= diagonal_row < 8:
            board[diagonal_row][diagonal_column] = '*'

for i in range(8):
    diagonal_row = row - i
    diagonal_column = column - i
    if 0 <= diagonal_column < 8 and 0 <= diagonal_row < 8:
        board[diagonal_row][diagonal_column] = '*'

for i in range(8):
    diagonal_row = row - i
    diagonal_column = column + i
    if 0 <= diagonal_column < 8 and 0 <= diagonal_row < 8:
        board[diagonal_row][diagonal_column] = '*'

for i in range(8):
    diagonal_row = row + i
    diagonal_column = column - i
    if 0 <= diagonal_column < 8 and 0 <= diagonal_row < 8:
        board[diagonal_row][diagonal_column] = '*'

        
board[row][column] = 'O'
print("a b c d e f g h")
for i, row in enumerate(board):
    print(f"{' '.join(row)} {i+1}")

# №7

horse_position = input("Enter the position of the horse :: ")
column = ord(horse_position[0]) - ord('a')
row = int(horse_position[1]) - 1

board = [['.' for _ in range(8)] for _ in range(8)]
board[row][column] = 'H'
horse_walk = [(-2, -1), (-2, 1), (-1, -2), (-1, 2), (1, -2), (1, 2), (2, -1), (2, 1)]
for walk in horse_walk:
    new_row = row + walk[0]
    new_column = column + walk[1]
    if 0 <= new_row < 8 and 0 <= new_column < 8:
        board[new_row][new_column] = '*'

print("a b c d e f g h")
for i, row in enumerate(board):
    print(f"{' '.join(row)} {i+1}")