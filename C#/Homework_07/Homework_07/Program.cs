using System;
using System.Linq;
using System.Collections.Generic;
namespace Homework_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema
            {
                Address = "123 Main Street"
            };

            cinema.AddMovie(new Movie
            {
                Title = "Inception",
                Director = new Director("Nolan", "Christopher"),
                Country = "USA",
                Genre = Genre.SciFi,
                Year = 2010,
                Rating = 8.8
            }); cinema.AddMovie(new Movie
            {
                Title = "The Shawshank Redemption",
                Director = new Director("Darabont", "Frank"),
                Country = "USA",
                Genre = Genre.Drama,
                Year = 1994,
                Rating = 9.3
            });

            // Display the movies in the Cinema
            Console.WriteLine("Movies in the Cinema:");
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
            }

            // Sort movies by default (using IComparable)
            Console.WriteLine("\nMovies after sorting by default:");
            cinema.Sort();
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
            }

            // Sort movies by a custom comparer (using IComparer)
            Console.WriteLine("\nMovies after sorting by year:");
            cinema.Sort(new YearComparer());
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine("\nMovies after sorting by rating:");
            cinema.Sort(new RatingComparer());
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
