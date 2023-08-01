using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducersViewModel>> GetAllProducersAsync();

        Task<ProducersViewModel> GetProducerByIdAsync(int id);

        Task AddProducerAsync(ProducersViewModel producer);

        Task<ProducersViewModel> UpdateProducerAsync(ProducersViewModel updateProducer);

        Task DeleteProducerAsync(int id);
    }
}
