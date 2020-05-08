using System;
namespace ApiTest
{
    public class GenreMovie
    {
        public int movieId { get; set; }
        public MovieClass movie { get; set; }
        public int genreId { get; set; }
        public GenreClass genre { get; set; }
    }
}
