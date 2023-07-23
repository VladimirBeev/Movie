using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Actor;

namespace MovieTickets.Services.Data
{
    public class ActorService : IActorService
    {
        private readonly MovieDbContext dbContext;

        public ActorService(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync()
        {
            return await dbContext.Actors.Select(a => new AllActorsViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                ImageUrl = a.ImageUrl,

            }).ToListAsync();
        }
    }
}
