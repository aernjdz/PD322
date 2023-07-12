# №1
print("======[ №1 ]=======")
def task_1():
    print("\033[90m\"Don't compare yourself with anyone in this world…\033[0m\n\033[91mif\033[0m you \033[91mdo so\033[0m, you are insulting yourself.\033[90m\"\033[0m\nBill Gates")
task_1()

# №2
print("======[ №2 ]=======")
def task_2(start:int,end:int):
    for i in range(start,end+1):
        if  i %2 == 0:
            print(i,end=' ')
    print()

task_2(10,20)
# №3
print("======[ №3 ]=======")
def task_3(length:int, symbol:str, filled:bool)->str:
    if filled:
        for i in range(length):
            for j in range(length):
                print(symbol,end=' ')
            print()
    else:
        for i in range(length):
            for j in range(length):
                if i == 0 or i == length - 1 or j == 0 or j == length - 1:
                    print(symbol, end=' ')
                else:
                    print(' ', end=' ')
            print()

task_3(4,'@',False)

# №4
print("======[ №4 ]=======")
def task_4(num1:int,num2:int,num3:int,num4:int,num5:int)->int:
    minimum = num1  
    if num2 < minimum:
        minimum = num2
    if num3 < minimum:
        minimum = num3
    if num4 < minimum:
        minimum = num4
    if num5 < minimum: 
        minimum = num5
    return minimum
    # return min(num1,num2,num3,num4,num5)
print(task_4(3,7,1,6,0))

# №5
print("======[ №5 ]=======")

def task_5(start:int,end:int):
    if start > end:
        start, end = end, start  
    product = 1
    for number in range(start, end + 1):
        product *= number
    return product

print(task_5(25,5))


# №6
print("======[ №6 ]=======")

def task_6(number:int):
   return len(str(number))

print(task_6(3456))

# №7
print("======[ №7 ]=======")

def task_7(number:int):
   return len(str(number))

print(task_7(3456))

# №8
print("======[ №8 ]=======")
def task_8(number:int):
    return str(number) == str(number)[::-1]

print(task_8(123321))

