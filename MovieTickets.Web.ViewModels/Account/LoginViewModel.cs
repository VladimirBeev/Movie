﻿using System.ComponentModel;
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
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
