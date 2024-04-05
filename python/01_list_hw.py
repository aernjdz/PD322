#N1
expression = input("Enter arithmetic expression :: ").replace(' ', '')
#print(eval(expression))
data = [ {
    "numbers": {
        "left": "",
        "right": "",
        },
    "operators": {
        "start_operator":"",
        "math_operator":"",
        "index":0
    },
    "result": 0
    }]
if expression.startswith('-'):
    data[0]["operators"]["start_operator"] = "-"
    expression = "".join([char for num, char in enumerate(expression) if num != 0])

for i in expression:
    if i in ["+", "-","*","/"]:
        data[0]["operators"]["math_operator"] = i
        data[0]["operators"]["index"] = expression.index(i)
for i in range(len(expression)):
    if  i < data[0]["operators"]["index"]:
        data[0]["numbers"]["left"] += expression[i]
    elif i > data[0]["operators"]["index"]:
        data[0]["numbers"]["right"] += expression[i]
    
match data[0]["operators"]["math_operator"]:
    case '-':
        data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') - int(f'{data[0]["numbers"]["right"]}'))
        print(f"Result: {data[0]['result']}")
    case '+':
         data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') + int(f'{data[0]["numbers"]["right"]}'))
         print(f"Result: {data[0]['result']}")
    case '*':
        data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') * int(f'{data[0]["numbers"]["right"]}'))
        print(f"Result: {data[0]['result']}")
    case '/':
        try:
            data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') / int(f'{data[0]["numbers"]["right"]}'))
            print(f"Result: {data[0]['result']}")
        except ZeroDivisionError:
            print("ZeroDivisionError")
    case _:
        print("Not result!")
print(data)
# import re
# expression = input("Enter arithmetic expression :: ")

# matches = re.match(r'(-?\d+)([-+\*/])(-?\d+)', expression)
# if matches:
#     number1 = float(matches.group(1))
#     operator = matches.group(2)
#     number2 = float(matches.group(3))

#     if operator == "+":
#         result = number1 + number2
#     elif operator == "-":
#         result = number1 - number2
#     elif operator == "*":
#         result = number1 * number2
#     elif operator == "/":
#         try:
#             result = number1 / number2
#         except ZeroDivisionError:
#             print("ZeroDivisionError")

# print(f"Результат:{'%.2f' % result}")
# # №2
# from  random import randint
# numbers = [randint(-10, 10) for _ in range(20)]
# print("Numbers list ::",end=" ")
# for i in numbers:
#     print(i,end=" ")
# print()
# print(f"Min :: {min(numbers)}")
# print(f"Max :: {max(numbers)}")
# print(f"Number of negative elements :: {sum(1 for num in numbers if num < 0)}")
# print(f"Number of positive elements :: { sum(1 for num in numbers if num > 0)} ")
# print(f"Number of zeros :: {sum(1 for num in numbers if num == 0)}")







