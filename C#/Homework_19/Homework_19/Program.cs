using System;

namespace Homework_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race();
            SportsCar sportsCar = new SportsCar();
            Sedan sedan = new Sedan();
            Bus bus = new Bus();

            race.StartRace += race.CarStart;
            race.EndRace += race.PrintWinner;

            sportsCar.Finish += (sender, e) => race.CarFinish("Sports Car");
            sedan.Finish += (sender, e) => race.CarFinish("Sedan");
            bus.Finish += (sender, e) => race.CarFinish("Bus");

            race.Start();

            while (sportsCar.Speed < 100 || sedan.Speed < 100 || bus.Speed < 100)
            {
                sportsCar.Move();
                sedan.Move();
                bus.Move();

                race.PrintCarStatus("Sports Car", sportsCar.Speed);
                race.PrintCarStatus("Sedan", sedan.Speed);
                race.PrintCarStatus("Bus", bus.Speed);
            }
        }
    }
}
