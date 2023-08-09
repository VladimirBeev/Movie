using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Email address")]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}
