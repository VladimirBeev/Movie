using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MovieTickets.Common.EntityValidationConstant.OrderConstant;

namespace MovieTickets.Data.EntityModels
{
	public class Order
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[EmailAddress]
		[MaxLength(OrderEmailMaxLength)]
		[DisplayName("Email Address")]
		public string Email { get; set; } = null!;

		[Required]
		public Guid UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; } = null!;

		public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
