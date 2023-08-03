using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Data.EntityModels
{
	public class ShoppingCartItems
	{
		[Key]
		public int Id { get; set; }

        public Movie Movie { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }

    }
}
