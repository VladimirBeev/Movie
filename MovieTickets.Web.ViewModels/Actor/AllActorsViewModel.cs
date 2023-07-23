using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieTickets.Web.ViewModels.Actor
{
    public class AllActorsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Biography")]
        public string? Description { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ImageUrl { get; set; }
    }
}
