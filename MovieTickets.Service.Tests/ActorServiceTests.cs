namespace MovieTickets.Service.Tests
{
	using Microsoft.EntityFrameworkCore;

	using MovieTickets.Data;
	using MovieTickets.Services.Data;
	using MovieTickets.Services.Data.Interfaces;
	using MovieTickets.Web.ViewModels.Actor;

	using static DataBaseSeeder;
	public class ActorServiceTests
	{
		private DbContextOptions<MovieDbContext> _dbContextOptions;

		private MovieDbContext _dbContext;

		private IActorService actorService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this._dbContextOptions = new DbContextOptionsBuilder<MovieDbContext>()
				.UseInMemoryDatabase("MovieDbInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new MovieDbContext(this._dbContextOptions, false);

			this._dbContext.Database.EnsureCreated();
			SeedActor(this._dbContext);

			this.actorService = new ActorService(this._dbContext);
		}

		[Test]
		public async Task GetActorByIdAsyncShouldReturnName()
		{
			var existActor = Actor;
			var result = await this.actorService.GetActorByIdAsync(existActor.Id);
			Assert.That(result.Name, Is.EqualTo(existActor.Name));
		}

		[Test]
		public async Task GetActorByIdAsyncShouldReturnNull()
		{
			var unexistActor = 10000000;
			var result = await this.actorService.GetActorByIdAsync(unexistActor);
			Assert.That(result, Is.EqualTo(null));
		}

		[Test]
		public async Task AddActorAsyncSuoidAddActor()
		{
			var existActorViewModel = ViewModel;
			var addViewModel = this.actorService.AddActorAsync(existActorViewModel);
			var result = await this.actorService.GetActorByIdAsync(existActorViewModel.Id);
			Assert.That(result.Id, Is.EqualTo(existActorViewModel.Id));
			Assert.That(result.Name, Is.EqualTo(existActorViewModel.Name));
			Assert.That(result.Description, Is.EqualTo(existActorViewModel.Description));
		}

		[Test]
		public async Task GetAllActorByIdAsyncShouldReturnNull()
		{
			var result = await this.actorService.GetAllActorsAsync();
			Assert.That(result.Count, Is.EqualTo(5));
		}

		[Test]
		public async Task DeleteActorAsyncReturnTrue()
		{
			var viewModel = ViewModel;
			var addViewModel = this.actorService.AddActorAsync(viewModel);
			await actorService.DeleteActorAsync(viewModel.Id);
			var getActor = await actorService.GetActorByIdAsync(viewModel.Id);
			Assert.That(getActor, Is.EqualTo(null));
		}

		[Test]
		public async Task DeleteActorAsyncReturnNull()
		{
			var viewModel = ViewModel;
			await actorService.DeleteActorAsync(viewModel.Id);
			var getActor = await actorService.GetActorByIdAsync(viewModel.Id);
			Assert.That(getActor, Is.EqualTo(null));
		}

		[Test]
		public async Task UpdateActorAsyncTrue()
		{
			var viewModel = ViewModel;
			var addViewModel = this.actorService.AddActorAsync(viewModel);
			var newviewModel = new ActorViewModel()
			{
				Id = viewModel.Id,
				Name = "Testt",
				Description = viewModel.Description,
			};
			var updateViewModel = await actorService.UpdateActorAsync(newviewModel);
			var getActor = await actorService.GetActorByIdAsync(viewModel.Id);
			Assert.That(getActor.Name, Is.EqualTo(newviewModel.Name));
		}

		[Test]
		public async Task UpdateActorAsyncNull()
		{
			var viewModel = ViewModel;
			var newviewModel = new ActorViewModel()
			{
				Id = 20,
				Name = "Testt",
				Description = viewModel.Description,
			};
			var updateViewModel = await actorService.UpdateActorAsync(newviewModel);
			Assert.That(updateViewModel, Is.EqualTo(null));
		}
	}
}