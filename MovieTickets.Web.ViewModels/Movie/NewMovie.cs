using Microsoft.AspNetCore.Http;

using MovieTickets.Data.EntityModels;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.MovieConstants;

namespace MovieTickets.Web.ViewModels.Movie
{
	public class NewMovie
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength)]
		public string Title { get; set; } = null!;

        [Required]
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength)]
        public string Description { get; set; } = null!;

		[Range(typeof(decimal),MoviePriceMinValue, MoviePriceMaxValue)]
        public decimal Price { get; set; }

        [MaxLength(MovieTitleMaxLength)]
		[DisplayName("Movie Image")]
        public string? ImageUrl { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now;

        [DisplayName("Actors")]
        public List<int> ActorIds { get; set; } = new List<int>();

        [DisplayName("Category")]
        public MovieCategory MovieCategory { get; set; }

        //[DisplayName("Cinema")]
        [Range(1,5)]
        public int CinemaId { get; set; }

        [DisplayName("Producer")]
        public int ProducerId { get; set; }
	}
}

