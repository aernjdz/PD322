using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    class Game
    {
        private List<Player> players;
        private List<Karta> kartas = new List<Karta>(36);
        string[] hlp = { "6", "7", "8", "9", "10", "B", "Q", "K", "A" };
        string[] suit = { "Diamonds", "Hearts", "Clubs", "Spades" };
        private void createKarts()
        {
            foreach( var item in suit)
            {
                for (uint i = 0; i < hlp.Length; i++)
                {
                    kartas.Add(new Karta(item,hlp[i],i));

                }
            }
        }
        public Game(int num)
        {
            players = new List<Player>(num);

            for(int i = 0; i < num; i++)
            {
                players.Add(new Player());
            }
            createKarts();

        }
        public void Print()
        {
            foreach (var item in players)
            {
                Console.WriteLine(item.GetType().Name);
                item.Print();
            }
        }
        public void Shuffler()
        {
            Random rnd = new Random();
            for (int i = 0; i < 36; i++)
            {
                int one = rnd.Next(0, kartas.Count()), two = rnd.Next(0, kartas.Count());
                var tmp = kartas[one];
                kartas[one] = kartas[two];
                kartas[two] = tmp;
            }
        }
        public void getKart()
        {
            for (int i = 0; i < kartas.Count; i+= players.Count) {
                for (int j = 0; j < players.Count; j++)
                {
                    players[j].list.Add(kartas[i + j]);
                }
            }
        }
        public void startGame()
        {
            while (check())
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.Write($"{players[i].list.Count,-15}");
                }
                Console.WriteLine();
                for (int i = 0; i < players.Count; i++)
                {
                    Console.Write($"Player [{i+1}]");
                }
                Console.WriteLine();
                for (int i = 0; i < players.Count; i++)
                {
                    Console.Write($"{players[i].list[0],-27}");

                }
                Console.WriteLine();
                giveKart();
            }
            Console.WriteLine("\n\n===============[Game Over]===============");

        }

        private int win()
        {
            int max = 0;
            for (int i = 0; i < players.Count-1; i++)
            {
                if (players[max].list[0].Priory < players[i].list[0].Priory)
                {
                    max = i + 1;
                }
            }
            return max;
        }
        private void giveKart()
        {
            int res = win();
            List<Karta> tmp = new List<Karta>();
            for (int i = 0; i < players.Count; i++)
            {
                tmp.Add(players[i].list[0]);
                players[i].list.RemoveAt(0);
            }
            players[res].list.AddRange(tmp);
        }

        private bool check()
        {
            return players.FindAll(s => s.list.Count > 0).Count > 2;
        }
    }
}
