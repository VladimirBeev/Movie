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
				Name = "Cinema Sofia",
				LogoUrl = "https://www1.lovethatdesign.com/wp-content/uploads/2019/03/Love-that-Design-NOVO-13-1024x623.jpg",
				City = "Sofia",
				Country = "Bulgaria",
				Street = "ul.Bulgaria 10",
				Description = "We've got 5 screens of film magic, " +
				"all screening stunning RealD 3D and perfectly located on the Top floor of the Sofia Mill " +
				"Superstore.For those who love life behind the wheel, you can pick you perfect parking " +
				"spot in the underground car park outside."
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 2,
				Name = "Cinema Plovdiv",
				LogoUrl = "https://whatson.ae/wp-content/uploads/2019/02/innerNovo-high-res-07.jpg",
				City = "Plovdiv",
				Country = "Bulgaria",
				Street = "ul.Plovdiv 10",
				Description = "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly " +
				"located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, " +
				"you can pick you perfect parking spot in the underground car park outside."
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 3,
				Name = "Cinema Varna",
				LogoUrl = "https://www1.lovethatdesign.com/wp-content/uploads/2019/03/Love-that-Design-NOVO-04.jpg",
				City = "Varna",
				Country = "Bulgaria",
				Street = "ul.Varna 10",
				Description = "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly " +
				"located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, " +
				"you can pick you perfect parking spot in the underground car park outside."
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 4,
				Name = "Cinema Burgas",
				LogoUrl = "https://img.freepik.com/free-vector/movie-home-curtains-cinema-seats_1419-1853.jpg?w=2000",
				City = "Burgas",
				Country = "Bulgaria",
				Street = "ul.Burgas 10",
				Description = "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly " +
				"located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, " +
				"you can pick you perfect parking spot in the underground car park outside."
			};
			cinemas.Add(cinema);

			cinema = new Cinema()
			{
				Id = 5,
				Name = "Cinema Smolyan",
				LogoUrl = "https://img.freepik.com/free-vector/movie-home-curtains-cinema-seats_1419-1853.jpg?w=2000",
				City = "Smolyan",
				Country = "Bulgaria",
				Street = "ul.Smolyan 10",
				Description = "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly " +
				"located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, " +
				"you can pick you perfect parking spot in the underground car park outside."
			};
			cinemas.Add(cinema);

			return cinemas.ToArray();
		} 
	}
}
