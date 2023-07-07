from random import randint
# №1

list = [randint(5,30) for i in range(20)]

print(f"List :: {' '.join(map(str,list))}")

max_index = list.index(max(list))
min_index = list.index(min(list))

start_index = min(min_index,max_index) + 1
end_index = max(min_index,max_index)

for i in range(start_index,end_index):
    list[i] *= 2

print(f"Result :: {' '.join(map(str,list))}")