using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface ICinemaService
    {
        Task<ICollection<CinemasViewModel>> GetAllCinemasAsync();

        Task AddCinemaAsync(CinemasViewModel actor);

        Task<CinemasViewModel> GetCinemaByIdAsync(int id);

        Task<CinemasViewModel> UpdateCinemaAsync(CinemasViewModel updateActor);

        Task DeleteCinemaAsync(int id);

    }
}
