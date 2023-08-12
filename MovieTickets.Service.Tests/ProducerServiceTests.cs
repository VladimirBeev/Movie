namespace MovieTickets.Service.Tests
{
	using Microsoft.EntityFrameworkCore;

	using MovieTickets.Data;
	using MovieTickets.Services.Data;
	using MovieTickets.Services.Data.Interfaces;
	using MovieTickets.Web.ViewModels.Actor;
	using MovieTickets.Web.ViewModels.Producer;

	using static DataBaseSeeder;
	public class ProducerServiceTests
	{
		private DbContextOptions<MovieDbContext> _dbContextOptions;

		private MovieDbContext _dbContext;

		private IProducerService producerService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this._dbContextOptions = new DbContextOptionsBuilder<MovieDbContext>()
				.UseInMemoryDatabase("MovieDbInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new MovieDbContext(this._dbContextOptions, false);

			this._dbContext.Database.EnsureCreated();
			SeedProducer(this._dbContext);

			this.producerService = new ProducerService(this._dbContext);
		}

		[Test]
		public async Task GetProducerByIdAsyncShouldReturnName()
		{
			var existProducer = Producer;

			var result = await this.producerService.GetProducerByIdAsync(existProducer.Id);

			Assert.That(result.Name, Is.EqualTo(existProducer.Name));
		}

		[Test]
		public async Task GetProducerByIdAsyncShouldReturnNull()
		{
			var unexistActor = 10000000;
			var result = await this.producerService.GetProducerByIdAsync(unexistActor);
			Assert.That(result, Is.EqualTo(null));
		}

		[Test]
		public async Task AddProducerAsyncShouldAddActor()
		{
			var existProducerViewModel = producersViewModel;
			var addViewModel = this.producerService.AddProducerAsync(existProducerViewModel);
			var result = await this.producerService.GetProducerByIdAsync(existProducerViewModel.Id);
			Assert.That(result.Id, Is.EqualTo(existProducerViewModel.Id));
			Assert.That(result.Name, Is.EqualTo(existProducerViewModel.Name));
			Assert.That(result.Description, Is.EqualTo(existProducerViewModel.Description));
		}

		[Test]
		public async Task GetAllProducerByIdAsyncShouldReturn()
		{
			var result = await this.producerService.GetAllProducersAsync();
			Assert.That(result, Has.Count.EqualTo(5));
		}

		[Test]
		public async Task DeleteProducerAsyncReturnTrue()
		{
			var viewModel = producersViewModel;
			var addView = this.producerService.AddProducerAsync(viewModel);
			var delete = this.producerService.DeleteProducerAsync(viewModel.Id);
			if (delete.IsCompleted)
			{
				Assert.Pass();
			}
			Assert.Fail();
		}

		[Test]
		public async Task DeleteProducerAsyncReturnNull()
		{
			var viewModel = 100;
			await this.producerService.DeleteProducerAsync(viewModel);
			var getProducer = await this.producerService.GetProducerByIdAsync(viewModel);
			Assert.That(getProducer, Is.EqualTo(null));
		}

		[Test]
		public async Task UpdateProducerAsyncTrue()
		{
			var viewModel = producersViewModel;
			var addViewModel = this.producerService.AddProducerAsync(viewModel);
			var newviewModel = new ProducersViewModel()
			{
				Id = viewModel.Id,
				Name = "Testtt",
				Description = viewModel.Description,
			};
			var updateViewModel = await this.producerService.UpdateProducerAsync(newviewModel);
			var getProducer = await this.producerService.GetProducerByIdAsync(updateViewModel.Id);
			Assert.That(getProducer.Name, Is.EqualTo(newviewModel.Name));
		}

		[Test]
		public async Task UpdateProducerAsyncNull()
		{
			var viewModel = producersViewModel;
			var add = this.producerService.AddProducerAsync(viewModel);
			var newviewModel = new ProducersViewModel()
			{
				Id = 500,
				Name = "Testt",
				Description = viewModel.Description,
			};
			var updateViewModel = await this.producerService.UpdateProducerAsync(newviewModel);
			var getProducer = await this.producerService.GetProducerByIdAsync(newviewModel.Id);
			Assert.That(getProducer, Is.EqualTo(null));
		}
	}
}