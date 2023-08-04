using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.EntityModels
{
    public class ShoppingCartItems
	{
		[Key]
		public Guid Id { get; set; }

        [Required]
        public Movie Movie { get; set; } = null!;

        public int Amount { get; set; }

        [Required]
        public string ShoppingCartId { get; set; } = null!;

    }
}
