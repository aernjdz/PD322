import random




size = 10

mines = 5




board = [[0 for i in range(size)] for j in range(size)]

flags = [[False for i in range(size)] for j in range(size)]





def printBoard():

    print("   ",end='')

    for i in range(size):

        print(i,' ',sep='',end='')

    print()

    print("  ",end='')

    for i in range(size):

        print('--',sep='',end='')

    print()

    for i in range(size):

        print(i,'|',sep='',end='')

        for j in range(size):

            if not flags[i][j]:

                print(' .',sep='',end='')

                #print(' ',board[i][j],sep='',end='')

            else:

                if board[i][j] == 0:

                    print('  ',sep='',end='')

                elif board[i][j] == 1:

                    print(' \033[34m',board[i][j],'\033[0m',sep='',end='')

                elif board[i][j] == 2:

                    print(' \033[32m',board[i][j],'\033[0m',sep='',end='')

                elif board[i][j] == 3:

                    print(' \033[35m',board[i][j],'\033[0m',sep='',end='')

                elif board[i][j] == 4:

                    print(' \033[36m',board[i][j],'\033[0m',sep='',end='')

                elif board[i][j] == 5:

                    print(' \033[33m',board[i][j],'\033[0m',sep='',end='')

                else:

                    print(' \033[31m',board[i][j],'\033[0m',sep='',end='')





        print()




def placeMines():

    count = 0

    while count < mines:

        x = random.randrange(0,size)

        y = random.randrange(0,size)

        if board[x][y] != '*':

            board[x][y] = '*'

            count+=1

def countMines(x,y):

    counter = 0

    if x > 0 and board[x-1][y] == '*':

        counter+=1

    if x < size - 1 and board[x+1][y] == '*':

        counter+=1

    if y > 0 and board[x][y-1] == '*':

        counter+=1

    if y < size - 1 and board[x][y+1] == '*':

        counter+=1

    if x > 0 and y > 0 and board[x-1][y-1] == '*':

        counter+=1

    if x < size-1 and y < size-1 and board[x+1][y+1] == '*':

        counter +=1

    if x > 0 and y < size-1 and board[x-1][y+1] == '*':

        counter+=1

    if x < size-1 and y > 0 and board[x+1][y-1] == '*':

        counter +=1

    return counter




def showFlags(x,y):

    if board[x][y] == '*':

        print('Game over')

        flags[x][y] = True

        return False

    if not flags[x][y]:

        board[x][y] = countMines(x,y)

        flags[x][y] = True

        if board[x][y] == 0:

            if x > 0 and board[x-1][y] != '*':

                showFlags(x-1,y)

            if x < size-1 and board[x+1][y] != '*':

                showFlags(x+1,y)

            if y > 0 and board[x][y - 1] != '*':

                showFlags(x,y-1)

            if y < size-1 and board[x][y + 1] != '*':

                showFlags(x,y+1)

            if x > 0 and y > 0 and board[x-1][y-1] != '*':

                showFlags(x-1,y-1)

            if x < size-1 and y < size-1 and board[x+1][y+1] != '*':

                showFlags(x+1,y+1)

            if x > 0 and y < size-1 and board[x-1][y+1] != '*':

                showFlags(x-1,y+1)

            if x < size-1 and y > 0 and board[x+1][y-1] != '*':

                showFlags(x+1,y-1)




def isGameWon():
    for i in range(size):
        for j in range(size):
            if not flags[i][j] and board[i][j] != '*':
                return False
    return True
def game():

    placeMines()

    while True:

        printBoard()

        x,y = list(map(int,input().split()))

        res = showFlags(x,y)

        if res is False:
            break
        if isGameWon():
            print("Congratulations! You won!")
            break

    printBoard()

   

game()