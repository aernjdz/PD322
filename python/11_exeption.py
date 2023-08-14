#N1
def divide_numbers_v1(num1:float, num2:float):
    return num1 / num2
def divide_numbers_v2( num1:float, num2:float):
    try:
        result = num1 / num2
        return result
    except ZeroDivisionError:
        return "Error: Zero Division Error."


try:
    num1 = float(input("Enter the first number: "))
    num2 = float(input("Enter the second number: "))      
    print("Result (v1):", divide_numbers_v1(num1, num2))
    print("Result (v2):", divide_numbers_v2(num1, num2))
except ValueError:
        print("Error: Value type error.")
#N2
#v0.1
def convert_to_number_v1(input_str):
    return int(input_str)
#v0.2

def convert_to_number_v2(input_str):
    try:
        number = int(input_str)
        return number
    except ValueError:
        return "Error: Cannot convert to a number."

input_str = input("Enter string: ")

    
try:
    print("Result: (v1):", convert_to_number_v1(input_str))
except ValueError:
    print("Error: Cannot convert to a number.")

   
print("Result: (v2):", convert_to_number_v2(input_str))
#N3
number = 0
import math
#v0.1
def calculate_square_root_v1(num):
    return math.sqrt(num)
#v0.2

def calculate_square_root_v2(num):
    try:
        if num < 0:
            raise ValueError("The entered number is less than zero")
        return math.sqrt(num)
    except ValueError as e:
        return str(e)

try:
    number = float(input("Enter the number: "))
    if number < 0:
         raise ValueError("The entered number is less than zero")
    print("Result: (v1):", calculate_square_root_v1(number))
    print("Result: (v2):", calculate_square_root_v2(number))
except ValueError:
        print("Error: Incorrect number entered.")

