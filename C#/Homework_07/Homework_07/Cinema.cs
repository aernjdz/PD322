using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    class Cinema : IEnumerable
    {
        private List<Movie> movies = new List<Movie>();

        public string Address { get; set; }

        public IEnumerator GetEnumerator()
        {
            return movies.GetEnumerator();
        }

        public void Sort()
        {
            movies.Sort();
        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public void Sort(IComparer<Movie> comparer)
        {
            movies.Sort(comparer);
        }

    }
}
