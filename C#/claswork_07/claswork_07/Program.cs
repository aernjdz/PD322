using System;
using System.Linq;
using System.Collections.Generic;
namespace claswork_07
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> years = new List<int> { 2000, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036 };
            var leap_Years = years.Where(year => DateTime.IsLeapYear(year)).OrderBy(year => year);

            Console.WriteLine("Leap Years ::");
            foreach (var year in leap_Years)
            {
                Console.WriteLine(year);
            }

            List<int> numbers = new List<int> { 5, 8, 12, 3, 16, 7, 22, 9 };
            var maxEven = numbers.Where(num => num % 2 == 0).Max();
            Console.WriteLine("Maximum Even Value :: " + maxEven);

            List<string> strings = new List<string> { "Hello", "How", "Are", "You", "Today?" };

            var modifiedStrings = strings.Select(str => str + "!!!");

            Console.WriteLine("Result ::");
            foreach (var str in modifiedStrings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Enter the character C ::");
            char C = Console.ReadLine()[0];
            Console.WriteLine("Enter the string collection A (comma-separated) ::");
            List<string> A = Console.ReadLine().Split(',').ToList();

            var filteredStrings = A.Where(str => str.Contains(C));
            Console.WriteLine("Strings containing character C ::");
            foreach (var str in filteredStrings)
            {
                Console.WriteLine(str);
            }

            List<string> s = new List<string> { "orange", "grape", "kiwi", "pear", "melon" };

            var groupedStrings = s.GroupBy(str => str.Length);
            Console.WriteLine("Grouped Strings by Length ::");
            foreach (var group in groupedStrings)
            {
                Console.WriteLine($"Strings with {group.Key} characters ::");
                foreach (var str in group)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine();
            }

            List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 35, Salary = 6000, Position = "Manager" },
            new Employee { Name = "Alice", Age = 25, Salary = 4500, Position = "Assistant" },
            new Employee { Name = "Bob", Age = 40, Salary = 7000, Position = "Manager" },
            new Employee { Name = "Emily", Age = 30, Salary = 5500, Position = "Supervisor" },
            new Employee { Name = "David", Age = 45, Salary = 8000, Position = "Director" }


        };

            var selected_Employees = employees.Where(emp => emp.Salary > 5000).Select(emp => new { emp.Name, emp.Salary });
            var employees_Over_30 = employees.Where(emp => emp.Age > 30).OrderByDescending(emp => emp.Age);
            double averageAge = employees.Average(emp => emp.Age);
            var groupedByPosition = employees.GroupBy(emp => emp.Position);


            Console.WriteLine("Employees with salary > 5000 ::");
            foreach (var emp in selected_Employees)
            {
                Console.WriteLine($"Name: {emp.Name}, Salary :: {emp.Salary}");
            }
            Console.WriteLine("\nEmployees over 30 ordered by age (descending) ::");
            foreach (var emp in employees_Over_30)
            {
                Console.WriteLine($"Name: {emp.Name}, Age :: {emp.Age}");
            }
            Console.WriteLine($"\nAverage age of employees :: {averageAge}");

            Console.WriteLine("\nEmployees grouped by position:");
            foreach (var group in groupedByPosition)
            {
                Console.WriteLine($"Position: {group.Key}");
                foreach (var emp in group)
                {
                    Console.WriteLine($" - Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
                }
            }
        }
    }
}
