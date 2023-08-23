import json 

def open_db():
    with open("personal.json",'r',encoding="utf-8") as table:
        return json.load(table)


def db_add(first_name:str,last_name:str,birth_day:str,contact:dict,info:dict) -> dict:
    pass