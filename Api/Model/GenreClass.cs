using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiTest
{
    public class GenreClass
    {
        public string Name { get; set; }
        public IList<GenreMovie> GenreMovies { get; set; }
        public int id { get; set; }
    }
}
