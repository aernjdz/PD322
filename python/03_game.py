from random import choice
print ("-----Game «Stone scissors  paper  lizard Spock»----\n")
user = 0
bot = 0

user_score = 0
bot_score = 0
name = {
    "r":"Rock",
    "p":"Scissors",
    "s":"Paper",
    "l":"Lizard",
    "k":"Spock"
}
game_stats = {
    "won":0,
    "lose":0,
    "draw":0
}
flag = 1
while flag == 1:
    user_score = 0
    bot_score = 0
    for i in range(5):
        print("========[Round#{}]========".format(i+1))
        print("=\t[r]- Rock\t=","=\t[s]- Scissors\t=","=\t[p]- Paper\t=","=\t[l]- Lizard\t=","=\t[k]- Spock\t=",sep="\n")
        print("=========================")
        while True:
            user = input("Enter you Choise :: ").lower()
            if user == "r" or user == "s" or user == "p" or user == "l" or user == "k":
                break
            else:
                print("Wrong Choice!") 
        bot = choice("rpslk")
        if user == "r" and bot == "s" or user == "k" and bot == "p" or user == "r" and bot == "l" or user == "l" and bot == "k" or user == "k" and bot == "s" or user == "s" and bot == "l" or user == "l" and bot == "p" or user == "k" and bot == "r" or user == "s" and bot ==  "p" or user == "p" and bot == "r":
            print("========[You Won!!!]========")
            user_score += 1
        elif bot == "r" and user == "s" or bot == "k" and user == "p" or bot == "r" and user == "l" or bot == "l" and user == "k" or bot == "k" and user == "s" or bot == "s" and user == "l" or bot == "l" and user == "p" or bot == "k" and user == "r" or bot == "s" and user ==  "p" or bot == "p" and user == "r":
            bot_score += 1
            print("========[You Lose!!!]========")
        else:
            print("========[Draw!!!]========")
        if user_score > bot_score:
            print("\n=[Score]============[Choise]=======\n")
            print("= You: {} \t|\t= You: {}".format(user_score,name[user]))
            print("= Bot: {}\t|\t= Bot: {}".format(bot_score,name[bot]))
            print("\n===================================\n")
            
        elif user_score < bot_score:
            print("\n=[Score]============[Choise]=======\n")
            print("= You: {} \t|\t= You: {}".format(user_score,name[user]))
            print("= Bot: {}\t|\t= Bot: {}".format(bot_score,name[bot]))
            print("\n===================================\n")
            
        elif user_score == bot_score:
            print("\n=[Score]============[Choise]=======\n")
            print("= You: {} \t|\t= You: {}".format(user_score,name[user]))
            print("= Bot: {}\t|\t= Bot: {}".format(bot_score,name[bot]))
            print("\n===================================\n")
            
    else:
        if  user_score > bot_score:
            game_stats["won"] +=1
        elif user_score < bot_score:
            game_stats["lose"] +=1
        elif user_score == bot_score:
            game_stats["draw"] +=1
        print("Restart game?")

        print("1/0","1 - yes 0 - no")

        flag = int(input('[]:>'))
else:
    print("\n============[Game Stats]================\n")
    print("= Game Won: {}".format(game_stats["won"]))
    print("= Game Lose: {}".format(game_stats["lose"]))
    print("= Game Draw: {}".format(game_stats["draw"]))
    print("\n========================================\n")