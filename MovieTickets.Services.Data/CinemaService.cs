using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
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

		public async Task AddCinemaAsync(CinemasViewModel actor)
		{
			Cinema cinema = new Cinema();

			cinema.Id = actor.Id;
			cinema.Name = actor.Name;
			cinema.Description = actor.Description;
			cinema.City = actor.City;
			cinema.Country = actor.Country;
			cinema.Street = actor.Street;
			cinema.LogoUrl = actor.LogoUrl;

			await dbContext.Cinemas.AddAsync(cinema);
			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteCinemaAsync(int id)
		{
			var cinema = await dbContext.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
			if (cinema != null)
			{
				dbContext.Cinemas.Remove(cinema);
				await dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<CinemasViewModel>> GetAllCinemasAsync()
		{
			return await dbContext.Cinemas
				.Select(c => new CinemasViewModel()
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

		public async Task<CinemasViewModel> GetCinemaByIdAsync(int id)
		{
			var cinema = await dbContext.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
			if (cinema != null)
			{
				var cinemaModel = new CinemasViewModel()
				{
					Id = cinema.Id,
					Name = cinema.Name,
					Description = cinema.Description,
					LogoUrl = cinema.LogoUrl,
					Country = cinema.Country,
					City = cinema.City,
					Street = cinema.Street
				};

				return cinemaModel;
			}
			
			return null!;
		}

		public async Task<CinemasViewModel> UpdateCinemaAsync(CinemasViewModel updateCinema)
		{
			var cinemaToEdit = await dbContext.Cinemas.FirstOrDefaultAsync(c => c.Id == updateCinema.Id);

			if (cinemaToEdit != null)
			{
				cinemaToEdit.Id = updateCinema.Id;
				cinemaToEdit.Name = updateCinema.Name;
				cinemaToEdit.Street = updateCinema.Street;
				cinemaToEdit.Description = updateCinema.Description;
				cinemaToEdit.City = updateCinema.City;
				cinemaToEdit.Country = updateCinema.Country;
				cinemaToEdit.LogoUrl = updateCinema.LogoUrl;
			}

			await dbContext.SaveChangesAsync();

			return (updateCinema);
		}
	}
}
