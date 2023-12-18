using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace City_
{
      internal class City
{
        private string cityName;
        private string countryName;
        private int population;
        private string phoneCode;
        private string[] districts;

        public City()
        {
           
            cityName = "";
            countryName = "";
            population = 0;
            phoneCode = "";
            districts = new string[0]; 
        }

        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        public int Population
        {
            get { return population; }
            set { population = value; }
        }

        public string PhoneCode
        {
            get { return phoneCode; }
            set { phoneCode = value; }
        }

        public string[] Districts
        {
            get { return districts; }
            set { districts = value; }
        }

        
        public City(string cityName, string countryName, int population, string phoneCode, string[] districts)
        {
            CityName = cityName;
            CountryName = countryName;
            Population = population;
            PhoneCode = phoneCode;
            Districts = districts;
        }


        public void InputData()
        {
            Console.Write("Enter city name: ");
            string cityNameInput;
            do
            {
                cityNameInput = Console.ReadLine().Trim(); 

                if (string.IsNullOrWhiteSpace(cityNameInput))
                {
                    Console.WriteLine("Invalid input for city name. Please enter a non-empty name.");
                    Console.Write("Enter city name: ");
                }

            } while (string.IsNullOrWhiteSpace(cityNameInput));

            CityName = cityNameInput;

            Console.Write("Enter country name: ");
            string countryNameInput;
            do
            {
                countryNameInput = Console.ReadLine().Trim(); 
                if (string.IsNullOrWhiteSpace(countryNameInput))
                {
                    
                    Console.WriteLine("Invalid input for country name. Please enter a non-empty name.");
                    Console.Write("Enter country name: ");
                }

            } while (string.IsNullOrWhiteSpace(countryNameInput));

            CountryName = countryNameInput;

            bool validPopulationInput = false;
            do
            {
                Console.Write("Enter the population of the city: ");
                string populationInput = Console.ReadLine().Trim(); 
                validPopulationInput = !string.IsNullOrWhiteSpace(populationInput) && int.TryParse(populationInput, out population);

                if (!validPopulationInput)
                {
                    Console.WriteLine("Invalid input for population. Please enter a non-empty integer.");
                    Console.Write("Enter the population of the city: ");
                }

            } while (!validPopulationInput);

            Console.Write("Enter phone code of the city: ");
            PhoneCode = Console.ReadLine();

            bool validDistrictsInput = false;
            do
            {
                Console.Write("Enter names of the city districts (separated by commas): ");
                string districtsInput = Console.ReadLine().Trim(); 
                validDistrictsInput = !string.IsNullOrWhiteSpace(districtsInput);

                if (validDistrictsInput)
                {
                    Districts = districtsInput.Split(',');
                }
                else
                {
                    Console.WriteLine("Invalid input for districts. Please enter non-empty names separated by commas.");
                    Console.Write("Enter phone code of the city: ");
                }

            } while (!validDistrictsInput);
        }




        public void DisplayData()
        {
            Console.WriteLine($"City: {CityName}");
            Console.WriteLine($"Country: {CountryName}");
            Console.WriteLine($"number of population: {Population}");
            Console.WriteLine($"Telephone code: {PhoneCode}");
            Console.WriteLine($"Name of districts: {string.Join(", ", Districts)}");
        }
    }
}

