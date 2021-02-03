using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class SearchStorage
    {
        private static List<ApplicationResponse> movies = new List<ApplicationResponse>();

        public static IEnumerable<ApplicationResponse> Movies => movies;

        public static void AddMovies(ApplicationResponse movie)
        {
            if (movie.Title != "Independence Day")
            {
             movies.Add(movie);
            }
            
        }
    }
}
