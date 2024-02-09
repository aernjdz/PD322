using System;

namespace Homework_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Game new_game = new Game(3);
            new_game.Shuffler();
            new_game.getKart();
            new_game.startGame();
        }
    }
}
