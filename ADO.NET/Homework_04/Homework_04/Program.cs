using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Homework_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDBEntities library = new LibraryDBEntities();
            Console.WriteLine("Task N1");
            Console.WriteLine();
            var books = library.books.Where(b => b.pages_count > 100).ToList();

            if (books.Count != 0)
            {


                foreach (var book in books)
                {
                    Console.WriteLine($"Book(ID) :: {book.ID,-5} Name :: {book.book_name,-20} Author(ID) :: {book.author_id} Language(ID) :: {book.language_id} Pages :: {book.pages_count}");
                }
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine("Task N2");
            Console.WriteLine();
            var booksStartingWithA = library.books.Where(b => b.book_name.StartsWith("A") || b.book_name.StartsWith("a")).ToList();
            if (booksStartingWithA.Count != 0)
            {
                foreach (var book in booksStartingWithA)
                {
                    Console.WriteLine($"Book(ID) :: {book.ID,-5} Name :: {book.book_name,-20} Author(ID) :: {book.author_id} Language(ID) :: {book.language_id} Pages :: {book.pages_count}");
                }
            }
            else {
                Console.WriteLine("(null)");
            }

            Console.WriteLine("Task N3");
            Console.WriteLine();
            var shakespeareBooks = library.books.Where(b => b.author.author_name == "William" && b.author.author_surname == "Shakespeare").ToList();
            if (shakespeareBooks.Count != 0)
            {
                foreach (var book in shakespeareBooks)
                {
                    Console.WriteLine($"Book(ID) :: {book.ID,-5} Name :: {book.book_name,-20} Author(ID) :: {book.author_id} Language(ID) :: {book.language_id} Pages :: {book.pages_count}");
                }
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine("Task N4");
            Console.WriteLine();
            var ukrainianBooks = library.books.Where(b => b.language.language_name == "Ukrainian").ToList();
            if (ukrainianBooks.Count != 0)
            {
                foreach (var book in ukrainianBooks)
                {
                    Console.WriteLine($"Book(ID) :: {book.ID,-5} Name :: {book.book_name,-20} Author(ID) :: {book.author_id} Language(ID) :: {book.language_id} Pages :: {book.pages_count}");
                }
            }
            else
            {
                Console.WriteLine("(null)");
            }

            Console.WriteLine("Task N5");
            Console.WriteLine();
            var shortNameBooks = library.books.Where(b => b.book_name.Length < 10).ToList();
            if (shortNameBooks.Count != 0)
            {
                foreach (var book in shortNameBooks)
                {
                    Console.WriteLine($"Book(ID) :: {book.ID,-5} Name :: {book.book_name,-20} Author(ID) :: {book.author_id} Language(ID) :: {book.language_id} Pages :: {book.pages_count}");
                }
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine("Task N6");
            Console.WriteLine();
            var maxPages = library.books.Where(b => b.language.language_name == "English").Max(b => b.pages_count); // I am use English (American) :)
            var maxPagesBook = library.books.Where(b => b.language.language_name == "English" && b.pages_count == maxPages).FirstOrDefault();
            if (maxPagesBook != null)
            {
                Console.WriteLine($"Book(ID) :: {maxPagesBook.ID,-5} Name :: {maxPagesBook.book_name,-20} Author(ID) :: {maxPagesBook.author_id} Language(ID) :: {maxPagesBook.language_id} Pages :: {maxPagesBook.pages_count}");
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine("Task N7");
            Console.WriteLine();
            var authorBooksCount = library.books.GroupBy(b => b.author_id).Select(g => new { AuthorID = g.Key, BooksCount = g.Count() }).ToList();
           
            int minBooksCountAuthorID = (int)authorBooksCount.OrderBy(ab => ab.BooksCount).Select(ab => ab.AuthorID).FirstOrDefault();
            
            var minBooksAuthor = library.authors.FirstOrDefault(a => a.ID == minBooksCountAuthorID);
            if (minBooksAuthor != null)
            {
                Console.WriteLine($"Author(ID) :: {minBooksAuthor.ID,-5} Name :: {minBooksAuthor.author_name,-10} Surname :: {minBooksAuthor.author_surname} Age :: {minBooksAuthor.age}");
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine("Task N8");
            Console.WriteLine();
            var authorsExceptAmerican = library.authors.Where(a => !a.books.Any(b => b.language.language_name == "English")).OrderBy(a => a.author_name).ToList();
            // I am use English (American) :)

            foreach (var author in authorsExceptAmerican)
            {
                Console.WriteLine($"Author(ID) :: {author.ID,-5} Name :: {author.author_name,-20} Surname :: {author.author_surname}");
            }
            Console.WriteLine("Task N9");
            Console.WriteLine();
            var countryBooksCount = library.books
       .GroupBy(b => b.language.country.country_name)
       .Select(g => new { CountryName = g.Key, BooksCount = g.Count() })
       .ToList();

            var maxBooksCountry = countryBooksCount
    .OrderByDescending(cb => cb.BooksCount)
    .FirstOrDefault();

            if (maxBooksCountry != null)
            {
                Console.WriteLine($"Country :: {maxBooksCountry.CountryName,-20} Books Count :: {maxBooksCountry.BooksCount}");
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine("Task N10");
            Console.WriteLine();
            var authorLanguagesCount = library.books
    .GroupBy(b => b.author_id)
    .Select(g => new { AuthorID = g.Key, LanguagesCount = g.Select(b => b.language_id).Distinct().Count() })
    .ToList();
            var authorsWithDifferentLanguages = authorLanguagesCount
    .Where(a => a.LanguagesCount > 1)
    .OrderByDescending(a => a.LanguagesCount)
    .ToList();
            foreach (var author in authorsWithDifferentLanguages)
            {
                var authorData = library.authors.FirstOrDefault(a => a.ID == author.AuthorID);
                if (authorData != null)
                {
                    Console.WriteLine($"Author(ID) :: {authorData.ID,-5} Name :: {authorData.author_name,-20} Surname :: {authorData.author_surname} Languages Count :: {author.LanguagesCount}");
                }
            }

            if (authorsWithDifferentLanguages.Count == 0)
            {
                Console.WriteLine("(null)");
            }
        }


    }
}
