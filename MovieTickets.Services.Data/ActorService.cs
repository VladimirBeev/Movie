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

        public async Task AddActorAsync(ActorViewModel actor)
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
            var actor = await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);

            dbContext.Actors.Remove(actor);

            await dbContext.SaveChangesAsync();
        }

        public async Task<ActorViewModel> GetActorByIdAsync(int id)
        {
            Actor? actor = await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            if (actor != null)
            {
                var actorModel = new ActorViewModel()
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    Description = actor.Description,
                    ImageUrl = actor.ImageUrl,
                };

                return actorModel;
            }

            return null!;
        }

        public async Task<ICollection<ActorViewModel>> GetAllActorsAsync()
        {
            return await dbContext.Actors.Select(a => new ActorViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                ImageUrl = a.ImageUrl,

            }).ToListAsync();
        }

        public async Task<ActorViewModel> UpdateActorAsync(ActorViewModel model)
        {
            var actorToEdit = await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == model.Id);

            if (actorToEdit == null)
            {
                return null!;
            }

            actorToEdit.Id = model.Id;
            actorToEdit.Name = model.Name;
            actorToEdit.Description = model.Description;
            actorToEdit.ImageUrl = model.ImageUrl;

            await dbContext.SaveChangesAsync();

            return (model);
        }
    }
}
