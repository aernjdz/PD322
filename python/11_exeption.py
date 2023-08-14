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

