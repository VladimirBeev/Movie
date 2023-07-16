using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Data.EntityModels
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? LogoUrl { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }
    }
}
