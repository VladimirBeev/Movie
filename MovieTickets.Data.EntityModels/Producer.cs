using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.EntityModels
{
    public class Producer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }


        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
