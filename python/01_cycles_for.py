# text = "Hyper text markup Language"

# for l in text[0:20:2]:
#     print(l,end=" _ ")
# for i in range(1,10):
#     print(i,end=" ")

# for i in range(1,20,2):
#     print(i,end=" ")

# while True:
#     n = int(input("2+2= ? ->"))
#     if n == 4:
#         break
# print("Congratulation")

# i = 0
# n = int(input("Enter end number :: ")) 
# while i < n:
#     i+=1
#     if i % 3 == 0:
#         continue
#     print(i,end=" ")
from math import sqrt
factorial = lambda x: x and x * factorial(x - 1) or 1 
n = int(input("Enter number :: "))
if n <= 1 :
    print("is not prime")
else:
    if(factorial(n-1)+1) % n == 0:
        print("is prime")
    else:
        print("is not prime")
    print("="*10)
    limit = int(sqrt(n) + 1)
    for i in range(2,limit):
        if n % i == 0:
            print("is not prime")
            break
    else:
        print("is prime")



