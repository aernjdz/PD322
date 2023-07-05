# from random import randint
# size = int(input("Enter matrix size: "))
# matrix = [[randint(10,50) for _ in range(size)] for _ in range(size)]

# for i in matrix:
#     for j in i:
#         print(j,end=" ")
#     print()
# data = {
#     "main":0,
#     "secondary":0
# }
# for i in range(size):
#     for j in range(size):
#         if i == j:
#             data["main"] += matrix[i][i]
#         if i+j == size-1:
#             data["secondary"] += matrix[i][j]
# #1
# print(f"Main diagonal:{data['main']}")
# print(f"Secondary diagonal:{data['secondary']}")
from random import choice
bad = [
'''
    +---+
        |
        |
        |
        |
        |
  =========
  ''',
  '''
     +---+
     |   |
     O   |
         |
         |
         |
  =========
  ''',
  '''
     +---+
     |   |
     O   |
     |   |
         |
         |
  =========
  ''',
  '''
     +---+
     |   |
     O   |
    /|   |
         |
         |
  =========
  ''',
  '''
     +---+
     |   |
     O   |
    /|\  |
         |
         |
  =========
  ''',
  '''
     +---+
     |   |
     O   |
    /|\  |
    /    |
         |
 =========
 ''',
 '''
    +---+
    |   |
    O   |
   /|\  |
   / \  |
        |
 =========
 ''']
wrong = 0
words = ['summer',"spider","winter","rain","butterfly"]
word = choice(words)
#print(word)
answer = ["_" for i in word]
counter = len(word)
wrong_leters = []
while counter != 0 and wrong != 6:
    print(bad[wrong])
    print(" ".join(answer))
    s = input("Enter letter ::")
    if len(s) !=1:
        print("Error")
        continue
    index = word.find(s)
    if index == -1:
        wrong_leters.append(s)
        wrong += 1
    while index != -1:
        answer[index] = s
        index = word.find(s,index + 1 )
        counter += -1
    
if wrong == 6:
    print(bad[wrong])
    print("Game Over!")
else:
    print(bad[wrong])
    print(" ".join(answer))
    print("Congratulation!! You Won!!")


    

