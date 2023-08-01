using MovieTickets.Web.ViewModels.Actor;
using MovieTickets.Web.ViewModels.Cinema;
using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Web.ViewModels.Movie
{
	public class NewMovieDropDown
	{
        public NewMovieDropDown()
        {
            Producers = new List<ProducersViewModel>();
            Cinemas = new List<CinemasViewModel>();
            Actors = new List<ActorViewModel>();
        }

        public List<ProducersViewModel> Producers { get; set; }
        public List<CinemasViewModel> Cinemas { get; set; }
        public List<ActorViewModel> Actors { get; set; }
    }
}
