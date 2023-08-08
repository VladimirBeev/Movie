using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Actor;
using MovieTickets.Web.ViewModels.Cinema;
using MovieTickets.Web.ViewModels.Producer;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MovieTickets.Common.EntityValidationConstant.MovieConstants;
namespace MovieTickets.Web.ViewModels.Movie
{
	public class DetailsMovie
    {
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MovieTitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(MovieDescriptionMaxLength)]
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }

		[MaxLength(MovieImageUrlMaxLength)]
		public string? ImageUrl { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public string MovieCategory { get; set; }
		public string CinemaName { get; set; } = null!;
		public string ProducerName { get; set; } = null!;

		public List<ActorViewModel> actorViewModels = new List<ActorViewModel>();
	}
}
