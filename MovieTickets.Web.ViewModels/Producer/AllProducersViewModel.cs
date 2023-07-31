using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.ProducerConstants;

namespace MovieTickets.Web.ViewModels.Producer
{
	public class AllProducersViewModel
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[StringLength(ProducerNameMaxLength, MinimumLength = ProducerNameMinLength)]
		[Display(Name = "Full Name")]
		public string Name { get; set; } = null!;

		[StringLength(ProducerDescriptionMaxLength, MinimumLength = ProducerDescriptionMinLength)]
		[Display(Name = "Biography")]
		public string? Description { get; set; } = null!;

		[StringLength(ProducerImageUrlMaxLength)]
		[Display(Name = "Profile Picture")]
		public string? ImageUrl { get; set; } = null!;
    }
}
