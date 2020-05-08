using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public List<MovieClass> arrayke = new List<MovieClass>();
        private MovieContext context;

        public MovieController(MovieContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public List<MovieClass> get(int? page, string sort, string genre, string title, int length = 2, string dir = "asc")
        {
            IQueryable<MovieClass> query = context.Movie;

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(m => m.Title == title);
            }
            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Include(m=>m.GenreMovies).Where(m => m.GenreMovies[0].genre.Name == genre);
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "title":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(m => m.Title);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(m => m.Title);
                        }
                        break;
                    case "date":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(m => m.ReleaseDate);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(m => m.ReleaseDate);
                        }
                        break;
                    case "director":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(m => m.Director);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(m => m.Director);
                        }
                        break;
                }
            }

            if (page.HasValue)
            {
                query = query.Skip(page.Value * length);
            }
            query = query.Take(length);

            return query.Include(Movie => Movie.Director).Include(Movie => Movie.GenreMovies).ThenInclude(Genre => Genre.genre).ToList();
        }
        [HttpPost]
        [Route("")]
        public void post([FromBody]MovieClass movie)
        {
            context.Movie.Add(movie);
            context.SaveChanges();
        }
        [HttpPut]
        [Route("")]
        public void put([FromBody]MovieClass movie)
        {
            context.Movie.Update(movie);
            context.SaveChanges();
        }
        [HttpDelete]
        [Route("{id}")]
        public void delete(int id)
        {
            context.Movie.Remove(context.Movie.SingleOrDefault(movie => movie.id == id));
            context.SaveChanges();
        }

    }
}