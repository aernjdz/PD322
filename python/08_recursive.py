# def fact(n:int):
#     return 1 if n==0 or n==1 else n* fact(n-1)
# print(fact(5))
def pow_rec(n:int,x:int):
    return 1 if x==0 else n if x==1 else 1/pow_rec(n,-x) if x<0 else n * pow_rec(n, x-1)
print(pow_rec(5,2))

def recursive_pow(n,x):
    if x==0:
        return 1
    if x==1:
        return n
    if x<0:
        return 1/recursive_pow(n,-x)
    else:
        return n *recursive_pow(n,x-1)
print(recursive_pow(2,2))