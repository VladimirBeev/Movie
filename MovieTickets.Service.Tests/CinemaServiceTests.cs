using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Service.Tests
{
	using static DataBaseSeeder;
	public class CinemaServiceTests
	{
		private DbContextOptions<MovieDbContext> _dbContextOptions;

		private MovieDbContext _dbContext;

		private ICinemaService cinemaService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this._dbContextOptions = new DbContextOptionsBuilder<MovieDbContext>()
				.UseInMemoryDatabase("MovieDbInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new MovieDbContext(this._dbContextOptions, false);

			this._dbContext.Database.EnsureCreated();
			SeedCinema(this._dbContext);

			this.cinemaService = new CinemaService(this._dbContext);
		}

		[Test]
		public async Task GetCinemaByIdAsyncShouldReturnName()
		{
			var existCinema = Cinema;

			var result = await this.cinemaService.GetCinemaByIdAsync(existCinema.Id);

			Assert.That(result.Name, Is.EqualTo(existCinema.Name));
		}

		[Test]
		public async Task GetCinemaByIdAsyncShouldReturnNull()
		{
			var unexistCinema = 10000000;
			var result = await this.cinemaService.GetCinemaByIdAsync(unexistCinema);
			Assert.That(result, Is.EqualTo(null));
		}

		[Test]
		public async Task AddCinemaAsyncShouldAddActor()
		{
			var existCinemaViewModel = cinemasView;
			var addViewModel = this.cinemaService.AddCinemaAsync(existCinemaViewModel);
			var result = await this.cinemaService.GetCinemaByIdAsync(existCinemaViewModel.Id);
			Assert.That(result.Id, Is.EqualTo(existCinemaViewModel.Id));
			Assert.That(result.Name, Is.EqualTo(existCinemaViewModel.Name));
			Assert.That(result.Description, Is.EqualTo(existCinemaViewModel.Description));
		}

		[Test]
		public async Task GetAllCinemaByIdAsyncShouldReturn()
		{
			var result = await this.cinemaService.GetAllCinemasAsync();
			Assert.That(result, Has.Count.EqualTo(5));
		}

		[Test]
		public async Task DeleteCinemaAsyncReturnTrue()
		{
			var viewModel = cinemasView;
			await this.cinemaService.AddCinemaAsync(viewModel);
			var delete = this.cinemaService.DeleteCinemaAsync(viewModel.Id);
			if (delete.IsCompleted)
			{
				Assert.Pass();
			}
			Assert.Fail();
		}

		[Test]
		public async Task DeleteCinemaAsyncReturnNull()
		{
			var viewModel = 100;
			await this.cinemaService.DeleteCinemaAsync(viewModel);
			var getProducer = await this.cinemaService.GetCinemaByIdAsync(viewModel);
			Assert.That(getProducer, Is.EqualTo(null));
		}

		[Test]
		public async Task UpdateCinemaAsyncTrue()
		{
			var viewModel = cinemasView;
			await this.cinemaService.AddCinemaAsync(viewModel);
			var newviewModel = new CinemasViewModel()
			{
				Id = viewModel.Id,
				Name = "Testtt",
				Description = viewModel.Description,
			};
			var updateViewModel = await this.cinemaService.UpdateCinemaAsync(newviewModel);
			var getCinema = await this.cinemaService.GetCinemaByIdAsync(updateViewModel.Id);
			Assert.That(getCinema.Name, Is.EqualTo(newviewModel.Name));
		}

		[Test]
		public async Task UpdateCinemaAsyncNull()
		{
			var viewModel = cinemasView;
			var add = this.cinemaService.AddCinemaAsync(viewModel);
			var newviewModel = new CinemasViewModel()
			{
				Id = 500,
				Name = "Testt",
				Description = viewModel.Description,
			};
			var updateViewModel = await this.cinemaService.UpdateCinemaAsync(newviewModel);
			var getCinema = await this.cinemaService.GetCinemaByIdAsync(newviewModel.Id);
			Assert.That(getCinema, Is.EqualTo(null));
		}
	}
}
