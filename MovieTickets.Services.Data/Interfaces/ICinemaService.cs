using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Services.Data.Interfaces
{
	public interface ICinemaService
	{
		Task<IEnumerable<AllCinemasViewModel>> GetAllCinemasAsync();
	}
}
