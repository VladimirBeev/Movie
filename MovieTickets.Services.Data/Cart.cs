using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;

using System.Text;

namespace MovieTickets.Services.Data
{
	public class Cart
	{
		private readonly MovieDbContext context;
		public string ShoppingCartId { get; set; } = null!;
		public List<ShoppingCartItems>? ShoppingCartItems { get; set; }

		public Cart(MovieDbContext context)
		{
			this.context = context;
		}

		public static Cart GetShoppingCart(IServiceProvider services)
		{
			ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<MovieDbContext>();

			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", cartId);

			return new Cart(context) { ShoppingCartId = cartId };
		}
	}
}
