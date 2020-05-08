using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiTest
{
    public class MovieClass
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DirectorClass Director { get; set; }
        [Url]
        public string ImdbUrl{get;set;}
        public IList<GenreMovie> GenreMovies { get; set; }
        public int id { get; set; }
    }
}
