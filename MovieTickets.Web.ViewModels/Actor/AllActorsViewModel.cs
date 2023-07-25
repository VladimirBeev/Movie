using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.ActorConstants;

namespace MovieTickets.Web.ViewModels.Actor
{
	public class AllActorsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ActorNameMaxLength)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = null!;

        [MaxLength(ActorDescriptionMaxLength)]
        [Display(Name = "Biography")]
        public string? Description { get; set; }

        [MaxLength(ActorImageUrlMaxLength)]
        [Display(Name = "Profile Picture")]
        public string? ImageUrl { get; set; }
    }
}
