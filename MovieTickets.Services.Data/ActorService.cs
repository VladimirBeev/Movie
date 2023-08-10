using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Actor;

using System.Net;

namespace MovieTickets.Services.Data
{
    public class ActorService : IActorService
    {
        private readonly MovieDbContext dbContext;

        public ActorService(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddActorAsync(ActorViewModel actorModel)
        {
            string actorName = WebUtility.HtmlEncode(actorModel.Name);
            actorModel.Name = actorName;

            string? actorDescription = WebUtility.HtmlEncode(actorModel.Description);
            actorModel.Description = actorDescription;

            string? actorImageUrl = WebUtility.UrlEncode(actorModel.ImageUrl);
            actorModel.ImageUrl = actorImageUrl;

            Actor newActor = new Actor();

            newActor.Id = actorModel.Id;
            newActor.Name = actorModel.Name;
            newActor.Description = actorModel.Description;
            newActor.ImageUrl = actorModel.ImageUrl;

            await dbContext.Actors.AddAsync(newActor);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteActorAsync(int id)
        {
            var actor = await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);

            if (actor != null)
            {
                dbContext.Actors.Remove(actor);

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ActorViewModel> GetActorByIdAsync(int id)
        {
            Actor? actor = await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            if (actor != null)
            {
                ActorViewModel actorModel = new ActorViewModel()
                {
                    Id = actor.Id,
                    Name = WebUtility.HtmlDecode(actor.Name),
                    Description = WebUtility.HtmlDecode(actor.Description),
                    ImageUrl = WebUtility.UrlDecode(actor.ImageUrl),
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
                Name = WebUtility.HtmlDecode(a.Name),
                Description = WebUtility.HtmlDecode(a.Description),
                ImageUrl = WebUtility.UrlDecode(a.ImageUrl),

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
            actorToEdit.Name = WebUtility.HtmlEncode(model.Name);
            actorToEdit.Description = WebUtility.HtmlEncode(model.Description);
            actorToEdit.ImageUrl = WebUtility.UrlEncode(model.ImageUrl);

            await dbContext.SaveChangesAsync();

            return (model);
        }
    }
}
