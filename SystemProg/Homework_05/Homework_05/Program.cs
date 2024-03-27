using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                // Create new entities
                var airplane = new Airplanes
                {
                    model = "Boeing 742",
                    type = "Passenger",
                    max_passengers = 245,
                    country = "USA"
                };

                var client = new Clients
                {
                    first_name = "test",
                    last_name = "1",
                    email = "test1@example.com",
                    gender = "M",
                    account_id = 4
                };

                var account = new Accounts
                {
                    login = "test1",
                    password = "test123"
                };

                var flight = new Flights
                {
                    flight_number = "ABC123",
                    airplane_id = 4,
                    clients = "1,2,3",
                    departure_date = DateTime.Now,
                    arrival_date = DateTime.Now.AddHours(2),
                    departure_location = "New York",
                    arrival_location = "Los Angeles"
                };

                // Add entities to context
                context.Airplanes.Add(airplane);
                context.Clients.Add(client);
                context.Accounts.Add(account);
                context.Flights.Add(flight);

                // Save changes to database
                context.SaveChanges();

                // Retrieve data from database
                var retrievedAirplane = context.Airplanes.FirstOrDefault();
                var retrievedClient = context.Clients.FirstOrDefault();
                var retrievedAccount = context.Accounts.FirstOrDefault();
                var retrievedFlight = context.Flights.FirstOrDefault();

                // Update an entity
                if (retrievedClient != null)
                {
                    retrievedClient.first_name = "Jane";
                    context.SaveChanges();
                }

                // Delete an entity
                if (retrievedAirplane != null)
                {
                    context.Airplanes.Remove(retrievedAirplane);
                    context.SaveChanges();
                }
            }
        }
    }
}