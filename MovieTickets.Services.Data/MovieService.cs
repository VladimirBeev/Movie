﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Services.Data.Models.Movie;
using MovieTickets.Web.ViewModels.Actor;
using MovieTickets.Web.ViewModels.Cinema;
using MovieTickets.Web.ViewModels.Movie;
using MovieTickets.Web.ViewModels.Movie.Enum;
using MovieTickets.Web.ViewModels.Producer;

using System.Data.Common;
using System.Net;

namespace MovieTickets.Services.Data
{
    public class MovieService : IMovieService
	{
		private readonly MovieDbContext dbContext;

		public MovieService(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddMovieAsync(NewMovie moviesViewModel)
		{
			Movie movie = new Movie();

			movie.Title = WebUtility.HtmlEncode(moviesViewModel.Title);
			movie.Description = WebUtility.HtmlEncode(moviesViewModel.Description);
			movie.Price = moviesViewModel.Price;
			movie.StartDate = moviesViewModel.StartDate;
			movie.EndDate = moviesViewModel.EndDate;
			movie.ImageUrl = WebUtility.UrlEncode(moviesViewModel.ImageUrl);
			movie.CinemaId = moviesViewModel.CinemaId;
			movie.MovieCategory = moviesViewModel.MovieCategory;
			movie.ProducerId = moviesViewModel.ProducerId;

			await dbContext.Movies.AddAsync(movie);
			await dbContext.SaveChangesAsync();

			foreach (var actorId in moviesViewModel.ActorIds)
			{
				var newActorMovie = new ActorMovie();
				newActorMovie.ActorId = actorId;
				newActorMovie.MovieId = movie.Id;

				await dbContext.ActorMovies.AddAsync(newActorMovie);
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task<AllMoviesFilteredAndPagedServiceModel> AllAsync(AllMoviesQueryModel allMoviesQueryModel)
		{
			IQueryable<Movie> moviesQuery = dbContext.Movies.AsQueryable();

			if (!string.IsNullOrWhiteSpace(allMoviesQueryModel.SearchString))
			{
                string wildCard = $"%{allMoviesQueryModel.SearchString.ToLower()}%";

                moviesQuery = moviesQuery
					.Where(h => EF.Functions.Like(h.Title, wildCard) ||
								EF.Functions.Like(h.Description, wildCard));
			}

			moviesQuery = allMoviesQueryModel.MovieSorting switch
			{
				MovieSorting.Newest => moviesQuery
					.OrderByDescending(h => h.StartDate),
				MovieSorting.Oldest => moviesQuery
					.OrderBy(h => h.StartDate),
				MovieSorting.PriceAscending => moviesQuery
					.OrderBy(h => h.Price),
				MovieSorting.PriceDescending => moviesQuery
					.OrderByDescending(h => h.Price),
				_ => moviesQuery
					.OrderBy(h => h.Price)
			};

			moviesQuery = allMoviesQueryModel.Category switch
			{
				MovieCategory.Action => moviesQuery
					.Where(m => m.MovieCategory == allMoviesQueryModel.Category),
				MovieCategory.Adventure => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Comedy => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Documentary => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Drama => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Fantasy => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Horror => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Romance => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Thriller => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                MovieCategory.Western => moviesQuery
                    .Where(m => m.MovieCategory == allMoviesQueryModel.Category),
                _ => moviesQuery
					.OrderBy(m => m.MovieCategory)
			};

			ICollection<AllMoviesViewModel> allMovies = await moviesQuery
			   .Skip((allMoviesQueryModel.CurrentPage - 1) * allMoviesQueryModel.MoviesPerPage)
			   .Take(allMoviesQueryModel.MoviesPerPage)
			   .Select(h => new AllMoviesViewModel
			   {
				   Id = h.Id,
				   ImageUrl = h.ImageUrl,
				   Title = h.Title,
				   Description = h.Description,
				   StartDate = h.StartDate,
				   EndDate = h.EndDate,
				   Cinema = h.Cinema.Name,
				   Producer = h.Producer.Name,
				   Price = h.Price,
				   MovieCategory = h.MovieCategory.ToString(),
			   })
			   .ToListAsync();

			int totalHouses = moviesQuery.Count();

			return new AllMoviesFilteredAndPagedServiceModel()
			{
				TotalMoviesCount = totalHouses,
				Movies = allMovies
			};

		}
		public async Task<ICollection<AllMoviesViewModel>> GetAllMoviesAsync()
		{
			return await dbContext.Movies
				.Select(m => new AllMoviesViewModel()
				{
					Id = m.Id,
					Title = WebUtility.HtmlDecode(m.Title),
					Description = WebUtility.HtmlDecode(m.Description),
					EndDate = m.EndDate,
					StartDate = m.StartDate,
					Cinema = WebUtility.HtmlDecode(m.Cinema.Name),
					ImageUrl = WebUtility.UrlDecode(m.ImageUrl),
					Price = m.Price,
					MovieCategory = WebUtility.HtmlDecode(m.MovieCategory.ToString()),
					Producer = WebUtility.HtmlDecode(m.Producer.Name)

				}).ToListAsync();
		}

		public async Task<ICollection<AllMoviesViewModel>> GetAllMoviesAsync(int id)
		{
			return await dbContext.Movies.Where(m => m.CinemaId == id)
				.Select(m => new AllMoviesViewModel()
				{
					Id = m.Id,
					Title = WebUtility.HtmlDecode(m.Title),
					Description = WebUtility.HtmlDecode(m.Description),
					EndDate = m.EndDate,
					StartDate = m.StartDate,
					Cinema = WebUtility.HtmlDecode(m.Cinema.Name),
					ImageUrl = WebUtility.UrlDecode(m.ImageUrl),
					Price = m.Price,
					MovieCategory = WebUtility.HtmlDecode(m.MovieCategory.ToString()),
					Producer = WebUtility.HtmlDecode(m.Producer.Name)

				}).ToListAsync();
		}

		public async Task<NewMovie> GetNewMovieByIdAsync(int id)
		{
			Movie? movie = await dbContext.Movies
				.Include(c => c.Cinema)
				.Include(p => p.Producer)
				.Include(am => am.ActorMovies)
				.ThenInclude(a => a.Actor)
				.FirstOrDefaultAsync(n => n.Id == id);

            if (movie == null)
            {
				return null!;
            }

            var modelToAdd = new NewMovie();

            modelToAdd.Id = movie.Id;
            modelToAdd.Title = WebUtility.HtmlDecode(movie.Title);
            modelToAdd.Description = WebUtility.HtmlDecode(movie.Description);
            modelToAdd.Price = movie.Price;
            modelToAdd.StartDate = (DateTime)movie.StartDate!;
            modelToAdd.EndDate = (DateTime)movie.EndDate!;
            modelToAdd.ImageUrl = WebUtility.UrlDecode(movie.ImageUrl);
            modelToAdd.MovieCategory = movie.MovieCategory;
            modelToAdd.CinemaId = movie.CinemaId;
            modelToAdd.ProducerId = movie.ProducerId;
            modelToAdd.ActorIds = movie.ActorMovies.Select(n => n.ActorId).ToList();


			return modelToAdd;
		}

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie? movie = await dbContext.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.ActorMovies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (movie == null)
            {
                return null!;
            }
            return movie;
        }

        public async Task<NewMovieDropDown> GetNewMovieDropDownAsync()
		{
			var response = new NewMovieDropDown();

			response.Actors = await dbContext.Actors
				.Select(a => new ActorViewModel()
				{
					Id = a.Id,
					Name = a.Name,
					Description = a.Description,
					ImageUrl = a.ImageUrl
				})
				.OrderBy(a => a.Name)
				.ToListAsync();

			response.Cinemas = await dbContext.Cinemas
				.Select(c => new CinemasViewModel()
				{
					Id = c.Id,
					Name = c.Name,
					Description = c.Description,
					ImageUrl = c.LogoUrl,
					Country = c.Country,
					City = c.City,
					Street = c.Street
				})
				.ToListAsync();

			response.Producers = await dbContext.Producers
				.Select(p => new ProducersViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					ImageUrl = p.ImageUrl
				})
				.ToListAsync();

			return response;
		}

		public async Task<ICollection<AllMoviesViewModel>> LastThreeMovies()
		{
			return await dbContext.Movies
				.OrderByDescending(m => m.Id)
				.Select(m => new AllMoviesViewModel
				{
					Id = m.Id,
					Title = m.Title,
					ImageUrl = m.ImageUrl

				})
				.Take(3)
				.ToListAsync();
		}

		public async Task<NewMovie> UpdateMovieAsync(NewMovie updateMovieViewModel)
		{
			var movieToUpdate = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == updateMovieViewModel.Id);

			if (movieToUpdate != null)
			{
				movieToUpdate.Title = WebUtility.HtmlEncode(updateMovieViewModel.Title);
				movieToUpdate.Description = WebUtility.HtmlEncode(updateMovieViewModel.Description);
				movieToUpdate.Price = updateMovieViewModel.Price;
				movieToUpdate.ImageUrl = WebUtility.UrlEncode(updateMovieViewModel.ImageUrl);
				movieToUpdate.CinemaId = updateMovieViewModel.CinemaId;
				movieToUpdate.StartDate = updateMovieViewModel.StartDate;
				movieToUpdate.EndDate = updateMovieViewModel.EndDate;
				movieToUpdate.MovieCategory = updateMovieViewModel.MovieCategory;
				movieToUpdate.ProducerId = updateMovieViewModel.ProducerId;

				await dbContext.SaveChangesAsync();
			}

			var existingActorsDb = await dbContext.ActorMovies
				.Where(a => a.MovieId == updateMovieViewModel.Id)
				.ToListAsync();

			dbContext.RemoveRange(existingActorsDb);
			await dbContext.SaveChangesAsync();

			foreach (var actorId in updateMovieViewModel.ActorIds)
			{
				var newActorMovie = new ActorMovie();
				newActorMovie.ActorId = actorId;
				newActorMovie.MovieId = updateMovieViewModel.Id;

				await dbContext.ActorMovies.AddAsync(newActorMovie);
			}

			await dbContext.SaveChangesAsync();

			return updateMovieViewModel;
		}
	}
}
