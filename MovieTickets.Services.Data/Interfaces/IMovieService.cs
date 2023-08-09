using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Models.Movie;
using MovieTickets.Web.ViewModels.Movie;

namespace MovieTickets.Services.Data.Interfaces
{
	public interface IMovieService
    {
        Task<ICollection<AllMoviesViewModel>> GetAllMoviesAsync();

        Task AddMovieAsync(NewMovie moviesViewModel);

        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropDown> GetNewMovieDropDownAsync();

        Task<NewMovie> UpdateMovieAsync(NewMovie updateMovieViewModel);

        Task<ICollection<AllMoviesViewModel>> LastThreeMovies();

        Task<AllMoviesFilteredAndPagedServiceModel> AllAsync(AllMoviesQueryModel allMoviesQueryModel);
    }
}
