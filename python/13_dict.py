import json
import requests
import os
data = requests.get("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5").json()
print(data[0])

def clear_screen():
    os.system("cls" if os.name == "nt" else "clear")

def choice(ch , currency):
    match(ch):
        case 1:
            if currency == 1:
                mach = float(input("How much money :: "))
                print(f'Result :: {mach} UAH = {"%.2f" %( mach / float(data[1]["buy"]))} USD')
            else:
                mach = float(input("How much money :: "))
                print(f'Result :: {mach} UAH = {"%.2f" %( mach / float(data[0]["buy"]))} EUR')
        case 2:
            if currency == 1:
                mach = float(input("How much money :: "))
                print(f'Result :: {mach} USD = {"%.2f" %( mach * float(data[1]["sale"]))} UAH')
            else:
                mach = float(input("How much money :: "))
                print(f'Result :: {mach} UAH = {"%.2f" %( mach * float(data[0]["sale"]))} UAH')
            
def main():
    print("===================================")
    print("=      [1] [ UAH <=> USD ]        =")
    print("=      [2] [ UAH <=> EUR ]        =")
    print("===================================")
    x = int(input("Choice operation :: "))
  
    match(x):
        case 1:
            clear_screen()
            print("======[UAH <=> USD ]=======")
            print("=     [1] UAH => USD      =")
            print("=     [2] USD => UAH      =")
            print("===========================")
            choice(int(input("Choice operation :: ")),x)
        case 2:
            clear_screen()
            print("======[UAH <=> EUR ]=======")
            print("=     [3] UAH => EUR      =")
            print("=     [4] EUR => UAH      =")
            print("===========================")
            choice(int(input("Choice operation :: ")),x)
if __name__ == "__main__":     
    main()