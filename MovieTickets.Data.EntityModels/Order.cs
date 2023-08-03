using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Data.EntityModels
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		public string Email { get; set; }

		public string UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; } = null!;

		public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
