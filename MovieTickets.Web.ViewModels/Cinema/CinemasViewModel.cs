using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Web.ViewModels.Cinema
{
	public class CinemasViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public string? LogoUrl { get; set; }
		public string? Country { get; set; }
		public string? City { get; set; }
		public string? Street { get; set; }
	}
}
