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

        public async Task AddProducerAsync(ProducersViewModel producerModel)
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

        public async Task<IEnumerable<ProducersViewModel>> GetAllProducersAsync()
        {
            return await dbContext.Producers
                .Select(p => new ProducersViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,

                }).ToListAsync();
        }

        public async Task<ProducersViewModel> GetProducerByIdAsync(int id)
        {
            var producer = await dbContext.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (producer != null)
            {
                var producerModel = new ProducersViewModel()
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

        public async Task<ProducersViewModel> UpdateProducerAsync(ProducersViewModel updateProducer)
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
