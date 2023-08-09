using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;

namespace Shopping
{
	public class ShoppingCart
	{
		public MovieDbContext context { get; set; }

		public string ShoppingCartId { get; set; } = null!;
		public List<ShoppingCartItems> ShoppingCartItems { get; set; }

		public ShoppingCart(MovieDbContext context)
		{
			this.context = context;
		}

		public static ShoppingCart GetShoppingCart(IServiceProvider services)
		{
			ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			MovieDbContext? context = services.GetService<MovieDbContext>();

			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", cartId);

			return new ShoppingCart(context!) { ShoppingCartId = cartId };
		}

		public void AddItemToCart(Movie movie)
		{
			var shoppingCartItem = context.ShoppingCartItems
				.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

			if (shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItems()
				{
					ShoppingCartId = ShoppingCartId,
					Movie = movie,
					Amount = 1
				};

				context.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;
			}

			context.SaveChanges();
		}

		public void RemoveItemFromCart(Movie movie)
		{
			var shoppingCartItem = context.ShoppingCartItems
				.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
				}
				else
				{
					context.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}

			context.SaveChanges();
		}

		public List<ShoppingCartItems> GetShoppingCartItems()
		{
			return ShoppingCartItems ?? 
				(ShoppingCartItems = context.ShoppingCartItems
				.Where(n => n.ShoppingCartId == ShoppingCartId)
				.Include(n => n.Movie)
				.ToList());
		}

		public decimal GetShoppingCartTotal()
		{
            return  context.ShoppingCartItems
				.Where(n => n.ShoppingCartId == ShoppingCartId)
				.Select(n => n.Movie.Price * n.Amount)
				.Sum();
        }

		public async Task ClearShoppingCartAsync()
		{
			var items = await context.ShoppingCartItems
				.Where(n => n.ShoppingCartId == ShoppingCartId)
				.ToListAsync();

			context.ShoppingCartItems.RemoveRange(items);

			await context.SaveChangesAsync();
		}
	}
}