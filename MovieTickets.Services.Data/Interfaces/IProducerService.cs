using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IProducerService
    {
        Task<ICollection<ProducersViewModel>> GetAllProducersAsync();

        Task AddProducerAsync(ProducersViewModel producer);

        Task<ProducersViewModel> GetProducerByIdAsync(int id);

        Task<ProducersViewModel> UpdateProducerAsync(ProducersViewModel updateProducer);

        Task DeleteProducerAsync(int id);
    }
}
