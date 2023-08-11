using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.Property(m => m.Price)
			.HasPrecision(6, 2);

			//builder.HasData(GenerateMovies());
		}

		private Movie[] GenerateMovies()
		{
			ICollection<Movie> movies = new List<Movie>();

			Movie movie;

			movie = new Movie()
			{
				Id = 1,
				Title = "Life",
				Description = "This is the Life movie description",
				Price = 39,
				ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
				StartDate = DateTime.Now.AddDays(-10),
				EndDate = DateTime.Now.AddDays(10),
				CinemaId = 3,
				ProducerId = 3,
				MovieCategory = MovieCategory.Documentary
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 2,
				Title = "The Shawshank Redemption",
				Description = "This is the Shawshank Redemption movie description",
				Price = 29,
				ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddDays(3),
				CinemaId = 1,
				ProducerId = 1,
				MovieCategory = MovieCategory.Action
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 3,
				Title = "Ghost",
				Description = "This is the Ghost movie description",
				Price = 19,
				ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddDays(7),
				CinemaId = 4,
				ProducerId = 4,
				MovieCategory = MovieCategory.Horror
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 4,
				Title = "Race",
				Description = "This is the Race movie description",
				Price = 49,
				ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
				StartDate = DateTime.Now.AddDays(-10),
				EndDate = DateTime.Now.AddDays(-5),
				CinemaId = 1,
				ProducerId = 2,
				MovieCategory = MovieCategory.Documentary
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 5,
				Title = "Scoob",
				Description = "This is the Scoob movie description",
				Price = 59,
				ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
				StartDate = DateTime.Now.AddDays(-10),
				EndDate = DateTime.Now.AddDays(-2),
				CinemaId = 1,
				ProducerId = 3,
				MovieCategory = MovieCategory.Comedy
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 6,
				Title = "Cold Soles",
				Description = "This is the Cold Soles movie description",
				Price = 79,
				ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
				StartDate = DateTime.Now.AddDays(3),
				EndDate = DateTime.Now.AddDays(20),
				CinemaId = 1,
				ProducerId = 5,
				MovieCategory = MovieCategory.Drama
			};
			movies.Add(movie);

			return movies.ToArray();
		}
	}
}
