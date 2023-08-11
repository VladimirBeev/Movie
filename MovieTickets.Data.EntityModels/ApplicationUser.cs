using Microsoft.AspNetCore.Identity;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.EntityModels
{
	public class ApplicationUser : IdentityUser<Guid>
	{
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [DisplayName("Fill Name")]
		[Required]
		public string FullName { get; set; } = null!;
	}
}
