# №1
num_1 = int(input("Enter first number :: "))
num_2 = int(input("Enter second number:: "))
print("Result ::", end=" ")
while num_1 <= num_2:
    print(num_1,end=" ")
    num_1 +=1
print()
# №2
num_1 = int(input("Enter first number :: "))
num_2 = int(input("Enter second number:: "))
print("Result ::", end=" ")
while num_1 <= num_2:
    if num_1 % 2 != 0:
        print(num_1,end=" ")
    num_1 +=1
print()
# №3
num_1 = int(input("Enter first number :: "))
num_2 = int(input("Enter second number:: "))
print("Result ::", end=" ")
while num_1 <= num_2:
    if num_1 % 2 == 0:
        print(num_1,end=" ")
    num_1 +=1
print()
# №4
num_1 = int(input("Enter first number :: "))
num_2 = int(input("Enter second number:: "))
print("Result ::", end=" ")
while num_1 <= num_2:
    print(num_2,end=" ")
    num_2 -=1
print()
# №5
num_1 = int(input("Enter first number :: "))
num_2 = int(input("Enter second number:: "))
print("Result ::", end=" ")
num_min = min(num_1,num_2)
num_max = max(num_1,num_2)
while num_min <= num_max:
    if num_min % 2 != 0:
        print(num_min,end=" ")
    num_min += 1
print()

