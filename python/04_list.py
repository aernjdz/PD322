# from random import randint
# fruits = ["apple","plum","banana","orenge"]
# rnumbers = list((5,8,7,3,2,9,0,7))

# # print(fruits[1])
# # print(len(rnumbers))
# # print(fruits[-1::-1])

# for item in fruits[0::2]:
#     for char in item:
#         print(char,end="_")
#     print()

# # print("banana" in fruits)

# numbers = [ x  for x in range(1,11)]

# numbers = [randint(20,50)  for x in range(10)]
# print(numbers)

# letters = [char for char in "banana"[0:2]]
# print("_".join(letters))

# letters_a_to_z =[ chr(i) for i in range(ord('a'), ord('z')+1)]
# print(letters_a_to_z)

# colors = ["red","blue","red"]
# print(f"Print list :: {' '.join(colors)}")
# colors.append("grean")
# print(f"Print list append :: {' '.join(colors)}")
# colors.insert(2,"pink")
# print(f"Print list insert :: {' '.join(colors)}")
# colors.extend(['brown','violet','white'])
# print(f"Print list extend :: {' '.join(colors)}")

# colors.remove("red")
# print(f"Print list remove :: {' '.join(colors)}")
# colors.pop(3)
# print(f"Print list pop :: {' '.join(colors)}")
# colors.pop()
# print(f"Print list pop :: {' '.join(colors)}")

# print(f"Red color index :: {colors.index('red')}")
# #colors.clear()
# print(f"Pink color caunt :: {colors.count('pink')}")

# numbers = [randint(10,100)  for x in range(10)]

# print(f"Print list :: {numbers}")
# print(f"Max ::{max(numbers)}")
# print(f"Min :: {min(numbers)}")
# print(f"Sum :: {sum(numbers)}")
# print(f"List sorted :: {sorted(numbers)}")

# numbers.sort(reverse=True)
# print(f"Print list :: {numbers}")

# colors = ["blue","red","green"]
# clone_colors = colors
# print(f"Colors ?= Clone_colors :: {colors is clone_colors}")
# print(f"Colors :: {colors}")
# print(f"Clone_colors :: {clone_colors}")

# # clone_colors = colors.copy()
# clone_colors = list(colors)
# print("="*50)
# colors[0] = "lime"
# print(f"Colors :: {colors}")
# print(f"Clone_colors :: {clone_colors}")

# №2
# 9 0 4 4 1 8 0 1 5 7 2 1 6 2 2 3 0 9 3 4 5 2 9 0 8 6 7 3 6 1 4 8 3 5 7 6 6 3 2 9 5
# user_list = list(map(int,input("Enter list numbers separated by a space (0 1 ... ...):: ").split()))
# number = int(input("Enter is number :: "))
# print(f"Number {number} is count {user_list.count(number)}")

# # №3
# user_list = list(map(int,input("Enter list numbers separated by a space (0 1 ... ...):: ").split()))
# print(f"Sum :: {sum(user_list)}")
# print(f"Arithmetic mean :: {'%.2f' % (sum(user_list)/len(user_list))}")

# N1

user_rating = list(map(int,input("Enter student rating list separated by a space (0 1 ... ...):: ").split()))
while True:
    print('=====================<[ good luck ]>=====================')
    print("=          [1] - print student rating list               ")
    print("=          [2] - Retaking the exam                       ")
    print("=          [3] - Is there a scholarship?                 ")
    print("=          [0] - Exit                                    ")
    print("=========================================================")
    choice = int(input("Enter you choice :: "))

    match choice:
        case 0:
            print("Good bye!")
            break
        case 1:
            print(f"Student rating :: {' '.join(map(str,user_rating))}")
        case 2:
            elem_id = int(input("Enter list element number :: "))
            if 0 < elem_id < len(user_rating):
                new_rating = int(input("Enter new reting :: "))
                user_rating[elem_id] = new_rating
            else:
                print("IndexError")
        case 3:
            if 10.7 <= (sum(user_rating)/len(user_rating)):
                print("A scholarship is available")
            else:
                print("The scholarship is not available")
        case _ :
            print("Wrong choice!")
            choice = int(input("Enter you choice :: "))



