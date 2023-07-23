using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<AllProducersViewModel>> GetAllProducersAsync();
    }
}
