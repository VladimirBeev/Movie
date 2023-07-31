using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.CinemaConstants;

namespace MovieTickets.Web.ViewModels.Cinema
{
	public class CinemasViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(CinemaNameMaxLength, MinimumLength = CinemaNameMinLength)]
		public string Name { get; set; } = null!;

		[StringLength(CinemaDescriptionMaxLength, MinimumLength = CinemaDescriptionMinLength)]
		public string? Description { get; set; }

		[StringLength(CinemaLogoUrlMaxLength)]
		public string? LogoUrl { get; set; }

		[StringLength(CinemaCountryMaxLength, MinimumLength = CinemaCountryMinLength)]
		public string? Country { get; set; }

		[StringLength(CinemaCityMaxLength, MinimumLength = CinemaCityMinLength)]
		public string? City { get; set; }

		[StringLength(CinemaStreetMaxLength, MinimumLength = CinemaStreetMinLength)]
		public string? Street { get; set; }
	}
}
