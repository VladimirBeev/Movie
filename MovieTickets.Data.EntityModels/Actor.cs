using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.ActorConstants;

namespace MovieTickets.Data.EntityModels
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ActorNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ActorDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(ActorImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();
    }
}