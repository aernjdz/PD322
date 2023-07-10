# # №1
# print("======[ №1 ]========")
# def task_1():
#     print("\033[90m\"Don't let the noise of others opinions\ndrown out your own inner voice.\"\033[0m\n\033[93mSteve Jobs\033[0m")
# task_1()

# # №2
# print("======[ №2 ]========")
# def task_2(a:int,b:int):
#     for i in range(a,b+1):
#         if i % 2 != 0:
#             print(i,end=' ')
#     print()
# task_2(20,40)

# # №3
# print("======[ №3 ]========")
# def task_3(length:int,direction:str ,char:str,):
#     if direction == "horizontal":
#         print(char*length)
#     elif direction == "vertical":
#         for i in range(length):
#             print(char)
#     else:
#         print("Wrong direction : (horizontal and vertical)")
# task_3(10,"horizontal","@")

# # №4
# print("======[ №4 ]========")
# def task_4(num_1:int,num_2:int,num_3:int,num_4:int):
#     return max((num_1,num_2,num_3,num_4))
# print(task_4(13,72,35,44))

# # №5
# print("======[ №5 ]========")
# def task_5(stat_range:int,end_range:int):
#     res = [i for i in range(stat_range,end_range+1)]
#     return sum(res) 
# print(task_5(10,20))

# # №6
# print("======[ №6 ]========")
# def task_6(num:int):
#     if num <=1 :
#        return False
#     for i in range(2,int(num ** 0.5)+1):
#         if num % i == 0:
#             return False
#     return True

# print(task_6(3))

# # №7
# print("======[ №7 ]========")
# def task_7(num:int):
#     num_str = str(num)
#     if len(num_str) != 6:
#         return False
    
#     first_sum = sum(int(_) for _ in num_str[:3])
#     second_sum = sum(int(_) for _ in num_str[3:])

#     if first_sum is second_sum:
#         return True
#     return False

# print(task_7(356770))

# # №7
# print("======[ №7 ]========")
# def task_7(num:int):
#     num_str = str(num)
#     if len(num_str) != 6:
#         return False
    
#     first_sum = sum(int(_) for _ in num_str[:3])
#     second_sum = sum(int(_) for _ in num_str[3:])

#     if first_sum is second_sum:
#         return True
#     return False

# print(task_7(356770))

#=========================================
# Частина 2
#=========================================

from random import randint
# №1
print("======[ №1 ]========")
def task_1(array:list):
    sum = 0
    for i in array:
        sum += i
    return sum
print(task_1([ randint(i,30) for  i in range(20) ]))

# №2
print("======[ №2 ]========")
def task_2(array:list):
    if len(array) == 0:
        raise ValueError("List is empty.")
    max_value = array[0]
    for num in array:
        if num > max_value:
            max_value = num
    
    return max_value
print(task_2([ randint(0,30) for  i in range(20) ]))

# №3
print("======[ №3 ]========")
def task_3(array:list):
    even_count, odd_count, positive_count, negative_count = 0,0,0,0
    
    for num in array:
        if num % 2 == 0:
            even_count += 1
        else:
            odd_count += 1
        
        if num > 0:
            positive_count += 1
        elif num < 0:
            negative_count += 1
    return even_count, odd_count, positive_count, negative_count
    # return {"even":even_count, "odd":odd_count, "positive":positive_count, "negative":negative_count}

print(task_3([ randint(-10,30) for  i in range(20) ]))

# №4
print("======[ №4 ]========")
def task_4(array:list):
   return array[::-1]
print(task_4([1, 2, 3, 4, 5]))

# №5
print("======[ №5 ]========")
def task_5(array:list,target:int):
    if target in array:
        return True
    else:
        return False

print(task_5([ randint(-10,30) for i in range(10) ],5))

# №6
print("======[ №6 ]========")
def task_6(array:list):
    factorial_lst = []
    for num in array:
        factorial = 1
        for i in range(1, num + 1):
            factorial *= i
        factorial_lst.append(factorial)
    return factorial_lst

print(task_6([1,2,3,4,5,6,7,8,9,10]))