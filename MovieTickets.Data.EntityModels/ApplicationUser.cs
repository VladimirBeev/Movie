using Microsoft.AspNetCore.Identity;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.EntityModels
{
	public class ApplicationUser : IdentityUser
	{
		[DisplayName("Fill Name")]
		[Required]
		public string FullName { get; set; }
	}
}
