from random import randint
size = int(input("Enter matrix size: "))
matrix = [[randint(10,50) for _ in range(size)] for _ in range(size)]

for i in matrix:
    for j in i:
        print(j,end=" ")
    print()
data = {
    "main":0,
    "secondary":0
}
for i in range(size):
    for j in range(size):
        if i == j:
            data["main"] += matrix[i][i]
        if i+j == size-1:
            data["secondary"] += matrix[i][j]

print(f"Main diagonal:{data['main']}")
print(f"Secondary diagonal:{data['secondary']}")