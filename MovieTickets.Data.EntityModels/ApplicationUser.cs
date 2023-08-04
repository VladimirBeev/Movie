using Microsoft.AspNetCore.Identity;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static MovieTickets.Common.EntityValidationConstant.UserConstant;

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
