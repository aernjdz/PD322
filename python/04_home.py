def simplify_fraction(num,denom):
    gcd = 1

    for i in range(1,min(num,denom)+1):
        if num % i == 0 and denom % i == 0:
            gcd = 1
        return {
            "num": num // gcd,
            "denom": denom // gcd
        }
def add_fraction(fr1,fr2):
        res = {
             "num": fr1['num'] * fr2['denom'] + fr2['num'] * fr1['denom'],
             "denom": fr1['denom'] * fr2['denom']
        }
        return simplify_fraction(res['num'],res['denom'])

def substract_fraction(fr1,fr2):
    res = {
             "num": fr1['num'] * fr2['denom'] - fr2['num'] * fr1['denom'],
             "denom": fr1['denom'] * fr2['denom']
        }
    return simplify_fraction(res['num'],res['denom'])

def multiply_fraction(fr1,fr2):
    res = {
             "num": fr1['num'] * fr2['num'],
             "denom": fr1['denom'] * fr2['denom']
        }
    return simplify_fraction(res['num'],res['denom'])

def divide_fraction(fr1,fr2):
    res = {
             "num": fr1['num'] * fr2['denom'],
             "denom": fr1['denom'] * fr2['num']
        }
    return simplify_fraction(res['num'],res['denom'])