using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Web.ViewModels.Account
{
	public class RegisterViewModel
	{
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; } = null!;

        [Required]
        [DisplayName("Email address")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;

        [Required]
        [DisplayName("Confirm password")]
        [PasswordPropertyText]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; } = null!;
    }
}
