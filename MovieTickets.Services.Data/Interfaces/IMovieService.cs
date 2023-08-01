using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Movie;

namespace MovieTickets.Services.Data.Interfaces
{
	public interface IMovieService
	{
		Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync();
		Task<Movie> GetMovieByIdAsync(int id);

		Task<NewMovieDropDown> GetNewMovieDropDownAsync();

		Task AddMovieAsync(NewMovie moviesViewModel);

		Task<NewMovie> UpdateMovieAsync(NewMovie updateMovieViewModel);

		Task DeleteMovieAsync(int id);
	}
}
