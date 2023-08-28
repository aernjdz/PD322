import json 
import os
def clear_screen():
    os.system("cls" if os.name == "nt" else "clear")

# load data in json
def load_db():
    with open("personal.json",'r',encoding="utf-8") as table:
        return json.load(table)
    
#generate castom user id
def generate_custom_id(first_name, last_name, department_name, number,position):
    custom_id = f"{first_name[:1]}{last_name[:1]}_{department_name}_{number}_{position}"
    return custom_id

# add new user in db
def db_add(data:dict):
    db = load_db()
    with open("personal.json","w",encoding="utf-8") as table:
        try:
            department_name = data["info"]["dep_name"]
            data["info"]["id"] = generate_custom_id(data["first_name"], data["last_name"], department_name, len([employee for employee in db if employee["info"]["dep_name"] == department_name]) + 1,data["info"]["position"])
            db.append(data)
            res  = json.dumps(db,indent=1)
            table.write(res) 
        except FileNotFoundError:
            print("DB not Found!")

# print all data db
def db_show():
    db = load_db()
    for pers in db:
        print(f'=====[{pers["info"]["id"]}]=====\n{pers["first_name"]} {pers["last_name"]}\nbirthday: {pers["birth_day"]}\n====[ contacts ]=====\nphone: {pers["contact"]["phone_number"]}\nemail: {pers["contact"]["email"]}\n======[ info ]=======\ndepartament: {pers["info"]["dep_name"]}\nposition: {pers["info"]["position"]}\n=====================\n')

#sort is dep_name      
def sort_dep():
    db = load_db()
    sorted_db = sorted(db, key=lambda x: (x["info"]["dep_name"], x["info"]["position"]))
    
    with open("personal.json", "w", encoding="utf-8") as table:
        res = json.dumps(sorted_db, indent=1)
        table.write(res)
    for pers in sorted_db:
        print(f'=====[{pers["info"]["id"]}]=====\n{pers["first_name"]} {pers["last_name"]}\nbirthday: {pers["birth_day"]}\n====[ contacts ]=====\nphone: {pers["contact"]["phone_number"]}\nemail: {pers["contact"]["email"]}\n======[ info ]=======\ndepartament: {pers["info"]["dep_name"]}\nposition: {pers["info"]["position"]}\n=====================\n')

# contact info in user db
def display_contact_info(employee):
    print(f'Contact information for {employee["first_name"]} {employee["last_name"]}:')
    print(f'Phone: {employee["contact"]["phone_number"]}')
    print(f'Email: {employee["contact"]["email"]}')

# search by name in db
def search_employee_by_name(first_name, last_name):
    db = load_db()
    found_employees = []
    for pers in db:
        if pers["last_name"].lower() == last_name.lower() and pers["first_name"].lower() == first_name.lower():
            found_employees.append(pers)
    if found_employees:
        for employee in found_employees:
            print(f'=====[{employee["info"]["id"]}]=====\n{employee["first_name"]} {employee["last_name"]}\nbirthday: {employee["birth_day"]}\n======[ info ]=======\ndepartament: {employee["info"]["dep_name"]}\nposition: {employee["info"]["position"]}\n=====================\n')
            display_contact_info(employee)
    else:
        print("Employee not found.")

# sort by dep_name
def employees_in_department(department_name):
    db = load_db()
    department_employees = []

    for pers in db:
        if pers["info"]["dep_name"].lower() == department_name.lower():
            department_employees.append(pers)

    if department_employees:
        for employee in department_employees:
            print(f'=====[{employee["info"]["id"]}]=====\n{employee["first_name"]} {employee["last_name"]}\nbirthday: {employee["birth_day"]}\n====[ contacts ]=====\nphone: {employee["contact"]["phone_number"]}\nemail: {employee["contact"]["email"]}\n======[ info ]=======\ndepartament: {employee["info"]["dep_name"]}\nposition: {employee["info"]["position"]}\n=====================\n')
    else:
        print("No employees found in the specified department.")

# user count 
def employees_in_department_count(department_name):
    db = load_db()
    count = 0

    for pers in db:
        if pers["info"]["dep_name"].lower() == department_name.lower():
            count += 1

    return count

# salary 
def calculate_salary_fund_per_department():
    db = load_db()
    department_salary_funds = {}

    for pers in db:
        department_name = pers["info"]["dep_name"]
        salary = int(pers["salary"]) 
        if department_name in department_salary_funds:
            department_salary_funds[department_name] += salary
        else:
            department_salary_funds[department_name] = salary

    return department_salary_funds

# remove data in db
def remove_employee(employee_id):
    db = load_db()
    new_db = [employee for employee in db if employee["info"]["id"] != employee_id]

    with open("personal.json", "w", encoding="utf-8") as table:
        res = json.dumps(new_db, indent=1)
        table.write(res)

    print(f"Employee with ID {employee_id} has been removed.")

