using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
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

        public async Task AddActorAsync(AllActorsViewModel actor)
        {
            Actor newActor = new Actor();

            newActor.Id = actor.Id;
            newActor.Name = actor.Name;
            newActor.Description = actor.Description;
            newActor.ImageUrl = actor.ImageUrl;

            await dbContext.Actors.AddAsync(newActor);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteActorAsync(int id)
        {
            var actor = await dbContext.Actors.FindAsync(id);
            dbContext.Actors.Remove(actor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actor = await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return actor;
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

        public async Task<AllActorsViewModel> UpdatActorAsync(int id, AllActorsViewModel updateActor)
        {
            return updateActor;
        }
    }
}
