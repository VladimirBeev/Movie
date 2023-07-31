using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<AllProducersViewModel>> GetAllProducersAsync();

        Task<AllProducersViewModel> GetProducerByIdAsync(int id);

        Task AddProducerAsync(AllProducersViewModel producer);

        Task<AllProducersViewModel> UpdateProducerAsync(AllProducersViewModel updateProducer);

        Task DeleteProducerAsync(int id);
    }
}
