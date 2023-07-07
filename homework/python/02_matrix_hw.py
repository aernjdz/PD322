from random import randint
# №1
size = int(input("Enter list size :: "))
list = [randint(0,20) for i in range(20)]

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
list = [randint(0,20) for i in range(20)]

print(f"Before :: {' '.join(map(str,list))}")
for i in range(0,len(list)-1,2):
    list[i],list[i+1] = list[i+1],list[i] 
print(f"After  :: {' '.join(map(str,list))}")

# №3
size = int(input("Enter list size :: "))
list = [randint(0,20) for i in range(20)]
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

