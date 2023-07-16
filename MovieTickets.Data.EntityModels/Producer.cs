using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.ProducerConstants;

namespace MovieTickets.Data.EntityModels
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProducerNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ProducerDescriptionMaxLength)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }


        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
