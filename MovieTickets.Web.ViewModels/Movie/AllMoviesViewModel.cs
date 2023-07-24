namespace MovieTickets.Web.ViewModels.Movie
{
	public class AllMoviesViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string MovieCategory { get; set; } = null!;
		public string Cinema { get; set; } = null!;
		public string Producer { get; set; } = null!;
	}
}
