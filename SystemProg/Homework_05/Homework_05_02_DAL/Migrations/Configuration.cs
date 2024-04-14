namespace Homework_05_02_DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Homework_05_02_DAL.LIbraryModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Homework_05_02_DAL.LIbraryModel context)
        {
            var authors = new List<Author>
    {
        new Author { Name = "George Orwell" },
        new Author { Name = "Jane Austen" },
        new Author { Name = "Ernest Hemingway" },
        new Author { Name = "J.K. Rowling" },
        new Author { Name = "Leo Tolstoy" }
    };

            authors.ForEach(a => context.Authors.AddOrUpdate(a));
            context.SaveChanges();

            // Books
            var books = new List<Book>
    {
        new Book { Title = "1984", AuthorId = 1, Year = 1949, Genre = "Dystopian Fiction" },
        new Book { Title = "Pride and Prejudice", AuthorId = 2, Year = 1813, Genre = "Romance" },
        new Book { Title = "The Old Man and the Sea", AuthorId = 3, Year = 1952, Genre = "Literary Fiction" },
        new Book { Title = "Harry Potter and the Philosopher's Stone", AuthorId = 4, Year = 1997, Genre = "Fantasy" },
        new Book { Title = "War and Peace", AuthorId = 5, Year = 1869, Genre = "Historical Fiction" },
        new Book { Title = "Animal Farm", AuthorId = 1, Year = 1945, Genre = "Political Satire" },
        new Book { Title = "Sense and Sensibility", AuthorId = 2, Year = 1811, Genre = "Romance" },
        new Book { Title = "For Whom the Bell Tolls", AuthorId = 3, Year = 1940, Genre = "War" },
        new Book { Title = "Harry Potter and the Chamber of Secrets", AuthorId = 4, Year = 1998, Genre = "Fantasy" },
        new Book { Title = "Anna Karenina", AuthorId = 5, Year = 1877, Genre = "Romantic Tragedy" },
        new Book { Title = "Brave New World", AuthorId = 1, Year = 1932, Genre = "Dystopian Fiction" },
        new Book { Title = "Emma", AuthorId = 2, Year = 1815, Genre = "Romance" },
        new Book { Title = "The Sun Also Rises", AuthorId = 3, Year = 1926, Genre = "Modernist Literature" },
        new Book { Title = "Harry Potter and the Prisoner of Azkaban", AuthorId = 4, Year = 1999, Genre = "Fantasy" },
        new Book { Title = "Crime and Punishment", AuthorId = 5, Year = 1866, Genre = "Psychological Fiction" },
        new Book { Title = "To Kill a Mockingbird", AuthorId = 1, Year = 1960, Genre = "Southern Gothic" },
        new Book { Title = "Mansfield Park", AuthorId = 2, Year = 1814, Genre = "Domestic Fiction" },
        new Book { Title = "A Farewell to Arms", AuthorId = 3, Year = 1929, Genre = "War" },
        new Book { Title = "Harry Potter and the Goblet of Fire", AuthorId = 4, Year = 2000, Genre = "Fantasy" },
        new Book { Title = "The Death of Ivan Ilyich", AuthorId = 5, Year = 1886, Genre = "Philosophical Fiction" }
    };

            books.ForEach(b => context.Books.AddOrUpdate(b));
            context.SaveChanges();
        }

    }
}