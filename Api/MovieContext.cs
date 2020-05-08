using System;
using Microsoft.EntityFrameworkCore;

namespace ApiTest
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreMovie>().HasKey(sc => new { sc.movieId, sc.genreId });
        }
        public DbSet<MovieClass> Movie { get; set; }
        public DbSet<DirectorClass> Director { get; set; }
        public DbSet<GenreClass> Genre { get; set; }
        public DbSet<GenreMovie> genreMovie { get; set; }
    }
}
