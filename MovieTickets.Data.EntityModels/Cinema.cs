using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.CinemaConstants;

namespace MovieTickets.Data.EntityModels
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CinemaNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(CinemaDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(CinemaLogoUrlMaxLength)]
        public string? LogoUrl { get; set; }

        [MaxLength(CinemaCountryMaxLength)]
        public string? Country { get; set; }

        [MaxLength(CinemaCityMaxLength)]
        public string? City { get; set; }

        [MaxLength(CinemaStreetMaxLength)]
        public string? Street { get; set; }


        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
