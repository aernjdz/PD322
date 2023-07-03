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

# from random import randint
# numbers = [randint(20,50)  for x in range(10)]
# print(numbers)

# letters = [char for char in "banana"[0:2]]
# print("_".join(letters))

# letters_a_to_z =[ chr(i) for i in range(ord('a'), ord('z')+1)]
# print(letters_a_to_z)

colors = ["red","blue","red"]
print(f"Print list :: {' '.join(colors)}")
colors.append("grean")
print(f"Print list append :: {' '.join(colors)}")
colors.insert(2,"pink")
print(f"Print list insert :: {' '.join(colors)}")
colors.extend(['brown','violet','white'])
print(f"Print list extend :: {' '.join(colors)}")

colors.remove("red")
print(f"Print list remove :: {' '.join(colors)}")
colors.pop(3)
print(f"Print list pop :: {' '.join(colors)}")
colors.pop()
print(f"Print list pop :: {' '.join(colors)}")

print(f"Red color index :: {colors.index('red')}")
print(f"Pink color caunt :: {colors.count('pink')}")