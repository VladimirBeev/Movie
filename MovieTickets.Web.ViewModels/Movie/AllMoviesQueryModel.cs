using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Movie.Enum;

using System.ComponentModel;

using static MovieTickets.Common.GeneralAppConstants;

namespace MovieTickets.Web.ViewModels.Movie
{
	public class AllMoviesQueryModel
	{
        public AllMoviesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.MoviesPerPage = EntitiesPerPage;
        }
        public MovieCategory? Category { get; set; }

        [DisplayName("Search by word")]
        public string? SearchString { get; set; }

        [DisplayName("Sort Movies By")]
        public MovieSorting? MovieSorting { get; set; }
        public int MoviesPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalMovies { get; set; }

        public IEnumerable<AllMoviesViewModel> AllMoviesViewModels { get; set; } = new HashSet<AllMoviesViewModel>();
    }
}
