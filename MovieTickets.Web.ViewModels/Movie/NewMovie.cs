using MovieTickets.Data.EntityModels;

namespace MovieTickets.Web.ViewModels.Movie
{
	public class NewMovie
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public List<int> ActorIds { get; set; } = new List<int>();
		public MovieCategory MovieCategory { get; set; }
		public int CinemaId { get; set; }
		public int ProducerId { get; set; }
	}
}

