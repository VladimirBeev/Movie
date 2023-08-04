using MovieTickets.Web.ViewModels.Actor;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorViewModel>> GetAllActorsAsync();

        Task<ActorViewModel> GetActorByIdAsync(int id);

        Task AddActorAsync(ActorViewModel actor);

        Task<ActorViewModel> UpdateActorAsync(ActorViewModel updateActor);

        Task DeleteActorAsync(int id);
    }
}
