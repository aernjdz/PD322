import json
student = {
    "First_name":"Andrii",
    "Last_name":"Zarichniuk",
    "rating":11.1,
    "group":"PD322",
    "birth_date":{
        "year": 2007,
        "month":12,
        "day":10
        },
    "email": "examle@gmail.com",
    "phone":"+3800000000000"
    }

with open("13_file/output.txt","w+",encoding="utf-8") as rest:
    rest.write(1)
