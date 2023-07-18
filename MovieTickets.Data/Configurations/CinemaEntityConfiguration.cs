using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class CinemaEntityConfiguration : IEntityTypeConfiguration<Cinema>
	{
		public void Configure(EntityTypeBuilder<Cinema> builder)
		{
			builder.HasData(GenerateCinemas());
		}

		private Cinema[] GenerateCinemas()
		{
			ICollection<Cinema> cinemas = new List<Cinema>();

			Cinema cinema;

			cinema = new Cinema()
			{
				Id = 1,
				Name = "Cinema Sofiq",
				LogoUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
				City = "Sofia",
				Country = "Bulgaria",
				Street = "ul.Bulgaria 10",
				Description = "This is my first Cinema in Sofia"
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 2,
				Name = "Cinema Plovdiv",
				LogoUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
				City = "Plovdiv",
				Country = "Bulgaria",
				Street = "ul.Plovdiv 10",
				Description = "This is my first Cinema in Plovdiv"
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 3,
				Name = "Cinema Varna",
				LogoUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
				City = "Varna",
				Country = "Bulgaria",
				Street = "ul.Varna 10",
				Description = "This is my first Cinema in Varna"
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 4,
				Name = "Cinema Burgas",
				LogoUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
				City = "Burgas",
				Country = "Bulgaria",
				Street = "ul.Burgas 10",
				Description = "This is my first Cinema in Burgas"
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 5,
				Name = "Cinema Smolyan",
				LogoUrl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
				City = "Smolyan",
				Country = "Bulgaria",
				Street = "ul.Smolyan 10",
				Description = "This is my first Cinema in Smolyan"
			};
			cinemas.Add(cinema);

			return cinemas.ToArray();
		} 
	}
}
