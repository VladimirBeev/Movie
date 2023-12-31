﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DisplayName("Confirm password")]
		[DataType(DataType.Password)]
		[Compare("Password")]
        public string PasswordConfirmation { get; set; } = null!;
    }
}
