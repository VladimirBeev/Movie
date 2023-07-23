using MovieTickets.Web.ViewModels.Actor;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync();
    }
}
