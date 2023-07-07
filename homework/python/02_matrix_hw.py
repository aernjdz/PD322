from random import randint
# №1

list = [randint(5,30) for i in range(20)]

print(f"Before :: {' '.join(map(str,list))}")

max_index = list.index(max(list))
min_index = list.index(min(list))

start_index = min(min_index,max_index) + 1
end_index = max(min_index,max_index)

for i in range(start_index,end_index):
    list[i] *= 2

print(f"After  :: {' '.join(map(str,list))}")

# №2
list = [randint(5,30) for i in range(20)]

print(f"Before :: {' '.join(map(str,list))}")
for i in range(0,len(list)-1,2):
    list[i],list[i+1] = list[i+1],list[i] 
print(f"After  :: {' '.join(map(str,list))}")

# №3