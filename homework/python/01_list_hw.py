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
    case '+':
         data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') + int(f'{data[0]["numbers"]["right"]}'))
    case '*':
        data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') * int(f'{data[0]["numbers"]["right"]}'))
    case '/':
        try:
            data[0]['result'] = (int(f'{data[0]["operators"]["start_operator"]}{data[0]["numbers"]["left"]}') / int(f'{data[0]["numbers"]["right"]}'))
        except ZeroDivisionError:
            print("ZeroDivisionError")
    case _:
        print("Not result!")
print(data[0]['result'])
 





