using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.ActorConstants;

namespace MovieTickets.Web.ViewModels.Actor
{
	public class ActorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ActorNameMaxLength, MinimumLength = ActorNameMinLength)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = null!;

        [StringLength(ActorDescriptionMaxLength, MinimumLength = ActorDescriptionMinLength)]
        [Display(Name = "Biography")]
        public string? Description { get; set; }

        [MaxLength(ActorImageUrlMaxLength)]
        [Display(Name = "Profile Picture")]
        public string? ImageUrl { get; set; }
    }
}
