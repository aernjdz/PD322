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
        }
    }
}
