namespace MovieTickets.Service.Tests
{
	using Microsoft.EntityFrameworkCore;

	using MovieTickets.Data;
	using MovieTickets.Services.Data;
	using MovieTickets.Services.Data.Interfaces;

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
	}
}