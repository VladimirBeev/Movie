using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Cinema;
using MovieTickets.Web.ViewModels.Movie;

using System.Net;

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
			cinema.Name = WebUtility.HtmlEncode(actor.Name);
			cinema.Description = WebUtility.HtmlEncode(actor.Description);
			cinema.City = WebUtility.HtmlEncode(actor.City);
			cinema.Country = WebUtility.HtmlEncode(actor.Country);
			cinema.Street = WebUtility.HtmlEncode(actor.Street);
			cinema.LogoUrl = WebUtility.UrlEncode(actor.ImageUrl);

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

		public async Task<ICollection<CinemasViewModel>> GetAllCinemasAsync()
		{
			return await dbContext.Cinemas
				.Select(c => new CinemasViewModel()
				{
					Id = c.Id,
					Name = WebUtility.HtmlDecode(c.Name),
					Description = WebUtility.HtmlDecode(c.Description),
					ImageUrl = WebUtility.UrlDecode(c.LogoUrl),
					Country = WebUtility.HtmlDecode(c.Country),
					City = WebUtility.HtmlDecode(c.City),
					Street = WebUtility.HtmlDecode(c.Street)

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
					Name = WebUtility.HtmlDecode(cinema.Name),
					Description = WebUtility.HtmlDecode(cinema.Description),
					ImageUrl = WebUtility.UrlDecode(cinema.LogoUrl),
					Country = WebUtility.HtmlDecode(cinema.Country),
					City = WebUtility.HtmlDecode(cinema.City),
					Street = WebUtility.HtmlDecode(cinema.Street)
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
				cinemaToEdit.Name = WebUtility.HtmlEncode(updateCinema.Name);
				cinemaToEdit.Street = WebUtility.HtmlEncode(updateCinema.Street);
				cinemaToEdit.Description = WebUtility.HtmlEncode(updateCinema.Description);
				cinemaToEdit.City = WebUtility.HtmlEncode(updateCinema.City);
				cinemaToEdit.Country = WebUtility.HtmlEncode(updateCinema.Country);
				cinemaToEdit.LogoUrl = WebUtility.UrlEncode(updateCinema.ImageUrl);
			}

			await dbContext.SaveChangesAsync();

			return (updateCinema);
		}
	}
}
