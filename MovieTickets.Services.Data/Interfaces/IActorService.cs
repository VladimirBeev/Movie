using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Actor;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync();

        Task<AllActorsViewModel> GetActorByIdAsync(int id);

        Task AddActorAsync(AllActorsViewModel actor);

        Task<AllActorsViewModel> UpdatActorAsync(int id, AllActorsViewModel updateActor);

        Task DeleteActorAsync(int id);
    }
}
