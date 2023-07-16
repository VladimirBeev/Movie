using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.EntityModels
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }


        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();
    }
}