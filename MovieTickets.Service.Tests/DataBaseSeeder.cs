using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Actor;
using MovieTickets.Web.ViewModels.Cinema;
using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Service.Tests
{
	public static class DataBaseSeeder
	{
		public static Cinema Cinema;
		public static CinemasViewModel cinemasView;
		public static Producer Producer;
		public static ProducersViewModel producersViewModel;
		public static Actor Actor;
		public static ActorViewModel ViewModel;

		public static void SeedActor(MovieDbContext dbContext)
		{
			Actor = new Actor()
			{
				Id = 1,
				Name = "Ryan Reynolds",
			};

			ViewModel = new ActorViewModel()
			{
				Id = 20,
				Name = "Test",
				Description = "Test",
			};
		}

		public static void SeedProducer(MovieDbContext dbContext)
		{
			Movie[] movies = new Movie[]
			{
				new Movie()
				{
					Id  = 20,
					Title = "Test",
					Description = "Test",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					Price = 1,
					CinemaId = 1,
					ProducerId = 1,
					MovieCategory = MovieCategory.Action,
					ImageUrl = "",
				},
				new Movie()
				{
					Id  = 30,
					Title = "TestT",
					Description = "TestT",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					Price = 2,
					CinemaId = 2,
					ProducerId = 2,
					MovieCategory = MovieCategory.Action,
					ImageUrl = "",
				},
			};

			Producer = new Producer()
			{
				Id = 1,
				Name = "Daniel Espinosa",
				Description = "Test",
				ImageUrl = "",
				Movies = movies
			};

			producersViewModel = new ProducersViewModel()
			{
				Id = 20,
				Name = "Test",
				Description = "Test",
				ImageUrl = ""
			};
		}

		public static void SeedCinema(MovieDbContext dbContext)
		{
			Movie[] movies = new Movie[]
			{
				new Movie()
				{
					Id  = 20,
					Title = "Test",
					Description = "Test",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					Price = 1,
					CinemaId = 1,
					ProducerId = 1,
					MovieCategory = MovieCategory.Action,
					ImageUrl = "",
				},
				new Movie()
				{
					Id  = 30,
					Title = "TestT",
					Description = "TestT",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					Price = 2,
					CinemaId = 2,
					ProducerId = 2,
					MovieCategory = MovieCategory.Action,
					ImageUrl = "",
				},
			};

			Cinema = new Cinema()
			{
				Id = 1,
				Name = "Cinema Sofia",

			};

			cinemasView = new CinemasViewModel()
			{
				Id = 20,
				Name = "Test",
			};
		}
	}
}
