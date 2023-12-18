using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using City_;
namespace task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city = new City("Kyiv", "Ukraine", 2800000, "(44)", new string[] { "Pechersky", "Holosiivskyi", "Shevchenkivskyi" });
            Console.WriteLine("Initial data about the city:");
            city.DisplayData();
            city.Population = 3000000;
            city.Districts = new string[] { "Pecherskyi", "Holosiivskyi", "Shevchenkivskyi", "Solomyanskyi" };

           
            Console.WriteLine("\nChanged city data:");
            city.DisplayData();

            City myCity = new City();
            myCity.InputData();
            myCity.DisplayData();
        }
    }
}
