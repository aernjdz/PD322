using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_07
{
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        SciFi,
        Thriller,
    }
    class Movie : ICloneable, IComparable
    {
        public string Title { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public object Clone()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"Title: {Title}\nDirector: {Director}\nCountry: {Country}\nGenre: {Genre}\nYear: {Year}\nRating: {Rating}";
        }
        public int CompareTo(object obj)
        {
            if (obj is Movie)
            {
                return Title.CompareTo(((Movie)obj).Title);
            }
            throw new NotImplementedException();
        }
    }
    class YearComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
    class RatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }
}
