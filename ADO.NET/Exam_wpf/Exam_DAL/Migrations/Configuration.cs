namespace Exam_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exam_DAL.LibraryModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Exam_DAL.LibraryModel context)
        {
            context.Books.AddOrUpdate(
                b => b.title,
                new book
                {
                    title = "The Great Gatsby",
                    author_name = "F. Scott Fitzgerald",
                    publisher = "Scribner",
                    pages = 180,
                    genre = "Classic",
                    publication_year = 1925,
                    cost_price = 5.00m,
                    selling_price = 10.00m,
                    is_reserved = "N",
                    is_shared = "N"
                },
                new book
                {
                    title = "To Kill a Mockingbird",
                    author_name = "Harper Lee",
                    publisher = "J. B. Lippincott & Co.",
                    pages = 281,
                    genre = "Fiction",
                    publication_year = 1960,
                    cost_price = 6.50m,
                    selling_price = 12.00m,
                    is_reserved = "N",
                    is_shared = "Y"
                },
                new book
                {
                    title = "1984",
                    author_name = "George Orwell",
                    publisher = "Secker & Warburg",
                    pages = 328,
                    genre = "Dystopian",
                    publication_year = 1949,
                    cost_price = 7.25m,
                    selling_price = 14.00m,
                    is_reserved = "N",
                    is_shared = "N"
                },
                new book
                {
                    title = "The Catcher in the Rye",
                    author_name = "J.D. Salinger",
                    publisher = "Little, Brown and Company",
                    pages = 224,
                    genre = "Classic",
                    publication_year = 1951,
                    cost_price = 6.75m,
                    selling_price = 13.00m,
                    is_reserved = "N",
                    is_shared = "N"
                },
                new book
                {
                    title = "Pride and Prejudice",
                    author_name = "Jane Austen",
                    publisher = "T. Egerton, Whitehall",
                    pages = 279,
                    genre = "Romance",
                    publication_year = 1813,
                    cost_price = 5.50m,
                    selling_price = 11.00m,
                    is_reserved = "N",
                    is_shared = "Y"
                },
                new book
                {
                    title = "To the Lighthouse",
                    author_name = "Virginia Woolf",
                    publisher = "Hogarth Press",
                    pages = 209,
                    genre = "Modernist",
                    publication_year = 1927,
                    cost_price = 8.00m,
                    selling_price = 16.00m,
                    is_reserved = "N",
                    is_shared = "N"
                },
                new book
                {
                    title = "The Hobbit",
                    author_name = "J.R.R. Tolkien",
                    publisher = "George Allen & Unwin",
                    pages = 310,
                    genre = "Fantasy",
                    publication_year = 1937,
                    cost_price = 7.50m,
                    selling_price = 15.00m,
                    is_reserved = "N",
                    is_shared = "N"
                }
            );

            context.SaveChanges();
        }

    }
}
