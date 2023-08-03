using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Data.EntityModels
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int Amount { get; set; }

		[Precision(8,2)]
		public decimal Price { get; set; }

        public int MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }

        public int OrderId { get; set; }
		[ForeignKey(nameof(OrderId))]
		public Order Order { get; set; } = null!;
    }
}
