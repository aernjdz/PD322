#N1
expression = input("Enter arithmetic expression :: ").strip(" ")
print(expression)
data = [ {
    "numbers": {
        "left": 0,
        "right": 0,
        },
    "operators": {
        "start_operator":"",
        "math_operator":"",
        "index":0
    }
    }]
if expression.startswith('-'):
    data[0]["operators"]["start_operator"] = "-"
    expression = "".join([char for num, char in enumerate(expression) if num != 0])

for i in expression:
    if i in ["+", "-","*","/"]:
        data[0]["operators"]["math_operator"] = i
        data[0]["operators"]["index"] = expression.index(i)

print(data)




