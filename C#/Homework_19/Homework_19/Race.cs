using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_19
{
    class Race
    {
        public delegate void StartRaceDelegate();
        public delegate void EndRaceDelegate(string winner);

        public event StartRaceDelegate StartRace;
        public event EndRaceDelegate EndRace;

        public void Start()
        {
            StartRace?.Invoke();
        }

        public void PrintCarStatus(string carType, int speed)
        {
            Console.WriteLine($"{carType}: {speed} km/h");
        }

        public void PrintWinner(string winner)
        {
            Console.WriteLine($"Winner :: {winner}");
        }

        public void CarStart()
        {
          
            Console.WriteLine("The race has begun!");
        }

        public void CarFinish(string winner)
        {
         
            EndRace?.Invoke(winner);
        }
    }
}
