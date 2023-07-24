using MovieTickets.Web.ViewModels.Movie;

namespace MovieTickets.Services.Data.Interfaces
{
	public interface IMovieService
	{
		Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync();
	}
}
