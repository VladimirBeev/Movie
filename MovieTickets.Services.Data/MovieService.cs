using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Movie;

using System;
using System.Globalization;

namespace MovieTickets.Services.Data
{
	public class MovieService : IMovieService
	{
		private readonly MovieDbContext dbContext;

		public MovieService(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync()
		{
			return await dbContext.Movies
				.Select(m => new AllMoviesViewModel()
				{
					Id = m.Id,
					Title = m.Title,
					Description = m.Description,
					EndDate = m.EndDate,
					StartDate = m.StartDate,
					Cinema = m.Cinema.Name,
					ImageUrl = m.ImageUrl,
					Price = m.Price,
					MovieCategory = m.MovieCategory.ToString(),
					Producer = m.Producer.Name

				}).ToListAsync();
		}
	}
}
