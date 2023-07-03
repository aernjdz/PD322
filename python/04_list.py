from random import randint
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
colors = ["blue","red","green"]
clone_colors = colors
print(f"Colors ?= Clone_colors :: {colors is clone_colors}")
print(f"Colors :: {colors}")
print(f"Clone_colors :: {clone_colors}")

# clone_colors = colors.copy()
clone_colors = list(colors)
print("="*50)
colors[0] = "lime"
print(f"Colors :: {colors}")
print(f"Clone_colors :: {clone_colors}")