using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Producer;

using System.Net;

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
            producer.Name = WebUtility.HtmlEncode(producerModel.Name);
            producer.Description = WebUtility.HtmlEncode(producerModel.Description);
            producer.ImageUrl = WebUtility.UrlEncode(producerModel.ImageUrl);

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

        public async Task<ICollection<ProducersViewModel>> GetAllProducersAsync()
        {
            return await dbContext.Producers
                .Select(p => new ProducersViewModel()
                {
                    Id = p.Id,
                    Name = WebUtility.HtmlDecode(p.Name),
                    Description = WebUtility.HtmlDecode(p.Description),
                    ImageUrl = WebUtility.UrlDecode(p.ImageUrl),

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
                    Name = WebUtility.HtmlDecode(producer.Name),
                    Description = WebUtility.HtmlDecode(producer.Description),
                    ImageUrl = WebUtility.HtmlDecode(producer.ImageUrl)
                };

                return producerModel;
            }

            return null!;
        }

        public async Task<ProducersViewModel> UpdateProducerAsync(ProducersViewModel updateProducer)
        {
            var producer = await dbContext.Producers.FirstOrDefaultAsync(p => p.Id == updateProducer.Id);

            if (producer == null)
            {
                return null!;
            }

			producer.Id = updateProducer.Id;
			producer.Name = WebUtility.HtmlEncode(updateProducer.Name);
			producer.Description = WebUtility.HtmlEncode(updateProducer.Description);
			producer.ImageUrl = WebUtility.HtmlEncode(updateProducer.ImageUrl);

			await dbContext.SaveChangesAsync();

            return updateProducer;
        }
    }
}
