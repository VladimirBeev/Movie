using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Services.Data
{
	public class CinemaService : ICinemaService
	{
		private readonly MovieDbContext dbContext;

		public CinemaService(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllCinemasViewModel>> GetAllCinemasAsync()
		{
			return await dbContext.Cinemas
				.Select(c => new AllCinemasViewModel() 
				{
					Id = c.Id,
					Name = c.Name,
					Description = c.Description,
					LogoUrl = c.LogoUrl,
					Country = c.Country,
					City = c.City,
					Street = c.Street

				}).ToListAsync();
		}
	}
}
