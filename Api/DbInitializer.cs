using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiTest
{
    public class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();
            var genreAction = new GenreClass()
            {
                Name = "Action",
            };
            var genreComedy = new GenreClass()
            {
                Name = "Comedy",
            };
            var director = new DirectorClass()
            {
                FirstName = "Steven",
                LastName = "Spielberg",
                BirthDate = DateTime.Now
            };
            var Movie = new MovieClass()
            {
                ReleaseDate = DateTime.Now,
                Title = "The Incredibles",
                Director = director,
            };
            var GenreMovie = new GenreMovie(){
                genre  = genreAction,
                movie = Movie
            };
            Movie.GenreMovies = new List<GenreMovie>();
            Movie.GenreMovies.Add(GenreMovie);
            if (context.Movie.Count() == 0)
            {
                context.Movie.Add(Movie);
                context.SaveChanges();
            }
            if (context.Director.Count() == 0)
            {
                context.Director.Add(director);
                context.SaveChanges();
            }
        }
    }
}
