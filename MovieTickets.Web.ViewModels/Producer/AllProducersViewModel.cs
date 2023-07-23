using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieTickets.Web.ViewModels.Producer
{
    public class AllProducersViewModel
	{
        public int Id { get; set; }

		[Display(Name = "Full Name")]
		public string Name { get; set; } = null!;

		[Display(Name = "Biography")]
		public string? Description { get; set; } = null!;

		[Display(Name = "Profile Picture")]
		public string? ImageUrl { get; set; } = null!;
    }
}
