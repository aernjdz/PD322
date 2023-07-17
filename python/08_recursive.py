# def fact(n:int):
#     return 1 if n==0 or n==1 else n* fact(n-1)
# print(fact(5))

# def pow_rec(n:int,x:int):
#     return 1 if x==0 else n if x==1 else 1/pow_rec(n,-x) if x<0 else n * pow_rec(n, x-1)
# print(pow_rec(5,2))

# def recursive_pow(n,x):
#     if x==0:
#         return 1
#     if x==1:
#         return n
#     if x<0:
#         return 1/recursive_pow(n,-x)
#     else:
#         return n *recursive_pow(n,x-1)
# print(recursive_pow(2,2))

#N1
def task_1(start:int,end:int):
    if start > end:
        return
    print(start,end=" ")
    task_1(start+1 ,end)

task_1(1,10)
print()
#N2
def task_2(start:int,end:int):
    if start > end:
        return
    print(end,end=" ")
    task_2(start ,end-1)
task_2(1,10)
print()
#N3
def task_3(n:int):
    if n<10:
        return n
    else:
        last = n % 10
        remaining = n // 10
        reversed_remaining = task_3(remaining)
        reversed = int(str(last) + str(reversed_remaining))  
        return reversed
print(task_3(1234))
#N4
def task_4(n:int):
    if n==0:
        return 0
    else:
        return n % 10 + task_4(n // 10)
print(task_4(1357))
#N5
def task_5(n:int):
    if n == 0:
        return ""
    else:
        return "({})".format(task_5(n - 1))
print(task_5(4))