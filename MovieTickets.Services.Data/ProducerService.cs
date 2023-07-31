using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Services.Data
{
    public class ProducerService : IProducerService
    {
        private readonly MovieDbContext dbContext;

        public ProducerService(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProducerAsync(AllProducersViewModel producerModel)
        {
            Producer producer = new Producer();
            producer.Id = producerModel.Id;
            producer.Name = producerModel.Name;
            producer.Description = producerModel.Description;
            producer.ImageUrl = producerModel.ImageUrl;

            await dbContext.Producers.AddAsync(producer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProducerAsync(int id)
        {
            var producer = await dbContext.Producers.FirstOrDefaultAsync(p => p.Id == id);
            if (producer != null)
            {
                dbContext.Producers.Remove(producer);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllProducersViewModel>> GetAllProducersAsync()
        {
            return await dbContext.Producers
                .Select(p => new AllProducersViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,

                }).ToListAsync();
        }

        public async Task<AllProducersViewModel> GetProducerByIdAsync(int id)
        {
            var producer = await dbContext.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (producer != null)
            {
                var producerModel = new AllProducersViewModel()
                {
                    Id = producer.Id,
                    Name = producer.Name,
                    Description = producer.Description,
                    ImageUrl = producer.ImageUrl
                };

                return producerModel;
            }

            return null!;
        }

        public async Task<AllProducersViewModel> UpdateProducerAsync(AllProducersViewModel updateProducer)
        {
            var producer = await dbContext.Producers.FirstOrDefaultAsync(p => p.Id == updateProducer.Id);

            if (producer != null)
            {
                producer.Id = updateProducer.Id;
                producer.Name = updateProducer.Name;
                producer.Description = updateProducer.Description;
                producer.ImageUrl = updateProducer.ImageUrl;
            }

            await dbContext.SaveChangesAsync();

            return updateProducer;
        }
    }
}
