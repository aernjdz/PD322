
def find_gcd(a, b):
    while b:
        a, b = b, a % b
    return a


def simplify_fraction(numerator, denominator):
    common_divisor = find_gcd(numerator, denominator)
    simplified_numerator = numerator // common_divisor
    simplified_denominator = denominator // common_divisor
    return {'numerator': simplified_numerator, 'denominator': simplified_denominator}


def mixed_to_improper(whole_part, numerator, denominator):
    return {'numerator': whole_part * denominator + numerator, 'denominator': denominator}


def improper_to_mixed(numerator, denominator):
    whole_part = numerator // denominator
    remaining_numerator = numerator % denominator
    return {'whole_part': whole_part, 'numerator': remaining_numerator, 'denominator': denominator}


def add_fractions(num1, den1, num2, den2):
    common_denominator = den1 * den2
    new_num1 = num1 * den2
    new_num2 = num2 * den1
    result_numerator = new_num1 + new_num2
    return simplify_fraction(result_numerator, common_denominator)

def subtract_fractions(num1, den1, num2, den2):
    common_denominator = den1 * den2
    new_num1 = num1 * den2
    new_num2 = num2 * den1
    result_numerator = new_num1 - new_num2
   
    return simplify_fraction(result_numerator, common_denominator)

def multiply_fractions(num1, den1, num2, den2):
    result_numerator = num1 * num2
    result_denominator = den1 * den2
    return simplify_fraction(result_numerator, result_denominator)

def divide_fractions(num1, den1, num2, den2):
    result_numerator = num1 * den2
    result_denominator = den1 * num2
    return simplify_fraction(result_numerator, result_denominator)


num1 = 5
den1 = 6
num2 = 4
den2 = 4

sum_result = add_fractions(num1, den1, num2, den2)
difference_result = subtract_fractions(num1, den1, num2, den2)
product_result = multiply_fractions(num1, den1, num2, den2)
division_result = divide_fractions(num1, den1, num2, den2)

mixed_result = improper_to_mixed(sum_result['numerator'], sum_result['denominator'])
print(f"Sum result: {mixed_result['whole_part'] if mixed_result['whole_part'] != 0 else ...} {mixed_result['numerator']}/{mixed_result['denominator']}")

mixed_result = improper_to_mixed(difference_result['numerator'],difference_result['denominator'])

print(f"Difference result: {mixed_result['whole_part'] if mixed_result['whole_part'] != 0 else  '' } {mixed_result['numerator']}/{mixed_result['denominator']}")

mixed_result = improper_to_mixed(product_result['numerator'], product_result['denominator'])
print(f"Product result: {mixed_result['whole_part'] if mixed_result['whole_part'] != 0 else '' } {mixed_result['numerator']}/{mixed_result['denominator']}")

mixed_result = improper_to_mixed(division_result['numerator'], division_result['denominator'])
print(f"Division result: {mixed_result['whole_part'] if mixed_result['whole_part'] != 0 else ''} {mixed_result['numerator']}/{mixed_result['denominator']}")
