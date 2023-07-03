# # №1
# num_1 = int(input("Enter first number :: "))
# num_2 = int(input("Enter second number :: "))
# sum = 0
# count = num_2-num_1
# while num_1 <= num_2:
#     sum += num_1
#     num_1 +=1
# print(f"Sum :: {sum}")
# print(f"Arithmetic mean :: {sum/count}")
# # №2
# num = int(input("Enter number :: "))
# i = 0
# factorial = 1
# while i < num:
#     i+=1
#     factorial *= i
# print(f"Factorial :: {factorial}")
# # №3
# len = int(input("Enter string length :: "))
# print("*"*len)
# # №4
# len = int(input("Enter string length :: "))
# char = input("Enter char :: ")
# print(char*len)

row = 2
column_number = 1
i = 1
print("="*40)
while i <= 2:
    if i == 1:
        while column_number <= 10:
            row = 1
            while row  <= 5:
                result = row * column_number
                print(f"{row}x{column_number}={result}",end="\t")
                row += 1
            print()
            column_number +=1
    else:

        column_number = 1
        while column_number <= 10:
            row = 6
            while row  <= 10 :
                result = row * column_number
                print(f"{row}x{column_number}={result}",end="\t")
                row += 1
            print()
            column_number +=1
    
    print("="*40)
    i+=1



    



