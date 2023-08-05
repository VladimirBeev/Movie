using MovieTickets.Web.ViewModels.Actor;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<ICollection<ActorViewModel>> GetAllActorsAsync();

        Task AddActorAsync(ActorViewModel actor);

        Task<ActorViewModel> GetActorByIdAsync(int id);

        Task<ActorViewModel> UpdateActorAsync(ActorViewModel updateActor);

        Task DeleteActorAsync(int id);
    }
}