# transfer user in dep
def transfer_employee(employee_id, new_department,position):
    db = load_db()

    for employee in db:
        if employee["info"]["id"] == employee_id:
            employee["info"]["dep_name"] = new_department
            employee["info"]["id"] = generate_custom_id(employee["first_name"], employee["last_name"], new_department, len([employee for employee in db if employee["info"]["dep_name"] == new_department]) + 1, position)

    with open("personal.json", "w", encoding="utf-8") as table:
        res = json.dumps(db, indent=1)
        table.write(res)

    print(f"Employee with ID {employee_id} has been transferred to department {new_department}.")
transfer_employee("EG_IT_3_Network Engineer","Marketing","Marketing Manager")

#salary report
def generate_salary_report():
    db = load_db()
    department_salary_funds = {}
    total_salary_fund = 0

   
    for employee in db:
        department_name = employee["info"]["dep_name"]
        salary = int(employee.get("salary", 0))
        
        if department_name in department_salary_funds:
            department_salary_funds[department_name] += salary
        else:
            department_salary_funds[department_name] = salary

        total_salary_fund += salary

  
    print("{:<20} {:<15} {:<10}".format("Department", "Employee Count", "Salary Fund"))
    print("="*45)

    for department, fund in department_salary_funds.items():
        employee_count = sum(1 for employee in db if employee["info"]["dep_name"] == department)
        print("{:<20} {:<15} {:<10}".format(department, employee_count, fund))
    
    print("="*45)
    print("{:<20} {:<15} {:<10}".format("Total", len(db), total_salary_fund))


flag = 1

while flag != 0:
    print("====================<[ HR department of the company ]>====================")
    print("=                                                                        =")
    print('=       [1] -> View data about all employees                             =')
    print('=       [2] -> add a new employee                                        =')
    print('=       [3] -> Removal from the database of the specified employee       =')
    print('=       [4] -> Arrangement: employees by departments, by positions       =')
    print('=       [5] -> search for an employee by last name                       =')
    print('=       [6] -> a sample of department employees                          =')
    print('=       [7] -> the number of employees in the department                 =')
    print('=       [8] -> salary fund by departments                                =')
    print('=       [9] -> transfer the employee to another department               =')
    print('=       [10] -> repport                                                  =')
    print('=       [0] -> exit                                                      =')
    print("=                                                                        =")
    print('==========================================================================')
    choice = input("Enter you choice:> ")
    match(choice):
        case '1':
            clear_screen()
            db_show()
        case '2':
            clear_screen()
            first_name = input("First Name :: ")
            last_name = input("Last Name ::")
            birth_day = input("Birthday (yyyy-mm-dd):: ")
            phone = input("Enter phone number (xxx-xxx-xxxx) :: ")
            email = input("Enter email (firstName.lastName@example.com) :: ")
            dep_name = input("Enter is departament (IT, Marketing, ...) :: ")
            position = input("Enter Position (Network Engineer, ...):: ")
            salary = int(input("Enter is salary :: >"))

            db_add( {
                    "first_name": first_name,
                    "last_name": last_name,
                    "birth_day": birth_day,
                    "contact": {
                        "email": email,
                        "phone_number": phone
                    },
                    "info": {
                        "dep_name": dep_name,
                        "position": position
                    },
                    "salary": salary
                    })
            clear_screen()
            print("Success!")
            search_employee_by_name(first_name,last_name)
        case '3':
            clear_screen()
            id = input("Enter employee ID to remove: ")
            remove_employee(id)
        case '4':
            clear_screen()
            sort_dep()
        case '5':
            clear_screen()
            first_name = input("Enter the first name of the employee: ")
            last_name = input("Enter the last name of the employee: ")
            search_employee_by_name(first_name, last_name)
        case '6':
            clear_screen()
            department_name = input("Enter the department name: ")
            employees_in_department(department_name)
        case '7':
            clear_screen()
            department_name = input("Enter the department name: ")
            count = employees_in_department_count(department_name)
            print(f"Number of employees in {department_name}: {count}")
        case '8':
            clear_screen()
            department_salary_funds = calculate_salary_fund_per_department()
            print("{:<20} {:<10}".format("Department", "Salary Fund"))
            print("="*30)
            for department, fund in department_salary_funds.items():
                print("{:<20} {:<10}".format(department, fund))
        case '9':
            clear_screen()
            employee_id = input("Enter employee ID to transfer: ")
            new_department = input("Enter new department: ")
            position = input("Enter new position: ")
            transfer_employee(employee_id, new_department, position)
        case '10':
            clear_screen()
            generate_salary_report()
        case '0':
            flag = 0
        case _:
            clear_screen()
            print("Invalid choice. Please select a valid option.")



