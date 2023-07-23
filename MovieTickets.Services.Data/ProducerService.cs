using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
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
    }
}
