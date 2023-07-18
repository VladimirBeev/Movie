using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MovieTickets.Common.EntityValidationConstant.MovieConstants;

namespace MovieTickets.Data.EntityModels
{
	public class Movie
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

        public MovieCategory MovieCategory { get; set; }


        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();

        public int CinemaId { get; set; }
        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; } = null!;

        public int ProducerId { get; set; }
        [ForeignKey(nameof(ProducerId))]
        public Producer Producer { get; set; } = null!;

    }
}
