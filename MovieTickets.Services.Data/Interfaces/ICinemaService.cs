using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemasViewModel>> GetAllCinemasAsync();

        Task<CinemasViewModel> GetCinemaByIdAsync(int id);

        Task AddCinemaAsync(CinemasViewModel actor);

        Task<CinemasViewModel> UpdateCinemaAsync(CinemasViewModel updateActor);

        Task DeleteCinemaAsync(int id);
    }
}
