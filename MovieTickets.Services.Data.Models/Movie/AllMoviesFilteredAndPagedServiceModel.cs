using MovieTickets.Web.ViewModels.Movie;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Services.Data.Models.Movie
{
	public class AllMoviesFilteredAndPagedServiceModel
	{
        public int TotalMoviesCount { get; set; }

        public IEnumerable<AllMoviesViewModel> Movies { get; set; } = new HashSet<AllMoviesViewModel>();
    }
}
