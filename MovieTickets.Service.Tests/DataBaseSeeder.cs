using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Actor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Service.Tests
{
	public static class DataBaseSeeder
	{
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
				Id=20,
				Name = "Test",
				Description = "Test",
			};
		}
	}
}
